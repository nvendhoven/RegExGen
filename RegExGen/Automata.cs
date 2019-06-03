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
        private SortedSet<Transition> transitions;

        private SortedSet<string> states;
        private SortedSet<string> startStates;
        private SortedSet<string> finalStates;
        // alphabet
        private SortedSet<char> symbols;

        public Automata()
        {
            transitions = new SortedSet<Transition>();
            states = new SortedSet<string>();
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(new SortedSet<char>());
        }

        public Automata(char[] s)
        {
            transitions = new SortedSet<Transition>();
            states = new SortedSet<string>();
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(new SortedSet<char>(s.ToList()));
        }

        public Automata(SortedSet<char> symbols)
        {
            transitions = new SortedSet<Transition>();
            states = new SortedSet<string>();
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
        /*
        public bool isDFA()
        {
            bool isDFA = true;

            foreach (string from in states)
            {
                foreach (char symbol in symbols)
                {
                    isDFA = isDFA && getToStates(from, symbol).size() == 1;
                }
            }

            return isDFA;
        }
        */






    }
}
