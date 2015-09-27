namespace Automaton_GUI
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
            this.components = new System.ComponentModel.Container();
            this.pbxDraw = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbxFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tbxInput = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbxID = new System.Windows.Forms.TextBox();
            this.tbxConnectTo = new System.Windows.Forms.TextBox();
            this.tbxConnectWith = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblConnectTo = new System.Windows.Forms.Label();
            this.lblConnectWith = new System.Windows.Forms.Label();
            this.cbxDraw = new System.Windows.Forms.CheckBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.radioInitial = new System.Windows.Forms.RadioButton();
            this.radioInter = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbxDraw = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveJPGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStep = new System.Windows.Forms.Button();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxDrawName = new System.Windows.Forms.TextBox();
            this.cbxFinal = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.cbxRegEx = new System.Windows.Forms.CheckBox();
            this.tbxRegEx = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDraw)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxDraw
            // 
            this.pbxDraw.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pbxDraw.Location = new System.Drawing.Point(174, 0);
            this.pbxDraw.Name = "pbxDraw";
            this.pbxDraw.Size = new System.Drawing.Size(707, 627);
            this.pbxDraw.TabIndex = 0;
            this.pbxDraw.TabStop = false;
            this.pbxDraw.DoubleClick += new System.EventHandler(this.pbxDraw_DoubleClick);
            this.pbxDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxDraw_MouseDown);
            this.pbxDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxDraw_MouseMove);
            this.pbxDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxDraw_MouseUp);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(19, 39);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(61, 28);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(15, 125);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbxFile.Size = new System.Drawing.Size(153, 20);
            this.tbxFile.TabIndex = 2;
            this.tbxFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxFile_KeyDown);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(16, 109);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(51, 13);
            this.lblFile.TabIndex = 3;
            this.lblFile.Text = "XML File:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // tbxInput
            // 
            this.tbxInput.Location = new System.Drawing.Point(12, 174);
            this.tbxInput.Name = "tbxInput";
            this.tbxInput.Size = new System.Drawing.Size(156, 20);
            this.tbxInput.TabIndex = 5;
            this.tbxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxInput_KeyDown);
            // 
            // btnRun
            // 
            this.btnRun.Enabled = false;
            this.btnRun.Location = new System.Drawing.Point(12, 206);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Run Input";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(16, 155);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(88, 13);
            this.lblInput.TabIndex = 7;
            this.lblInput.Text = "Input Expression:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add State";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbxID
            // 
            this.tbxID.Enabled = false;
            this.tbxID.Location = new System.Drawing.Point(86, 328);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(75, 20);
            this.tbxID.TabIndex = 9;
            // 
            // tbxConnectTo
            // 
            this.tbxConnectTo.Enabled = false;
            this.tbxConnectTo.Location = new System.Drawing.Point(86, 380);
            this.tbxConnectTo.Name = "tbxConnectTo";
            this.tbxConnectTo.Size = new System.Drawing.Size(75, 20);
            this.tbxConnectTo.TabIndex = 10;
            this.tbxConnectTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxConnectTo_KeyDown);
            this.tbxConnectTo.Leave += new System.EventHandler(this.tbxConnectTo_Leave);
            // 
            // tbxConnectWith
            // 
            this.tbxConnectWith.Enabled = false;
            this.tbxConnectWith.Location = new System.Drawing.Point(86, 406);
            this.tbxConnectWith.Name = "tbxConnectWith";
            this.tbxConnectWith.Size = new System.Drawing.Size(75, 20);
            this.tbxConnectWith.TabIndex = 11;
            this.tbxConnectWith.Enter += new System.EventHandler(this.tbxConnectWith_Enter);
            this.tbxConnectWith.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxConnectWith_KeyDown);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(16, 331);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 12;
            this.lblID.Text = "ID:";
            // 
            // lblConnectTo
            // 
            this.lblConnectTo.AutoSize = true;
            this.lblConnectTo.Location = new System.Drawing.Point(8, 383);
            this.lblConnectTo.Name = "lblConnectTo";
            this.lblConnectTo.Size = new System.Drawing.Size(66, 13);
            this.lblConnectTo.TabIndex = 13;
            this.lblConnectTo.Text = "Connect To:";
            // 
            // lblConnectWith
            // 
            this.lblConnectWith.AutoSize = true;
            this.lblConnectWith.Location = new System.Drawing.Point(8, 409);
            this.lblConnectWith.Name = "lblConnectWith";
            this.lblConnectWith.Size = new System.Drawing.Size(75, 13);
            this.lblConnectWith.TabIndex = 14;
            this.lblConnectWith.Text = "Connect With:";
            // 
            // cbxDraw
            // 
            this.cbxDraw.AutoSize = true;
            this.cbxDraw.Enabled = false;
            this.cbxDraw.Location = new System.Drawing.Point(18, 533);
            this.cbxDraw.Name = "cbxDraw";
            this.cbxDraw.Size = new System.Drawing.Size(105, 17);
            this.cbxDraw.TabIndex = 15;
            this.cbxDraw.Text = "Draw Transitions";
            this.cbxDraw.UseVisualStyleBackColor = true;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.Location = new System.Drawing.Point(12, 305);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(110, 13);
            this.lblSelected.TabIndex = 16;
            this.lblSelected.Text = "Selected State (Blue):";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(16, 502);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 25);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update Selected State";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(18, 73);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(62, 23);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // radioInitial
            // 
            this.radioInitial.AutoSize = true;
            this.radioInitial.Location = new System.Drawing.Point(86, 433);
            this.radioInitial.Name = "radioInitial";
            this.radioInitial.Size = new System.Drawing.Size(49, 17);
            this.radioInitial.TabIndex = 19;
            this.radioInitial.TabStop = true;
            this.radioInitial.Text = "Initial";
            this.radioInitial.UseVisualStyleBackColor = true;
            this.radioInitial.Click += new System.EventHandler(this.radioInitial_Click);
            // 
            // radioInter
            // 
            this.radioInter.AutoSize = true;
            this.radioInter.Location = new System.Drawing.Point(85, 456);
            this.radioInter.Name = "radioInter";
            this.radioInter.Size = new System.Drawing.Size(83, 17);
            this.radioInter.TabIndex = 20;
            this.radioInter.TabStop = true;
            this.radioInter.Text = "Intermediate";
            this.radioInter.UseVisualStyleBackColor = true;
            this.radioInter.Click += new System.EventHandler(this.radioInter_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(86, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 28);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(93, 234);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete State";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbxDraw
            // 
            this.tbxDraw.Location = new System.Drawing.Point(263, 49);
            this.tbxDraw.Name = "tbxDraw";
            this.tbxDraw.Size = new System.Drawing.Size(30, 20);
            this.tbxDraw.TabIndex = 26;
            this.tbxDraw.Visible = false;
            this.tbxDraw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDraw_KeyDown);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(86, 73);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(62, 23);
            this.btnHelp.TabIndex = 27;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(9, 431);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 28;
            this.lblCategory.Text = "Category:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(881, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.SaveJPGToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // SaveJPGToolStripMenuItem
            // 
            this.SaveJPGToolStripMenuItem.Name = "SaveJPGToolStripMenuItem";
            this.SaveJPGToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.SaveJPGToolStripMenuItem.Text = "Save As JPG";
            this.SaveJPGToolStripMenuItem.Click += new System.EventHandler(this.SaveJPGToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runInputToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.runTestsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // runInputToolStripMenuItem
            // 
            this.runInputToolStripMenuItem.Name = "runInputToolStripMenuItem";
            this.runInputToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.runInputToolStripMenuItem.Text = "Run Input";
            this.runInputToolStripMenuItem.Click += new System.EventHandler(this.runInputToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // runTestsToolStripMenuItem
            // 
            this.runTestsToolStripMenuItem.Name = "runTestsToolStripMenuItem";
            this.runTestsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.runTestsToolStripMenuItem.Text = "Run Tests";
            this.runTestsToolStripMenuItem.Click += new System.EventHandler(this.runTestsToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(126, 301);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(35, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStep
            // 
            this.btnStep.Location = new System.Drawing.Point(93, 205);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 23);
            this.btnStep.TabIndex = 31;
            this.btnStep.Text = "Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // tbxName
            // 
            this.tbxName.Enabled = false;
            this.tbxName.Location = new System.Drawing.Point(86, 354);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(75, 20);
            this.tbxName.TabIndex = 32;
            this.tbxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxName_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 357);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 33;
            this.lblName.Text = "Name:";
            // 
            // tbxDrawName
            // 
            this.tbxDrawName.Location = new System.Drawing.Point(345, 530);
            this.tbxDrawName.Name = "tbxDrawName";
            this.tbxDrawName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbxDrawName.Size = new System.Drawing.Size(17, 20);
            this.tbxDrawName.TabIndex = 34;
            this.tbxDrawName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxDrawName_KeyDown);
            // 
            // cbxFinal
            // 
            this.cbxFinal.AutoSize = true;
            this.cbxFinal.Location = new System.Drawing.Point(85, 479);
            this.cbxFinal.Name = "cbxFinal";
            this.cbxFinal.Size = new System.Drawing.Size(48, 17);
            this.cbxFinal.TabIndex = 35;
            this.cbxFinal.Text = "Final";
            this.cbxFinal.UseVisualStyleBackColor = true;
            this.cbxFinal.CheckedChanged += new System.EventHandler(this.cbxFinal_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 556);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(134, 45);
            this.trackBar1.TabIndex = 36;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // cbxRegEx
            // 
            this.cbxRegEx.AutoSize = true;
            this.cbxRegEx.Location = new System.Drawing.Point(19, 266);
            this.cbxRegEx.Name = "cbxRegEx";
            this.cbxRegEx.Size = new System.Drawing.Size(136, 17);
            this.cbxRegEx.TabIndex = 37;
            this.cbxRegEx.Text = "Regular Expression File";
            this.cbxRegEx.UseVisualStyleBackColor = true;
            // 
            // tbxRegEx
            // 
            this.tbxRegEx.Location = new System.Drawing.Point(11, 596);
            this.tbxRegEx.Name = "tbxRegEx";
            this.tbxRegEx.Size = new System.Drawing.Size(150, 20);
            this.tbxRegEx.TabIndex = 38;
            this.tbxRegEx.Text = "Input Regular Expression";
            this.tbxRegEx.Enter += new System.EventHandler(this.tbxRegEx_Enter);
            this.tbxRegEx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxRegEx_KeyDown);
            this.tbxRegEx.Leave += new System.EventHandler(this.tbxRegEx_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 628);
            this.Controls.Add(this.tbxRegEx);
            this.Controls.Add(this.cbxRegEx);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.cbxFinal);
            this.Controls.Add(this.tbxDrawName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbxDraw);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radioInter);
            this.Controls.Add(this.radioInitial);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.cbxDraw);
            this.Controls.Add(this.lblConnectWith);
            this.Controls.Add(this.lblConnectTo);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.tbxConnectWith);
            this.Controls.Add(this.tbxConnectTo);
            this.Controls.Add(this.tbxID);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tbxInput);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.pbxDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Automaton GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDraw)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxDraw;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbxFile;
        private System.Windows.Forms.Label lblFile;
        
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox tbxInput;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.TextBox tbxConnectTo;
        private System.Windows.Forms.TextBox tbxConnectWith;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblConnectTo;
        private System.Windows.Forms.Label lblConnectWith;
        private System.Windows.Forms.CheckBox cbxDraw;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton radioInitial;
        private System.Windows.Forms.RadioButton radioInter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbxDraw;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveJPGToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxDrawName;
        private System.Windows.Forms.CheckBox cbxFinal;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem runTestsToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxRegEx;
        private System.Windows.Forms.TextBox tbxRegEx;
    }
}

