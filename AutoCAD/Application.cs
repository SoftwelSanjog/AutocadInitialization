using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCADWrapper
{
    public class Application
    {
        private int currentAcadProcessId;
        private AcadApplication AcadApp;
        private AcadDocument AcadDoc;
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
                AcadApp = (AcadApplication)Marshal.GetActiveObject(acadversion);
                nPid = GetProcessId();
            }
            catch (Exception ex)
            {
                try
                {
                    AcadApp = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(acadversion), true);
                    nPid = GetProcessId();
                    AcadApp.Visible = visibility;
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
                AcadApp.Quit();
                //if the normal process doesnot kill the process then second time process killing
                if (currentAcadProcessId > 0)
                {
                    Process proc = Process.GetProcessById(currentAcadProcessId);
                    proc.Kill();
                }
                AcadApp = null;
            }
            catch
            {

            }
        }
        public Document getActiveDocument()
        {
            Document doc = new Document();
            doc.SetDocumentObject(AcadApp.GetType().InvokeMember("ActiveDocument", System.Reflection.BindingFlags.GetProperty, null, AcadApp, null));
            return doc;
        }
        public void Update()
        {
            AcadApp.Update();
        }
        public void ZoomExtents()
        {
            AcadApp.ZoomExtents();
        }
    }
}
