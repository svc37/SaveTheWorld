using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExtensions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Copy and paste the file path to the folder that contains your xml file.");

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

                    foreach (var file in jsonFiles)
                    {
                        path = path + "\\drugbank.xml";
                        Extensions.XmlToJson(path);
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
