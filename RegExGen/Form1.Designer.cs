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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pb_dfa = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pb_odfa = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_regex = new System.Windows.Forms.Label();
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
            this.pb_ndfa.Location = new System.Drawing.Point(0, 0);
            this.pb_ndfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ndfa.Name = "pb_ndfa";
            this.pb_ndfa.Size = new System.Drawing.Size(600, 300);
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
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(675, 420);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pb_ndfa);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(667, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NDFA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pb_dfa);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(667, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DFA";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pb_dfa
            // 
            this.pb_dfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_dfa.Location = new System.Drawing.Point(0, 0);
            this.pb_dfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_dfa.Name = "pb_dfa";
            this.pb_dfa.Size = new System.Drawing.Size(600, 300);
            this.pb_dfa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_dfa.TabIndex = 1;
            this.pb_dfa.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pb_odfa);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(667, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Optimized DFA";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pb_odfa
            // 
            this.pb_odfa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_odfa.Location = new System.Drawing.Point(0, 0);
            this.pb_odfa.Margin = new System.Windows.Forms.Padding(0);
            this.pb_odfa.Name = "pb_odfa";
            this.pb_odfa.Size = new System.Drawing.Size(600, 300);
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
            this.lb_regex.AutoSize = true;
            this.lb_regex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_regex.Location = new System.Drawing.Point(92, 22);
            this.lb_regex.Name = "lb_regex";
            this.lb_regex.Size = new System.Drawing.Size(21, 20);
            this.lb_regex.TabIndex = 3;
            this.lb_regex.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 480);
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
    }
}

