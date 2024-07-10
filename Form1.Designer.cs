namespace AutocadInitialization
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.lvDrawings = new System.Windows.Forms.ListView();
            this.colDwgName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoad = new System.Windows.Forms.Button();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtHead = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDivision = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.chkHead = new System.Windows.Forms.CheckBox();
            this.chkDepartment = new System.Windows.Forms.CheckBox();
            this.chkDivision = new System.Windows.Forms.CheckBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFirmName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirmLocation = new System.Windows.Forms.TextBox();
            this.chkFirmLocation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkFirmName = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProjectLocation = new System.Windows.Forms.TextBox();
            this.chkProjectLocation = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkProjectName = new System.Windows.Forms.CheckBox();
            this.btnReadExcel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtDesignerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDesignedDate = new System.Windows.Forms.TextBox();
            this.chkDesignedDate = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkDesignerName = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtDrawingName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkDrawingName = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Autocad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(697, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(692, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Draw";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(697, 174);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Read Excel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(697, 200);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Execulte Replace";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(539, 247);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(135, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Read Excel With Class";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lvDrawings
            // 
            this.lvDrawings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDrawings.CheckBoxes = true;
            this.lvDrawings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDwgName});
            this.lvDrawings.FullRowSelect = true;
            this.lvDrawings.GridLines = true;
            this.lvDrawings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDrawings.HideSelection = false;
            this.lvDrawings.Location = new System.Drawing.Point(12, 276);
            this.lvDrawings.MultiSelect = false;
            this.lvDrawings.Name = "lvDrawings";
            this.lvDrawings.Size = new System.Drawing.Size(774, 237);
            this.lvDrawings.TabIndex = 6;
            this.lvDrawings.UseCompatibleStateImageBehavior = false;
            this.lvDrawings.View = System.Windows.Forms.View.Details;
            // 
            // colDwgName
            // 
            this.colDwgName.Text = "Drawing Name";
            this.colDwgName.Width = 300;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(697, 120);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load Dwg";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // chkSelect
            // 
            this.chkSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelect.AutoSize = true;
            this.chkSelect.Location = new System.Drawing.Point(12, 524);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(70, 17);
            this.chkSelect.TabIndex = 8;
            this.chkSelect.Text = "Select All";
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(678, 520);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Execute";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(693, 93);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 10;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.btnReload);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.btnReadExcel);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 229);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import from Excel";
            // 
            // txtHead
            // 
            this.txtHead.Location = new System.Drawing.Point(70, 19);
            this.txtHead.Name = "txtHead";
            this.txtHead.Size = new System.Drawing.Size(230, 20);
            this.txtHead.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Head";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Department";
            // 
            // txtDepartment
            // 
            this.txtDepartment.Location = new System.Drawing.Point(70, 45);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(230, 20);
            this.txtDepartment.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Division";
            // 
            // txtDivision
            // 
            this.txtDivision.Location = new System.Drawing.Point(70, 71);
            this.txtDivision.Name = "txtDivision";
            this.txtDivision.Size = new System.Drawing.Size(230, 20);
            this.txtDivision.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Location";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(70, 95);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(230, 20);
            this.txtLocation.TabIndex = 6;
            // 
            // chkHead
            // 
            this.chkHead.AutoSize = true;
            this.chkHead.Location = new System.Drawing.Point(306, 22);
            this.chkHead.Name = "chkHead";
            this.chkHead.Size = new System.Drawing.Size(15, 14);
            this.chkHead.TabIndex = 8;
            this.chkHead.UseVisualStyleBackColor = true;
            // 
            // chkDepartment
            // 
            this.chkDepartment.AutoSize = true;
            this.chkDepartment.Location = new System.Drawing.Point(306, 48);
            this.chkDepartment.Name = "chkDepartment";
            this.chkDepartment.Size = new System.Drawing.Size(15, 14);
            this.chkDepartment.TabIndex = 9;
            this.chkDepartment.UseVisualStyleBackColor = true;
            // 
            // chkDivision
            // 
            this.chkDivision.AutoSize = true;
            this.chkDivision.Location = new System.Drawing.Point(306, 74);
            this.chkDivision.Name = "chkDivision";
            this.chkDivision.Size = new System.Drawing.Size(15, 14);
            this.chkDivision.TabIndex = 10;
            this.chkDivision.UseVisualStyleBackColor = true;
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(306, 98);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(15, 14);
            this.chkLocation.TabIndex = 11;
            this.chkLocation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHead);
            this.groupBox2.Controls.Add(this.chkLocation);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.chkDivision);
            this.groupBox2.Controls.Add(this.txtDepartment);
            this.groupBox2.Controls.Add(this.chkDepartment);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkHead);
            this.groupBox2.Controls.Add(this.txtDivision);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 124);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFirmName);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtFirmLocation);
            this.groupBox3.Controls.Add(this.chkFirmLocation);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.chkFirmName);
            this.groupBox3.Location = new System.Drawing.Point(349, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(337, 74);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Consultancy";
            // 
            // txtFirmName
            // 
            this.txtFirmName.Location = new System.Drawing.Point(70, 19);
            this.txtFirmName.Name = "txtFirmName";
            this.txtFirmName.Size = new System.Drawing.Size(230, 20);
            this.txtFirmName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Firm Name";
            // 
            // txtFirmLocation
            // 
            this.txtFirmLocation.Location = new System.Drawing.Point(70, 45);
            this.txtFirmLocation.Name = "txtFirmLocation";
            this.txtFirmLocation.Size = new System.Drawing.Size(230, 20);
            this.txtFirmLocation.TabIndex = 2;
            // 
            // chkFirmLocation
            // 
            this.chkFirmLocation.AutoSize = true;
            this.chkFirmLocation.Location = new System.Drawing.Point(306, 48);
            this.chkFirmLocation.Name = "chkFirmLocation";
            this.chkFirmLocation.Size = new System.Drawing.Size(15, 14);
            this.chkFirmLocation.TabIndex = 9;
            this.chkFirmLocation.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Location";
            // 
            // chkFirmName
            // 
            this.chkFirmName.AutoSize = true;
            this.chkFirmName.Location = new System.Drawing.Point(306, 22);
            this.chkFirmName.Name = "chkFirmName";
            this.chkFirmName.Size = new System.Drawing.Size(15, 14);
            this.chkFirmName.TabIndex = 8;
            this.chkFirmName.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtProjectName);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtProjectLocation);
            this.groupBox4.Controls.Add(this.chkProjectLocation);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.chkProjectName);
            this.groupBox4.Location = new System.Drawing.Point(349, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 74);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Project Information";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(70, 19);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(230, 20);
            this.txtProjectName.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name";
            // 
            // txtProjectLocation
            // 
            this.txtProjectLocation.Location = new System.Drawing.Point(70, 45);
            this.txtProjectLocation.Name = "txtProjectLocation";
            this.txtProjectLocation.Size = new System.Drawing.Size(230, 20);
            this.txtProjectLocation.TabIndex = 2;
            // 
            // chkProjectLocation
            // 
            this.chkProjectLocation.AutoSize = true;
            this.chkProjectLocation.Location = new System.Drawing.Point(306, 48);
            this.chkProjectLocation.Name = "chkProjectLocation";
            this.chkProjectLocation.Size = new System.Drawing.Size(15, 14);
            this.chkProjectLocation.TabIndex = 9;
            this.chkProjectLocation.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Location";
            // 
            // chkProjectName
            // 
            this.chkProjectName.AutoSize = true;
            this.chkProjectName.Location = new System.Drawing.Point(306, 22);
            this.chkProjectName.Name = "chkProjectName";
            this.chkProjectName.Size = new System.Drawing.Size(15, 14);
            this.chkProjectName.TabIndex = 8;
            this.chkProjectName.UseVisualStyleBackColor = true;
            // 
            // btnReadExcel
            // 
            this.btnReadExcel.Location = new System.Drawing.Point(692, 31);
            this.btnReadExcel.Name = "btnReadExcel";
            this.btnReadExcel.Size = new System.Drawing.Size(76, 23);
            this.btnReadExcel.TabIndex = 15;
            this.btnReadExcel.Text = "Read Excel";
            this.btnReadExcel.UseVisualStyleBackColor = true;
            this.btnReadExcel.Click += new System.EventHandler(this.btnReadExcel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtDesignerName);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtDesignedDate);
            this.groupBox5.Controls.Add(this.chkDesignedDate);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.chkDesignerName);
            this.groupBox5.Location = new System.Drawing.Point(6, 149);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 74);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Designer Information";
            // 
            // txtDesignerName
            // 
            this.txtDesignerName.Location = new System.Drawing.Point(70, 19);
            this.txtDesignerName.Name = "txtDesignerName";
            this.txtDesignerName.Size = new System.Drawing.Size(230, 20);
            this.txtDesignerName.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Name";
            // 
            // txtDesignedDate
            // 
            this.txtDesignedDate.Location = new System.Drawing.Point(70, 45);
            this.txtDesignedDate.Name = "txtDesignedDate";
            this.txtDesignedDate.Size = new System.Drawing.Size(230, 20);
            this.txtDesignedDate.TabIndex = 2;
            // 
            // chkDesignedDate
            // 
            this.chkDesignedDate.AutoSize = true;
            this.chkDesignedDate.Location = new System.Drawing.Point(306, 48);
            this.chkDesignedDate.Name = "chkDesignedDate";
            this.chkDesignedDate.Size = new System.Drawing.Size(15, 14);
            this.chkDesignedDate.TabIndex = 9;
            this.chkDesignedDate.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Date";
            // 
            // chkDesignerName
            // 
            this.chkDesignerName.AutoSize = true;
            this.chkDesignerName.Location = new System.Drawing.Point(306, 22);
            this.chkDesignerName.Name = "chkDesignerName";
            this.chkDesignerName.Size = new System.Drawing.Size(15, 14);
            this.chkDesignerName.TabIndex = 8;
            this.chkDesignerName.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtDrawingName);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.chkDrawingName);
            this.groupBox6.Location = new System.Drawing.Point(349, 174);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(337, 49);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Drawing No.";
            // 
            // txtDrawingName
            // 
            this.txtDrawingName.Location = new System.Drawing.Point(70, 19);
            this.txtDrawingName.Name = "txtDrawingName";
            this.txtDrawingName.Size = new System.Drawing.Size(230, 20);
            this.txtDrawingName.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Name";
            // 
            // chkDrawingName
            // 
            this.chkDrawingName.AutoSize = true;
            this.chkDrawingName.Location = new System.Drawing.Point(306, 22);
            this.chkDrawingName.Name = "chkDrawingName";
            this.chkDrawingName.Size = new System.Drawing.Size(15, 14);
            this.chkDrawingName.TabIndex = 8;
            this.chkDrawingName.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.chkSelect);
            this.Controls.Add(this.lvDrawings);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Autocad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView lvDrawings;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.ColumnHeader colDwgName;
        internal System.Windows.Forms.CheckBox chkSelect;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDivision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.CheckBox chkDivision;
        private System.Windows.Forms.CheckBox chkDepartment;
        private System.Windows.Forms.CheckBox chkHead;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFirmName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirmLocation;
        private System.Windows.Forms.CheckBox chkFirmLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkFirmName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProjectLocation;
        private System.Windows.Forms.CheckBox chkProjectLocation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkProjectName;
        private System.Windows.Forms.Button btnReadExcel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtDrawingName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkDrawingName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtDesignerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDesignedDate;
        private System.Windows.Forms.CheckBox chkDesignedDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkDesignerName;
    }
}

