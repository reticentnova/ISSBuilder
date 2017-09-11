using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ISSBuilder
{
    class UIdTracker
    {
        protected List<string> UIds = new List<string>();
        public String newUId;
        public static Random random = new Random();

        public UIdTracker(XDocument doc)
        {
            getUIds(doc);
        }

        private void getUIds(XDocument doc)
        {
            var UI = (from U in doc.Descendants()
                      from A in U.Attributes()
                      where A.Name == "UId"
                      select A.Value);

            foreach(var item in UI)
            {
                UIds.Add(item);
            }
        }

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
;        }
    }
}
