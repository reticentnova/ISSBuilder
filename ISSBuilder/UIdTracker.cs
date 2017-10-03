using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ISSBuilder
{
    public class UIdTracker
    {
        protected List<string> UIds = new List<string>();
        public String newUId;
        public string mcUId;
        public static Random random = new Random();

        //Constructor. Always get all UIds when the tracker is created.
        public UIdTracker(XDocument doc)
        {
            getUIds(doc);
        }

        //Get all UIds in the xml document. Also save the UId of the MC tag since 
        //all merge blocks use it.
        private void getUIds(XDocument doc)
        {
            var UI = (from U in doc.Descendants()
                      from A in U.Attributes()
                      where A.Name == "UId"
                      select A.Value);

            mcUId = (string)(from M in doc.Descendants("Tag")
                      where (string)M.Attribute("Name") == "MC"
                      select M).Single().Attribute("UId");                  
            
            foreach(var item in UI)
            {
                UIds.Add(item);
            }
        }

        //method to generate new UIds for tags, rungs and blocks
        public string generateUId()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            newUId = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            //If we somehow get unlucky and generate an existing UID, try again.
            if (UIds.Contains(newUId))
                return this.generateUId();
            else
            {
                UIds.Add(newUId);
                return newUId;
            }
        }
    }
}
