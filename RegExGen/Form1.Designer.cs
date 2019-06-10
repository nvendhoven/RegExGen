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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_dfa = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_odfa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_regex = new System.Windows.Forms.Label();
            this.tb_regex = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.automataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.nOTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGramaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFromRegexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.oRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFromRegexToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadAutomataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNVERTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_ndfa = new System.Windows.Forms.PictureBox();
            this.pb_dfa = new System.Windows.Forms.PictureBox();
            this.pb_odfa = new System.Windows.Forms.PictureBox();
            this.tc_automata.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).BeginInit();
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
            this.tc_automata.Location = new System.Drawing.Point(3, 64);
            this.tc_automata.Name = "tc_automata";
            this.tc_automata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tc_automata.SelectedIndex = 0;
            this.tc_automata.Size = new System.Drawing.Size(1157, 649);
            this.tc_automata.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb_regular_lan_ndfa);
            this.tabPage1.Controls.Add(this.pb_ndfa);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1149, 623);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NDFA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_ndfa
            // 
            this.lb_regular_lan_ndfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_ndfa.Location = new System.Drawing.Point(3, 16);
            this.lb_regular_lan_ndfa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_regular_lan_ndfa.Name = "lb_regular_lan_ndfa";
            this.lb_regular_lan_ndfa.Size = new System.Drawing.Size(295, 596);
            this.lb_regular_lan_ndfa.TabIndex = 1;
            this.lb_regular_lan_ndfa.Text = ".";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_regular_lan_dfa);
            this.tabPage2.Controls.Add(this.pb_dfa);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1149, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_dfa
            // 
            this.lb_regular_lan_dfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_dfa.Location = new System.Drawing.Point(3, 14);
            this.lb_regular_lan_dfa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_regular_lan_dfa.Name = "lb_regular_lan_dfa";
            this.lb_regular_lan_dfa.Size = new System.Drawing.Size(295, 591);
            this.lb_regular_lan_dfa.TabIndex = 2;
            this.lb_regular_lan_dfa.Text = ".";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lb_regular_lan_odfa);
            this.tabPage3.Controls.Add(this.pb_odfa);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1149, 623);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimized DFA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_odfa
            // 
            this.lb_regular_lan_odfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_odfa.Location = new System.Drawing.Point(3, 16);
            this.lb_regular_lan_odfa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_regular_lan_odfa.Name = "lb_regular_lan_odfa";
            this.lb_regular_lan_odfa.Size = new System.Drawing.Size(295, 603);
            this.lb_regular_lan_odfa.TabIndex = 2;
            this.lb_regular_lan_odfa.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regex:";
            // 
            // lb_regex
            // 
            this.lb_regex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regex.Location = new System.Drawing.Point(428, 39);
            this.lb_regex.Name = "lb_regex";
            this.lb_regex.Size = new System.Drawing.Size(720, 20);
            this.lb_regex.TabIndex = 3;
            this.lb_regex.Text = "...";
            this.lb_regex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_regex
            // 
            this.tb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_regex.Location = new System.Drawing.Point(79, 36);
            this.tb_regex.Margin = new System.Windows.Forms.Padding(2);
            this.tb_regex.Name = "tb_regex";
            this.tb_regex.Size = new System.Drawing.Size(284, 23);
            this.tb_regex.TabIndex = 4;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(367, 36);
            this.btn_run.Margin = new System.Windows.Forms.Padding(2);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(56, 23);
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
            this.lb_status.Location = new System.Drawing.Point(4, 716);
            this.lb_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(1154, 26);
            this.lb_status.TabIndex = 8;
            this.lb_status.Text = ".";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.automataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1160, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripSeparator2,
            this.importGramaticaToolStripMenuItem,
            this.importRegexToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(159, 6);
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
            this.automataToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.automataToolStripMenuItem.Text = "Automata";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // nOTToolStripMenuItem
            // 
            this.nOTToolStripMenuItem.Image = global::RegExGen.Properties.Resources.exit;
            this.nOTToolStripMenuItem.Name = "nOTToolStripMenuItem";
            this.nOTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nOTToolStripMenuItem.Text = "NOT";
            this.nOTToolStripMenuItem.Click += new System.EventHandler(this.nOTToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::RegExGen.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = global::RegExGen.Properties.Resources.load;
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // importGramaticaToolStripMenuItem
            // 
            this.importGramaticaToolStripMenuItem.Image = global::RegExGen.Properties.Resources.import;
            this.importGramaticaToolStripMenuItem.Name = "importGramaticaToolStripMenuItem";
            this.importGramaticaToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importGramaticaToolStripMenuItem.Text = "Import grammar";
            this.importGramaticaToolStripMenuItem.Click += new System.EventHandler(this.importGramaticaToolStripMenuItem_Click);
            // 
            // importRegexToolStripMenuItem
            // 
            this.importRegexToolStripMenuItem.Image = global::RegExGen.Properties.Resources.import;
            this.importRegexToolStripMenuItem.Name = "importRegexToolStripMenuItem";
            this.importRegexToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.importRegexToolStripMenuItem.Text = "Import regex";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::RegExGen.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Image = global::RegExGen.Properties.Resources.create;
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // aDDToolStripMenuItem
            // 
            this.aDDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewFromRegexToolStripMenuItem,
            this.loadToolStripMenuItem1});
            this.aDDToolStripMenuItem.Image = global::RegExGen.Properties.Resources.and;
            this.aDDToolStripMenuItem.Name = "aDDToolStripMenuItem";
            this.aDDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aDDToolStripMenuItem.Text = "AND";
            // 
            // createNewFromRegexToolStripMenuItem
            // 
            this.createNewFromRegexToolStripMenuItem.Image = global::RegExGen.Properties.Resources.create;
            this.createNewFromRegexToolStripMenuItem.Name = "createNewFromRegexToolStripMenuItem";
            this.createNewFromRegexToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.createNewFromRegexToolStripMenuItem.Text = "Create new from regex";
            this.createNewFromRegexToolStripMenuItem.Click += new System.EventHandler(this.createNewFromRegexToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Image = global::RegExGen.Properties.Resources.import;
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
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
            this.oRToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.oRToolStripMenuItem.Text = "OR";
            // 
            // createNewFromRegexToolStripMenuItem1
            // 
            this.createNewFromRegexToolStripMenuItem1.Image = global::RegExGen.Properties.Resources.create;
            this.createNewFromRegexToolStripMenuItem1.Name = "createNewFromRegexToolStripMenuItem1";
            this.createNewFromRegexToolStripMenuItem1.Size = new System.Drawing.Size(193, 22);
            this.createNewFromRegexToolStripMenuItem1.Text = "Create new from regex";
            this.createNewFromRegexToolStripMenuItem1.Click += new System.EventHandler(this.createNewFromRegexToolStripMenuItem1_Click);
            // 
            // loadAutomataToolStripMenuItem
            // 
            this.loadAutomataToolStripMenuItem.Image = global::RegExGen.Properties.Resources.import;
            this.loadAutomataToolStripMenuItem.Name = "loadAutomataToolStripMenuItem";
            this.loadAutomataToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadAutomataToolStripMenuItem.Text = "Import automata";
            this.loadAutomataToolStripMenuItem.Click += new System.EventHandler(this.loadAutomataToolStripMenuItem_Click);
            // 
            // iNVERTToolStripMenuItem
            // 
            this.iNVERTToolStripMenuItem.Image = global::RegExGen.Properties.Resources.inverse;
            this.iNVERTToolStripMenuItem.Name = "iNVERTToolStripMenuItem";
            this.iNVERTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.iNVERTToolStripMenuItem.Text = "INVERT";
            this.iNVERTToolStripMenuItem.Click += new System.EventHandler(this.iNVERTToolStripMenuItem_Click);
            // 
            // pb_ndfa
            // 
            this.pb_ndfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ndfa.Location = new System.Drawing.Point(300, 0);
            this.pb_ndfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ndfa.Name = "pb_ndfa";
            this.pb_ndfa.Size = new System.Drawing.Size(822, 628);
            this.pb_ndfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ndfa.TabIndex = 0;
            this.pb_ndfa.TabStop = false;
            // 
            // pb_dfa
            // 
            this.pb_dfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_dfa.Location = new System.Drawing.Point(300, 0);
            this.pb_dfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dfa.Name = "pb_dfa";
            this.pb_dfa.Size = new System.Drawing.Size(818, 625);
            this.pb_dfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dfa.TabIndex = 1;
            this.pb_dfa.TabStop = false;
            // 
            // pb_odfa
            // 
            this.pb_odfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_odfa.Location = new System.Drawing.Point(300, 0);
            this.pb_odfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_odfa.Name = "pb_odfa";
            this.pb_odfa.Size = new System.Drawing.Size(814, 623);
            this.pb_odfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_odfa.TabIndex = 1;
            this.pb_odfa.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 746);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tb_regex);
            this.Controls.Add(this.lb_regex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tc_automata);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Formele methodes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tc_automata.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).EndInit();
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
        private System.Windows.Forms.Label lb_regular_lan_odfa;
        private System.Windows.Forms.TextBox tb_regex;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label lb_regular_lan_dfa;
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
        private System.Windows.Forms.ToolStripMenuItem importRegexToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createNewFromRegexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createNewFromRegexToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadAutomataToolStripMenuItem;
    }
}

