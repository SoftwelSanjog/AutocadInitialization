using AutocadInitialization.Class;
using AutoCADWrapper;
using Autodesk.AutoCAD.Interop;
using Autodesk.AutoCAD.Interop.Common;
using Microsoft.Office.Interop.Excel;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AutocadInitialization
{
    public partial class Main : Form
    {
        private int currentAcadProcessId;
        //private AcadApplication AcadApp;
        //private AcadDocument AcadDoc;
        private AutoCADWrapper.Document AcadDoc;
        private AcadDocument acadDocs;
        private AutoCADWrapper.Application AcadApp;
        private AttributeData attributeData;
        private ListViewItemArranger listItemArranger;
        private SqliteClass objSqlite;
        public static string dbPath = System.Windows.Forms.Application.StartupPath + "\\support\\settings.dat";

        private const string progId = "AutoCAD.Application.24.1";
        private Settings settings;
        public Main()
        {
            InitializeComponent();
            InitializeCheckboxTag();
            settings = new Settings();
            settings.SettingsChanged += Settings_SettingChanged;

        }
        private void InitializeCheckboxTag()
        {

            //lets assign the checkbox tags as property name for easy identificatin
            //store related textboxes in checkbox tag
            //chkHead.Tag = nameof(attributeData.isClientHead);
            //chkDepartment.Tag = nameof(attributeData.isDepartment);
            //chkLocation.Tag = nameof(attributeData.isClientLocation);
            //chkFirmName.Tag = nameof(attributeData.isFirmName);
            //chkFirmLocation.Tag = nameof(attributeData.isFirmLocation);
            //chkProjectName.Tag = nameof(attributeData.isProjectName);
            //chkProjectLocation.Tag = nameof(attributeData.isProjectLocation);
            //chkDesignerName.Tag = nameof(attributeData.isDesigner);
            //chkDesignedDate.Tag = nameof(attributeData.isDate);
            //chkDrawingName.Tag = nameof(attributeData.isDrawingName);

            chkHead.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtHead, nameof(attributeData.isClientHead));
            chkDepartment.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtDepartment, nameof(attributeData.isDepartment));
            chkDivision.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtDivision, nameof(attributeData.isDivision));
            chkLocation.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtLocation, nameof(attributeData.isClientLocation));
            chkFirmName.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtFirmName, nameof(attributeData.isFirmName));
            chkFirmLocation.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtFirmLocation, nameof(attributeData.isFirmLocation));
            chkProjectName.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtProjectName, nameof(attributeData.isProjectName));
            chkProjectLocation.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtProjectLocation, nameof(attributeData.isProjectLocation));
            chkDesignerName.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtDesignerName, nameof(attributeData.isDesigner));
            chkDesignedDate.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtDesignedDate, nameof(attributeData.isDate));
            chkDrawingName.Tag = new Tuple<System.Windows.Forms.TextBox, string>(txtDrawingName, nameof(attributeData.isDrawingName));
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
            this.Text += " Current Version " + Global.CurrentVersion.ToString();
            copyDbFile();
            readSettings();
        }
        private void copyDbFile()
        {
            string localFilePath = IO.UserDataFolder();
            Global.localDbPath = localFilePath + "\\settings.dat";
            if (!File.Exists(Global.localDbPath))
            {
                File.Copy(dbPath, Global.localDbPath);
            }
            else
            {

            }
        }
        private void readSettings()
        {
            objSqlite = new SqliteClass(Global.localDbPath);
            System.Data.DataTable dt = objSqlite.ReadDataFromTable("*", "tblsettings", "id=1");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Global.selectedCadVersion = (double)dr["cadVersion"];
                    Global.dwgFolderpath = (string)dr["dwgfolderpath"].ToString();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (Global.dwgFolderpath == null || !Directory.Exists(Global.dwgFolderpath))
            {
                MessageBox.Show("Please set the drawing collection path in setting.", "Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                LoadDwgFiles(Global.dwgFolderpath);
            }
            txtDwgFolderPath.Text = Global.dwgFolderpath;


            //if (Global.dwgFolderpath == string.Empty)
            //{
            //    MessageBox.Show("You can set the drawing file directory in setting page.", "Setting", MessageBoxButtons.OK);
            //    return;
            //}
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //if (dialog.ShowDialog() != DialogResult.OK) return;
            //folderpath = dialog.SelectedPath;

        }
        private void LoadDwgFiles(string fpath)
        {
            lvDrawingsFrom.Items.Clear();
            foreach (string file in Directory.GetFiles(Global.dwgFolderpath))
            {
                string extension = Path.GetExtension(file);
                if (extension == ".dwg")
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = Path.GetFileNameWithoutExtension(file);
                    lvDrawingsFrom.Items.Add(item);
                }
            }
            chkSelect.Enabled = lvDrawingsFrom.Items.Count != 0;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDrawingsFrom.Items)
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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.Text == string.Empty)
            {
                MessageBox.Show("Please choose folder path to copy the drawings.", "Path", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Directory.Exists(txtFolderPath.Text))
            {
                MessageBox.Show("Directory doesnot exist. Please create the folder and try again.", "Folder Not Exist.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (attributeData == null)
            {
                MessageBox.Show("Please read data from Excel First.", "Read Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lvDrawingsTo.Items.Count == 0)
            {
                MessageBox.Show("Please select the drawing to execute.", "Select", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var files = Directory.EnumerateFiles(txtFolderPath.Text,"*.*",SearchOption.AllDirectories)
                            .Select(file=> new FileInfo(file));
            int fileCount = files.Count();
            if (fileCount > 0)
            {
                DialogResult result = MessageBox.Show("Folder contains files. Do you want to delete those files first?", "Delete Files", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    foreach(var file in files)
                    {
                        file.Delete();
                    }
                }
                else
                {
                    tsStatus.Text = "Operation Terminated.";
                    return;
                }
            }


            AutoCADWrapper.Application app = new AutoCADWrapper.Application();
            try
            {
                app.Initialize(Global.selectedCadVersion.ToString(), true);
                //Copy the selected drawing to the destination folder 
                
                foreach (ListViewItem lvItem in lvDrawingsTo.CheckedItems)
                {
                    string FileName = lvItem.Text;
                    string sourceFilePath = Path.Combine(Global.dwgFolderpath, FileName + ".dwg");
                    string destinationFilePath = Path.Combine(Global.dwgFolderpathCopied, FileName+ ".dwg");
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    try
                    {                        
                        int retryCount = 5;
                        int delay = 2000;
                        //while (retryCount > 0)
                        //{
                        //try
                        //{
                        //string dwgFilePath = @"C:\Users\shaky\Downloads\00 Drawing Test\08 VALVE CHAMBER.dwg";
                        //string dwgFilePath = @"C:\Users\Sanjog Shakya\Downloads\AutocadTest\08 VALVE CHAMBER.dwg";
                        acadDocs = app.AcadApplication.Documents.Open(destinationFilePath);
                        tsStatus.Text = "Now Processing " + acadDocs.Name;
                        try
                        {
                            foreach (AcadLayout layout in acadDocs.Layouts)
                            {
                                //tsStatus.Text = $"Processing Layout : {layout.Name}";
                                Thread.Sleep(delay);

                                AcadBlock block = (AcadBlock)layout.Block;
                                foreach (AcadEntity entity in block)
                                {
                                    if (entity is AcadBlockReference)
                                    {
                                        //if (entity.Eff != "A3_Template_New") continue;
                                        AcadBlockReference blockRef = (AcadBlockReference)entity;
                                        //tsStatus.Text = $"Found block reference: {blockRef.Name}";

                                        if (blockRef.Name != "A3_Template_New") continue;
                                        foreach (AcadAttributeReference attrRef in blockRef.GetAttributes())
                                        {
                                            tsStatus.Text = $"Processing attribute: {attrRef.TagString}";

                                            switch (attrRef.TagString.ToUpper())
                                            {
                                                case "DESIGNER":
                                                    attrRef.TextString = attributeData.Designer;
                                                    break;
                                                case "DATE":
                                                    attrRef.TextString = attributeData.Date;
                                                    break;
                                                case "PROJECT_NAME":
                                                    attrRef.TextString = attributeData.ProjectName;
                                                    break;
                                                case "PROJECT_LOCATION":
                                                    attrRef.TextString = attributeData.ProjectLocation;
                                                    break;
                                                case "DWG_NO":
                                                    attrRef.TextString = attributeData.DrawingNo;
                                                    break;
                                                case "":
                                                    attrRef.TextString = attributeData.DrawingNo;
                                                    break;
                                                case "CLIENTHEAD":
                                                    attrRef.TextString = attributeData.ClientHead;
                                                    break;
                                                case "DEPARTMENT":
                                                    attrRef.TextString = attributeData.Department;
                                                    break;
                                                case "DIVISION":
                                                    attrRef.TextString = attributeData.Division;
                                                    break;
                                                case "CLIENTLOCATION":
                                                    attrRef.TextString = attributeData.ClientLocation;
                                                    break;
                                                case "FIRMNAME":
                                                    attrRef.TextString = attributeData.FirmName;
                                                    break;
                                                case "FIRMLOCATION":
                                                    attrRef.TextString = attributeData.FirmLocation;
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
                            Console.WriteLine($"Error processing {destinationFilePath}: {ex.Message}");
                        }
                        acadDocs.Save();
                        acadDocs.Close();
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to initialize Autocad Application.");
                    }
                    finally
                    {
                        if (acadDocs != null)
                        {
                            Marshal.ReleaseComObject(acadDocs);
                            acadDocs = null; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                tsStatus.Text = "Ready";
                app.Finalized();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadDwgFiles(Global.dwgFolderpath);
        }

        private void btnReadExcel_Click(object sender, EventArgs e)
        {
            ExcelWrapper excelWrapper = new ExcelWrapper();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                excelWrapper.Initialize();
                tsStatus.Text = "Reading Excel.....";
                attributeData = excelWrapper.GetAttributeData();
                txtHead.Text = attributeData.ClientHead;
                txtDepartment.Text = attributeData.Department;
                txtDivision.Text = attributeData.Division;
                txtLocation.Text = attributeData.ClientLocation;
                txtFirmName.Text = attributeData.FirmName;
                txtFirmLocation.Text = attributeData.FirmLocation;
                txtProjectName.Text = attributeData.ProjectName;
                txtProjectLocation.Text = attributeData.ProjectLocation;
                txtDesignerName.Text = attributeData.Designer;
                txtDesignedDate.Text = attributeData.Date;
                txtDrawingName.Text = attributeData.DrawingNo;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //excelWrapper.Finalized();
                tsStatus.Text = "Ready";
                Cursor.Current = Cursors.Default;
            }

        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox checkbox = sender as System.Windows.Forms.CheckBox;
            if (checkbox != null && checkbox.Tag is Tuple<System.Windows.Forms.TextBox, string> tag)
            {
                //string propName = checkbox.Tag as string;
                //if (propName != null)
                //{
                //    // use reflection to set the property value dynamically
                //    typeof(AttributeData).GetProperty(propName).SetValue(attributeData, checkbox.Checked);
                //}

                System.Windows.Forms.TextBox textBox = tag.Item1 as System.Windows.Forms.TextBox;
                string propName = tag.Item2 as string;
                typeof(AttributeData).GetProperty(propName)?.SetValue(attributeData, checkbox.Checked);
                textBox.Enabled = checkbox.Checked;
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show($"chkClientHead: {attributeData.isClientHead}\n" +
            //                $"chkDepartment: {attributeData.isDepartment}\n" +
            //                $"chkLocation: {attributeData.isClientLocation}\n" +
            //                $"chkFirmName: {attributeData.isFirmName}\n" +
            //                $"chkFirmLocation: {attributeData.isFirmLocation}\n" +
            //                $"chkProjectName: {attributeData.isProjectName}\n" +
            //                $"chkProjectLocation: {attributeData.isProjectLocation}\n" +
            //                $"chkDate: {attributeData.isDate}\n" +
            //                $"chkDesigner: {attributeData.isDesigner}\n");
            Settings objSettings = new Settings();
            objSettings.ShowDialog();
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            //object selectedItem;

            foreach (ListViewItem selectedItem in lvDrawingsFrom.CheckedItems)
            {
                lvDrawingsTo.Items.Add(selectedItem.Text.ToString());
            }
            //remove the selected item
            int selectedCount = lvDrawingsFrom.CheckedItems.Count;
            ListViewItem selectedItm;
            while (selectedCount > 0)
            {
                selectedItm = lvDrawingsFrom.CheckedItems[0];
                lvDrawingsFrom.Items.Remove(selectedItm);
                selectedCount = lvDrawingsFrom.CheckedItems.Count;
            }
            chkSelectTo.Enabled = lvDrawingsTo.Items.Count != 0;
            chkSelectTo.Checked = lvDrawingsTo.Items.Count != 0;
            //chkSelect.Checked = lvDrawingsFrom.Items.Count != 0;
            chkSelect.Enabled = lvDrawingsFrom.Items.Count != 0;
            chkSelect.Text = "Select All";
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in lvDrawingsTo.CheckedItems)
            {
                lvDrawingsFrom.Items.Add(selectedItem.Text.ToString());
            }
            //remove the selected item
            int selectedCount = lvDrawingsTo.CheckedItems.Count;
            ListViewItem selectedItm;
            while (selectedCount > 0)
            {
                selectedItm = lvDrawingsTo.CheckedItems[0];
                lvDrawingsTo.Items.Remove(selectedItm);
                selectedCount = lvDrawingsTo.CheckedItems.Count;
            }
            chkSelect.Enabled = lvDrawingsFrom.Items.Count != 0;
            chkSelect.Checked = false;

            chkSelectTo.Enabled = lvDrawingsTo.Items.Count != 0;
            chkSelectTo.Checked = lvDrawingsTo.Items.Count != 0;
            chkSelectTo.Text = "Select All";
        }

        private void chkSelectTo_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvDrawingsTo.Items)
            {
                item.Checked = chkSelectTo.Checked;
            }
            if (chkSelectTo.CheckState == CheckState.Checked)
            {
                chkSelectTo.Text = "Unselect All";
            }
            else
            {
                chkSelectTo.Text = "Select All";
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            listItemArranger = new ListViewItemArranger(lvDrawingsTo);
            listItemArranger.MoveUp();
        }

        private void lvDrawingsTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listItemArranger = new ListViewItemArranger(lvDrawingsTo);
            listItemArranger.MoveDown();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            listItemArranger = new ListViewItemArranger(lvDrawingsTo);
            listItemArranger.MoveDown();
        }

        private void Settings_SettingChanged(object sender, EventArgs e)
        {
            readSettings();
        }
        // Helper method to invoke methods on COM objects
        private object InvokeMethod(object comObject, string methodName, BindingFlags bindingFlags, object[] args)
        {
            return comObject.GetType().InvokeMember(methodName, bindingFlags, null, comObject, args);
        }
        #region autocad methods

        #endregion

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            if (txtFolderPath.Text == String.Empty)
            {
                FolderBrowserDialog fdb = new FolderBrowserDialog();
                if (fdb.ShowDialog() == DialogResult.OK)
                {
                    Global.dwgFolderpathCopied = fdb.SelectedPath;
                }
            }
            else
            {
                //open that folder in fileexplorer
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Arguments = Global.dwgFolderpathCopied,
                        FileName = Global.dwgFolderpathCopied,
                        UseShellExecute = true

                    };
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {

                }
            }
            txtFolderPath.Text = Global.dwgFolderpathCopied;
        }

        private void lvDrawingsFrom_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = 0;
            foreach (ListViewItem lv in lvDrawingsFrom.Items)
            {
                if (lv.Checked) { count++; }
            }
            if (count == 0)
            {
                chkSelect.Text = "Select All";
                chkSelect.Enabled = true;
            }
            else
            {
                //chkSelect.Text = "Select All";
                chkSelect.Enabled = true;
                //chkSelect.Checked = false;
            }
        }
    }
}
