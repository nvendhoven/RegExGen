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
        Automata ndfa;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetRegex("(a|b)+|(aaa)");
        }

        public void SetRegex(string regex)
        {
            lb_regex.Text = regex;

            try
            {
                RegExp r = RegExParser.GetRegEx(regex);
                updateAutomata(new ThompsonConverter().RegExToAutomata(r));
                tc_automata.TabPages[0].Enabled = true;
                status(Status.SUCCESS, "Regex successfully parsed!");
            }
            catch (Exception e)
            {
                status(Status.ERROR, e.Message);
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            //TODO: add validaton
            SetRegex(tb_regex.Text);
        }

        private void updateAutomata(Automata ndfa)
        {
            this.ndfa = ndfa;

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
            string m = "???";
            switch (s)
            {
                case Status.SUCCESS: m = "SUCCESS"; lb_status.ForeColor = Color.GreenYellow; break;
                case Status.WARN: m = "WARNING"; lb_status.ForeColor = Color.Orange; break;
                case Status.ERROR: m = "ERROR"; lb_status.ForeColor = Color.Red; break;
            }
            lb_status.Text = m + ": " + msg;
            this.Update();
        }

        private void importGramaticaToolStripMenuItem_Click(object sender, EventArgs e)
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
                    lb_regex.Text = "";
                }
                catch (Exception ex)
                {
                    status(Status.ERROR, ex.Message);
                }
            }
            else
                status(Status.WARN, "File import interrupted");
        }

        private void iNVERTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to invert");
                return;
            }

            try
            {
                updateAutomata(this.ndfa.Inverse());
                lb_regex.Text = "Inverted " + lb_regex.Text;
                status(Status.SUCCESS, "Automata successfully inverted");
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }

        private void nOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to negate");
                return;
            }

            try
            {
                updateAutomata(this.ndfa.getDfa().Not());
                tc_automata.SelectedIndex = 1;
                lb_regex.Text = "Not " + lb_regex.Text;
                status(Status.SUCCESS, "Automata successfully negated");
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to save");
                return;
            }

            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text|*.txt|All|*.*";
                string sfdname = sfd.FileName;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetFullPath(sfd.FileName);
                    FileIO.saveAutomataToTextFile(path, this.ndfa);
                }
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }

        }

        //ADD from regex
        private void createNewFromRegexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to add");
                return;
            }

            try
            {
                string regex = Prompt.ShowDialog("Enter regex: ", "AND");
                Automata a = new ThompsonConverter().RegExToAutomata(RegExParser.GetRegEx(regex)).getDfa();
                and(a);
                lb_regex.Text = "(" + lb_regex.Text + " AND " + regex + ")";
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }


        //OR from regex
        private void createNewFromRegexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to or");
                return;
            }

            try
            {
                string regex = Prompt.ShowDialog("Enter regex: ", "OR");
                Automata a = new ThompsonConverter().RegExToAutomata(RegExParser.GetRegEx(regex)).getDfa();
                or(a);
                lb_regex.Text = "(" + lb_regex.Text + " OR " + regex + ")";
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }

        //Generate
        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string startRegex = Prompt.ShowDialog("Starts with: ", "Generate automata");
            string containsRegex = Prompt.ShowDialog("Contains: ", "Generate automata");
            string endswithRegex = Prompt.ShowDialog("Ends with: ", "Generate automata");

            try
            {
                RegExp regex = new RegExp();

                #region NEVER_OPEN_DIS_PLS
                if (startRegex != "" && containsRegex != "" && endswithRegex != "")
                {
                    regex = LanguageGenerator.generateRegExpStartingWith(startRegex).dot(
                        LanguageGenerator.generateRegExpContaining(containsRegex).dot(
                             LanguageGenerator.generateRegExpEndingWith(endswithRegex)
                        )
                    );
                }
                else if (startRegex == "" && containsRegex != "" && endswithRegex != "")
                {
                    regex = LanguageGenerator.generateRegExpContaining(containsRegex).dot(
                            LanguageGenerator.generateRegExpEndingWith(endswithRegex)
                       );
                }
                else if (startRegex != "" && containsRegex == "" && endswithRegex != "")
                {
                    regex = LanguageGenerator.generateRegExpStartingWith(startRegex).dot(
                            LanguageGenerator.generateRegExpEndingWith(endswithRegex)
                       );
                }
                else if (startRegex != "" && containsRegex != "" && endswithRegex == "")
                {
                    regex = LanguageGenerator.generateRegExpStartingWith(startRegex).dot(
                            LanguageGenerator.generateRegExpContaining(containsRegex)
                       );
                }
                else
                {
                    if (startRegex != "") regex = LanguageGenerator.generateRegExpStartingWith(startRegex);
                    if (containsRegex != "") regex = LanguageGenerator.generateRegExpContaining(containsRegex);
                    if (endswithRegex != "") regex = LanguageGenerator.generateRegExpEndingWith(endswithRegex);
                }
                #endregion

                lb_regex.Text = regex.ToString();
                updateAutomata(new ThompsonConverter().RegExToAutomata(regex));
                status(Status.SUCCESS, "Language succesfully generated");
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                updateAutomata(loadAutomata());
                lb_regex.Text = "";
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }

        private Automata loadAutomata()
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Text|*.txt|All|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    status(Status.SUCCESS, "File successfully loaded");
                    Automata a = FileIO.loadAutomataFromTextFile(file.FileName);
                    return a;
                }
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
            status(Status.WARN, "Canceled load");
            return null;
        }

        //AND load
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Automata a = loadAutomata();
            if (a != null)
                and(a.getDfa());
            else
                status(Status.ERROR, "File is not a valid automata");
        }

        //OR load
        private void loadAutomataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Automata a = loadAutomata();
            if (a != null)
                or(a.getDfa());
            else
                status(Status.ERROR, "File is not a valid automata");
        }

        private void and(Automata a)
        {
            tc_automata.SelectedIndex = 1;

            updateAutomata(this.ndfa.getDfa().And(a));
            status(Status.SUCCESS, "Automata AND successful");

        }

        private void or(Automata a)
        {
            tc_automata.SelectedIndex = 1;

            updateAutomata(this.ndfa.getDfa().Or(a));
            status(Status.SUCCESS, "Automata OR successful");
        }

        private void checkWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ndfa == null)
            {
                status(Status.ERROR, "No automata to check from");
                return;
            }
            try
            {
                Prompt.CheckAutmataProperty(this.ndfa.getDfa(), "Enter word: ", "Check word");
            }
            catch (Exception ex)
            {
                status(Status.ERROR, ex.Message);
            }
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Question q = new QuestionGenerator().GenerateReExpQuestion(1);
            handleAnswer(q, Prompt.ShowDialog(q.QuestionText, "Easy question"));
        }

        private void handleAnswer(Question q, string answer) {

        }
    }
}

