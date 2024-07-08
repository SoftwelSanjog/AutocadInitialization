using Autodesk.AutoCAD.Interop;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AutoCADWrapper;

namespace AutocadInitialization
{
    public partial class Form1 : Form
    {
        private int currentAcadProcessId;
        //private AcadApplication AcadApp;
        //private AcadDocument AcadDoc;
        private AutoCADWrapper.Document AcadDoc;
        private AutoCADWrapper.Application AcadApp;

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

            AcadApp = new AutoCADWrapper.Application();
            AcadApp.Initialize("24.1", true);


        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            //Finalized();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AcadDoc = new Document();   
            AcadDoc =(Document) AcadApp.getActiveDocument();
            double[] center = { 0, 0, 0 };
            ModelSpace mod =  AcadDoc.ModelSpace();
            mod.AddCircle(center, 10);

            double[] startpt = { 0, 0, 0 };
            double[] endpt = { 100, 100, 0 };
            mod.AddLine(startpt, endpt);    

            AcadApp.ZoomExtents();

        }
    }
}
