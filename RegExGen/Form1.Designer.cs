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
            ((System.ComponentModel.ISupportInitialize)(this.pb_ndfa)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_dfa)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_odfa)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_ndfa
            // 
            this.pb_ndfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_ndfa.Location = new System.Drawing.Point(307, 0);
            this.pb_ndfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ndfa.Name = "pb_ndfa";
            this.pb_ndfa.Size = new System.Drawing.Size(1015, 591);
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
            this.tabControl1.Location = new System.Drawing.Point(4, 73);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1330, 620);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lb_regular_lan_ndfa);
            this.tabPage1.Controls.Add(this.pb_ndfa);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1322, 591);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NDFA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_ndfa
            // 
            this.lb_regular_lan_ndfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_ndfa.Location = new System.Drawing.Point(4, 20);
            this.lb_regular_lan_ndfa.Name = "lb_regular_lan_ndfa";
            this.lb_regular_lan_ndfa.Size = new System.Drawing.Size(300, 557);
            this.lb_regular_lan_ndfa.TabIndex = 1;
            this.lb_regular_lan_ndfa.Text = ".";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lb_regular_lan_dfa);
            this.tabPage2.Controls.Add(this.pb_dfa);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1088, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_dfa
            // 
            this.lb_regular_lan_dfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_dfa.Location = new System.Drawing.Point(3, 21);
            this.lb_regular_lan_dfa.Name = "lb_regular_lan_dfa";
            this.lb_regular_lan_dfa.Size = new System.Drawing.Size(300, 552);
            this.lb_regular_lan_dfa.TabIndex = 2;
            this.lb_regular_lan_dfa.Text = ".";
            // 
            // pb_dfa
            // 
            this.pb_dfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_dfa.Location = new System.Drawing.Point(306, 0);
            this.pb_dfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dfa.Name = "pb_dfa";
            this.pb_dfa.Size = new System.Drawing.Size(782, 577);
            this.pb_dfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dfa.TabIndex = 1;
            this.pb_dfa.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lb_regular_lan_odfa);
            this.tabPage3.Controls.Add(this.pb_odfa);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1088, 577);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimized DFA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lb_regular_lan_odfa
            // 
            this.lb_regular_lan_odfa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regular_lan_odfa.Location = new System.Drawing.Point(3, 20);
            this.lb_regular_lan_odfa.Name = "lb_regular_lan_odfa";
            this.lb_regular_lan_odfa.Size = new System.Drawing.Size(300, 559);
            this.lb_regular_lan_odfa.TabIndex = 2;
            this.lb_regular_lan_odfa.Text = ".";
            // 
            // pb_odfa
            // 
            this.pb_odfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_odfa.Location = new System.Drawing.Point(306, 0);
            this.pb_odfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_odfa.Name = "pb_odfa";
            this.pb_odfa.Size = new System.Drawing.Size(782, 577);
            this.pb_odfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_odfa.TabIndex = 1;
            this.pb_odfa.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
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
            this.lb_regex.Location = new System.Drawing.Point(998, 31);
            this.lb_regex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_regex.Name = "lb_regex";
            this.lb_regex.Size = new System.Drawing.Size(324, 25);
            this.lb_regex.TabIndex = 3;
            this.lb_regex.Text = "...";
            this.lb_regex.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tb_regex
            // 
            this.tb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_regex.Location = new System.Drawing.Point(121, 28);
            this.tb_regex.Name = "tb_regex";
            this.tb_regex.Size = new System.Drawing.Size(377, 27);
            this.tb_regex.TabIndex = 4;
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(504, 28);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 28);
            this.btn_run.TabIndex = 5;
            this.btn_run.Text = "run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // btn_import_language
            // 
            this.btn_import_language.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_import_language.Location = new System.Drawing.Point(8, 700);
            this.btn_import_language.Name = "btn_import_language";
            this.btn_import_language.Size = new System.Drawing.Size(133, 28);
            this.btn_import_language.TabIndex = 6;
            this.btn_import_language.Text = "Import language";
            this.btn_import_language.UseVisualStyleBackColor = true;
            this.btn_import_language.Click += new System.EventHandler(this.btn_import_language_Click);
            // 
            // btn_import_regex
            // 
            this.btn_import_regex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_import_regex.Location = new System.Drawing.Point(147, 700);
            this.btn_import_regex.Name = "btn_import_regex";
            this.btn_import_regex.Size = new System.Drawing.Size(133, 28);
            this.btn_import_regex.TabIndex = 7;
            this.btn_import_regex.Text = "Import regex";
            this.btn_import_regex.UseVisualStyleBackColor = true;
            // 
            // lb_status
            // 
            this.lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.Location = new System.Drawing.Point(669, 703);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(661, 23);
            this.lb_status.TabIndex = 8;
            this.lb_status.Text = ".";
            this.lb_status.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 733);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.btn_import_regex);
            this.Controls.Add(this.btn_import_language);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.tb_regex);
            this.Controls.Add(this.lb_regex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

