namespace DW2_Extractor
{
    partial class DW2_Extractor
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openTblExtraction = new System.Windows.Forms.Button();
            this.openTblInsertion = new System.Windows.Forms.Button();
            this.tabPanel1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.generateAllBinDungMess = new System.Windows.Forms.Button();
            this.extractAllTxtFilesMess = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.helpMess = new System.Windows.Forms.Button();
            this.saveTxtMess = new System.Windows.Forms.Button();
            this.saveBinMess = new System.Windows.Forms.Button();
            this.openTxtMess = new System.Windows.Forms.Button();
            this.openBinMess = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.helpItems = new System.Windows.Forms.Button();
            this.saveTxtItems = new System.Windows.Forms.Button();
            this.saveBinItems = new System.Windows.Forms.Button();
            this.openTxtItems = new System.Windows.Forms.Button();
            this.openBinItems = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.helpSysMess = new System.Windows.Forms.Button();
            this.saveTxtSysMess = new System.Windows.Forms.Button();
            this.saveBinSysMess = new System.Windows.Forms.Button();
            this.openTxtSysMess = new System.Windows.Forms.Button();
            this.openBinSysMess = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.generateAllBinCityMess = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.extractAllTxtCityMess = new System.Windows.Forms.Button();
            this.saveTxtCityMess = new System.Windows.Forms.Button();
            this.saveBinCityMess = new System.Windows.Forms.Button();
            this.openTxtCityMess = new System.Windows.Forms.Button();
            this.openBinCityMess = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dw2Name = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openTblExtraction);
            this.panel1.Controls.Add(this.openTblInsertion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 67);
            this.panel1.TabIndex = 0;
            // 
            // openTblExtraction
            // 
            this.openTblExtraction.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTblExtraction.Enabled = false;
            this.openTblExtraction.Location = new System.Drawing.Point(0, 32);
            this.openTblExtraction.Name = "openTblExtraction";
            this.openTblExtraction.Size = new System.Drawing.Size(521, 32);
            this.openTblExtraction.TabIndex = 8;
            this.openTblExtraction.Text = "Open TBL file (Extraction)";
            this.openTblExtraction.UseVisualStyleBackColor = true;
            this.openTblExtraction.Click += new System.EventHandler(this.openTblExtraction_Click);
            // 
            // openTblInsertion
            // 
            this.openTblInsertion.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTblInsertion.Location = new System.Drawing.Point(0, 0);
            this.openTblInsertion.Name = "openTblInsertion";
            this.openTblInsertion.Size = new System.Drawing.Size(521, 32);
            this.openTblInsertion.TabIndex = 7;
            this.openTblInsertion.Text = "Open TBL file (Insertion/Extraction)";
            this.openTblInsertion.UseVisualStyleBackColor = true;
            this.openTblInsertion.Click += new System.EventHandler(this.openTblInsertion_Click);
            // 
            // tabPanel1
            // 
            this.tabPanel1.Controls.Add(this.tabPage1);
            this.tabPanel1.Controls.Add(this.tabPage2);
            this.tabPanel1.Controls.Add(this.tabPage3);
            this.tabPanel1.Controls.Add(this.tabPage4);
            this.tabPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel1.Location = new System.Drawing.Point(0, 47);
            this.tabPanel1.Name = "tabPanel1";
            this.tabPanel1.SelectedIndex = 0;
            this.tabPanel1.Size = new System.Drawing.Size(521, 272);
            this.tabPanel1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.generateAllBinDungMess);
            this.tabPage1.Controls.Add(this.extractAllTxtFilesMess);
            this.tabPage1.Controls.Add(this.saveTxtMess);
            this.tabPage1.Controls.Add(this.saveBinMess);
            this.tabPage1.Controls.Add(this.openTxtMess);
            this.tabPage1.Controls.Add(this.openBinMess);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(513, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DungMess";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // generateAllBinDungMess
            // 
            this.generateAllBinDungMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.generateAllBinDungMess.Enabled = false;
            this.generateAllBinDungMess.Location = new System.Drawing.Point(3, 163);
            this.generateAllBinDungMess.Name = "generateAllBinDungMess";
            this.generateAllBinDungMess.Size = new System.Drawing.Size(507, 32);
            this.generateAllBinDungMess.TabIndex = 8;
            this.generateAllBinDungMess.Text = "Generate all BIN files";
            this.generateAllBinDungMess.UseVisualStyleBackColor = true;
            this.generateAllBinDungMess.Click += new System.EventHandler(this.generateAllBinDungMess_Click);
            // 
            // extractAllTxtFilesMess
            // 
            this.extractAllTxtFilesMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.extractAllTxtFilesMess.Enabled = false;
            this.extractAllTxtFilesMess.Location = new System.Drawing.Point(3, 131);
            this.extractAllTxtFilesMess.Name = "extractAllTxtFilesMess";
            this.extractAllTxtFilesMess.Size = new System.Drawing.Size(507, 32);
            this.extractAllTxtFilesMess.TabIndex = 7;
            this.extractAllTxtFilesMess.Text = "Extract all TXT files";
            this.extractAllTxtFilesMess.UseVisualStyleBackColor = true;
            this.extractAllTxtFilesMess.Click += new System.EventHandler(this.extractAllTxtFilesMess_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 45);
            this.panel2.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.helpMess);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(399, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(108, 45);
            this.panel5.TabIndex = 0;
            // 
            // helpMess
            // 
            this.helpMess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helpMess.Location = new System.Drawing.Point(0, 10);
            this.helpMess.Name = "helpMess";
            this.helpMess.Size = new System.Drawing.Size(108, 35);
            this.helpMess.TabIndex = 0;
            this.helpMess.Text = "Help";
            this.helpMess.UseVisualStyleBackColor = true;
            this.helpMess.Click += new System.EventHandler(this.helpMess_Click);
            // 
            // saveTxtMess
            // 
            this.saveTxtMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveTxtMess.Enabled = false;
            this.saveTxtMess.Location = new System.Drawing.Point(3, 99);
            this.saveTxtMess.Name = "saveTxtMess";
            this.saveTxtMess.Size = new System.Drawing.Size(507, 32);
            this.saveTxtMess.TabIndex = 5;
            this.saveTxtMess.Text = "Save TXT File";
            this.saveTxtMess.UseVisualStyleBackColor = true;
            this.saveTxtMess.Click += new System.EventHandler(this.saveTxtMess_Click);
            // 
            // saveBinMess
            // 
            this.saveBinMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveBinMess.Enabled = false;
            this.saveBinMess.Location = new System.Drawing.Point(3, 67);
            this.saveBinMess.Name = "saveBinMess";
            this.saveBinMess.Size = new System.Drawing.Size(507, 32);
            this.saveBinMess.TabIndex = 4;
            this.saveBinMess.Text = "Save BIN File";
            this.saveBinMess.UseVisualStyleBackColor = true;
            this.saveBinMess.Click += new System.EventHandler(this.saveBinMess_Click);
            // 
            // openTxtMess
            // 
            this.openTxtMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTxtMess.Enabled = false;
            this.openTxtMess.Location = new System.Drawing.Point(3, 35);
            this.openTxtMess.Name = "openTxtMess";
            this.openTxtMess.Size = new System.Drawing.Size(507, 32);
            this.openTxtMess.TabIndex = 3;
            this.openTxtMess.Text = "Open TXT file";
            this.openTxtMess.UseVisualStyleBackColor = true;
            this.openTxtMess.Click += new System.EventHandler(this.openTxtMess_Click);
            // 
            // openBinMess
            // 
            this.openBinMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openBinMess.Enabled = false;
            this.openBinMess.Location = new System.Drawing.Point(3, 3);
            this.openBinMess.Name = "openBinMess";
            this.openBinMess.Size = new System.Drawing.Size(507, 32);
            this.openBinMess.TabIndex = 0;
            this.openBinMess.Text = "Open BIN file";
            this.openBinMess.UseVisualStyleBackColor = true;
            this.openBinMess.Click += new System.EventHandler(this.openBinMess_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.saveTxtItems);
            this.tabPage2.Controls.Add(this.saveBinItems);
            this.tabPage2.Controls.Add(this.openTxtItems);
            this.tabPage2.Controls.Add(this.openBinItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(513, 290);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(507, 156);
            this.panel3.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.helpItems);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(399, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(108, 156);
            this.panel6.TabIndex = 0;
            // 
            // helpItems
            // 
            this.helpItems.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helpItems.Location = new System.Drawing.Point(0, 121);
            this.helpItems.Name = "helpItems";
            this.helpItems.Size = new System.Drawing.Size(108, 35);
            this.helpItems.TabIndex = 0;
            this.helpItems.Text = "Help";
            this.helpItems.UseVisualStyleBackColor = true;
            this.helpItems.Click += new System.EventHandler(this.helpItems_Click);
            // 
            // saveTxtItems
            // 
            this.saveTxtItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveTxtItems.Enabled = false;
            this.saveTxtItems.Location = new System.Drawing.Point(3, 99);
            this.saveTxtItems.Name = "saveTxtItems";
            this.saveTxtItems.Size = new System.Drawing.Size(507, 32);
            this.saveTxtItems.TabIndex = 9;
            this.saveTxtItems.Text = "Save TXT File";
            this.saveTxtItems.UseVisualStyleBackColor = true;
            this.saveTxtItems.Click += new System.EventHandler(this.saveTxtItems_Click);
            // 
            // saveBinItems
            // 
            this.saveBinItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveBinItems.Enabled = false;
            this.saveBinItems.Location = new System.Drawing.Point(3, 67);
            this.saveBinItems.Name = "saveBinItems";
            this.saveBinItems.Size = new System.Drawing.Size(507, 32);
            this.saveBinItems.TabIndex = 8;
            this.saveBinItems.Text = "Generate BIN File";
            this.saveBinItems.UseVisualStyleBackColor = true;
            this.saveBinItems.Click += new System.EventHandler(this.saveBinItems_Click);
            // 
            // openTxtItems
            // 
            this.openTxtItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTxtItems.Enabled = false;
            this.openTxtItems.Location = new System.Drawing.Point(3, 35);
            this.openTxtItems.Name = "openTxtItems";
            this.openTxtItems.Size = new System.Drawing.Size(507, 32);
            this.openTxtItems.TabIndex = 7;
            this.openTxtItems.Text = "Open TXT file";
            this.openTxtItems.UseVisualStyleBackColor = true;
            this.openTxtItems.Click += new System.EventHandler(this.openTxtItems_Click);
            // 
            // openBinItems
            // 
            this.openBinItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.openBinItems.Enabled = false;
            this.openBinItems.Location = new System.Drawing.Point(3, 3);
            this.openBinItems.Name = "openBinItems";
            this.openBinItems.Size = new System.Drawing.Size(507, 32);
            this.openBinItems.TabIndex = 6;
            this.openBinItems.Text = "Open BIN file";
            this.openBinItems.UseVisualStyleBackColor = true;
            this.openBinItems.Click += new System.EventHandler(this.openBinItems_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Controls.Add(this.saveTxtSysMess);
            this.tabPage3.Controls.Add(this.saveBinSysMess);
            this.tabPage3.Controls.Add(this.openTxtSysMess);
            this.tabPage3.Controls.Add(this.openBinSysMess);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(513, 290);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "SysMess";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 128);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(513, 162);
            this.panel4.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.helpSysMess);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(404, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(109, 162);
            this.panel7.TabIndex = 0;
            // 
            // helpSysMess
            // 
            this.helpSysMess.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.helpSysMess.Location = new System.Drawing.Point(0, 127);
            this.helpSysMess.Name = "helpSysMess";
            this.helpSysMess.Size = new System.Drawing.Size(109, 35);
            this.helpSysMess.TabIndex = 1;
            this.helpSysMess.Text = "Help";
            this.helpSysMess.UseVisualStyleBackColor = true;
            this.helpSysMess.Click += new System.EventHandler(this.helpSysMess_Click);
            // 
            // saveTxtSysMess
            // 
            this.saveTxtSysMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveTxtSysMess.Enabled = false;
            this.saveTxtSysMess.Location = new System.Drawing.Point(0, 96);
            this.saveTxtSysMess.Name = "saveTxtSysMess";
            this.saveTxtSysMess.Size = new System.Drawing.Size(513, 32);
            this.saveTxtSysMess.TabIndex = 13;
            this.saveTxtSysMess.Text = "Save TXT File";
            this.saveTxtSysMess.UseVisualStyleBackColor = true;
            this.saveTxtSysMess.Click += new System.EventHandler(this.saveTxtSystemMess_Click);
            // 
            // saveBinSysMess
            // 
            this.saveBinSysMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveBinSysMess.Enabled = false;
            this.saveBinSysMess.Location = new System.Drawing.Point(0, 64);
            this.saveBinSysMess.Name = "saveBinSysMess";
            this.saveBinSysMess.Size = new System.Drawing.Size(513, 32);
            this.saveBinSysMess.TabIndex = 12;
            this.saveBinSysMess.Text = "Generate BIN File";
            this.saveBinSysMess.UseVisualStyleBackColor = true;
            this.saveBinSysMess.Click += new System.EventHandler(this.saveBinSystemMess_Click);
            // 
            // openTxtSysMess
            // 
            this.openTxtSysMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTxtSysMess.Enabled = false;
            this.openTxtSysMess.Location = new System.Drawing.Point(0, 32);
            this.openTxtSysMess.Name = "openTxtSysMess";
            this.openTxtSysMess.Size = new System.Drawing.Size(513, 32);
            this.openTxtSysMess.TabIndex = 11;
            this.openTxtSysMess.Text = "Open TXT file";
            this.openTxtSysMess.UseVisualStyleBackColor = true;
            this.openTxtSysMess.Click += new System.EventHandler(this.openTxtSystemMess_Click);
            // 
            // openBinSysMess
            // 
            this.openBinSysMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openBinSysMess.Enabled = false;
            this.openBinSysMess.Location = new System.Drawing.Point(0, 0);
            this.openBinSysMess.Name = "openBinSysMess";
            this.openBinSysMess.Size = new System.Drawing.Size(513, 32);
            this.openBinSysMess.TabIndex = 10;
            this.openBinSysMess.Text = "Open BIN file";
            this.openBinSysMess.UseVisualStyleBackColor = true;
            this.openBinSysMess.Click += new System.EventHandler(this.openBinSystemMess_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(513, 290);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "CityMess";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.generateAllBinCityMess);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.extractAllTxtCityMess);
            this.panel8.Controls.Add(this.saveTxtCityMess);
            this.panel8.Controls.Add(this.saveBinCityMess);
            this.panel8.Controls.Add(this.openTxtCityMess);
            this.panel8.Controls.Add(this.openBinCityMess);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(513, 290);
            this.panel8.TabIndex = 7;
            // 
            // generateAllBinCityMess
            // 
            this.generateAllBinCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.generateAllBinCityMess.Enabled = false;
            this.generateAllBinCityMess.Location = new System.Drawing.Point(0, 160);
            this.generateAllBinCityMess.Name = "generateAllBinCityMess";
            this.generateAllBinCityMess.Size = new System.Drawing.Size(513, 32);
            this.generateAllBinCityMess.TabIndex = 14;
            this.generateAllBinCityMess.Text = "Generate all BIN files";
            this.generateAllBinCityMess.UseVisualStyleBackColor = true;
            this.generateAllBinCityMess.Click += new System.EventHandler(this.generateAllBinCityMess_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 160);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(513, 130);
            this.panel9.TabIndex = 13;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button6);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(405, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(108, 130);
            this.panel10.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button6.Location = new System.Drawing.Point(0, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 35);
            this.button6.TabIndex = 0;
            this.button6.Text = "Help";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // extractAllTxtCityMess
            // 
            this.extractAllTxtCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.extractAllTxtCityMess.Enabled = false;
            this.extractAllTxtCityMess.Location = new System.Drawing.Point(0, 128);
            this.extractAllTxtCityMess.Name = "extractAllTxtCityMess";
            this.extractAllTxtCityMess.Size = new System.Drawing.Size(513, 32);
            this.extractAllTxtCityMess.TabIndex = 12;
            this.extractAllTxtCityMess.Text = "Extract all TXT files";
            this.extractAllTxtCityMess.UseVisualStyleBackColor = true;
            this.extractAllTxtCityMess.Click += new System.EventHandler(this.extractAllTxtFilesCityMess_Click);
            // 
            // saveTxtCityMess
            // 
            this.saveTxtCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveTxtCityMess.Enabled = false;
            this.saveTxtCityMess.Location = new System.Drawing.Point(0, 96);
            this.saveTxtCityMess.Name = "saveTxtCityMess";
            this.saveTxtCityMess.Size = new System.Drawing.Size(513, 32);
            this.saveTxtCityMess.TabIndex = 11;
            this.saveTxtCityMess.Text = "Save TXT File";
            this.saveTxtCityMess.UseVisualStyleBackColor = true;
            this.saveTxtCityMess.Click += new System.EventHandler(this.saveTxtCityMess_Click);
            // 
            // saveBinCityMess
            // 
            this.saveBinCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveBinCityMess.Enabled = false;
            this.saveBinCityMess.Location = new System.Drawing.Point(0, 64);
            this.saveBinCityMess.Name = "saveBinCityMess";
            this.saveBinCityMess.Size = new System.Drawing.Size(513, 32);
            this.saveBinCityMess.TabIndex = 10;
            this.saveBinCityMess.Text = "Generate BIN File";
            this.saveBinCityMess.UseVisualStyleBackColor = true;
            this.saveBinCityMess.Click += new System.EventHandler(this.saveBinCityMess_Click);
            // 
            // openTxtCityMess
            // 
            this.openTxtCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openTxtCityMess.Enabled = false;
            this.openTxtCityMess.Location = new System.Drawing.Point(0, 32);
            this.openTxtCityMess.Name = "openTxtCityMess";
            this.openTxtCityMess.Size = new System.Drawing.Size(513, 32);
            this.openTxtCityMess.TabIndex = 9;
            this.openTxtCityMess.Text = "Open TXT file";
            this.openTxtCityMess.UseVisualStyleBackColor = true;
            this.openTxtCityMess.Click += new System.EventHandler(this.openTxtCityMess_Click);
            // 
            // openBinCityMess
            // 
            this.openBinCityMess.Dock = System.Windows.Forms.DockStyle.Top;
            this.openBinCityMess.Enabled = false;
            this.openBinCityMess.Location = new System.Drawing.Point(0, 0);
            this.openBinCityMess.Name = "openBinCityMess";
            this.openBinCityMess.Size = new System.Drawing.Size(513, 32);
            this.openBinCityMess.TabIndex = 8;
            this.openBinCityMess.Text = "Open BIN file";
            this.openBinCityMess.UseVisualStyleBackColor = true;
            this.openBinCityMess.Click += new System.EventHandler(this.openBinCityMess_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.dw2Name);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(521, 47);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 12, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imagen DW2:";
            // 
            // dw2Name
            // 
            this.dw2Name.Location = new System.Drawing.Point(104, 10);
            this.dw2Name.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dw2Name.MaxLength = 250;
            this.dw2Name.Name = "dw2Name";
            this.dw2Name.Size = new System.Drawing.Size(300, 22);
            this.dw2Name.TabIndex = 1;
            // 
            // DW2_Extractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 386);
            this.Controls.Add(this.tabPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DW2_Extractor";
            this.Text = "DW2_Extractor";
            this.panel1.ResumeLayout(false);
            this.tabPanel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openTblExtraction;
        private System.Windows.Forms.Button openTblInsertion;
        private System.Windows.Forms.TabControl tabPanel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button saveBinMess;
        private System.Windows.Forms.Button openTxtMess;
        private System.Windows.Forms.Button openBinMess;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button saveTxtMess;
        private System.Windows.Forms.Button saveTxtItems;
        private System.Windows.Forms.Button saveBinItems;
        private System.Windows.Forms.Button openTxtItems;
        private System.Windows.Forms.Button openBinItems;
        private System.Windows.Forms.Button saveTxtSysMess;
        private System.Windows.Forms.Button saveBinSysMess;
        private System.Windows.Forms.Button openTxtSysMess;
        private System.Windows.Forms.Button openBinSysMess;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button helpMess;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button helpItems;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button helpSysMess;
        private System.Windows.Forms.Button extractAllTxtFilesMess;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button extractAllTxtCityMess;
        private System.Windows.Forms.Button saveTxtCityMess;
        private System.Windows.Forms.Button saveBinCityMess;
        private System.Windows.Forms.Button openTxtCityMess;
        private System.Windows.Forms.Button openBinCityMess;
        private System.Windows.Forms.Button generateAllBinDungMess;
        private System.Windows.Forms.Button generateAllBinCityMess;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dw2Name;

    }
}