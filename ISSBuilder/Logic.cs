using ISSBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //test to make sure this method executes.
            FA_ISS_C mc = new FA_ISS_C("MC", "UID", merge.NumLanes, merge.RecircID);
            FA_ISS_BD bed = new FA_ISS_BD("BD", "UID");


        }
    }
}
