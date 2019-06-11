namespace RegExGen
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
            this.tc_automata = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_ndfa = new System.Windows.Forms.Label();
            this.pb_ndfa = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pb_dfa = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pb_odfa = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_regex = new System.Windows.Forms.Label();
            this.tb_regex = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGramaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFromRegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFromRegexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAutomataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNVERTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.getWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getExcludedWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.difficultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extremeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_regular_lan_dfa = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_regular_lan_odfa = new System.Windows.Forms.Label();
            this.tc_automata.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_automata
            // 
            this.tc_automata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_automata.Controls.Add(this.tabPage1);
            this.tc_automata.Controls.Add(this.tabPage2);
            this.tc_automata.Controls.Add(this.tabPage3);
            this.tc_automata.Location = new System.Drawing.Point(4, 79);
            this.tc_automata.Margin = new System.Windows.Forms.Padding(4);
            this.tc_automata.Name = "tc_automata";
            this.tc_automata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tc_automata.SelectedIndex = 0;
            this.tc_automata.Size = new System.Drawing.Size(1432, 643);
            this.tc_automata.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.pb_ndfa);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1424, 614);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NDFA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_ndfa
            // 
            this.lb_regular_lan_ndfa.AutoSize = true;
            this.lb_regular_lan_ndfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_ndfa.Location = new System.Drawing.Point(5, 5);
            this.lb_regular_lan_ndfa.Name = "lb_regular_lan_ndfa";
            this.lb_regular_lan_ndfa.Size = new System.Drawing.Size(13, 20);
            this.lb_regular_lan_ndfa.TabIndex = 1;
            this.lb_regular_lan_ndfa.Text = ".";
            // 
            // pb_ndfa
            // 
            this.pb_ndfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ndfa.Location = new System.Drawing.Point(400, 0);
            this.pb_ndfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ndfa.Name = "pb_ndfa";
            this.pb_ndfa.Size = new System.Drawing.Size(985, 617);
            this.pb_ndfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ndfa.TabIndex = 0;
            this.pb_ndfa.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.pb_dfa);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1424, 614);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pb_dfa
            // 
            this.pb_dfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_dfa.Location = new System.Drawing.Point(400, 0);
            this.pb_dfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dfa.Name = "pb_dfa";
            this.pb_dfa.Size = new System.Drawing.Size(980, 613);
            this.pb_dfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dfa.TabIndex = 1;
            this.pb_dfa.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.pb_odfa);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1424, 614);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimized DFA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pb_odfa
            // 
            this.pb_odfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_odfa.Location = new System.Drawing.Point(400, 0);
            this.pb_odfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_odfa.Name = "pb_odfa";
            this.pb_odfa.Size = new System.Drawing.Size(974, 611);
            this.pb_odfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_odfa.TabIndex = 1;
            this.pb_odfa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regex:";
            // 
            // lb_regex
            // 
            this.lb_regex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regex.Location = new System.Drawing.Point(460, 48);
            this.lb_regex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_regex.Name = "lb_regex";
            this.lb_regex.Size = new System.Drawing.Size(960, 25);
            this.lb_regex.TabIndex = 3;
            this.lb_regex.Text = "...";
            this.lb_regex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_regex
            // 
            this.tb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_regex.Location = new System.Drawing.Point(105, 44);
            this.tb_regex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_regex.Name = "tb_regex";
            this.tb_regex.Size = new System.Drawing.Size(377, 27);
            this.tb_regex.TabIndex = 4;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(489, 44);
            this.btn_run.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 28);
            this.btn_run.TabIndex = 5;
            this.btn_run.Text = "run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // lb_status
            // 
            this.lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_status.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(5, 725);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(1428, 32);
            this.lb_status.TabIndex = 8;
            this.lb_status.Text = ".";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.automataToolStripMenuItem,
            this.regexToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.questionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1436, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.exportToolStripMenuItem,
            this.importGramaticaToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::RegExGen.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::RegExGen.Properties.Resources.load;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Image = global::RegExGen.Properties.Resources.export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.exportToolStripMenuItem.Text = "Export grammar";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // importGramaticaToolStripMenuItem
            // 
            this.importGramaticaToolStripMenuItem.Image = global::RegExGen.Properties.Resources.import;
            this.importGramaticaToolStripMenuItem.Name = "importGramaticaToolStripMenuItem";
            this.importGramaticaToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.importGramaticaToolStripMenuItem.Text = "Import grammar";
            this.importGramaticaToolStripMenuItem.Click += new System.EventHandler(this.importGramaticaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::RegExGen.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // automataToolStripMenuItem
            // 
            this.automataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem,
            this.toolStripSeparator1,
            this.aDDToolStripMenuItem,
            this.oRToolStripMenuItem,
            this.iNVERTToolStripMenuItem,
            this.nOTToolStripMenuItem});
            this.automataToolStripMenuItem.Name = "automataToolStripMenuItem";
            this.automataToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.automataToolStripMenuItem.Text = "Automata";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Image = global::RegExGen.Properties.Resources.create;
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewFromRegexToolStripMenuItem,
            this.loadToolStripMenuItem1});
            this.aDDToolStripMenuItem.Image = global::RegExGen.Properties.Resources.and;
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.aDDToolStripMenuItem.Text = "AND";
            // 
            // createNewFromRegexToolStripMenuItem
            // 
            this.createNewFromRegexToolStripMenuItem.Image = global::RegExGen.Properties.Resources.create;
            this.createNewFromRegexToolStripMenuItem.Name = "createNewFromRegexToolStripMenuItem";
            this.createNewFromRegexToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.createNewFromRegexToolStripMenuItem.Text = "Create new from regex";
            this.createNewFromRegexToolStripMenuItem.Click += new System.EventHandler(this.createNewFromRegexToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Image = global::RegExGen.Properties.Resources.import;
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(235, 26);
            this.loadToolStripMenuItem1.Text = "Import automata";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // oRToolStripMenuItem
            // 
            this.oRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewFromRegexToolStripMenuItem1,
            this.loadAutomataToolStripMenuItem});
            this.oRToolStripMenuItem.Image = global::RegExGen.Properties.Resources.or;
            this.oRToolStripMenuItem.Name = "oRToolStripMenuItem";
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.oRToolStripMenuItem.Text = "OR";
            // 
            // createNewFromRegexToolStripMenuItem1
            // 
            this.createNewFromRegexToolStripMenuItem1.Image = global::RegExGen.Properties.Resources.create;
            this.createNewFromRegexToolStripMenuItem1.Name = "createNewFromRegexToolStripMenuItem1";
            this.createNewFromRegexToolStripMenuItem1.Size = new System.Drawing.Size(235, 26);
            this.createNewFromRegexToolStripMenuItem1.Text = "Create new from regex";
            this.createNewFromRegexToolStripMenuItem1.Click += new System.EventHandler(this.createNewFromRegexToolStripMenuItem1_Click);
            // 
            // loadAutomataToolStripMenuItem
            // 
            this.loadAutomataToolStripMenuItem.Image = global::RegExGen.Properties.Resources.import;
            this.loadAutomataToolStripMenuItem.Name = "loadAutomataToolStripMenuItem";
            this.loadAutomataToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.loadAutomataToolStripMenuItem.Text = "Import automata";
            this.loadAutomataToolStripMenuItem.Click += new System.EventHandler(this.loadAutomataToolStripMenuItem_Click);
            // 
            // iNVERTToolStripMenuItem
            // 
            this.iNVERTToolStripMenuItem.Image = global::RegExGen.Properties.Resources.inverse;
            this.iNVERTToolStripMenuItem.Name = "iNVERTToolStripMenuItem";
            this.iNVERTToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.iNVERTToolStripMenuItem.Text = "INVERT";
            this.iNVERTToolStripMenuItem.Click += new System.EventHandler(this.iNVERTToolStripMenuItem_Click);
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Image = global::RegExGen.Properties.Resources.exit;
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.nOTToolStripMenuItem_Click);
            // 
            // regexToolStripMenuItem
            // 
            this.regexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem2});
            this.regexToolStripMenuItem.Name = "regexToolStripMenuItem";
            this.regexToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.regexToolStripMenuItem.Text = "Regex";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Image = global::RegExGen.Properties.Resources.save;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(117, 26);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem2
            // 
            this.loadToolStripMenuItem2.Image = global::RegExGen.Properties.Resources.load;
            this.loadToolStripMenuItem2.Name = "loadToolStripMenuItem2";
            this.loadToolStripMenuItem2.Size = new System.Drawing.Size(117, 26);
            this.loadToolStripMenuItem2.Text = "Load";
            this.loadToolStripMenuItem2.Click += new System.EventHandler(this.loadToolStripMenuItem2_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkWordToolStripMenuItem,
            this.toolStripSeparator4,
            this.getWordsToolStripMenuItem,
            this.getExcludedWordsToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // checkWordToolStripMenuItem
            // 
            this.checkWordToolStripMenuItem.Image = global::RegExGen.Properties.Resources.check;
            this.checkWordToolStripMenuItem.Name = "checkWordToolStripMenuItem";
            this.checkWordToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.checkWordToolStripMenuItem.Text = "Check word";
            this.checkWordToolStripMenuItem.Click += new System.EventHandler(this.checkWordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(212, 6);
            // 
            // getWordsToolStripMenuItem
            // 
            this.getWordsToolStripMenuItem.Image = global::RegExGen.Properties.Resources.list;
            this.getWordsToolStripMenuItem.Name = "getWordsToolStripMenuItem";
            this.getWordsToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.getWordsToolStripMenuItem.Text = "Get words";
            this.getWordsToolStripMenuItem.Click += new System.EventHandler(this.getWordsToolStripMenuItem_Click);
            // 
            // getExcludedWordsToolStripMenuItem
            // 
            this.getExcludedWordsToolStripMenuItem.Image = global::RegExGen.Properties.Resources.exlc_list;
            this.getExcludedWordsToolStripMenuItem.Name = "getExcludedWordsToolStripMenuItem";
            this.getExcludedWordsToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.getExcludedWordsToolStripMenuItem.Text = "Get excluded words";
            this.getExcludedWordsToolStripMenuItem.Click += new System.EventHandler(this.getExcludedWordsToolStripMenuItem_Click);
            // 
            // questionsToolStripMenuItem
            // 
            this.questionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.normalToolStripMenuItem,
            this.difficultToolStripMenuItem,
            this.extremeToolStripMenuItem});
            this.questionsToolStripMenuItem.Name = "questionsToolStripMenuItem";
            this.questionsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.questionsToolStripMenuItem.Text = "Questions";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Image = global::RegExGen.Properties.Resources.flag_1;
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.easyToolStripMenuItem.Text = "Easy";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.easyToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Image = global::RegExGen.Properties.Resources.flag_2;
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // difficultToolStripMenuItem
            // 
            this.difficultToolStripMenuItem.Image = global::RegExGen.Properties.Resources.flag_3;
            this.difficultToolStripMenuItem.Name = "difficultToolStripMenuItem";
            this.difficultToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.difficultToolStripMenuItem.Text = "Difficult";
            this.difficultToolStripMenuItem.Click += new System.EventHandler(this.difficultToolStripMenuItem_Click);
            // 
            // extremeToolStripMenuItem
            // 
            this.extremeToolStripMenuItem.Image = global::RegExGen.Properties.Resources.flag_4;
            this.extremeToolStripMenuItem.Name = "extremeToolStripMenuItem";
            this.extremeToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
            this.extremeToolStripMenuItem.Text = "Extreme";
            this.extremeToolStripMenuItem.Click += new System.EventHandler(this.extremeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_regular_lan_ndfa);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 619);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lb_regular_lan_dfa);
            this.panel2.Location = new System.Drawing.Point(-1, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 619);
            this.panel2.TabIndex = 3;
            // 
            // lb_regular_lan_dfa
            // 
            this.lb_regular_lan_dfa.AutoSize = true;
            this.lb_regular_lan_dfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_dfa.Location = new System.Drawing.Point(5, 5);
            this.lb_regular_lan_dfa.Name = "lb_regular_lan_dfa";
            this.lb_regular_lan_dfa.Size = new System.Drawing.Size(13, 20);
            this.lb_regular_lan_dfa.TabIndex = 1;
            this.lb_regular_lan_dfa.Text = ".";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.AutoScroll = true;
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lb_regular_lan_odfa);
            this.panel3.Location = new System.Drawing.Point(-1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 619);
            this.panel3.TabIndex = 4;
            // 
            // lb_regular_lan_odfa
            // 
            this.lb_regular_lan_odfa.AutoSize = true;
            this.lb_regular_lan_odfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_odfa.Location = new System.Drawing.Point(5, 5);
            this.lb_regular_lan_odfa.Name = "lb_regular_lan_odfa";
            this.lb_regular_lan_odfa.Size = new System.Drawing.Size(13, 20);
            this.lb_regular_lan_odfa.TabIndex = 1;
            this.lb_regular_lan_odfa.Text = ".";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 762);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tb_regex);
            this.Controls.Add(this.lb_regex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tc_automata);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Formele methodes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tc_automata.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_ndfa;
        private System.Windows.Forms.TabControl tc_automata;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pb_odfa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_regex;
        private System.Windows.Forms.Label lb_regular_lan_ndfa;
        private System.Windows.Forms.TextBox tb_regex;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.PictureBox pb_dfa;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGramaticaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nOTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNVERTToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createNewFromRegexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createNewFromRegexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadAutomataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem getWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getExcludedWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem difficultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extremeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_regular_lan_dfa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_regular_lan_odfa;
    }
}

