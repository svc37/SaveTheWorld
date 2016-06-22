using Newtonsoft.Json;
using PdbMClasses;
using SaveTheWorld.Helpers;
using System;
using System.Collections.Generic;
using System.IO;

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
                        string whereToSaveInElastic = "data/" + documentType + "/";

                        if (documentType == "package")
                        {
                            IEnumerable<Package> packages = JsonConvert.DeserializeObject<IEnumerable<Package>>(File.ReadAllText(path));
                            ElasticHelper.InsertIntoElastic(packages);
                        }
                        if (documentType == "product")
                        {
                            IEnumerable<Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(File.ReadAllText(path));
                            ElasticHelper.InsertIntoElastic(products);
                        }

                    }

                    else
                    {

                        Console.WriteLine("That directory doesn't exist.  Please double check that you copied the right one.");

                    }
                }

            }
        }

    }
}
