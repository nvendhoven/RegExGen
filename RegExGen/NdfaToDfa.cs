using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    static class NdfaToDfa
    {
        struct ToestandSymbolPair{
            public SortedSet<string> toestand;
            public char symbol;

            public ToestandSymbolPair(SortedSet<string> toestanden, char symbol)
            {
                toestand = toestanden;
                this.symbol = symbol;
            }

            public ToestandSymbolPair(string[] toestanden, char symbol)
            {
                toestand = new SortedSet<string>(toestanden);
                this.symbol = symbol;
            }
        }

        public static Automata run(Automata Ndfa)
        {
            // "hulp tabel"
            var toestandenMet1SymboolVerwijderd = new Dictionary<ToestandSymbolPair, SortedSet<string>>();

            foreach (var state in Ndfa.states)
            {
                foreach (var symbol in Ndfa.getAlphabet())
                {
                    // maak nieuwe key
                    var toestandSymboolPair = new ToestandSymbolPair(new[] {state}, symbol);

                    // get connected states door epsilon -> symbol -> epsilon connections te checken
                    var connectedStates = getEpsilonConnectedStates(Ndfa, state)
                        .SelectMany(firstConnectedState => Ndfa.getToStates(firstConnectedState, symbol)
                            .SelectMany(symbolConnectedState => getEpsilonConnectedStates(Ndfa, state)));

                    // voeg toe aan 'hulp tabel'
                    toestandenMet1SymboolVerwijderd.Add(toestandSymboolPair,
                        new SortedSet<string>(connectedStates));
                }
            }

            var startState = new SortedSet<string>(Ndfa.startStates
                .SelectMany(start => getEpsilonConnectedStates(Ndfa, start)));
            var stateQueue = new Queue<SortedSet<string>>(new[] { startState });

            var dfaDictionary = new Dictionary<ToestandSymbolPair, SortedSet<string>>();

            do
            {
                var toCheckState = stateQueue.Dequeue();
                foreach(var symbol in Ndfa.getAlphabet())
                {

                    // kijk waar de state naartoe wijst
                    var newState = new SortedSet<string>(toCheckState.SelectMany(state =>
                    {
                        if (toestandenMet1SymboolVerwijderd.TryGetValue(
                            new ToestandSymbolPair(new[] { state }, symbol),//maak nieuwe toestand als key
                            out var toValue))
                        {
                            return toValue;
                        }
                        else throw new KeyNotFoundException("single symbol not found in 'hulp tabel'");
                    }));
                    if (dfaDictionary.Keys.Select(ToestandSymbolPair => ToestandSymbolPair.toestand).All(state=> {
                        // todo make compare work
                        newState
                        }
                    )) continue;

                    // voeg toe aan dfaDictionary
                    dfaDictionary.Add(new ToestandSymbolPair(toCheckState, symbol), newState);

                    // voeg toe in de queue
                    stateQueue.Enqueue(newState);
                }
            } while (stateQueue.Any());

            string makeStateName(SortedSet<string> state)
            {
                var name = "(";
                foreach (var partName in state)
                    name += (partName).ToString() + " ";
                return name + ")";
            }

            var dfa = new Automata(Ndfa.getAlphabet());
            foreach(var key in dfaDictionary.Keys)
            {
                dfa.addTransition(new Transition(
                        makeStateName(key.toestand),
                        key.symbol,
                        makeStateName(dfaDictionary[key])));
            }

            dfa.startStates.Add(makeStateName(startState));

            var dfaEndStates = Ndfa.finalStates.SelectMany(
                finalState => dfaDictionary.Keys.Select(
                    key=> key.toestand).Where(state => state.Contains(finalState)))
                    .Select(state => makeStateName(state));
            foreach (var endState in dfaEndStates)
                dfa.finalStates.Add(endState);

            return dfa;
        }

        private static IEnumerable<string> getEpsilonConnectedStates(Automata Ndfa, string stateToStart)
        {
            var conectedStates = Ndfa.getToStates(stateToStart, Automata.EPSILON);
            return conectedStates.SelectMany(state => getEpsilonConnectedStates(Ndfa, state));
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
            var endNode = "2";

            testAutomata.defineAsStartState(beginNode);
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition(beginNode, 'x', endNode));
            testAutomata.addTransition(new Transition(beginNode, 'y', endNode));
            testAutomata.addTransition(new Transition(endNode, 'x', endNode));
            testAutomata.addTransition(new Transition(endNode, 'y', endNode));

            if (!run(testAutomata).isDFA()) throw new Exception("ndfa to dfa test Failed");
        }
    }
}
