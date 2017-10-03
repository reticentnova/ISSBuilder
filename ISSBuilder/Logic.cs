using ISSBuilder.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ISSBuilder
{   
    /// <summary>
    /// Class to process the form and output a .L5X file.
    /// </summary>
    /// <param name="merge"> Merge Object containing all information about the to generate.</param>
    public class Logic
    {
        public static void ExportLogic(MergeModel merge, MergeProgramModel program)
        {
            //Most of the Logic pertaining to creating FA_ISS_* objects should be moved to the ProgramModel class.
            //It should be responsible for holding all the data related to the program itself.


            //hold a list of instructions for each rung until the rung is built
            List<string> InstructionList = new List<string>();
            //Dictionary that holds the UId(key) and XCData(value) for each rung.
            Dictionary<string, string> rungDict = new Dictionary<string, string>();
            //List to hold FA_ISS_LN Objects
            List<FA_ISS_LN> laneList = new List<FA_ISS_LN>();

            //Load the ISS Template L5X file
            //TODO: Package the L5X as a resource.
            XDocument L5X = XDocument.Load("C:\\Users\\frantzgj\\Downloads\\ISS_LN_TEMPLATE.L5X");
            //Create a UIdTracker to track and generate new, unique, UIDs
            UIdTracker UIds = new UIdTracker(L5X);


            //Find the spot in the XML Template to insert new tags.
            XElement Tags = L5X.Elements("RSLogix5000Content").Elements("Controller").Elements("Tags").Single();

            //Find the spot in the XML Template to insert new rungs.
            XElement Rungs = L5X.Elements("RSLogix5000Content").Elements("Controller").Elements("Programs").Elements("Program").
                Elements("Routines").Elements("Routine").Elements("RLLContent").Single();


            //Create FA_ISS_C and FA_ISS_BD objects
            FA_ISS_C mc = new FA_ISS_C(program.FA_ISS_C, UIds, merge);
            FA_ISS_BD bed = new FA_ISS_BD(program.FA_ISS_BD, UIds);

            //Add the mc tag definition to the L5X file
            Tags.Add(mc.DefineAOI());
            //Add the FA_ISS_C block to the instruction list for the current rung
            InstructionList.Add(mc.CreateBlock());

            //Add the bed tag definition to the L5X file
            Tags.Add(bed.DefineAOI());
            //Add the FA_ISS_BD block to the instruction list for the current rung
            InstructionList.Add(bed.CreateBlock());
            
            //Combine all instructions from list into one rung and store in a dictionary
            rungDict.Add(UIds.generateUId(), RungBuilder.BuildRung(ref InstructionList));


            //Create FA_ISS_LN objects for each lane in the merge.
            foreach(var lane in merge.Lanes)
            {
                string laneTag = string.Format("Lane_{0}", lane.LaneNumber.ToString());
                laneList.Add(new FA_ISS_LN(laneTag, lane.LaneNumber, UIds));                
            }

            //For each new lane object:
            //Define tag in L5X file.
            //Add block to the instruction list for the current rung
            //Each Lane block is on its own rung so the rung gets built imediately after the instruction is added.
            foreach(var laneobj in laneList)
            {
                InstructionList.Add(laneobj.CreateBlock());
                Tags.Add(laneobj.DefineAOI());
                rungDict.Add(UIds.generateUId(), RungBuilder.BuildRung(ref InstructionList));
            }

            //After all rungs for the routine are stored in rungDict in string form,
            //Form list of XElements to be added to L5X <Rungs/> Element            
            List<XElement> rungList = new List<XElement>();
            rungList = RoutineBuilder.BuildRoutine(rungDict);

            //Add the rungs to the L5X file.
            for(int index = 0; index < rungList.Count; index++)
            {
                Rungs.Add(rungList[index]);
            }

            //Save the document.
            //TODO: Ask for filename before saving
            L5X.Save("C:\\Users\\frantzgj\\Downloads\\ISS_LN_CONFIG.L5X");
        }
        public static void ImportAOI(MergeProgramModel program)
        {
            string importme = program.AOITOIMPORT;
            XDocument source = XDocument.Load(string.Format("C:\\Users\\frantzgj\\Downloads\\{0}.L5X", importme));
            XDocument dest = XDocument.Load("C:\\Users\\frantzgj\\Downloads\\TEMPLATE.L5X");

            XElement AOIs = dest.Elements("RSLogix5000Content").Elements("Controller").Elements("AddOnInstructionDefinitions").Single();
            XElement DATATYPESs = dest.Elements("RSLogix5000Content").Elements("Controller").Elements("DataTypes").Single();
            var curr = source.Elements("RSLogix5000Content").Elements("Controller").Elements("AddOnInstructionDefinitions").Elements();
            var datacurr = source.Elements("RSLogix5000Content").Elements("Controller").Elements("DataTypes").Elements();

            AOIs.Add(curr);
            DATATYPESs.Add(datacurr);
                //Root.Add(curr.Elements());
            dest.Save("C:\\Users\\frantzgj\\Downloads\\AOIDEFINETEST.L5X");

        }
    }
}
