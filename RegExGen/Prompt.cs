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
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Run", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
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
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 350 }; 
            PictureBox pb = new PictureBox { Location = new Point(400, 50), Size = new Size(50, 50), Image = RegExGen.Properties.Resources.exit };

            textBox.TextChanged += new EventHandler(changed);

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
    }
}
