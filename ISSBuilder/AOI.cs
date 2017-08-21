using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    public abstract class AOI
    {
        public string TagName {get; set; }
        public string UID { get; set; }

        public abstract XElement DefineAOI();
        public abstract String CreateBlock();
    }
}
