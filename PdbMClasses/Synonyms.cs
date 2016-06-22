using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdbMClasses
{
    [Serializable]
    public class Synonyms
    {
        public string name { get; set; }
        public IEnumerable<Salt> salts { get; set; }
        public IEnumerable<Synonym> synonyms { get; set; }
        public IEnumerable<Brand> brands { get; set; }

        public class Salt
        {
            public string name { get; set; }
        }

        public class Synonym
        {
            public string name { get; set; }
        }

        public class Brand
        {
            public string name { get; set; }
        }

    }
}
