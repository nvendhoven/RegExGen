using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class Automata
    {
        // node - edge - node
        private SortedSet<Transition> transitions = new SortedSet<Transition>();

        private SortedSet<string> states {
            get {
                return new SortedSet<string>( 
                    transitions.SelectMany(tr => new[] { tr.toState, tr.fromState }));}
        }
        private SortedSet<string> startStates;
        private SortedSet<string> finalStates; 
        // alphabet
        private SortedSet<char> symbols;

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
            states.Add(t.getFromState());
            states.Add(t.getToState());
        }

        public void defineAsStartState(string t)
        {
            // if already in states no problem because a Set will remove duplicates.
            states.Add(t);
            startStates.Add(t);
        }

        public void defineAsFinalState(string t)
        {
            // if already in states no problem because a Set will remove duplicates.
            states.Add(t);
            finalStates.Add(t);
        }

        public void printTransitions()
        {

            foreach(Transition t in transitions)
            {
                Debug.WriteLine(t);
            }
        }

        public SortedSet<string> getToStates(string from, char withSymbol)
        {
            return new SortedSet<string>(
            transitions.Where(transition => transition.symbol == withSymbol)
                .Select(transitionWithSymbol => transitionWithSymbol.getToState())
            );
        }

        public bool isDFA()
        {
            bool isDFA = true;

            // elke node heeft elk symbool precies 1 keer als uitgaande pijl
            foreach (string from in states)
            {
                foreach (char symbol in symbols)
                {
                    isDFA = isDFA && getToStates(from, symbol).Count == 1;
                    if (!isDFA) return false;
                }
            }

            // geen epsilon overgangen
            isDFA = isDFA && transitions.Any(transitions => transitions.symbol != Transition.EPSILON);
            return isDFA;
        }
    }
}
