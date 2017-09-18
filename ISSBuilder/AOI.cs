using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    public abstract class AOI
    {
        public string TagName {get; set; }
        public string UID { get; set; }

        //Method to define the AOI in the L5X doc.
        //Gives it a UId, tag name, assigns constants within block etc.
        public abstract XElement DefineAOI();

        //Method to output the string used in the XCData portion of 
        //each rung by the RoutineBuilder Class.
        public abstract String CreateBlock();
    }
}
