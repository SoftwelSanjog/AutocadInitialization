using Autodesk.AutoCAD.Interop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCADWrapper
{
    public class ModelSpace
    {
        private AcadModelSpace AcadModelSpace;
        public void setModelSpaceObject(object modelSpace)
        {
            AcadModelSpace = (AcadModelSpace)modelSpace;
        }
        public object AddCircle(double[] center, double radius)
        {
            return AcadModelSpace.GetType().InvokeMember("AddCircle",System.Reflection.BindingFlags.InvokeMethod, null, AcadModelSpace,new object[] {center,radius});
        }
        public object AddLine(double[] startPoint, double[] endPoint)
        {
            return AcadModelSpace.GetType().InvokeMember("AddLine", System.Reflection.BindingFlags.InvokeMethod, null, AcadModelSpace, new object[] { startPoint, endPoint});
        }
        public object AddText(string myText, double[] txtCoordinate, double factor)
        {
            return AcadModelSpace.GetType().InvokeMember("AddText", System.Reflection.BindingFlags.InvokeMethod, null, AcadModelSpace, new object[] {myText , txtCoordinate,factor });
        }
        public object AddPoint(double[] Point)
        {
            return AcadModelSpace.GetType().InvokeMember("AddPoint", System.Reflection.BindingFlags.InvokeMethod, null, AcadModelSpace, new object[] { Point });
        }
        public object AddLWPolyline(double[] coordinates)
        {
            return AcadModelSpace.GetType().InvokeMember("AddLightWeightPolyline", System.Reflection.BindingFlags.InvokeMethod, null, AcadModelSpace, new object[] { coordinates });
        }
    }
}
