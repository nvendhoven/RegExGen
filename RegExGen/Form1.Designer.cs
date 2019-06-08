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
            this.pb_ndfa = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_ndfa = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_dfa = new System.Windows.Forms.Label();
            this.pb_dfa = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lb_regular_lan_odfa = new System.Windows.Forms.Label();
            this.pb_odfa = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_regex = new System.Windows.Forms.Label();
            this.tb_regex = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.btn_import_language = new System.Windows.Forms.Button();
            this.btn_import_regex = new System.Windows.Forms.Button();
            this.lb_status = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb_ndfa
            // 
            this.pb_ndfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ndfa.Location = new System.Drawing.Point(230, 0);
            this.pb_ndfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ndfa.Name = "pb_ndfa";
            this.pb_ndfa.Size = new System.Drawing.Size(761, 480);
            this.pb_ndfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_ndfa.TabIndex = 0;
            this.pb_ndfa.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(998, 504);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb_regular_lan_ndfa);
            this.tabPage1.Controls.Add(this.pb_ndfa);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(990, 478);
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
            this.lb_regular_lan_ndfa.Size = new System.Drawing.Size(225, 453);
            this.lb_regular_lan_ndfa.TabIndex = 1;
            this.lb_regular_lan_ndfa.Text = ".";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(990, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_dfa
            // 
            this.lb_regular_lan_dfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_dfa.Location = new System.Drawing.Point(0, 0);
            this.lb_regular_lan_dfa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_regular_lan_dfa.Name = "lb_regular_lan_dfa";
            this.lb_regular_lan_dfa.Size = new System.Drawing.Size(331, 475);
            this.lb_regular_lan_dfa.TabIndex = 2;
            this.lb_regular_lan_dfa.Text = ".";
            // 
            // pb_dfa
            // 
            this.pb_dfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_dfa.Location = new System.Drawing.Point(0, 0);
            this.pb_dfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dfa.Name = "pb_dfa";
            this.pb_dfa.Size = new System.Drawing.Size(338, 475);
            this.pb_dfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dfa.TabIndex = 1;
            this.pb_dfa.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lb_regular_lan_odfa);
            this.tabPage3.Controls.Add(this.pb_odfa);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(990, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimized DFA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_odfa
            // 
            this.lb_regular_lan_odfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_odfa.Location = new System.Drawing.Point(2, 16);
            this.lb_regular_lan_odfa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_regular_lan_odfa.Name = "lb_regular_lan_odfa";
            this.lb_regular_lan_odfa.Size = new System.Drawing.Size(225, 454);
            this.lb_regular_lan_odfa.TabIndex = 2;
            this.lb_regular_lan_odfa.Text = ".";
            // 
            // pb_odfa
            // 
            this.pb_odfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_odfa.Location = new System.Drawing.Point(230, 0);
            this.pb_odfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_odfa.Name = "pb_odfa";
            this.pb_odfa.Size = new System.Drawing.Size(586, 469);
            this.pb_odfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_odfa.TabIndex = 1;
            this.pb_odfa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Regex:";
            // 
            // lb_regex
            // 
            this.lb_regex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regex.Location = new System.Drawing.Point(748, 25);
            this.lb_regex.Name = "lb_regex";
            this.lb_regex.Size = new System.Drawing.Size(243, 20);
            this.lb_regex.TabIndex = 3;
            this.lb_regex.Text = "...";
            this.lb_regex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_regex
            // 
            this.tb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_regex.Location = new System.Drawing.Point(91, 23);
            this.tb_regex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_regex.Name = "tb_regex";
            this.tb_regex.Size = new System.Drawing.Size(284, 23);
            this.tb_regex.TabIndex = 4;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(378, 23);
            this.btn_run.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(56, 23);
            this.btn_run.TabIndex = 5;
            this.btn_run.Text = "run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_import_language
            // 
            this.btn_import_language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_import_language.Location = new System.Drawing.Point(6, 569);
            this.btn_import_language.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_import_language.Name = "btn_import_language";
            this.btn_import_language.Size = new System.Drawing.Size(100, 23);
            this.btn_import_language.TabIndex = 6;
            this.btn_import_language.Text = "Import language";
            this.btn_import_language.UseVisualStyleBackColor = true;
            this.btn_import_language.Click += new System.EventHandler(this.btn_import_language_Click);
            // 
            // btn_import_regex
            // 
            this.btn_import_regex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_import_regex.Location = new System.Drawing.Point(110, 569);
            this.btn_import_regex.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_import_regex.Name = "btn_import_regex";
            this.btn_import_regex.Size = new System.Drawing.Size(100, 23);
            this.btn_import_regex.TabIndex = 7;
            this.btn_import_regex.Text = "Import regex";
            this.btn_import_regex.UseVisualStyleBackColor = true;
            // 
            // lb_status
            // 
            this.lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(502, 571);
            this.lb_status.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(496, 19);
            this.lb_status.TabIndex = 8;
            this.lb_status.Text = ".";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lb_regular_lan_dfa);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pb_dfa);
            this.splitContainer1.Size = new System.Drawing.Size(987, 475);
            this.splitContainer1.SplitterDistance = 645;
            this.splitContainer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 596);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_import_regex);
            this.Controls.Add(this.btn_import_language);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tb_regex);
            this.Controls.Add(this.lb_regex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Formele methodes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_ndfa;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pb_dfa;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pb_odfa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_regex;
        private System.Windows.Forms.Label lb_regular_lan_ndfa;
        private System.Windows.Forms.Label lb_regular_lan_dfa;
        private System.Windows.Forms.Label lb_regular_lan_odfa;
        private System.Windows.Forms.TextBox tb_regex;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.Button btn_import_language;
        private System.Windows.Forms.Button btn_import_regex;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

