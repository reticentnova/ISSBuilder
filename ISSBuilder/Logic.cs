using ISSBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISSBuilder
{   
    /// <summary>
    /// Class to process the form and output a .L5X file.
    /// </summary>
    /// <param name="merge"> Merge Object containing all information about the 
    ///         to generate.</param>
    public class Logic
    {
        public static void ExportLogic(MergeModel merge, MergeProgramModel program)
        {
            //hold a list of instructions for each rung until the rung is built
            List<string> instructionList = new List<string>();
            //Dictionary that holds the UId(key) and XCData(value) for each rung.
            Dictionary<string, string> rungDict = new Dictionary<string, string>();
            //List to hold FA_ISS_LN Objects
            List<FA_ISS_LN> laneList = new List<FA_ISS_LN>();

            //Load the ISS Template L5X file
            XDocument L5X = XDocument.Load("C:\\Users\\frantzgj\\Downloads\\ISS_LN_TEMPLATE.L5X");
            //Create a UIdTracker to track and generate new, unique, UIDs
            UIdTracker UIds = new UIdTracker(L5X);


            //Find the spot in the XML Template to insert new tags.
            //XElement Tags = (from children in L5X.Descendants("Tags")
            //select children).FirstOrDefault();
            XElement Tags = L5X.Elements("RSLogix5000Content").Elements("Controller").Elements("Tags").Single();

            //Find the spot in the XML Template to insert new rungs.
            //XElement Rungs = (from rungs in L5X.Descendants("Programs")
            //select rungs).Descendants("RLLContent").FirstOrDefault();
            XElement Rungs = L5X.Elements("RSLogix5000Content").Elements("Controller").Elements("Programs").Elements("Program").
                Elements("Routines").Elements("Routine").Elements("RLLContent").Single();


            //Test AOI creation, rung definition and rung string concatination
            FA_ISS_C mc = new FA_ISS_C(program.FA_ISS_C, UIds, merge);
            FA_ISS_BD bed = new FA_ISS_BD(program.FA_ISS_BD, UIds);

            //mc.DefineAOI();
            Tags.Add(mc.DefineAOI());

            instructionList.Add(mc.CreateBlock());

            //bed.DefineAOI();
            Tags.Add(bed.DefineAOI());
            instructionList.Add(bed.CreateBlock());
            
            rungDict.Add(UIds.generateUId(), RungBuilder.BuildRung(ref instructionList));

            foreach(var lane in merge.Lanes)
            {
                string laneTag = string.Format("Lane_{0}", lane.LaneNumber.ToString());
                laneList.Add(new FA_ISS_LN(laneTag, lane.LaneNumber, UIds));                
            }

            foreach(var laneobj in laneList)
            {
                instructionList.Add(laneobj.CreateBlock());
                Tags.Add(laneobj.DefineAOI());
                rungDict.Add(UIds.generateUId(), RungBuilder.BuildRung(ref instructionList));
            }

            List<XElement> rungList = new List<XElement>();
            rungList = RoutineBuilder.BuildRoutine(rungDict);

            for(int index = 0; index < rungList.Count; index++)
            {
                Rungs.Add(rungList[index]);
            }
            L5X.Save("C:\\Users\\frantzgj\\Downloads\\ISS_LN_CONFIG.L5X");
        }
    }
}
