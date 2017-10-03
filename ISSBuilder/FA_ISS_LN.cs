using System;
using System.Xml.Linq;

namespace ISSBuilder
{
    public class FA_ISS_LN : AOI
    {
        private string MCUID { get; set; }
        int LANE_NUM;

        public FA_ISS_LN(string tagName, int lane_num, UIdTracker uidtracker)
        {
            this.TagName = tagName;
            this.LANE_NUM = lane_num;
            this.UID = uidtracker.generateUId();
            this.MCUID = uidtracker.mcUId;
        }

        public override XElement DefineAOI()
        {
            XElement newNode = new XElement("Tag", new XAttribute("Name", this.TagName), new XAttribute("Constant", "false"), new XAttribute("ExternalAccess", "Read/Write"), new XAttribute("TagType", "Base"), new XAttribute("DataType", "FA_ISS_LN"), new XAttribute("UId", this.UID),
                new XElement("Data", String.Format("01 00 00 00 0{0} 00 00 00 00 00 00 00 00 00 00 00\r\n " +
                "00 00 00 00 00 00 00 00 00 00 00 00 94 11 00 00\r\n " +
                "00 00 00 00 00 00 00 00 00 00 00 00 94 11 00 00\r\n " +
                "00 00 00 00 00 00 00 00", this.LANE_NUM)),
                new XElement("Data", 
                    new XAttribute("Format", "Decorated"),
                    new XElement("Structure",
                    new XAttribute("DataType", "FA_ISS_LN"),
                        new XElement("DataValueMember", 
                            new XAttribute("Name", "EnableIn"), new XAttribute("DataType", "BOOL"), new XAttribute("Value","1")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "EnableOut"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "LN_NUM"), new XAttribute("DataType", "DINT"), new XAttribute("Radix","Decimal"), new XAttribute("Value", this.LANE_NUM)),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PE_MP"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PE_SP"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PE_TE"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PE_PP"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "OK"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "REL_ENA"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "CURR_VEL"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal") ,new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PPI_CNT"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PE_EOW"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PB_EOW"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PRIOR1"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PRIOR2"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PRIOR3"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PRIOR4"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "PRIOR_EXTRA"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "COUNT_PLAN"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "COUNT_ACT"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "MERGE_POINT"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "4500")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "W_LENGTH"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "S_LENGTH"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "JOG_S"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "JOG_G"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "BUILD"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "EMPTY"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "FULL"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "RELEASE"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "DIRECT"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "JOG"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "EOW"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "RUN_G"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "DZC"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "SLG"), new XAttribute("DataType", "BOOL"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "VEL_W_TARGET"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "VEL_S_TARGET"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "4500")),
                        new XElement("DataValueMember",
                            new XAttribute("Name", "VEL_G_TARGET"), new XAttribute("DataType", "DINT"), new XAttribute("Radix", "Decimal"), new XAttribute("Value", "0"))
                        )));
            return newNode;
        }

        public override string CreateBlock()
        {
            return String.Format("FA_ISS_LN(@{0}@,@{1}@,@{0}@.PE_MP,@{0}@.PE_SP,@{0}@.PE_TE,@{0}@.PE_PP,@{0}@.OK,@{0}@.REL_ENA,@{0}@.CURR_VEL,@{0}@.PPI_CNT,@{0}@.PRIOR1,@{0}@.PRIOR2,@{0}@.PRIOR3,@{0}@.PRIOR4" + ")", this.UID, this.MCUID);
        }
    }
}
