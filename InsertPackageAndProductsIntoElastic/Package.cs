using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.InsertPackageAndProductsIntoElastic
{
    [Serializable]
     class Package
    {
        public string ProductId { get; set; }
        public string ProductNdc { get; set; }
        public string NdcPackageCode { get; set; }
        public string PackageDescription { get; set; }

        public static string Save(IEnumerable<Package> packages)
        {

            string url = "http://localhost:9200/";


            if (packages != null && packages.Count() > 0)
            {
                // ElasticHelper retVal = new ElasticHelper();
                //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}{1}/result/_bulk", ElasticURL, collection));
                //req.Timeout = 1000 * 60 * 3;//3minutes

                StringBuilder sb = new StringBuilder();
                int numLines = 0;
                string eh = string.Empty;
                foreach (Package p in packages)
                {
                    try
                    {
                        DateTime start = DateTime.Now;
                        sb.AppendLine(string.Format("{{ \"index\": {{ \"_id\":\"{0}\" }} }}", p.NdcPackageCode));
                        sb.AppendLine(Newtonsoft.Json.JsonConvert.SerializeObject(p, Newtonsoft.Json.Formatting.None, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore }));
                        numLines++;

                        if (numLines == 10000)
                        {
                            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(string.Format("{0}data/package/_bulk", url));
                            req.ContentType = "application/json";
                            req.Method = "PUT";

                            eh = req.GetResponseString(sb.ToString());
                            Console.WriteLine(String.Format("sent {0} records in {1}", numLines, DateTime.Now - start));
                            sb.Clear();
                            numLines = 0;

                        }
                    }
                    catch (Exception e)
                    {
                    }
                }

                if (!String.IsNullOrEmpty(eh))
                {
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}data/package/_bulk", url));
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
