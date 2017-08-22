using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    public class FA_ISS_BD : AOI
    {
        public FA_ISS_BD(string tagName, string uid)
        {
            this.TagName = tagName;
            this.UID = uid;
        }
        public override XElement DefineAOI()
        {
            XElement newNode = new XElement("Tag", new XAttribute("Name", this.TagName), new XAttribute("TagType", "Base"), new XAttribute("DataType", "FA_ISS_BD"), new XAttribute("UId", this.UID),
                new XElement("Data", "01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00\r\n 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00\r\n 00 00 00 00 00 00 00 00")
                );
            return newNode;
        }

        public override String CreateBlock(string mcUID)
        {
            return "FA_ISS_BD(@" + this.UID + "@,@" + mcUID + "@,@" + this.UID + "@.PE_MP" + ",@" + this.UID + "@.OK" + ",@" + this.UID + "@.REL_ENA" + ",@" + this.UID + "@.CURR_VEL" + ",@" + this.UID + "@.PPI_CNT" + ",@" + this.UID + "@.AGL" + ",@" + this.UID + "@.RES_COUNTS" + ")";
        }
    }
}
