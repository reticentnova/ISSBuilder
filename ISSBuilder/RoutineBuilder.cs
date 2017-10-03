using System.Collections.Generic;
using System.Xml.Linq;

namespace ISSBuilder
{
    public static class RoutineBuilder
    {
        public static List<XElement> BuildRoutine(Dictionary<string,string> rungDict)
        {
            //TODO pass this in later or have another class track rung number?
            int rungNumber = 1;
            List<XElement> rungList = new List<XElement>();
            foreach(var entry in rungDict)
            {
                XElement nextRung = new XElement("Rung", new XAttribute("Use", "Target"), new XAttribute("Number", rungNumber), new XAttribute("Type", "N"), new XAttribute("UId", entry.Key),
                    new XElement("Text", new XCData(entry.Value))
                    );

                rungList.Add(nextRung);
                rungNumber++;
            }
            return rungList;
        }
    }
}
