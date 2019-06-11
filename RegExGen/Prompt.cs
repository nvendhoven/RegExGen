using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExGen
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 30, Top = 20, Width = 440, Height= 60, Text = text };
            TextBox textBox = new TextBox() { Left = 30, Top = 50, Width = 430 };
            Button confirmation = new Button() { Text = "OK", Left = 350, Width = 110, Top = 75, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static void CheckAutmataProperty(Automata automata, string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 30, Top = 30, Width = 440, Text = text };
            TextBox textBox = new TextBox() { Left = 30, Top = 50, Width = 370 }; 
            PictureBox pb = new PictureBox { Location = new Point(400, 50), Size = new Size(50, 50)};

            textBox.TextChanged += new EventHandler(changed);
            changed(null, null);

            void changed(object sender, EventArgs e)
            {
                if(automata.CheckWord(textBox.Text))
                    pb.Image = RegExGen.Properties.Resources.check;
                else
                    pb.Image = RegExGen.Properties.Resources.exit;
                prompt.Update();
            }

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(pb);
            prompt.ShowDialog();
        }

        public static void Dictionary(IEnumerable<string> words, string caption) {
            Form prompt = new Form()
            {
                Width = 600,
                Height = 650,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
            };

            StringBuilder sbl = new StringBuilder();
            StringBuilder sbr = new StringBuilder();

            int i = 0;
            foreach(string s in words)
            {
                if (i % 2 == 0)
                    sbl.AppendLine(s);
                else
                    sbr.AppendLine(s);
                i++;
            }

            Label left = new Label() { Left = 20, Top = 20, Width = 290, Height= 590, Text = sbl.ToString() };
            Label right = new Label() { Left = 310, Top = 20, Width = 570, Height = 590, Text = sbr.ToString() };

            prompt.Controls.Add(left);
            prompt.Controls.Add(right);
            prompt.ShowDialog();
        }
    }
}
