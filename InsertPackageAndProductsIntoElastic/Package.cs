using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.InsertPackageAndProductsIntoElastic
{
    [Serializable]
    public class Package
    {
        public string ProductId { get; set; }
        public string ProductNdc { get; set; }
        public string NdcPackageCode { get; set; }
        public string PackageDescription { get; set; }
    }
}
