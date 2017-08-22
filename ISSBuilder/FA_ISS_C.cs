using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    class FA_ISS_C : AOI
    {
        public int NumLanes { get; set; }
        public int RecircLane { get; set; }

        public FA_ISS_C(string tagName, string uid, int numLanes, int recircLane)
        {
            this.TagName = tagName;
            this.UID = uid;
            this.NumLanes = numLanes;
            this.RecircLane = recircLane;

        }
        public override XElement DefineAOI()
        {
            XElement newNode = new XElement("Tag", new XAttribute("Name", this.TagName), new XAttribute("TagType", "Base"), new XAttribute("DataType", "FA_ISS_C"), new XAttribute("UId", this.UID),
                new XElement("Data", "0D 00 00 00 0" + this.NumLanes + " 00 00 00 0" + this.RecircLane + " 00 00 00 28 00 00 00\r\n 33 33 B3 3E 33 33 CB 41 70 03 00 00 FA 00 00 00\r\n 58 02 00 00 F4 01 00 00 9A 99 99 3F CD CC 8C 3F\r\n 66 66 86 3F 60 EA 00 00 01 00 00 00 00 00 00 00\r\n 32 00 00 00 00 00 00 00 66 66 66 3F 9A 99 99 3E\r\n CD CC 4C 3F 66 66 66 3F 05 00 00 00 02 00 00 00\r\n 12 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00\r\n 00 00 00 00 00 00 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00\r\n 00 00 00 00 01 00 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00 FF FF 00 00 00 00 00 00 01 00 00 00\r\n 00 00 00 00")
                );
            return newNode;
        }

        public override String CreateBlock(string mcUID)
        {
            return "FA_ISS_C(@" + this.UID + "@,@" + mcUID + "@)";
        }
    }
}
