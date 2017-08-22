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
    public class Logic
    {
        public static void ExportLogic(MergeModel merge)
        {
            //test to make sure this method executes.
            FA_ISS_C mc = new FA_ISS_C("MC", "UID", merge.NumLanes, merge.RecircID);
        }
    }
}
