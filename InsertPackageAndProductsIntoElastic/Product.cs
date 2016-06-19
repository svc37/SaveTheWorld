using SaveTheWorld.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.InsertPackageAndProductsIntoElastic
{
    [Serializable]
    class Product
    {
        public string ProductId { get; set; }
        public string ProductNdc { get; set; }
        public string ProductTypeName { get; set; }
        public string ProprietaryName { get; set; }
        public string ProprietaryNameSuffix { get; set; }
        public string NonProprietaryName { get; set; }
        public string DosageFormName { get; set; }
        public string RouteName { get; set; }
        public string StartMarketingDate { get; set; }
        public object EndMarketingDate { get; set; }
        public string MarketingCategoryName { get; set; }
        public string ApplicationNumber { get; set; }
        public string LabelerName { get; set; }
        public string SubstanceName { get; set; }
        public string Active_Numerator_Strength { get; set; }
        public string Active_Ingred_Unit { get; set; }
        public string Pharm_Classes { get; set; }
        public string Deaschedule { get; set; }


        public static string Save(IEnumerable<Product> products)
        {

            string url = "http://localhost:9200/";


            if (products != null && products.Count() > 0)
            {
               // ElasticHelper retVal = new ElasticHelper();
                //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}{1}/result/_bulk", ElasticURL, collection));
                //req.Timeout = 1000 * 60 * 3;//3minutes

                StringBuilder sb = new StringBuilder();
                int numLines = 0;
                string eh = string.Empty;
                foreach (Product p in products)
                {
                    try
                    {
                        DateTime start = DateTime.Now;
                        sb.AppendLine(string.Format("{{ \"index\": {{ \"_id\":\"{0}\" }} }}", p.ProductId));
                        sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(p, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }));
                        numLines++;

                        if (numLines == 10000 )
                        {
                            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}data/product/_bulk", url));
                            req.ContentType = "application/json";
                            req.Method = "PUT";

                            eh = req.GetResponseString(sb.ToString());
                            Console.WriteLine(String.Format("sent {0} records in {1}", numLines, DateTime.Now - start ));
                            sb.Clear();
                            numLines = 0;

                        }
                    }
                    catch(Exception e)
                    {
                    }
                }

                if (!String.IsNullOrEmpty(eh))
                {
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}data/product/_bulk", url));
                    req.ContentType = "application/json";
                    req.Method = "PUT";

                    eh = req.GetResponseString(sb.ToString());
                }
                //if (eh != null)
                //{
                //    retVal = Newtonsoft.Json.JsonConvert.DeserializeObject<ElasticHelper>(eh);
                //}
                //return retVal;
                return eh;
            }
            return "";
        }

    }


}
