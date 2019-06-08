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

            var dfaAlphabet = Ndfa.getAlphabet().Where(symbol => symbol != Automata.EPSILON );

            //voeg foute state toe
            foreach (var symbol in dfaAlphabet)
                toestandenMet1SymboolVerwijderd.Add(
                    key: new ToestandSymbolPair(new[] {Automata.EMPTY }, symbol),
                    value: new SortedSet<string>(new[] {Automata.EMPTY}));


            //construeer hulptabel
            foreach (var state in Ndfa.states)
            {
                foreach (var symbol in dfaAlphabet)
                {
                    // maak nieuwe key
                    var toestandSymboolPair = new ToestandSymbolPair(new[] {state}, symbol);

                    //check of er epsilon connecties zijn
                    var fistEpsilonConnectedStates = getEpsilonConnectedStates(Ndfa, state).ToList();
                    fistEpsilonConnectedStates.Add(state);

                    //gebuik epsilon connected states en huidige state voor checken next state
                    SortedSet<string> connectedStates = new SortedSet<string>();
                    foreach(var connectedstate in fistEpsilonConnectedStates)
                        connectedStates.UnionWith(Ndfa.getToStates(connectedstate, symbol));

                    //voeg symbol epsion connected state toe vanaf berijkte symbols
                    foreach (var letterConnectedState in connectedStates.ToList())
                        connectedStates.UnionWith(getEpsilonConnectedStates(Ndfa, letterConnectedState));

                    // als verzameling leeg is een leege state aanmaken
                    if (connectedStates.Count == 0) connectedStates.Add(Automata.EMPTY);

                    // voeg toe aan 'hulp tabel'
                    toestandenMet1SymboolVerwijderd.Add(toestandSymboolPair,
                        new SortedSet<string>(connectedStates));
                }
            }


            
            // add starting states from Ndfa as one state
            var startState = new SortedSet<string>(Ndfa.startStates);
            // add epsilon connected states to state
            startState.UnionWith(
                Ndfa.startStates.SelectMany(start => getEpsilonConnectedStates(Ndfa, start)));

            // define naming function
            string makeStateName(SortedSet<string> state)
            {
                var name = "N";
                foreach (var partName in state)
                    name += "" +(partName).ToString() + ",";
                return name + "";
            }

            // start a new queue with the starting states
            var stateQueue = new Queue<SortedSet<string>>(new[] { startState });

            // start a list with complex states to define end state later on
            // todo optimize
            // var complexStateList = new List<SortedSet<string>>();

            // make new dfa
            var dfa = new Automata(new SortedSet<char>(dfaAlphabet));
            var checkedStates = new List<string>();
            // define start state in dfa
            dfa.startStates.Add(makeStateName(startState));
            do
            {
                var toCheckState = stateQueue.Dequeue();
                // check for every possible symbol in ndfa behalve epsilon
                foreach(var symbol in dfaAlphabet)
                {
                    // kijk waar de state naartoe wijst en sla deze op
                    var newState = new SortedSet<string>(
                        // per 'compound' state check where it leads in original automata with given symbol and build a new state out of it
                        toCheckState.SelectMany(state =>{
                        if (toestandenMet1SymboolVerwijderd.TryGetValue(
                            //maak nieuwe toestand als key
                            new ToestandSymbolPair(new[] { state }, symbol),
                            out var toValue))
                        {
                            return toValue;
                        }
                        else throw new KeyNotFoundException("single symbol not found in 'hulp tabel'");}));

                    var newStateName = makeStateName(newState);

                    // voeg toe aan dfa
                    dfa.addTransition(new Transition(
                            makeStateName(toCheckState),
                            symbol,
                            newStateName));

                    // als nieuwe stat al in dfa staat verder niets doen.
                    if (checkedStates.Any(visitedState => visitedState == newStateName))
                        continue;
                    checkedStates.Add(newStateName);

                    // voeg toe in de queue
                    stateQueue.Enqueue(newState);

                    //complexStateList.Add(newState);
                    if (newState.Any(statePart => Ndfa.finalStates.Contains(statePart)))
                        dfa.finalStates.Add(newStateName);
                }
            } while (stateQueue.Any());

            //var dfaEndStates = complexStateList.Where(state =>
            //    state.Any(statePart => 
            //        Ndfa.finalStates.Contains(statePart)
            //        )
            //    ).Select(state => makeStateName(state));

            //dfa.finalStates.UnionWith(dfaEndStates);

            //var dfaEndStates = Ndfa.finalStates.SelectMany(
            //   finalState => complexStateList.Where(
            //       complexState => complexState.Any(
            //          partComplexState => partComplexState == finalState)));

            dfa.isDFA(true);
            return dfa;
        }

        private static IEnumerable<string> getEpsilonConnectedStates(Automata Ndfa, string stateToStart)
        {
            var conectedStates = Ndfa.getToStates(stateToStart, Automata.EPSILON);
            if (conectedStates.Any())
                return conectedStates.Union(
                    conectedStates.SelectMany(state => getEpsilonConnectedStates(Ndfa, state))).ToList();
            else return conectedStates;
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
