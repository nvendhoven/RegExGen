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
            SetRegex(new RegExp("aa|bb+"));
        }

        public void SetRegex(RegExp regex) {
            lb_regex.Text = "((aaa+b)|(bbb))a*(ba*ba*)*";

            //TODO: remove
            regex = Program.TestRegExp();

            //NDFA
            Automata ndfa = new ThompsonConverter().RegExToAutomata(regex);
            lb_regular_lan_ndfa.Text = RegularLanguageConverter.Convert(ndfa);
            pb_ndfa.Image = Graph.CreateImage(ndfa);

            //DFA
            //Automata dfa = NdfaToDfa<string>.run(ndfa);
            //lb_regular_lan_dfa.Text = RegularLanguageConverter.Convert(dfa);
            //pb_dfa.Image = Graph.CreateImage(dfa);

            //ODFA
            //Automata odfa = NdfaToDfa(NdfaToDfa(dfa.Reverse()).Reverse());
            //lb_regular_lan_odfa.Text = RegularLanguageConverter.Convert(odfa);
            //pb_odfa.Image = Graph.CreateImage(DfaToOdfa<string>.run(automata));

            this.Update();
        }


    }
}
