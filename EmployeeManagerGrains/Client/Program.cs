using GrainInterfaces;
using Orleans;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for Orleans Silo to start. Press Enter to proceed...");
            Console.ReadLine();

            ClientConfiguration config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30005);
            GrainClient.Initialize(config);



            // ClientConfiguration config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30005);
            // GrainClient.Initialize(config);

            SolutionAPI solutionApi = new SolutionAPI();
            Console.WriteLine();

            #region 2.0 Code

            //Console.WriteLine("Create New Solution and Add Product DSPER230");
            //Console.ReadLine();

            //solutionApi.AddProduct_V2("12345.1" + "|" + "EURO", "g_20204|20204|DSPER230");

            //Console.WriteLine();
            //Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            //Console.ReadLine();
            //solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            //Console.WriteLine();
            //Console.WriteLine("Add Next Product DX123");
            //Console.ReadLine();

            //solutionApi.AddProduct_V2("12345.1" + "|" + "EURO", "g_20204|20204|DSPER630");

            //Console.WriteLine();
            //Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            //Console.ReadLine();
            //solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            #endregion

            #region 1.5 Code

            Console.WriteLine("Create New Solution 12345.1 and Add Product H224H");
            Console.ReadLine();

            solutionApi.AddProduct("12345.1" + "|" + "EURO", "H224H");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            Console.WriteLine();
            Console.WriteLine("Add Next Product DX123");
            Console.ReadLine();

            solutionApi.AddProduct("12345.1" + "|" + "EURO", "DX123");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            Console.WriteLine();
            Console.WriteLine("Add Next Product DX5000");
            Console.ReadLine();
            solutionApi.AddProduct("12345.1" + "|" + "EURO", "DX5000");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 12345.1 ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");


            ////////////////////////////////////////////////////////////////////

            Console.WriteLine();
            Console.WriteLine("Create Next Solution 98765.1 and Add Product H224H");
            Console.ReadLine();

            solutionApi.AddProduct("98765.1" + "|" + "EURO", "H224H");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 98765.1 ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("98765.1" + "|" + "EURO");

            Console.WriteLine();
            Console.WriteLine("Add Next Product DX123");
            Console.ReadLine();

            solutionApi.AddProduct("98765.1" + "|" + "EURO", "DX123");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 98765.1 ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("98765.1" + "|" + "EURO");


            //////////////////// Refresh Order code //////////////////////////
            Console.WriteLine();
            Console.WriteLine("RefreshOrderCode DX123?");
            Console.ReadLine();
            solutionApi.RefreshOrderCode("DX123");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 12345.1  ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("12345.1" + "|" + "EURO");

            Console.WriteLine();
            Console.WriteLine("Get Solution Items for Solution Id 98765.1  ?");
            Console.ReadLine();
            solutionApi.GetSolutionItems("98765.1" + "|" + "EURO");

            Console.WriteLine();
            Console.WriteLine("Get Light Product  ?");
            Console.ReadLine();
            solutionApi.GetPrice();

            Console.WriteLine();
            Console.WriteLine("Get Price  ?");
            Console.ReadLine();
            solutionApi.GetPrice();

            Console.WriteLine();
            Console.WriteLine("Get Product Catalog  ?");
            Console.ReadLine();
            solutionApi.GetProductCatalogData();



            Console.WriteLine();
            Console.WriteLine("Get Validation Info");
            Console.ReadLine();
            solutionApi.GetValidationInfo();

            #endregion

            #region Commented
            // Orleans comes with a rich XML and programmatic configuration. Here we're just going to set up with basic programmatic config
            //var config = Orleans.Runtime.Configuration.ClientConfiguration.LocalhostSilo(30005);
            //GrainClient.Initialize(config);

            // Orleans comes with a rich XML and programmatic configuration. Here we're just going to set up with basic programmatic config
            //var grainFactory = GrainClient.GrainFactory;
            //var ids = new string[] {
            //    "42783519-d64e-44c9-9c29-399e3afaa625",
            //    "d694a4e0-1bc3-4c3f-a1ad-ba95103622bc",
            //    "9a72b0c6-33df-49db-ac05-14316edd332d",
            //    "6526a751-b9ac-4881-9bfb-836ecce2ca9f",
            //    "ae4b106f-3c96-464a-b48d-3583ed584b17",
            //    "b715c40f-d8d2-424d-9618-76afbc0a2a0a",
            //    "5ad92744-a0b1-487b-a9e7-e6b91e9a9826",
            //    "e23a55af-217c-4d76-8221-c2b447bf04c8",
            //    "2eef0ac5-540f-4421-b9a9-79d89400f7ab"
            //};

            //var e0 = GrainClient.GrainFactory.GetGrain<IEmployee>(Guid.Parse(ids[0]));
            //var e1 = GrainClient.GrainFactory.GetGrain<IEmployee>(Guid.Parse(ids[1]));
            //var e2 = GrainClient.GrainFactory.GetGrain<IEmployee>(Guid.Parse(ids[2]));
            //var e3 = GrainClient.GrainFactory.GetGrain<IEmployee>(Guid.Parse(ids[3]));
            //var e4 = GrainClient.GrainFactory.GetGrain<IEmployee>(Guid.Parse(ids[4]));

            //var m0 = GrainClient.GrainFactory.GetGrain<IManager>(Guid.Parse(ids[5]));
            //var m1 = GrainClient.GrainFactory.GetGrain<IManager>(Guid.Parse(ids[6]));
            //var m0e = m0.AsEmployee().Result;
            //var m1e = m1.AsEmployee().Result;

            //m0e.Promote(10);
            //m1e.Promote(11);

            //m0.AddDirectReport(e0).Wait();
            //m0.AddDirectReport(e1).Wait();
            //m0.AddDirectReport(e2).Wait();

            //m1.AddDirectReport(m0e).Wait();
            //m1.AddDirectReport(e3).Wait();

            //m1.AddDirectReport(e4).Wait();

            //var grain = GrainClient.GrainFactory.GetGrain<IStockGrain>("MSFT");
            //var price = grain.GetPrice().Result;
            //if (string.IsNullOrEmpty(price))
            //{
            //    grain.UpdatePrice();
            //    price = grain.GetPrice().Result;
            //}
            //Console.WriteLine(price);
            #endregion

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();
        }
    }
}
