using SaveTheWorld.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InsertCpicJsonFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string elasticUrl = "http://localhost:9200/cpic/datatest/";

            Console.WriteLine("Copy and paste the file path to the folder that contains your json files.");

            string path = Console.ReadLine();

            if (string.IsNullOrEmpty(path))

            {
                Console.WriteLine("Bro, just paste the file path to the folder that contains your json files.  That's it.");

            }

            else

            {

                if (Directory.Exists(path))

                {

                    string[] jsonFiles = Directory.GetFiles(path);

                    int id = 1;

                    foreach (var file in jsonFiles)

                    {

                         elasticUrl = elasticUrl + id;

                        byte[] data = File.ReadAllBytes(file);

                        using (var client = new WebClient())

                        {

                            client.UploadData(elasticUrl, "PUT", data);

                        }

                        Console.WriteLine(file + "was successfully added to ElasticSearch");

                        id++;

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
