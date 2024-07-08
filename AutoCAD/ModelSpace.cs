using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            return InvokeAcadModalSpaceMethod("AddCircle",BindingFlags.InvokeMethod, new object[] {center,radius});
        }
        public object AddLine(double[] startPoint, double[] endPoint) //AcadLine
        {
            return InvokeAcadModalSpaceMethod("AddLine",BindingFlags.InvokeMethod,new object[] { startPoint, endPoint});
        }
        public object AddText(string myText, double[] txtCoordinate, double factor)
        {
            return InvokeAcadModalSpaceMethod("AddText", BindingFlags.InvokeMethod, new object[] { myText, txtCoordinate, factor });
        }
        public object AddPoint(double[] Point)
        {
            
            return InvokeAcadModalSpaceMethod("AddPoint", BindingFlags.InvokeMethod,new object[] { Point });
        }
        
        public object AddLWPolyline(double[] coordinates)
        {
            return InvokeAcadModalSpaceMethod("AddLightWeightPolyline", BindingFlags.InvokeMethod, new object[] { coordinates });
        }
        public object AddHatch(object loops, int patternType, string patternName)
        {
            return InvokeAcadModalSpaceMethod("AddHatch", BindingFlags.InvokeMethod, new object[] { loops, patternType, patternName });
        }
        public object AddDimension(int dimType, double[] extensionLine1, double[] extensionLine2, double[] dimensionLine)
        {
            return InvokeAcadModalSpaceMethod("AddDimAligned", BindingFlags.InvokeMethod, new object[] { dimType, extensionLine1, extensionLine2, dimensionLine });
        }
        public object AddLeader(double[] landingPoint, object vertices)
        {
            
            return InvokeAcadModalSpaceMethod("AddLeader", BindingFlags.InvokeMethod, new object[] { landingPoint, vertices });
        }
        private object InvokeAcadModalSpaceMethod(string methodName, BindingFlags bindingFlags, object[] args)
        {
            return AcadModelSpace.GetType().InvokeMember(methodName, bindingFlags, null, AcadModelSpace, args);
        }
    }
}
