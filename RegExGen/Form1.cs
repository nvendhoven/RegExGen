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

            RegExp r = RegExParser.GetRegEx(regex);

            //NDFA
            Automata ndfa = new ThompsonConverter().RegExToAutomata(r);
            lb_regular_lan_ndfa.Text = RegularLanguageConverter.Convert(ndfa);
            pb_ndfa.ImageLocation = Graph.CreateImagePath(Graph.Type.NDFA, ndfa);

            //DFA
            Automata dfa = NdfaToDfa.run(ndfa);
            lb_regular_lan_dfa.Text = RegularLanguageConverter.Convert(dfa);
            pb_dfa.ImageLocation = Graph.CreateImagePath(Graph.Type.DFA, dfa);

            //ODFA
            //Automata odfa = NdfaToDfa(NdfaToDfa(dfa.Reverse()).Reverse());
            //lb_regular_lan_odfa.Text = RegularLanguageConverter.Convert(odfa);
            //pb_odfa.Image = Graph.CreateImagePath(Graph.Type.ODFA, odfa);

            this.Update();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            //TODO: add validator
            SetRegex(tb_regex.Text);
        }
    }
}

