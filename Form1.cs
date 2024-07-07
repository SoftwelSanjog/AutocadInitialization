using Autodesk.AutoCAD.Interop;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutocadInitialization
{
    public partial class Form1 : Form
    {
        private int currentAcadProcessId;
        private AcadApplication AcadApp;
        private const string progId = "AutoCAD.Application.24.1";
        public Form1()
        {
            InitializeComponent();
        }
        private int getProcessId()
        {
            int pId = 0;
            foreach (Process proc in Process.GetProcessesByName("acad"))
            {
                pId += proc.Id;
            }
            return pId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int oPid = getProcessId();
            int nPid = 0;
            try
            {
                AcadApp = (AcadApplication)Marshal.GetActiveObject(progId);
                nPid = getProcessId();
            }
            catch (Exception ex)
            {
                try
                {
                    AcadApp = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(progId), true);
                    nPid = getProcessId();
                    AcadApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Instance of 'Autocad.Application' could not be created.");
                }
            }
            currentAcadProcessId = nPid - oPid;


        }

        private void Finalized()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Finalized();
        }
    }
}
