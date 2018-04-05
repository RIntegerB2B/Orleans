using GrainInterface;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Runtime;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static int Main(string[] args)
        {
            return RunMainAsync().Result;
        }

        private static async Task<int> RunMainAsync()
        {
            try
            {
                using (var client = await StartClientWithRetries())
                {
                    await DoClientWork(client);
                    Console.ReadKey();
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
                return 1;
            }
        }

        private static async Task<IClusterClient> StartClientWithRetries(int initializeAttemptsBeforeFailing = 20)
        {
            int attempt = 0;
            IClusterClient client;
            while (true)
            {
                try
                {
                    client = new ClientBuilder()
                        .UseLocalhostClustering()
                        .Configure<ClusterOptions>(options =>
                        {
                            options.ClusterId = "DEV";
                            options.ServiceId = "SolutionOrleans";
                        })
                        .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(ISolutionGrain).Assembly).WithReferences())
                        .ConfigureLogging(logging => logging.AddConsole())
                        .Build();

                    await client.Connect();
                    Console.WriteLine("Client successfully connect to silo host");
                    break;
                }
                catch (SiloUnavailableException)
                {
                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(4));
                }
            }

            return client;
        }

        private static async Task DoClientWork(IClusterClient client)
        {
            // example of calling grains from the initialized client
            //var friend = client.GetGrain<ITestGrain>("Test");
            //var response = await friend.TestGrain("Good morning, my friend!");
            SolutionAPI solutionApi = new SolutionAPI(client);

            Console.WriteLine("Create New Solution 12345.1 and Add Product DSPER230");
            Console.ReadLine();

            Task dsper230Task =  solutionApi.AddProduct("12345.1" + "|" + "EURO", "uk|en|g_20204|20204|DSPER230");

            Console.WriteLine();
            Console.WriteLine("Add Product DSPER430");
            Console.ReadLine();

            Task dsper430Task = solutionApi.AddProduct("12345.1" + "|" + "EURO", "uk|en|g_20204|20204|DSPER430");

            Console.WriteLine("/nAdd Product DSPER630");
            Console.ReadLine();

            Task dsper630Task = solutionApi.AddProduct("12345.1" + "|" + "EURO", "uk|en|g_20204|20204|DSPER630");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            Console.ReadLine();

            Console.WriteLine("Started at - " + DateTime.Now.ToString("HH:mm:ss.fff"));

            Console.WriteLine();
            await Task.WhenAll(dsper230Task, dsper430Task, dsper630Task);
            solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            // Console.WriteLine("\n\n{0}\n\n", response);
        }
    }
}
