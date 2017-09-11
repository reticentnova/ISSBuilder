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
        public static void ExportLogic(MergeModel merge)
        {
            //Load the ISS Template L5X file
            XDocument L5X = XDocument.Load("C:\\Users\\frantzgj\\Downloads\\ISS_Template.L5X");
            //Create a UIdTracker to track and generate new, unique, UIDs
            UIdTracker UIds = new UIdTracker(L5X);

            //test to make sure this method executes.
            FA_ISS_C mc = new FA_ISS_C("MC", UIds.generateUId(), merge.NumLanes, merge.RecircID);
            FA_ISS_BD bed = new FA_ISS_BD("BD", UIds.generateUId());


        }
    }
}
