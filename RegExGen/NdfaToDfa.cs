using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    static class NdfaToDfa<T> where T : IComparable
    {
        public static Automata<T> run(Automata<T> Ndfa)
        {
            // todo
            return Ndfa;
        }

        public static void testAll()
        {
            test1();
            test2();
        }

        public static void test1()
        {
            /*
            var testAutomata = new Automata<T>(new[] { 'x', 'y' });
           
            T beginNode = "1";
            testAutomata.defineAsStartState(beginNode);
            T endNode = "2";
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition<T>(beginNode, 'x', endNode));

            if (run(testAutomata).isDFA()) throw new Exception("ndfa to dfa test Failed");
            */
        }

        public static void test2()
        {
            var testAutomata = new Automata<T>(new[] { 'x', 'y' });
           
            var beginNode = "1";
            var endNode = "2";
            /*(
            testAutomata.defineAsStartState(beginNode);
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition<T>(beginNode, 'x', endNode));
            testAutomata.addTransition(new Transition<T>(beginNode, 'y', endNode));
            testAutomata.addTransition(new Transition<T>(endNode, 'x', endNode));
            testAutomata.addTransition(new Transition<T>(endNode, 'y', endNode));
            */
            if (!run(testAutomata).isDFA()) throw new Exception("ndfa to dfa test Failed");
        }
    }
}
