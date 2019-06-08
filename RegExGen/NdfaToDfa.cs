using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    static class NdfaToDfa
    {
        public static Automata run(Automata Ndfa)
        {
            //Creat Hulptabellen.
            string[] statesList = Ndfa.states.ToArray();
            char[] letterList = Ndfa.getAlphabet().ToArray();
            List<List<SortedSet<string>>> hulpTabel = new List<List<SortedSet<string>>>();//create 2d array with lists as objects.

            //Hulptabel vullen met lege items
            for (int state = 0; state < Ndfa.states.Count; state++)
            {
                hulpTabel.Add(new List<SortedSet<string>>());
            }
            for (int state = 0; state < Ndfa.states.Count; state++)
            {
                for (int letter = 0; letter < Ndfa.symbols.Count; letter++)
                {
                    hulpTabel[state].Add(new SortedSet<string>());
                }
            }

            //Hulptabel vullen.
            for (int letter = 0; letter < Ndfa.getAlphabet().Count; letter++)
            {
                for (int state = 0; state < Ndfa.states.Count; state++)
                {
                    hulpTabel[state][letter] = GetDestinations(Ndfa.transitions,Ndfa.symbols,state, letter);
                }
            }

            print2dArray(hulpTabel);

            Automata returnAutomata = new Automata();
            returnAutomata.setAlphabet(Ndfa.getAlphabet());

            SortedSet<SortedSet<string>> notDoneStates = new SortedSet<SortedSet<string>>();
            SortedSet<SortedSet<string>> doneStates = new SortedSet<SortedSet<string>>();


            //-----DONE WITH BASIC STUFF, NOW COMES THE HARD PART-----//

            while (notDoneStates.Count != 0)
            {
                var aState = notDoneStates.First();
                doneStates.Add(aState);
                notDoneStates.Remove(aState);

                //Check of het een final state bevat;
                if (Ndfa.finalStates.Contains(aState))
                {
                    returnAutomata.defineAsFinalState(aState);
                }

                var charEnumerator = Ndfa.getAlphabet().GetEnumerator();

                //Voor elk symbool die de ndfa kent
                while (charEnumerator.MoveNext())
                {
                    // Next state
                    SortedSet<string> nextStates = EpsilonClosure();

                    if (!notDoneStates.Contains(nextStates) && !doneStates.Contains(nextStates))
                    {
                        notDoneStates.Add(nextStates);
                    }




                }
            }





            return returnAutomata;
        }

        public static void print2dArray(List<List<SortedSet<string>>> arr)
        {
            Console.WriteLine("");
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr[i].Count; j++)
                {
                    string str = "";
                    foreach (var s in arr[i][j])
                    {
                        str += s;
                    }
                    Console.Write(string.Format("{0} ", str));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public static SortedSet<string> GetDestinations(SortedSet<Transition> transitions, SortedSet<char> symbols, int state, int letter)
        {
            //Zoek de state op die bij het nummer hoort
            SortedSet<string> returnList = new SortedSet<string>();
            string previousState = transitions.First().fromState;
            int stateCounter = 0;
            string savedState = "#";

            foreach (Transition t in transitions)
            {
                if (!t.fromState.Equals(previousState))
                {
                    stateCounter++;
                }

                if (stateCounter == state)
                {
                    //Will enter this if once for every state in the ndfa.
                    savedState = t.fromState;
                }
                previousState = t.fromState;
            }

            //Zoek de letter op die bij het nummer hoort.
            char previousLetter = transitions.First().symbol;
            int letterCounter = 0;
            char savedLetter = transitions.First().symbol;
            foreach (char t in symbols)
            {
                if (!t.Equals(previousLetter))
                {
                    letterCounter++;
                }

                if (letterCounter == letter)
                {
                    //Will enter this if once for every letter in the alphabet.
                    savedLetter = t;
                }

                previousLetter = t;
            }

            Debug.Write("Destination for: " + savedState + " -> " + savedLetter + "-> ");
            var transition = transitions.Where(Transition => (Transition.fromState == savedState && Transition.symbol == savedLetter));

            if (transition.Count() > 0)
                foreach (var toState in transition)
                {
                    returnList.Add(toState.toState);
                }
            else
                returnList.Add(Automata.EMPTY);

            return returnList;
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
            var testAutomata = new Automata(new[] { 'x', 'y' });
           
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
