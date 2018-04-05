using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Orleans;
using Orleans.Storage;
using Orleans.Runtime;
using Newtonsoft.Json;
using Orleans.Serialization;

using Orleans.Providers;
using System.Linq;
using System.Collections;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StorageProvider
{
    public class MongoGrainStorage : IGrainStorage
    {
        private JsonSerializerSettings _jsonSettings;


        public string Name { get; set; }

        public string RootDirectory { get; set; }

        private SerializationManager _serializationManager;

        IMongoCollection<BsonDocument> collection;

        public Task Init(string name, Orleans.Providers.IProviderRuntime providerRuntime,
                      Orleans.Providers.IProviderConfiguration config)
        {
            _serializationManager = providerRuntime.ServiceProvider.GetRequiredService<SerializationManager>();
            var typeResolver = providerRuntime.ServiceProvider.GetRequiredService<ITypeResolver>();
            _jsonSettings = OrleansJsonSerializer.UpdateSerializerSettings(OrleansJsonSerializer.GetDefaultSerializerSettings(typeResolver, providerRuntime.GrainFactory), config);

            this.Name = name;
            if (string.IsNullOrWhiteSpace(config.Properties["RootDirectory"]))
                throw new ArgumentException("RootDirectory property not set");

            var directory = new System.IO.DirectoryInfo(config.Properties["RootDirectory"]);
            if (!directory.Exists)
                directory.Create();

            this.RootDirectory = directory.FullName;

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = mongoClient.GetDatabase("EnterpriseSolution");
            collection = database.GetCollection<BsonDocument>("orleans");

            return Task.CompletedTask;
        }

        public Task Close()
        {
            throw new NotImplementedException();
        }

        public async Task ReadStateAsync(string grainType,
                                   GrainReference grainRef,
                                   IGrainState grainState)
        {
            var collectionName = grainState.GetType().Name;
            var key = grainRef.ToKeyString();

            var fName = key + "." + collectionName;
            //var path = System.IO.Path.Combine(RootDirectory, fName);

            //var fileInfo = new System.IO.FileInfo(path);
            //if (fileInfo.Exists)
            //using (var stream = fileInfo.OpenText())
            //{
            //    var storedData = await stream.ReadToEndAsync();

            //    grainState.State = JsonConvert.DeserializeObject(storedData, grainState.State.GetType(), _jsonSettings);
            //}
            var filter = Builders<BsonDocument>.Filter.Eq("Key", fName);
            var projection = Builders<BsonDocument>.Projection.Include("Value").Exclude("_id");
            var result = collection.Find<BsonDocument>(filter).Project(projection).ToList();
            if (result.Count > 0)
            {
                grainState.State = JsonConvert.DeserializeObject(Convert.ToString(result[0][0].AsString), grainState.State.GetType(), _jsonSettings);
                Console.WriteLine(Convert.ToString(result));
            }
            // var document = collection.Find(filter).First();



            //return TaskDone.Done;
        }

        public async Task WriteStateAsync(string grainType,
                                    GrainReference grainRef,
                                    IGrainState grainState)
        {
            var storedData = JsonConvert.SerializeObject(grainState.State, _jsonSettings);

            var collectionName = grainState.GetType().Name;
            var key = grainRef.ToKeyString();

            var fName = key + "." + collectionName;
            //var path = System.IO.Path.Combine(RootDirectory, fName);

            //var fileInfo = new System.IO.FileInfo(path);

            //using (var stream = new System.IO.StreamWriter(
            //           fileInfo.Open(System.IO.FileMode.Create,
            //                         System.IO.FileAccess.Write)))
            //{
            //    await stream.WriteAsync(storedData);
            //}

            var document = new BsonDocument
            {
                { "Key", fName },
                { "Value", storedData }
            };
            var updateOption = new FindOneAndUpdateOptions<BsonDocument>();
            updateOption.IsUpsert = true;
            //await collection.InsertOneAsync(document);
            await collection.FindOneAndUpdateAsync(
                                Builders<BsonDocument>.Filter.Eq("Key", fName),
                                Builders<BsonDocument>.Update.Set("Value", storedData), updateOption

                                );

            //var filter = Builders<BsonDocument>.Filter.Eq(s => s., studentId);
            //var update = Builders<Student>.Update.AddToSet(s => s.CoursesList, courseId);
            //var result = await collection.UpdateOneAsync(filter, update);
        }


        public Task ClearStateAsync(string grainType,
                                    GrainReference grainRef,
                                    IGrainState grainState)
        {
            throw new NotImplementedException();
        }

       
    }
}
