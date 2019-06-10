using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExGen
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private enum Status { SUCCESS, ERROR, WARN }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetRegex("(a|b)+|(aaa)");
        }

        public void SetRegex(string regex) {
            lb_regex.Text = regex;

            try
            {
                RegExp r = RegExParser.GetRegEx(regex);
                updateAutomata(new ThompsonConverter().RegExToAutomata(r));
                status(Status.SUCCESS, "Regex successfully parsed!");
            }
            catch (Exception e) {
                status(Status.ERROR, e.Message);
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            //TODO: add validaton
            SetRegex(tb_regex.Text);
        }

        private void btn_import_language_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Text|*.txt|All|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                StringBuilder input = FileIO.loadLanguage(file.FileName);
                try
                {
                    Automata a = RegularLanguageConverter.ConvertLanguageToAutomata(input.ToString());
                    updateAutomata(a);
                    status(Status.SUCCESS, "File successfully parsed!");
                    lb_regex.Text = "---";
                }
                catch (Exception ex) {
                    status(Status.ERROR, ex.Message);
                }
            }
            else
                status(Status.WARN, "File import interrupted");      
        }

        private void updateAutomata(Automata ndfa) {
            //NDFA
            lb_regular_lan_ndfa.Text = RegularLanguageConverter.ConvertAutomataToLanguage(ndfa);
            pb_ndfa.ImageLocation = Graph.CreateImagePath(Graph.Type.NDFA, ndfa);

            //DFA
            Automata dfa = ndfa.getDfa();
            lb_regular_lan_dfa.Text = RegularLanguageConverter.ConvertAutomataToLanguage(dfa);
            pb_dfa.ImageLocation = Graph.CreateImagePath(Graph.Type.DFA, dfa);

            //ODFA
            Automata odfa = dfa.getOptimized();
            lb_regular_lan_odfa.Text = RegularLanguageConverter.ConvertAutomataToLanguage(odfa);
            pb_odfa.ImageLocation = Graph.CreateImagePath(Graph.Type.ODFA, odfa);

            this.Update();
        }

        private void status(Status s, string msg)
        {
            lb_status.Text = msg;
            switch (s)
            {
                case Status.SUCCESS: lb_status.ForeColor = Color.DarkOliveGreen; break;
                case Status.WARN: lb_status.ForeColor = Color.Orange; break;
                case Status.ERROR: lb_status.ForeColor = Color.Red; break;
            }
            this.Update();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

