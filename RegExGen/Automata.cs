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
        // node - edge - node
        public SortedSet<Transition> transitions = new SortedSet<Transition>();

        public SortedSet<string> states {
            get {
                return new SortedSet<string>( 
                    transitions.SelectMany(tr => new[] { tr.toState, tr.fromState }));}
        }
        public SortedSet<string> startStates;
        public SortedSet<string> finalStates;
        // alphabet
        public SortedSet<char> symbols;

        public Automata()
        {
            startStates = new SortedSet<string>();
            finalStates = new SortedSet<string>();
            this.setAlphabet(new SortedSet<char>());
        }

        public Automata(Automata newAutomata)
        {
            transitions = newAutomata.transitions; 
            startStates = newAutomata.startStates;
            finalStates = newAutomata.finalStates;
            symbols = newAutomata.symbols;
            //states = newAutomata.states;
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
            transitions.Where(transition => transition.symbol == withSymbol)
                .Select(transitionWithSymbol => transitionWithSymbol.toState)
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

            // geen meerdere start toestanden
            isDFA = isDFA && startStates.Count > 1; 
            return isDFA;
        }

        public Automata Inverse()
        {
            Automata returnAutomata = new Automata(this);
            returnAutomata.startStates = finalStates;
            returnAutomata.finalStates = startStates;
            returnAutomata.transitions = GetInverseTransitions();
            return returnAutomata;
        }

        public SortedSet<Transition> GetInverseTransitions()
        {
            SortedSet<Transition> inverseTransitions = new SortedSet<Transition>();
            foreach (Transition t in transitions)
            {
                inverseTransitions.Add(new Transition(t.toState, t.symbol, t.fromState));
            }
            return inverseTransitions;
        }

        //Returns the NOT of the automata.
        public Automata Not()
        {
            Automata returnAutomata = new Automata(this);
            returnAutomata.startStates = finalStates;
            returnAutomata.finalStates = startStates;
            return returnAutomata;
        }

        //Returns the AND of the automata.
        public Automata And(Automata other)
        {
            //Creat Hulptabellen.
            string[,] hulpTabel = new string[states.Count, getAlphabet().Count];
            
            //Hulptabel vullen.
            for (int letter = 0; letter < getAlphabet().Count; letter++)
            {
                for (int state = 0; state < states.Count; state++)
                {
                    hulpTabel[state, letter] = GetDestination(state, letter);
                }
            }



            //string[,] hulpTabelOther = new string[other.states.Count,other.getAlphabet().Count];



            return this;
        }

        public string GetDestination(int state, int letter)
        {
            //Zoek de state op die bij het nummer hoort
            string previousState = transitions.First().fromState;
            int stateCounter = 0;
            string savedState = "";
            foreach (Transition t in transitions)
            {
                if (stateCounter == state)
                {
                    savedState = t.fromState;
                }

                if (!t.fromState.Equals(previousState))
                {
                    stateCounter++;
                }
                previousState = t.fromState;
            }

            //Zoek de letter op die bij het nummer hoort.
            char previousLetter = transitions.First().symbol;
            int letterCounter = 0;
            char savedLetter = ' ';
            foreach (char t in symbols)
            {
                if (letterCounter == letter)
                {
                    savedLetter = t;
                }

                if (!t.Equals(savedLetter))
                {
                    letterCounter++;
                }
                savedLetter = t;
            }


            transitions.Where(Transition => Transition.fromState == state.ToString());



            return null;
        }

        //Returns the OR of the automata.
        public Automata Or(Automata other)
        {
            return this;
        }

    }
}
