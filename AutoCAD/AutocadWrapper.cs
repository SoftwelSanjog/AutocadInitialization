using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutocadInitialization.AutoCAD
{
    public class AutocadWrapper
    {
        private int currentAcadProcessId;
        private AcadApplication acadApplication;

        public AutocadWrapper()
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
    }
}
