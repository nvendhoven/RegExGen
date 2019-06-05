using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
   public  static class NdfaToDfa
    {
        class ToestandSymbolPair : IEqualityComparer<ToestandSymbolPair>{
            public SortedSet<string> toestand;
            public char symbol;

            public ToestandSymbolPair() { }
            public ToestandSymbolPair(string[] toestanden, char symbol)
            {
                
                toestand = new SortedSet<string>(toestanden);
                this.symbol = symbol;
            }

            public override int GetHashCode()
            {
                int toestandHash = 0;
                foreach(var toestandsonderdeel in toestand.ToArray())
                    toestandHash ^= toestandsonderdeel.GetHashCode();
                toestandHash ^= symbol.GetHashCode();
                return toestandHash & 0xfffffff;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is ToestandSymbolPair)) return false;
                var otherObj = obj as ToestandSymbolPair;
                return areSortedSetEqual(toestand, otherObj.toestand) && symbol == otherObj.symbol;
            }

            public bool Equals(ToestandSymbolPair x, ToestandSymbolPair y)
            {
                return x.Equals(y);
            }

            public int GetHashCode(ToestandSymbolPair obj)
            {
                return obj.GetHashCode();
            }
        }

        private static bool areSortedSetEqual(SortedSet<string> x,SortedSet<string> y)
        {
            return x.Count == y.Count && x.Union(y).Count() == y.Count;
        }

        public static Automata run(Automata Ndfa)
        {
            // "hulp tabel"
            var toestandenMet1SymboolVerwijderd = new Dictionary<ToestandSymbolPair, SortedSet<string>>(new ToestandSymbolPair());

            var dfaAlphabet = Ndfa.getAlphabet().Where(c => c != Automata.EPSILON);

            //voeg foute state toe
            foreach (var symbol in dfaAlphabet)
                toestandenMet1SymboolVerwijderd.Add(
                    key: new ToestandSymbolPair(new[] {Automata.EMPTY }, symbol),
                    value: new SortedSet<string>(new[] {Automata.EMPTY}));

            foreach (var state in Ndfa.states)
            {
                foreach (var symbol in Ndfa.getAlphabet())
                {
                    // maak nieuwe key
                    var toestandSymboolPair = new ToestandSymbolPair(new[] {state}, symbol);

                    //check of er epsilon connecties zijn
                    var fistEpsilonConnectedStates = new List<string>(getEpsilonConnectedStates(Ndfa, state));
                    fistEpsilonConnectedStates.Add(state);
                    //gebuik epsilon connected states en huidige state voor checken next state

                    SortedSet<string> connectedStates = new SortedSet<string>();
                    foreach(var connectedstate in fistEpsilonConnectedStates)
                        connectedStates.UnionWith(Ndfa.getToStates(connectedstate, symbol));

                    //voeg symbol epsion connected state toe vanaf berijkte symbols
                    foreach (var letterConnectedState in connectedStates)
                        connectedStates.UnionWith(getEpsilonConnectedStates(Ndfa, letterConnectedState));

                    // als verzameling leeg is een leege state aanmaken
                    if (connectedStates.Count == 0) connectedStates.Add(Automata.EMPTY);

                    // voeg toe aan 'hulp tabel'
                    toestandenMet1SymboolVerwijderd.Add(toestandSymboolPair,
                        new SortedSet<string>(connectedStates));
                }
            }

            var startState = new SortedSet<string>(Ndfa.startStates);
            startState.UnionWith(Ndfa.startStates.SelectMany(start => getEpsilonConnectedStates(Ndfa, start)));

            var stateQueue = new Queue<SortedSet<string>>(new[] { startState });

            var dfaDictionary = new Dictionary<ToestandSymbolPair, SortedSet<string>>(new ToestandSymbolPair());
            do
            {
                var toCheckState = stateQueue.Dequeue();
                foreach(var symbol in dfaAlphabet)
                {
                    if (symbol == Automata.EPSILON) continue;
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

                    var isInDfaDict = false;
                    foreach(var state in dfaDictionary.Keys.Select(ToestandSymbolPair => ToestandSymbolPair.toestand))
                    {
                        if (state.SequenceEqual(newState))
                        {
                            isInDfaDict = true;
                            continue;
                        }
                    }
                    if (isInDfaDict) continue;

                    // voeg toe aan dfaDictionary
                    dfaDictionary.Add(new ToestandSymbolPair(toCheckState.ToArray(), symbol), newState);

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

            var dfa = new Automata(new SortedSet<char>(dfaAlphabet));
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

        public static Automata test1()
        {
            var testAutomata = new Automata(new[] { 'x', 'y' });
           
            var beginNode = "1";
            testAutomata.defineAsStartState(beginNode);
            var endNode = "2";
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition(beginNode, 'x', endNode));

            var newAutomata = run(testAutomata);

            if (newAutomata.isDFA(true)) throw new Exception("ndfa to dfa test Failed");
            return newAutomata;
        }

        public static Automata test2()
        {
            var testAutomata = new Automata(new[] { 'x', 'y' });
           
            var beginNode = "1";
            var otherNode = "2";
            var endNode = "3";
            testAutomata.defineAsStartState(beginNode);
            testAutomata.defineAsFinalState(endNode);

            testAutomata.addTransition(new Transition(beginNode, 'x', endNode));
            testAutomata.addTransition(new Transition(beginNode, 'y', otherNode));

            testAutomata.addTransition(new Transition(otherNode, 'x', otherNode));
            testAutomata.addTransition(new Transition(otherNode, 'y', endNode));

            testAutomata.addTransition(new Transition(endNode, 'x', endNode));
            testAutomata.addTransition(new Transition(endNode, 'y', endNode));

            var Dfa = run(testAutomata);
            //if (!Dfa.isDFA()) throw new Exception("ndfa to dfa test Failed");
            return Dfa;
        }
    }
}
