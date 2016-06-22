using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using PdbMClasses;

namespace CombineCpicWithSynonyms
{
    //http://www.newtonsoft.com/json/help/html/ModifyJson.htm

    class Program
    {
        static void Main(string[] args)
        {
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
                    foreach (string file in jsonFiles)
                    {
                        string f = File.ReadAllText(file);

                        JObject rss = JObject.Parse(f);
                        string name = rss["name"].ToString();
                        JArray relatedChemicals = (JArray)rss["relatedChemicals"];
                        JValue rcName = (JValue)relatedChemicals[0]["name"];
                        int index = file.LastIndexOf("\\");
                        string fileName = file.Substring(index);


                        IEnumerable<Synonyms> syns = JsonConvert.DeserializeObject<IEnumerable<Synonyms>>(File.ReadAllText(@"C:\Code\Data\DrugSynonyms\DrugSynonyms.json"));
                        foreach (Synonyms syn in syns)
                        {
                            //TODO: missing 5 files from original set
                            //tegafur: example of a missing file.  Just no synonyms????
                            if (name.ToLower().Contains(syn.name.ToLower()))
                            {
                                //JArray synonyms = (JArray)relatedChemicals[0]["synonyms"];
                                JArray synonyms = new JArray();
                                foreach (var item in syn.synonyms)
                                {
                                    synonyms.Add(item.name);
                                }
                                foreach (var item in syn.salts)
                                {
                                    synonyms.Add(item.name);
                                }
                                foreach (var item in syn.brands)
                                {
                                    synonyms.Add(item.name);
                                }

                                rss["synynoms"] = synonyms;
                                File.WriteAllText(@"C:\Code\Data\CpicTest\" + fileName, JsonConvert.SerializeObject(rss, Formatting.Indented));

                            }
                            else
                            {
                             //   File.WriteAllText(@"C:\Code\Data\CpicTest\" + fileName, JsonConvert.SerializeObject(rss, Formatting.Indented));
                            }
                        }

                        Console.WriteLine(rss.ToString());
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
