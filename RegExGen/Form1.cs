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
            //Automata<string> automata = ThompsonConverter<string>.RegExToAutomata(regex);
            regex = Program.TestRegExp();
            Automata automata = new ThompsonConverter().RegExToAutomata(regex);
            //lb_regex.Text = regex.ToString();
            lb_regex.Text = "((aaa+b)|(bbb))a*(ba*ba*)*";

            pb_ndfa.Image = Graph.CreateImage(automata);
            //pb_dfa.Image = Graph.CreateImage(NdfaToDfa<string>.run(automata));
            //pb_odfa.Image = Graph.CreateImage(DfaToOdfa<string>.run(automata));

            this.Update();
        }


    }
}
