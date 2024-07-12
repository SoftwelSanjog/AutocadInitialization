using AutocadInitialization;
using Autodesk.AutoCAD.Interop;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoCADWrapper
{
    public class Application
    {
        private int currentAcadProcessId;
        private AcadApplication acadApplication;
        //private AcadDocument acadDocument;
        private const string progId = "AutoCAD.Application.24.1";

        public Application()
        {

        }
        private int GetProcessId()
        {
            int pId = 0;
            foreach (Process proc in Process.GetProcessesByName("acad"))
            {
                pId += proc.Id;
            }
            return pId;
        }

        public void Initialize(string version = "", bool visibility = false)
        {
            int oPid = GetProcessId();
            int nPid = 0;
            string acadversion = "AutoCAD.Application";

            if (version != "")
            {
                acadversion += "." + version;
            }
            try
            {
                acadApplication = (AcadApplication)Marshal.GetActiveObject(acadversion);
                nPid = GetProcessId();
            }
            catch (Exception ex)
            {
                try
                {
                    acadApplication = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(acadversion), true);
                    System.Threading.Thread.Sleep(1000);
                    nPid = GetProcessId();
                    acadApplication.Visible = visibility;
                }
                catch
                {
                    MessageBox.Show("Instance of 'Autocad.Application' could not be created.");
                }
            }
            currentAcadProcessId = nPid - oPid;
        }

        public void Finalized()
        {
            try
            {
                acadApplication.Quit();
                //if the normal process doesnot kill the process then second time process killing
                if (currentAcadProcessId > 0)
                {
                    Process proc = Process.GetProcessById(currentAcadProcessId);
                    proc.Kill();
                }
                acadApplication = null;
            }
            catch
            {

            }
        }
        public Document getActiveDocument()
        {
            Document doc = new Document();
            doc.SetDocumentObject(InvokeAcadApplicationMethod("ActiveDocument", BindingFlags.GetProperty, null));
            return doc;
        }
        public object Documents
        {
            get
            {
                return InvokeAcadApplicationMethod("Documents", BindingFlags.GetProperty, null);
            }
        }
        public void openDwgFile(string filename)
        {
            object documents = Documents;
            InvokeAcadApplicationMethod("Open", BindingFlags.InvokeMethod, new object[] { filename });
        }
        private object InvokeAcadApplicationMethod(string methodName, BindingFlags bindingFlags, object[] args)
        {
            return acadApplication.GetType().InvokeMember(methodName, bindingFlags, null, acadApplication, args);
        }


        public void Update()
        {
            acadApplication.Update();
        }
        public void ZoomExtents()
        {
            acadApplication.ZoomExtents();
        }
        /*acadApp = obj as AcadApplication;
        double[] cen = new double[] { 0, 0, 0 };
        circle = acadApp.ActiveDocument.Database.ModelSpace.AddCircle(cen, 10);
                    color = acadApp.GetInterfaceObject("Autocad.AcCmColor.18") as AcadAcCmColor;
                    color.SetRGB(50, 150, 250);
                    circle.TrueColor = color;
        You can try this too
            finally
            {
                if (color != null) Marshal.FinalReleaseComObject(color);
                if (circle != null) Marshal.FinalReleaseComObject(circle);
                if (acadApp != null) Marshal.FinalReleaseComObject(acadApp);
            }
        */
        public object getColor()
        {
            Object color;
            color = acadApplication.GetInterfaceObject("AutoCAD.AcCmColor." + Global.selectedCadVersion);
            return color;
        }

    }
}

