using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class Automata
    {
        public static readonly char EPSILON = Transition.EPSILON;
        public static readonly String EMPTY = "#";

        // node - edge - node
        public SortedSet<Transition> transitions = new SortedSet<Transition>();

        public SortedSet<string> states {
            get {
                return new SortedSet<string>( 
                    transitions.SelectMany(tr => new[] { tr.toState, tr.fromState }));}
        }
        public SortedSet<string> startStates { get; }
        public SortedSet<string> finalStates { get; } 

        // alphabet
        public SortedSet<char> symbols;

        public Automata()
        {
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(new SortedSet<char>());
        }

        public Automata(char[] s)
        {
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(new SortedSet<char>(s.ToList()));
        }

        public Automata(SortedSet<char> symbols)
        {
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(symbols);
        }

        public void setAlphabet(char[] s)
        {
            this.setAlphabet(new SortedSet<char>(s.ToList()));
        }

        public void setAlphabet(SortedSet<char> symbols)
        {
            this.symbols = symbols;
        }

        public SortedSet<char> getAlphabet()
        {
            return symbols;
        }

        public void addTransition(Transition t)
        {
            transitions.Add(t);
            states.Add(t.fromState);
            states.Add(t.toState);
            symbols.Add(t.symbol);
        }

        public void defineAsStartState(string t)
        {
            // if already in states no problem because a Set will remove duplicates.
            startStates.Add(t);
        }

        public void defineAsFinalState(string t)
        {
            // if already in states no problem because a Set will remove duplicates.
            finalStates.Add(t);
        }

        public void printTransitions()
        {

            foreach(Transition t in transitions)
            {
                Debug.WriteLine(t.ToString());
            }
        }

        public SortedSet<string> getToStates(string from, char withSymbol)
        {
            return new SortedSet<string>(
            transitions.Where(
                transition => transition.symbol == withSymbol 
                && string.Equals(transition.fromState, from.ToString()))
                .Select(transitionWithSymbol => transitionWithSymbol.toState)
            );
        }

        class NoDfaExeption : Exception { public NoDfaExeption(string message) : base(message) { } };
        public bool isDFA(bool throwExeptions = true)
        {
            bool isDFA = true;

            // elke node heeft elk symbool precies 1 keer als uitgaande pijl
            foreach (string from in states)
            {
                foreach (char symbol in symbols)
                {
                    var stateCount = getToStates(from, symbol).Count;
                    isDFA = isDFA && stateCount == 1;
                    if (throwExeptions&& !isDFA) throw new NoDfaExeption("state: "+ from + " with symbol '"+symbol+ "' has " + stateCount + " connections");
                    if (!isDFA) return false;
                }
            }

            // geen epsilon overgangen
            isDFA = isDFA && transitions.Any(transitions => transitions.symbol != EPSILON);
            if (throwExeptions && !isDFA) throw new NoDfaExeption(message: "not a dfa has epsilon overgang");

            // geen meerdere start toestanden
            isDFA = isDFA && startStates.Count > 1;
            if (throwExeptions && !isDFA) throw new NoDfaExeption("has more than one state");
            return isDFA;
        }
    }
}
