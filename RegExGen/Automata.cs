using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class Automata<T> where T : IComparable
    {
        // node - edge - node
        public SortedSet<Transition<T>> transitions = new SortedSet<Transition<T>>();

        public SortedSet<T> states {
            get {
                return new SortedSet<T>( 
                    transitions.SelectMany(tr => new[] { tr.toState, tr.fromState }));}
        }
        public SortedSet<T> startStates { get; }
        public SortedSet<T> finalStates { get; }
        // alphabet
        private SortedSet<char> symbols;

        public Automata()
        {
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
            this.setAlphabet(new SortedSet<char>());
        }

        public Automata(char[] s)
        {
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
            this.setAlphabet(new SortedSet<char>(s.ToList()));
        }

        public Automata(SortedSet<char> symbols)
        {
            startStates = new SortedSet<T>();
            finalStates = new SortedSet<T>();
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

        public void addTransition(Transition<T> t)
        {
            transitions.Add(t);
            states.Add(t.fromState);
            states.Add(t.toState);
        }

        public void defineAsStartState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            startStates.Add(t);
        }

        public void defineAsFinalState(T t)
        {
            // if already in states no problem because a Set will remove duplicates.
            finalStates.Add(t);
        }

        public void printTransitions()
        {

            foreach(Transition<T> t in transitions)
            {
                Debug.WriteLine(t);
            }
        }

        public SortedSet<T> getToStates(T from, char withSymbol)
        {
            return new SortedSet<T>(
            transitions.Where(transition => transition.symbol == withSymbol)
                .Select(transitionWithSymbol => transitionWithSymbol.toState)
            );
        }

        public bool isDFA()
        {
            bool isDFA = true;

            // elke node heeft elk symbool precies 1 keer als uitgaande pijl
            foreach (T from in states)
            {
                foreach (char symbol in symbols)
                {
                    isDFA = isDFA && getToStates(from, symbol).Count == 1;
                    if (!isDFA) return false;
                }
            }

            // geen epsilon overgangen
            isDFA = isDFA && transitions.Any(transitions => transitions.symbol != Transition<T>.EPSILON);

            // geen meerdere start toestanden
            isDFA = isDFA && startStates.Count > 1; 
            return isDFA;
        }
    }
}
