using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace RegExGen
{
    [Serializable]
    public class Automata
    {
        public static readonly char EPSILON = Transition.EPSILON;
        public static readonly String EMPTY = "#";
        public readonly Dictionary<string, string> newNameDictionary = new Dictionary<string, string>();

        // node - edge - node
        public SortedSet<Transition> transitions = new SortedSet<Transition>();

        public SortedSet<string> states {
            get {
                return new SortedSet<string>( 
                    transitions.SelectMany(tr => new[] { tr.toState, tr.fromState }));}
        }
        public SortedSet<string> startStates { get; private set; }
        public SortedSet<string> finalStates { get; private set; } 

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
            transitions.Where(
                transition => transition.symbol == withSymbol 
                && string.Equals(transition.fromState, from.ToString()))
                .Select(transitionWithSymbol => transitionWithSymbol.toState)
            );
        }

        class NoDfaExeption : Exception { public NoDfaExeption(string message) : base(message) { } };

        public bool isDFA(bool throwExeptions = false)
        {
            bool isDFA = true;

            // elke node heeft elk symbool precies 1 keer als uitgaande pijl
            foreach (string from in states)
            {
                foreach (char symbol in symbols)
                {
                    var stateCount = getToStates(from, symbol).Count;
                    isDFA = isDFA && stateCount == 1;

                    if (throwExeptions&& !isDFA) throw new NoDfaExeption("dfa error state: "+ from + " with symbol '"+symbol+ "' has " + stateCount + " connections where 1 was expected");
                    if (!isDFA) return false;
                }
            }

            // geen epsilon overgangen
            isDFA = isDFA && transitions.Any(transitions => transitions.symbol != EPSILON);
            if (throwExeptions && !isDFA) throw new NoDfaExeption(message: "dfa not a dfa has epsilon overgang");

            // geen meerdere start toestanden
            isDFA = isDFA && startStates.Count == 1;
            if (throwExeptions && !isDFA) throw new NoDfaExeption("dfa has more than one start state");

            // geen state heeft geen ingaande pielen behalven start states
            foreach (var state in states.Where(s => !startStates.Contains(s)).ToList())
            {
                isDFA = isDFA && transitions.Select(t => t.toState).Any(s => s == state);
                if (throwExeptions && !isDFA) throw new NoDfaExeption("dfa contains state '" + state + "'with no incoming transitions");
            }

            return isDFA;
        }

        /// <param name="maxWords">the maximum amount of words that need to be generated; 0 = returns all words possible words with a given length</param>
        /// <param name="maxLeght">max word langth. to avoid boring words; 0 = dynamic number</param>
        /// <param name="logByas">if removing words how byas is it towords larger words. Uses a logarithmic scale randNum^logbyas / maxNum. value of 1 = no byas. value of less than 1 is byas towords returning larger words</param>
        public IEnumerable<string> generateInvallidWords(int maxWords = 0, int maxLeght = 0, double logByas = 1.8) 
            => this.getDfa().Not().generateWords(maxWords, maxLeght, logByas);

        /// <param name="maxWords">the maximum amount of words that need to be generated; 0 = returns all words possible words with a given length</param>
        /// <param name="maxLeght">max word langth. to avoid boring words; 0 = dynamic number</param>
        /// <param name="logByas">if removing words how byas is it towords larger words. Uses a logarithmic scale randNum^logbyas / maxNum. value of 1 = no byas. value of less than 1 is byas towords returning larger words</param>
        public IEnumerable<string> generateWords(int maxWords = 0, int maxLeght = 0, double logByas = 1.8)
        {
            var walkableAutomata = getOptimized();

            // for each state that isnt a start state or end state
            foreach (var state in walkableAutomata.states.Where(s => (!startStates.Contains(s) && !finalStates.Contains(s)))
                    .ToList())
                // if all the outgoing transitions of a state
                if (walkableAutomata.transitions.Where(t=> t.fromState == state)
                    // only lead back to itself
                    .All(t => t.toState == state))
                {
                    // it is a fuik and should be removed
                    walkableAutomata.transitions.RemoveWhere(t => t.toState == state || t.fromState == state);
                    walkableAutomata.states.Remove(state);
                }



            var possibleWords = new LinkedList<string>();
            var toCheckQueue = new Queue<Tuple<string, string, int>>();
            if (maxLeght == 0) maxLeght = walkableAutomata.states.Count() * 2;

            toCheckQueue.Enqueue(new Tuple<string, string, int>("",walkableAutomata.startStates.First(),maxLeght));

            do
            {
                var tup = toCheckQueue.Dequeue();
                string currentWord = tup.Item1; string currentState = tup.Item2; int maxWordLength = tup.Item3;
                if (possibleWords.Count > maxWords)
                    break;

                maxWordLength--;
                if (maxWordLength == 0)
                {
                    continue;
                }
                if (walkableAutomata.finalStates.Contains(currentState))
                    possibleWords.AddLast(currentWord);

                foreach (var transition in walkableAutomata.transitions.Where(s => s.fromState == currentState))
                    toCheckQueue.Enqueue(new Tuple<string, string, int>(currentWord + transition.symbol, transition.toState, maxWordLength));
            } while (toCheckQueue.Any());

            var possibleWordsList = possibleWords.OrderBy(word => word.Length).ToList();

            // if words need to be removed
            if(maxWords != 0 && possibleWordsList.Count > maxWords)
            {
                var newList = new List<string>();
                var rnd = new Random();
                for (int i = 0; i < maxWords; i++)
                    //remove words with a bias towards longer words at the end
                    newList.Add(possibleWordsList[i]);
                possibleWordsList = newList;
            }

            return possibleWordsList;
        }

        public override bool Equals(object compare)
        {
            if (!(compare is Automata))
                return false;
            var toCompare = compare as Automata;
            
            foreach (var character in toCompare.getAlphabet())
                if (!symbols.Contains(character))
                    return false;

            toCompare = toCompare.getOptimized().Not().And(this.getOptimized()).getOptimized();
            return toCompare.states.Count == 1;

        }

        public void renameStates()
        {
            newNameDictionary.Clear();

            var statecounter = 0;
            // generate new names
            string generateGetOrSetName(string stateName)
            {
                newNameDictionary.TryGetValue(stateName, out string dictName);
                if(dictName == null)
                {
                    dictName = "N" + statecounter++;
                    newNameDictionary[stateName] = dictName;
                }
                return dictName;
            }

            foreach(var transition in transitions)
            {
                transition.fromState = generateGetOrSetName(transition.fromState);
                transition.toState = generateGetOrSetName(transition.toState);
            }

            foreach(var state in finalStates.ToList())
            {
                finalStates.Add(generateGetOrSetName(state));
                finalStates.Remove(state);
            }

            foreach(var state in startStates.ToList())
            {
                startStates.Add(generateGetOrSetName(state));
                startStates.Remove(state);
            }
        }

        public Automata getOptimized() => Inverse().getDfa().Inverse().getDfa(true);

        public Automata getDfa(bool renameStates = false)
        {
            if (isDFA())
                return this;
            return NdfaToDfa.run(this, renameStates);
        }

        //Function that checks if a word is in the language.
        public bool CheckWord(string word)
        {
            /*
            if (!isDFA())
            {
                throw new Exception("Can't check string on a NDFA");
            }
            */

            bool canwork = false;
            foreach (string startstate in startStates)
            {
                canwork = true;
                CharEnumerator charEnumerator = word.GetEnumerator();
                string currentState = startstate;
                while (charEnumerator.MoveNext())
                {
                    //var transition = Tuple.Create(states, symbol);
                    if (transitions.Any(transitions =>
                        (transitions.symbol == charEnumerator.Current && transitions.fromState == currentState)))
                    {
                        var t = transitions.Where(transitions =>
                            (transitions.symbol == charEnumerator.Current && transitions.fromState == currentState));
                        currentState = t.First().toState;
                        //Er bestaat een transitie van die state naar een andere state
                    }
                    else
                    {
                        canwork = false;
                    }
                }

                if (!finalStates.Contains(currentState))
                {
                    canwork = false;
                }
            }

            return canwork;
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
            if (!isDFA())
            {
                throw new Exception("The automata isn't a DFA");
            }
            Automata returnAutomata = new Automata(this);
            returnAutomata.finalStates = states;
            foreach(string state in finalStates)
            {
                returnAutomata.finalStates.Remove(state);
            }
            return returnAutomata;
        }

        //Returns the AND of the automata.
        public Automata Or(Automata other)
        {
            if ((getAlphabet().Equals(other.getAlphabet())))
            {
                throw new Exception("You cant AND these 2 Automata, because the alphabets are not the same.");
            }

            if (!isDFA() || !other.isDFA())
            {
                throw new Exception("One or both of the automata aren't DFA's");
            }

            //Creat Hulptabellen.
            string[] statesList = states.ToArray();
            char[] letterList = getAlphabet().ToArray();
            string[,] hulpTabel = new string[states.Count, getAlphabet().Count];

            //Hulptabel vullen.
            for (int letter = 0; letter < getAlphabet().Count; letter++)
            {
                for (int state = 0; state < states.Count; state++)
                {
                    hulpTabel[state, letter] = GetDestination(state, letter);
                }
            }

            print2dArray(hulpTabel);

            string[] statesListOther = other.states.ToArray();
            char[] letterListOther = other.getAlphabet().ToArray();
            string[,] hulpTabelOther = new string[other.states.Count, other.getAlphabet().Count];

            //Hulptabel vullen.
            for (int letter = 0; letter < other.getAlphabet().Count; letter++)
            {
                for (int state = 0; state < other.states.Count; state++)
                {
                    hulpTabelOther[state, letter] = other.GetDestination(state, letter);
                }
            }

            print2dArray(hulpTabelOther);

            var result = new SortedSet<Transition>();
            var currentStates = new SortedSet<Tuple<string, string>>();
            bool notDone = true;
            Automata returnAutomata = new Automata();
            returnAutomata.defineAsStartState(startStates.First() + "-" + other.startStates.First()); //Defineer de states die in zowel 1 als 2 start zijn.
            returnAutomata.setAlphabet(getAlphabet());

            currentStates.Add(Tuple.Create(startStates.First(), other.startStates.First()));//Create the first mixed state (0,0)
            //Heb nu beide hulparrays,
            while (result.Count < transitions.Count * other.transitions.Count && notDone)//blijf doorgaan tot het maximum aantal states bereikt is.
            {
                var nextStates = new SortedSet<Tuple<string, string>>();
                foreach (var currentState in currentStates)//Alle huidige states             
                {
                    if (finalStates.Contains(currentState.Item1) || other.finalStates.Contains(currentState.Item2))//check of beide states in hun eigen automaat eindstates zijn.
                    {
                        returnAutomata.defineAsFinalState(currentState.Item1 + "-" + currentState.Item2);
                    }
                    foreach (char symbol in symbols)//ga alle sybolen langs voor de 2 states.
                    {
                        var nextState =
                            new Tuple<string, string>(
                                FindDestinationBasedOnSymbolAndState(hulpTabel, statesList, letterList, currentState.Item1, symbol),
                                FindDestinationBasedOnSymbolAndState(hulpTabelOther, statesListOther, letterListOther, currentState.Item2, symbol)
                                );//De state waar het symbool naartoe gaat.
                        Debug.WriteLine("Found State: " + nextState.Item1 + "-" + nextState.Item2);
                        nextStates.Add(nextState);//Voeg de nieuwe state toe aan de lijst, zodat deze hierna behandeld kan worden.
                        result.Add(new Transition(currentState.Item1 + "-" + currentState.Item2, symbol, nextState.Item1 + "-" + nextState.Item2));
                        Debug.WriteLine("Found Transition: " + currentState.Item1 + "-" + currentState.Item2 + " --> " + symbol + " --> " + nextState.Item1 + "-" + nextState.Item2);
                    }
                }

                if (CompateSets(currentStates, nextStates))
                {
                    notDone = false;
                }
                currentStates = nextStates;
            }



            foreach (var t in result)
            {
                returnAutomata.addTransition(t);
            }

            return returnAutomata;
        }


        //Returns the AND of the automata.
        public Automata And(Automata other)
        {
            if ((getAlphabet().Equals(other.getAlphabet())))
            {
                throw new Exception("You cant AND these 2 Automata, because the alphabets are not the same.");
            }

            if (!isDFA() || !other.isDFA())
            {
                throw new Exception("One or both of the automata aren't DFA's");
            }

            //Creat Hulptabellen.
            string[] statesList = states.ToArray();
            char[] letterList = getAlphabet().ToArray();
            string[,] hulpTabel = new string[states.Count, getAlphabet().Count];
            
            //Hulptabel vullen.
            for (int letter = 0; letter < getAlphabet().Count; letter++)
            {
                for (int state = 0; state < states.Count; state++)
                {
                    hulpTabel[state, letter] = GetDestination(state, letter);
                }
            }

            print2dArray(hulpTabel);

            string[] statesListOther = other.states.ToArray();
            char[] letterListOther = other.getAlphabet().ToArray();
            string[,] hulpTabelOther = new string[other.states.Count,other.getAlphabet().Count];

            //Hulptabel vullen.
            for (int letter = 0; letter < other.getAlphabet().Count; letter++)
            {
                for (int state = 0; state < other.states.Count; state++)
                {
                    hulpTabelOther[state, letter] = other.GetDestination(state, letter);
                }
            }

            print2dArray(hulpTabelOther);



            var result = new SortedSet<Transition>();
            var currentStates = new SortedSet<Tuple<string, string>>();
            bool notDone = true;
            Automata returnAutomata = new Automata();

            returnAutomata.defineAsStartState(startStates.First() + "-" + other.startStates.First()); //Defineer de states die in zowel 1 als 2 start zijn.
            returnAutomata.setAlphabet(getAlphabet());
            currentStates.Add(Tuple.Create(startStates.First(), other.startStates.First()));//Create the first mixed state (0,0)
            //Heb nu beide hulparrays,
            while (result.Count < transitions.Count * other.transitions.Count && notDone)//blijf doorgaan tot het maximum aantal states bereikt is.
            {
                var nextStates = new SortedSet<Tuple<string, string>>();
                foreach (var currentState in currentStates)//Alle huidige states             
                {
                    if (finalStates.Contains(currentState.Item1) && other.finalStates.Contains(currentState.Item2))//check of beide states in hun eigen automaat eindstates zijn.
                    {
                        returnAutomata.defineAsFinalState(currentState.Item1 + "-" + currentState.Item2);
                    }
                    foreach (char symbol in symbols)//ga alle sybolen langs voor de 2 states.
                    {
                        var nextState = 
                            new Tuple<string,string>(
                                FindDestinationBasedOnSymbolAndState(hulpTabel, statesList, letterList,currentState.Item1,symbol),
                                FindDestinationBasedOnSymbolAndState(hulpTabelOther, statesListOther, letterListOther, currentState.Item2, symbol)
                                );//De state waar het symbool naartoe gaat.
                        //Debug.WriteLine("Found State: "+nextState.Item1 + "-" + nextState.Item2);
                        nextStates.Add(nextState);//Voeg de nieuwe state toe aan de lijst, zodat deze hierna behandeld kan worden.
                        result.Add(new Transition(currentState.Item1 + "-" + currentState.Item2, symbol, nextState.Item1 + "-" + nextState.Item2));
                        //Debug.WriteLine("Found Transition: "+ currentState.Item1 + "-" + currentState.Item2 + " --> " +  symbol + " --> " + nextState.Item1 + "-" + nextState.Item2);
                    }
                }

                if (CompateSets(currentStates,nextStates))
                {
                    notDone = false;
                }
                currentStates = nextStates;
            }



            foreach (var t in result)
            {
                returnAutomata.addTransition(t);
            }

            return returnAutomata;
        }

        public bool CompateSets(SortedSet<Tuple<string,string>> s1, SortedSet<Tuple<string, string>> s2)
        {
            if (s1.Count != s2.Count)
            {
                return false;
            }

            for (int i = 0; i < s1.Count; i++)
            {
                if (s1.ToArray()[i].Item1 != s2.ToArray()[i].Item1 ||
                    s1.ToArray()[i].Item1 != s2.ToArray()[i].Item1)
                {
                    return false;
                }
            }


            return true;
        }

        public string FindDestinationBasedOnSymbolAndState(string[,] hulptable,string[] stateTable, char[] symbolTable,string fromState, char symbol)
        {
            if (fromState == EMPTY)
            {
                return EMPTY;
            }
            int indexOfState = -1;
            int indexOfSymbol = -1;

            int stateLenght = stateTable.GetLength(0);
            for (int i = 0; i < stateLenght; i++)
            {
                if (stateTable[i] == fromState)
                {
                    indexOfState = i;
                }
            }

            int symbolLenght = symbolTable.GetLength(0);
            for (int i = 0; i < symbolLenght; i++)
            {
                if (symbolTable[i] == symbol)
                {
                    indexOfSymbol = i;
                }
            }

            if (indexOfState >= 0 && indexOfSymbol >= 0)
                return hulptable[indexOfState, indexOfSymbol];
            throw new Exception("Cant find state");
        }

        public void print2dArray(string[,] arr)
        {
            //long[,] arr = new long[5, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 }, { 3, 3, 3, 3 }, { 4, 4, 4, 4 } };

            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        public string GetDestination(int state, int letter)
        {
            //Zoek de state op die bij het nummer hoort
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
                    //Will enter this if once for every letter in the alphabet.
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
                    savedLetter = t;
                }

                previousLetter = t;
            }

            Debug.Write("Destination for: "+ savedState + " -> " + savedLetter + "-> ");
            var transition = transitions.Where(Transition => (Transition.fromState == savedState && Transition.symbol == savedLetter));
            string toState;

            if (transition.Count() > 0)
                toState = transition.First().toState;
            else
                toState = EMPTY;

            Debug.Write(toState+"\n");

            return toState;
        }

    }
}
