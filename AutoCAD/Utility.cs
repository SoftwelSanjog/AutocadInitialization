using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCADWrapper
{
    public class Utility
    {
        private AcadUtility AcadUtility;
        public void setUtilityObject(object utility)
        {
            AcadUtility = (AcadUtility)utility;
        }
        public object getUtilityObject()
        {
            return AcadUtility;
        }
        public void Prompt(string message) { 
        AcadUtility.GetType().InvokeMember("Prompt", System.Reflection.BindingFlags.InvokeMethod,null, AcadUtility, new object[] { message });
        }
        public string GetString(int HasSpaces, string prompt)
        {
            return (string)AcadUtility.GetType().InvokeMember("GetString", System.Reflection.BindingFlags.InvokeMethod, null, AcadUtility, new object[] { HasSpaces, prompt }); 
        }
        public void GetEntity(ref object obj, ref object pickPoint, ref string prompt)
        {
            obj = new object();
            AcadUtility.GetEntity(out obj, out pickPoint, prompt);
        }

    }
}
