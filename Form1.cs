using AutoCADWrapper;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            AcadDoc = (Document)AcadApp.getActiveDocument();
            double[] center = { 0, 0, 0 };
            ModelSpace mod = AcadDoc.ModelSpace();
            mod.AddCircle(center, 10);

            double[] startpt = { 0, 0, 0 };
            double[] endpt = { 100, 100, 0 };
            mod.AddLine(startpt, endpt);

            AcadApp.ZoomExtents();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string excelFilePath = @"C:\Users\Sanjog Shakya\Downloads\AutocadTest\Book1.xlsx";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(excelFilePath);
            Excel.Worksheet excelWorksheet = excelWorkbook.Sheets[1];

            string designer = excelWorksheet.Cells[2, 2].Value.ToString();
            string scale = excelWorksheet.Cells[3, 2].Value.ToString();
            string date = excelWorksheet.Cells[4, 2].Value.ToString();
            string dwgTitle = excelWorksheet.Cells[5, 2].Value.ToString();
            string projectTitle = excelWorksheet.Cells[6, 2].Value.ToString();
            string projectLocation = excelWorksheet.Cells[7, 2].Value.ToString();
            string dwgNo = excelWorksheet.Cells[8, 2].Value.ToString();
            string sheetNo = excelWorksheet.Cells[9, 2].Value.ToString();

            AcadApplication acadApp;
            // AutoCADWrapper.Application acadApp = new AutoCADWrapper.Application();
            //acadApp.Initialize("24.1", true);

            try
            {
                acadApp = (AcadApplication)Marshal.GetActiveObject("AutoCAD.Application.24.1");
            }
            catch
            {
                acadApp = new AcadApplication();
                acadApp.Visible = true;
            }

            string dwgFilePath = @"C:\Users\Sanjog Shakya\Downloads\AutocadTest\08 VALVE CHAMBER.dwg";

            int retryCount = 5;
            int delay = 2000;
            while (retryCount > 0)
            {
                try
                {

                    AcadDocument acadDoc = acadApp.Documents.Open(dwgFilePath);
                    //AutoCADWrapper.Document acadDoc = acadApp.Documents.Open(dwgFilePath);

                    try
                    {
                        foreach (AcadLayout layout in acadDoc.Layouts)
                        {
                            Console.WriteLine($"Processing Layout : {layout.Name}");


                            AcadBlock block = (AcadBlock)layout.Block;
                            foreach (AcadEntity entity in block)
                            {
                                if (entity is AcadBlockReference)
                                {

                                    //if (entity.Eff != "A3_Template_New") continue;
                                    AcadBlockReference blockRef = (AcadBlockReference)entity;
                                    Console.WriteLine($"Found block reference: {blockRef.Name}");

                                    if (blockRef.Name != "A3_Template_New") continue;
                                    foreach (AcadAttributeReference attrRef in blockRef.GetAttributes())
                                    {
                                        Console.WriteLine($"Processing attribute: {attrRef.TagString}");

                                        switch (attrRef.TagString.ToUpper())
                                        {
                                            case "DESIGNER":
                                                attrRef.TextString = designer;
                                                break;
                                            case "SCALE":
                                                attrRef.TextString = scale;
                                                break;
                                            case "DATE":
                                                attrRef.TextString = date;
                                                break;
                                            case "DWG_TITLE":
                                                attrRef.TextString = dwgTitle;
                                                break;
                                            case "PROJECT_NAME":
                                                attrRef.TextString = projectTitle;
                                                break;
                                            case "PROJECT_LOCATION":
                                                attrRef.TextString = projectLocation;
                                                break;
                                            case "DWG_NO":
                                                attrRef.TextString = dwgNo;
                                                break;
                                            case "SHEET_NO":
                                                attrRef.TextString = sheetNo;
                                                break;

                                        }
                                        attrRef.Update();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing {dwgFilePath}: {ex.Message}");
                    }
                    #region For ModelSpace
                    //foreach (AcadEntity entity in acadDoc.PaperSpace)
                    //{
                    //    if (entity is AcadBlockReference)
                    //    {
                    //        AcadBlockReference blockRef = (AcadBlockReference)entity;
                    //        foreach (AcadAttributeReference attrRef in blockRef.GetAttributes())
                    //        {
                    //            switch (attrRef.TagString.ToUpper())
                    //            {
                    //                case "DESIGNER":
                    //                    attrRef.TextString = designer;
                    //                    break;
                    //                case "SCALE":
                    //                    attrRef.TextString = scale;
                    //                    break;
                    //                case "DATE":
                    //                    attrRef.TextString = date;
                    //                    break;
                    //                case "DWG_TITLE":
                    //                    attrRef.TextString = dwgTitle;
                    //                    break;
                    //                case "PROJECT_NAME":
                    //                    attrRef.TextString = projectTitle;
                    //                    break;
                    //                case "PROJECT_LOCATION":
                    //                    attrRef.TextString = projectLocation;
                    //                    break;
                    //                case "DWG_NO":
                    //                    attrRef.TextString = dwgNo;
                    //                    break;
                    //                case "SHEET_NO":
                    //                    attrRef.TextString = sheetNo;
                    //                    break;

                    //            }
                    //            attrRef.Update();
                    //        }
                    //    }
                    //}
                    #endregion
                    acadDoc.Save();
                    acadDoc.Close();

                }
                catch (COMException comEx)
                {
                    if ((uint)comEx.ErrorCode == 0x80010001) // RPC_E_CALL_REJECTED
                    {
                        retryCount--;
                        Console.WriteLine("Call was rejected by callee, retrying...");
                        Thread.Sleep(delay);
                    }
                    else
                    {
                        throw;
                    }
                }


                excelWorkbook.Close(false);
                excelApp.Quit();
                //Release com objects
                Marshal.ReleaseComObject(excelWorkbook);
                Marshal.ReleaseComObject(excelApp);
                break;
            }
            if (retryCount == 0)
            {
                Console.WriteLine("Failed to process");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string dwgPath = @"C:\Users\Sanjog Shakya\Downloads\AutocadTest\08 VALVE CHAMBER.dwg";
            AutoCADWrapper.Application app = new AutoCADWrapper.Application();
            app.Initialize("24.1", true);

            object documents = app.GetType().InvokeMember("Documents", System.Reflection.BindingFlags.GetProperty, null, app, null);

            documents.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, documents, new object[] { dwgPath });

            AutoCADWrapper.Document doc = app.getActiveDocument();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;
            string folderpath = dialog.SelectedPath;
            lvDrawings.Items.Clear();
            foreach (string file in Directory.GetFiles(folderpath))
            {
                string extension = Path.GetExtension(file);
                if (extension == ".dwg")
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Path.GetFileNameWithoutExtension(file);
                    lvDrawings.Items.Add(item);
                }
            }
            chkSelect.Enabled = lvDrawings.Items.Count != 0;

        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDrawings.Items)
            {
                item.Checked = chkSelect.Checked;
            }
            if (chkSelect.CheckState == CheckState.Checked)
            {
                chkSelect.Text = "Unselect All";
            }
            else
            {
                chkSelect.Text = "Select All";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //read excel first
            ReadExcelData();
        }
    }
}
