using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombineCpicWithSynonyms
{
    public class Cpic
    {
        public string objCls { get; set; }
        //public string @id { get; set; }
        public string context { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public IEnumerable<Group> groups { get; set; }
        public IEnumerable<RelatedChemical> relatedChemicals { get; set; }
        public IEnumerable<RelatedGene> relatedGenes { get; set; }
        public string source { get; set; }
        public string summaryHtml { get; set; }
        public string textHtml { get; set; }
    }

    public class Type
    {
        //public string @id { get; set; }
        public string context { get; set; }
        public int id { get; set; }
        public string src { get; set; }
        public string term { get; set; }
        public string termId { get; set; }
    }

    public class Annotation
    {
        public int id { get; set; }
        public string text { get; set; }
        public string textHtml { get; set; }
        public Type type { get; set; }
    }

    public class Strength
    {
        //public string @id { get; set; }
        public string context { get; set; }
        public int id { get; set; }
        public string src { get; set; }
        public string term { get; set; }
        public string termId { get; set; }
    }

    public class Group
    {
        public string objCls { get; set; }
        //public string @id { get; set; }
        public string context { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public IEnumerable<Annotation> annotations { get; set; }
        public IEnumerable<string> genotypes { get; set; }
        public Strength strength { get; set; }
    }

    public class RelatedChemical
    {
        public string objCls { get; set; }
        //public string @id { get; set; }
        public string context { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    public class RelatedGene
    {
        public string objCls { get; set; }
        //public string @id { get; set; }
        public string context { get; set; }
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
    }

    //public class Example
    //{
    //    public string objCls { get; set; }
    //    public string @id { get; set; }
    //    public string context { get; set; }
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public IEnumerable<Group> groups { get; set; }
    //    public IEnumerable<RelatedChemical> relatedChemicals { get; set; }
    //    public IEnumerable<RelatedGene> relatedGenes { get; set; }
    //    public string source { get; set; }
    //    public string summaryHtml { get; set; }
    //    public string textHtml { get; set; }
    //}
}
