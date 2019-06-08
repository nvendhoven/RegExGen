using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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
            //NdfaToDfa<string>.testAll();
            //TestRegExpParser();
            //TestRegExpToStringParser();
            //TestFileIO();
            //TestAutomataOperations();
            //TestAutomataSaveAndLoad();
            Debug.WriteLine("Done");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //TestRegExp();
            //TestAutomata();
        }

        public static void TestAutomataSaveAndLoad()
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
            m.defineAsFinalState("q1");
            m.defineAsFinalState("q3");

            m.printTransitions();

            FileIO.saveAutomataToTextFile("D:/School/P3.4/Formele Methoden/RegExGen/auto.json",m);
            Debug.WriteLine("--Saved--");
            Automata m2 = FileIO.loadAutomataFromTextFile("D:/School/P3.4/Formele Methoden/RegExGen/auto.json");
            m2.printTransitions();
            Debug.WriteLine("--Done--");
        }

        public static void TestAutomataOperations()
        {
            throw new Exception("Need to turn these automata into dfa's");
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
            m.defineAsFinalState("q1");
            m.defineAsFinalState("q3");


            //bbb
            char[] alphabet2 = {'a', 'b' };
            Automata m2 = new Automata(alphabet2);

            m2.addTransition(new Transition("q0", 'a', "q1"));
            m2.addTransition(new Transition("q1", 'a', "q2"));
            //m2.addTransition(new Transition("q2",'a', Automata.EMPTY));

            //1 begintoestand
            m2.defineAsStartState("q0");

            //2 eindtoestanden
            m2.defineAsFinalState("q1");



            Debug.WriteLine("---0---");
            m.printTransitions();
            Debug.WriteLine("---1---");
            m2.printTransitions();
            /*
            Automata m3 = m.Not();
            Automata m4 = m2.Not();
            Debug.WriteLine("---0 Negative---");
            m3.printTransitions();
            Debug.WriteLine("---1 Negative---");
            m4.printTransitions();

            Automata m5 = m.Inverse();
            Automata m6 = m2.Inverse();
            Debug.WriteLine("---0 inverse---");
            m5.printTransitions();
            Debug.WriteLine("---1 inverse---");
            m6.printTransitions();
            */
            Debug.WriteLine("---0 AND 1---");
            Automata m7 = m.Or(m2);
            m7.printTransitions();

            Debug.WriteLine("Done");
        }

        public static void TestFileIO()
        {
            List<RegExp> list = FileIO.loadRegExesFromTextFile("C:/Users/Cave-PC_2/Desktop/RegExGen/RegExes.txt");
            foreach (RegExp regExp in list)
            {
                Debug.WriteLine("---"+regExp.ToString()+"---");
                regExp.PrintTree(0);
            }

            Debug.WriteLine("EndOfTest");
        }

        public static void TestRegExpToStringParser()
        {
            Debug.WriteLine("---1---");
            Debug.WriteLine("ab*");
            RegExp regExp = new RegExp("a").dot(new RegExp("b").star()); // ab*
            Debug.WriteLine(regExp.ToString());

            Debug.WriteLine("---2---");
            Debug.WriteLine("(ab)*");
            RegExp regExp2 = new RegExp("a").dot(new RegExp("b")).star(); // (ab)*
            Debug.WriteLine(regExp2.ToString());

            Debug.WriteLine("---3---");
            Debug.WriteLine("(ab)*");
            RegExp regExp3 = new RegExp("a").dot(new RegExp("b")).plus(); // (ab)+
            Debug.WriteLine(regExp3.ToString());

            Debug.WriteLine("---4---");
            Debug.WriteLine("(ab)* (a|b)");
            RegExp regExp4 = new RegExp("a").dot(new RegExp("b")).star().dot(new RegExp("a").or(new RegExp("b"))); // (ab)* ab
            regExp4.PrintTree(0);
            Debug.WriteLine(regExp4.ToString());
            RegExp regExp5 = RegExParser.GetRegEx(regExp4.ToString());
            regExp5.PrintTree(0);

            Debug.WriteLine("---5---");
            Debug.WriteLine("(ab)* ab*");
            RegExp regExp6 = new RegExp("a").dot(new RegExp("b")).star().dot(new RegExp("a").dot(new RegExp("b").star())); // (ab)* ab
            regExp6.PrintTree(0);
            Debug.WriteLine(regExp6.ToString());
            RegExp regExp7 = RegExParser.GetRegEx(regExp6.ToString());
            regExp7.PrintTree(0);
            Debug.WriteLine("Succesvol: " + (regExp6.Equals(regExp7)));

            Debug.WriteLine("EndOfTest");
        }

        public static void TestRegExpParser()
        {
            RegExp regExp = RegExParser.GetRegEx("ab");
            RegExp regExp1 = RegExParser.GetRegEx("a|b");
            RegExp regExp2 = RegExParser.GetRegEx("a*b");
            RegExp regExp3 = RegExParser.GetRegEx("a+b");
            RegExp regExp4 = RegExParser.GetRegEx("(ab) a");
            RegExp regExp5 = RegExParser.GetRegEx("ab+");
            RegExp regExp6 = RegExParser.GetRegEx("(ab)* a (b|a)+");
            regExp.PrintTree(0);
            Debug.WriteLine("---1---");
            regExp1.PrintTree(0);
            Debug.WriteLine("---2---");
            regExp2.PrintTree(0);
            Debug.WriteLine("---3---");
            regExp3.PrintTree(0);
            Debug.WriteLine("---4---");
            regExp4.PrintTree(0);
            Debug.WriteLine("---5---");
            regExp5.PrintTree(0);
            Debug.WriteLine("---6---");
            regExp6.PrintTree(0);
            Debug.WriteLine("EndOfTest");
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
