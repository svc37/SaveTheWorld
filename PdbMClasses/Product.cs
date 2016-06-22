using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PdbMClasses
{
    [Serializable]
    public class Product
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

    }

}
