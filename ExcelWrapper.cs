using Autodesk.AutoCAD.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutocadInitialization
{
    public class ExcelWrapper
    {
        private int currentAcadProcessId;
        private Microsoft.Office.Interop.Excel.Application xlApplication;
        private Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        private Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        private const string progId = "Excel.Application";
        private int GetProcessId()
        {
            int pId = 0;
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                pId += proc.Id;
            }
            return pId;
        }

        public void Initialize(bool visibility = false)
        {
            int oPid = GetProcessId();
            int nPid = 0;
            try
            {
                xlApplication = (Microsoft.Office.Interop.Excel.Application)Marshal.GetActiveObject(progId);
                xlWorkBook = xlApplication.ActiveWorkbook;

                nPid = GetProcessId();
            }
            catch (Exception ex)
            {
                try
                {
                    xlApplication = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Type.GetTypeFromProgID(progId), true);
                    System.Threading.Thread.Sleep(1000);
                    nPid = GetProcessId();
                    xlApplication.Visible = visibility;
                }
                catch
                {
                    MessageBox.Show("Instance of 'Excel.Application' could not be created.");
                }
            }
            currentAcadProcessId = nPid - oPid;
        }
        public void Finalized()
        {
            try
            {
                xlApplication.Quit();
                //if the normal process doesnot kill the process then second time process killing
                if (currentAcadProcessId > 0)
                {
                    Process proc = Process.GetProcessById(currentAcadProcessId);
                    proc.Kill();
                }
                xlApplication = null;
            }
            catch
            {

            }
        }

        public AttributeData GetAttributeData() {
            xlWorkSheet = xlWorkBook.Worksheets["DataSheet"];
            AttributeData attributeData = new AttributeData();
            attributeData.ClientHead =string.IsNullOrEmpty(xlWorkSheet.Cells[2, 2].Value.ToString())? "": xlWorkSheet.Cells[2, 2].Value.ToString();
            attributeData.Department = xlWorkSheet.Cells[3, 2].Value;
            attributeData.Division = xlWorkSheet.Cells[4, 2].Value.ToString();
            attributeData.ClientLocation = xlWorkSheet.Cells[5, 2].Value.ToString();
            attributeData.Designer = xlWorkSheet.Cells[58, 2].Value.ToString();
            attributeData.Date = xlWorkSheet.Cells[59, 2].Value.ToString();
            attributeData.FirmName = xlWorkSheet.Cells[7, 2].Value.ToString();
            attributeData.FirmLocation = xlWorkSheet.Cells[8, 2].Value.ToString();
            attributeData.ProjectName = xlWorkSheet.Cells[11, 2].Value.ToString();
            attributeData.ProjectLocation = xlWorkSheet.Cells[17, 2].Value.ToString();
            attributeData.DrawingNo = xlWorkSheet.Cells[60, 2].Value.ToString();
            return attributeData;
        }
    }
}
