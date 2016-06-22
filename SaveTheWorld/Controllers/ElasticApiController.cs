using Newtonsoft.Json;
using PdbMClasses;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SaveTheWorld.Controllers
{
    public class ElasticApiController : ApiController
    {
        [HttpGet]
        public string GetFinalShit(string ndcNumber)
        {
            string productId = GetProductId(ndcNumber);
            string substanceName = GetSubstanceName(productId);
            string recommendation = GetRecommendation(substanceName);
            //currently summaryHtml.  TODO: check on this.
            return recommendation; 
        }

        string GetProductId(string ndcNumber)
        {
            //use ndc to get ProductId from Package
           string url = "http://localhost:9200/data/package/_search?q=NdcPackageCode:" + ndcNumber;
           IEnumerable<Package> packageData = JsonConvert.DeserializeObject<IEnumerable<Package>>(url);
            return packageData.FirstOrDefault().ProductId;

        }

        string GetSubstanceName(string ProductId)
        {
            //use productId to get substance name from Product
            string url = "http://localhost:9200/data/product/_search?q=ProductId:" + ProductId;
            IEnumerable<Product> productInfo = JsonConvert.DeserializeObject<IEnumerable<Product>>(url);
            return productInfo.FirstOrDefault().SubstanceName;

        }

        string GetRecommendation(string substanceName)
        {
            //get recommendation from cpic using substance name
            string url = "http://localhost:9200/data/cpic/_search?q=substancename:" + substanceName;
            IEnumerable<Cpic> cpicInfo = JsonConvert.DeserializeObject<IEnumerable<Cpic>>(url);
            return cpicInfo.FirstOrDefault().summaryHtml;
        }


    }
}
