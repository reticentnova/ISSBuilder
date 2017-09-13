using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    class FA_ISS_BD : AOI
    {
        private string MCUID { get; set; }
        public FA_ISS_BD(string tagName, UIdTracker uidtracker)
        {
            this.TagName = tagName;
            this.UID = uidtracker.generateUId();
            this.MCUID = uidtracker.mcUId;
        }
        public override XElement DefineAOI()
        {
            XElement newNode = new XElement("Tag", new XAttribute("Name", this.TagName), new XAttribute("TagType", "Base"), new XAttribute("DataType", "FA_ISS_BD"), new XAttribute("UId", this.UID),
                new XElement("Data", "01 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00\r\n " +
                "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00\r\n " +
                "00 00 00 00 00 00 00 00")
                );
            return newNode;
        }

        public override String CreateBlock()
        {
            //return "FA_ISS_BD(@" + this.UID + "@,@" + mcUID + "@,@" + this.UID + "@.PE_MP" + ",@" + this.UID + "@.OK" + ",@" + this.UID + "@.REL_ENA" + ",@" + this.UID + "@.CURR_VEL" + ",@" + this.UID + "@.PPI_CNT" + ",@" + this.UID + "@.AGL" + ",@" + this.UID + "@.RES_COUNTS" + ")";
            return String.Format("FA_ISS_BD(@{0}@,@{1}@,@{0}@.PE_MP,@{0}@.OK,@{0}@.REL_ENA,@{0}@.CURR_VEL," +
                "@{0}@.PPI_CNT,@{0}@.AGL,@{0}@.RES_COUNTS)", this.UID, this.MCUID);

        }
    }
}
