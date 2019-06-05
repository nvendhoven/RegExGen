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
            //TestRegExp();
            //TestAutomata();
            //TestThompsonConstruction();
            //TestRegExpToAutomata();
            //NdfaToDfa.testAll();
            Debug.WriteLine("Done");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //TestRegExp();
            //TestAutomata();
        }

        public static void TestRegExpToAutomata()
        {
            RegExp regExp9 = new RegExp("a").star();
            RegExp regExp0 = new RegExp("baa").star();
            Automata automata9 = new ThompsonConverter().RegExToAutomata(regExp9);
            Automata automata0 = new ThompsonConverter().RegExToAutomata(regExp0);

            RegExp regExp7 = new RegExp("a").plus();
            RegExp regExp8 = new RegExp("baa").plus();
            Automata automata7 = new ThompsonConverter().RegExToAutomata(regExp7);
            Automata automata8 = new ThompsonConverter().RegExToAutomata(regExp8);

            RegExp regExp5 = new RegExp("a").dot(new RegExp("b"));
            RegExp regExp6 = new RegExp("baa").dot(new RegExp("abb"));
            Automata automata5 = new ThompsonConverter().RegExToAutomata(regExp5);
            Automata automata6 = new ThompsonConverter().RegExToAutomata(regExp6);


            RegExp regExp = new RegExp("baa");
            RegExp regExp2 = new RegExp("a");
            Automata automata = new ThompsonConverter().RegExToAutomata(regExp);
            Automata automata2 = new ThompsonConverter().RegExToAutomata(regExp2);


            RegExp regExp3 = new RegExp("baa").or(new RegExp("abb"));
            RegExp regExp4 = new RegExp("a").or(new RegExp("b"));
            Automata automata3 = new ThompsonConverter().RegExToAutomata(regExp3);
            Automata automata4 = new ThompsonConverter().RegExToAutomata(regExp4);

            Debug.WriteLine("EndOfTest");
        }

        public static Automata TestAutomata()
        {
            char[] alphabet = { 'a', 'b' };
            Automata m = new Automata(alphabet);

            m.addTransition(new Transition("q0", 'a', "q1"));
            m.addTransition(new Transition("q0", 'b', "q4"));
            m.addTransition(new Transition("q1", 'a', "q4"));
            m.addTransition(new Transition("q1", 'b', "q2"));
            m.addTransition(new Transition("q2", 'a', "q3"));
            m.addTransition(new Transition("q2", 'b', "q4"));
            m.addTransition(new Transition("q3", 'a', "q1"));
            m.addTransition(new Transition("q3", 'b', "q2"));
            m.addTransition(new Transition("q4", 'a'));
            m.addTransition(new Transition("q4", 'b'));

            //1 begintoestand
            m.defineAsStartState("q0");

            //2 eindtoestanden
            m.defineAsFinalState("q2");
            m.defineAsFinalState("q3");

            return m;
        }

        private static RegExp expr1, expr2, expr3, expr4, expr5, expr6, e, a, b, all;

        public static RegExp TestRegExp()
        {
            Debug.WriteLine("Start Test");
            a = new RegExp("a");
            b = new RegExp("b");

            // expr1: "baa"
            expr1 = new RegExp("baa");
            // expr2: "bb"
            expr2 = new RegExp("bb");
            // expr3: "baa | bb"
            expr3 = expr1.or(expr2);

            // all: "(a|b)*"
            all = (a.or(b)).star();

            all.PrintTree(0);

            // expr4: "(baa | bb)+"
            expr4 = expr3.plus();
            // expr5: "(baa | bb)+ (a|b)*"
            expr5 = expr4.dot(all);

            testLanguage();

            return expr5;
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
            expr6.PrintTree(0);
            Automata ndfa = new ThompsonConverter().RegExToAutomata(expr6);
            Debug.WriteLine(ndfa.ToString());
        }
    }
}
