using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISSBuilder
{
    public static class RungBuilder
    {
        public static string BuildRung(ref List<string> instructionList)
        {
            string temp = "";
            for (int i = 0; i < instructionList.Count; i++)
            {
                temp = temp + instructionList[i];
            }
            instructionList.Clear();
            return temp + ";";
        }
    }
}
