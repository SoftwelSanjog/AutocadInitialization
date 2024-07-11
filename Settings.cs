using AutocadInitialization.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutocadInitialization
{
    public partial class Settings : Form
    {
        Dictionary<string, double> cadVersion = new Dictionary<string, double>();
        public Settings()
        {
            InitializeComponent();
            LoadCadVersion();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadCadVersion();
        }
        private void LoadCadVersion()
        {
            cboCadVersion.Items.Add("AutoCAD 2000 (15)");
            cboCadVersion.Items.Add("AutoCAD 2002 (15.2)");
            cboCadVersion.Items.Add("AutoCAD 2004 (16)");
            cboCadVersion.Items.Add("AutoCAD 2005 (16.1)");
            cboCadVersion.Items.Add("AutoCAD 2006 (16.2)");
            cboCadVersion.Items.Add("AutoCAD 2007 (17)");
            cboCadVersion.Items.Add("AutoCAD 2008 (17.1)");
            cboCadVersion.Items.Add("AutoCAD 2009 (17.2)");
            cboCadVersion.Items.Add("AutoCAD 2010 (18)");
            cboCadVersion.Items.Add("AutoCAD 2011 (18.1)");
            cboCadVersion.Items.Add("AutoCAD 2012 (18.2)");
            cboCadVersion.Items.Add("AutoCAD 2013 (19)");
            cboCadVersion.Items.Add("AutoCAD 2014 (19.1)");
            cboCadVersion.Items.Add("AutoCAD 2015 (20)");
            cboCadVersion.Items.Add("AutoCAD 2016 (20.1)");
            cboCadVersion.Items.Add("AutoCAD 2017 (21)");
            cboCadVersion.Items.Add("AutoCAD 2018 (22)");
            cboCadVersion.Items.Add("AutoCAD 2019 (23)");
            cboCadVersion.Items.Add("AutoCAD 2020 (23.1)");
            cboCadVersion.Items.Add("AutoCAD 2021 (24)");
            cboCadVersion.Items.Add("AutoCAD 2022 (24.1)");
            cboCadVersion.Items.Add("AutoCAD 2023 (24.2)");

            //SelectItem1(cboCadVersion, Global.selectedCadVersion.ToString());
        }
        private void SelectItem1(ComboBox box, string version)
        {
            int curIndex = 0;
            foreach (var item in cboCadVersion.Items)
            {
                string itemString = item.ToString();
                if (itemString.Split('(')[1].Replace(")", "") == version)
                {
                    box.SelectedIndex = curIndex;
                    return;
                }
                curIndex++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqliteClass objsqlite = new SqliteClass(Global.localDbPath);
            string qry = "UPDATE tblsettings SET cadVersion=" + Global.selectedCadVersion;
            List<string> qrylst = new List<string> { qry };

            if (objsqlite.Transaction(qrylst.ToArray()))
            {
                Global.selectedCadVersion = double.Parse(cboCadVersion.Text.Split('(')[1].Replace(")", ""));
                MessageBox.Show("Setting Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
        }

        private void cboCadVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCadVersion.SelectedIndex < 0) return;
            Global.selectedCadVersion = double.Parse(cboCadVersion.Text.Split('(')[1].Replace(")", ""));
        }
    }
}
