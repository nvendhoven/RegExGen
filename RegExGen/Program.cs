using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegExGen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestRegExp();
            TestAutomata();

            //NdfaToDfa<string>.testAll();
            Debug.WriteLine("Done");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }

        public static void TestRegExpToAutomata()
        {
            RegExp regExp = new RegExp("baa");
            Automata<string> automata = ThompsonConverter<string>.RegExToAutomata(regExp);
            Debug.WriteLine(automata.ToString());
        }

        public static void TestAutomata()
        {
            char[] alphabet = { 'a', 'b' };
            Automata<string> m = new Automata<string>(alphabet);

            m.addTransition(new Transition<string>("q0", 'a', "q1"));
            m.addTransition(new Transition<string>("q0", 'b', "q4"));
            m.addTransition(new Transition<string>("q1", 'a', "q4"));
            m.addTransition(new Transition<string>("q1", 'b', "q2"));
            m.addTransition(new Transition<string>("q2", 'a', "q3"));
            m.addTransition(new Transition<string>("q2", 'b', "q4"));
            m.addTransition(new Transition<string>("q3", 'a', "q1"));
            m.addTransition(new Transition<string>("q3", 'b', "q2"));
            m.addTransition(new Transition<string>("q4", 'a'));
            m.addTransition(new Transition<string>("q4", 'b'));

            //1 begintoestand
            m.defineAsStartState("q0");

            //2 eindtoestanden
            m.defineAsFinalState("q2");
            m.defineAsFinalState("q3");

        }

        private static RegExp expr1, expr2, expr3, expr4, expr5, expr6, e, a, b, all;

        public static void TestRegExp()
        {
            Debug.WriteLine("Start Test");
            a = new RegExp("a");
            b = new RegExp("b");

            // expr1: "baa"
            expr1 = new RegExp("baa");
            // expr2: "bb"
            expr2 = new RegExp("bb");
            // expr3: "baa | baa"
            expr3 = expr1.or(expr2);

            // all: "(a|b)*"
            all = (a.or(b)).star();

            // expr4: "(baa | baa)+"
            expr4 = expr3.plus();
            // expr5: "(baa | baa)+ (a|b)*"
            expr5 = expr4.dot(all);
            testLanguage();
        }

        public static void testLanguage()
        {
            Debug.WriteLine("taal van (baa):\n" + expr1.getLanguage(5));
            Debug.WriteLine("taal van (bb):\n" + expr2.getLanguage(5));
            Debug.WriteLine("taal van (baa | bb):\n" + expr3.getLanguage(5));

            Debug.WriteLine("taal van (a|b)*:\n" + all.getLanguage(5));
            Debug.WriteLine("taal van (baa | bb)+:\n" + expr4.getLanguage(5));
            Debug.WriteLine("taal van (baa | bb)+ (a|b)*:\n" + expr5.getLanguage(6));
        }

        public static void TestThompsonConstruction()
        {
            Debug.WriteLine("Start Thompson");
            e = new RegExp("$");
            a = new RegExp("a");
            b = new RegExp("b");


            //($ | a*b)
            expr6 = e.or(a.star().dot(b));
            Automata<string> ndfa = ThompsonConverter<string>.RegExToAutomata(expr6);
            Debug.WriteLine(ndfa.ToString());
        }
    }
}
