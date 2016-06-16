using Newtonsoft.Json;
using SaveTheWorld.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace InsertPackageAndProductsIntoElastic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type 'Product' or 'Package'.  This is not case sensitive. ");

            string documentType = Console.ReadLine().ToLower();

            if (documentType != "product" && documentType != "package")
            {
                Console.WriteLine("Please type 'Product' or 'Package'!!!!!");
            }
            else
            {
                Console.WriteLine("Copy and paste the file path to the folder that contains your " + documentType + ".json file.");

                string path = Console.ReadLine();
                path = path + "\\" + documentType + ".json";

                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("Bro, just paste the file path to the folder that contains your " + documentType + ".json file.  That's it.");

                }

                else
                {
                    if (File.Exists(path))
                    {
                        string url = "http://localhost:9200/";
                        string whereToSaveInElastic = "data/" + documentType + "/";



                        using (var client = new WebClient())
                        {
                            if (documentType == "package")
                            {
                                PackageWork(path, url, whereToSaveInElastic, client);
                            }
                            if (documentType == "product")
                            {
                                ProductWork(path, url, whereToSaveInElastic, client);
                            }

                        }

                    }

                    else
                    {

                        Console.WriteLine("That directory doesn't exist.  Please double check that you copied the right one.");

                    }
                }

            }
        }

        private static void PackageWork(string path, string url, string whereToSaveInElastic, WebClient client)
        {
            IEnumerable<SaveTheWorld.InsertPackageAndProductsIntoElastic.Package> packages = JsonConvert.DeserializeObject<IEnumerable<SaveTheWorld.InsertPackageAndProductsIntoElastic.Package>>(File.ReadAllText(path));
            foreach (SaveTheWorld.InsertPackageAndProductsIntoElastic.Package package in packages)
            {
                //TODO: double check the NdcPackageCode
                string ndcPackageCode = package.NdcPackageCode;
                string elasticUrl = string.Format("{0}{1}", url, whereToSaveInElastic);

                elasticUrl = elasticUrl + ndcPackageCode;

                try
                {
                    string s = JsonConvert.SerializeObject(package);

                    client.UploadString(elasticUrl, "PUT", s);
                    Console.WriteLine("Successfully added to ElasticSearch");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());

                }

            }

        }

        private static void ProductWork(string path, string url, string whereToSaveInElastic, WebClient client)
        {
            IEnumerable<SaveTheWorld.InsertPackageAndProductsIntoElastic.Product> products = JsonConvert.DeserializeObject<IEnumerable<SaveTheWorld.InsertPackageAndProductsIntoElastic.Product>>(File.ReadAllText(path));
            foreach (SaveTheWorld.InsertPackageAndProductsIntoElastic.Product product in products)
            {
                //TODO: double check the NdcPackageCode
                string productId = product.ProductId;
                string elasticUrl = string.Format("{0}{1}", url, whereToSaveInElastic);

                elasticUrl = elasticUrl + productId;

                try
                {
                    string s = JsonConvert.SerializeObject(product);

                    client.UploadString(elasticUrl, "PUT", s);
                    Console.WriteLine("Successfully added to ElasticSearch");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());

                }

            }

        }

    }
}
