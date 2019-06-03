using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    static class NdfaToDfa
    {
        public static Automata run(Automata Ndfa)
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
            var testAutomata = new Automata(new[] { 'x', 'y' });
           
            var beginNode = "1";
            testAutomata.defineAsStartState(beginNode);
            var endNode = "2";
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition(beginNode, 'x', endNode));

            if (run(testAutomata).isDFA()) throw new Exception("ndfa to dfa test Failed");
        }

        public static void test2()
        {
            var testAutomata = new Automata(new[] { 'x', 'y' });
           
            var beginNode = "1";
            testAutomata.defineAsStartState(beginNode);
            var endNode = "2";
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition(beginNode, 'x', endNode));
            testAutomata.addTransition(new Transition(beginNode, 'y', endNode));
            testAutomata.addTransition(new Transition(endNode, 'x', endNode));
            testAutomata.addTransition(new Transition(endNode, 'y', endNode));

            if (!run(testAutomata).isDFA()) throw new Exception("ndfa to dfa test Failed");
        }
    }
}
