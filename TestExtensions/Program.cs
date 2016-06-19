using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:9200/api/ElasticApi";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(string.Format("{0}data/product/_bulk", url));
            req.ContentType = "application/json";
            req.Method = "PUT";

            string s = req.GetResponseString(sb.ToString());


        }
    }
}
