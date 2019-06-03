using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using state = System.Int32;

namespace RegExGen
{
    class ThompsonConverter
    {
        public state statenumber = 0;

        private SortedSet<string> startStates = new SortedSet<string>();
        private SortedSet<string> finalStates = new SortedSet<string>();
        SortedSet<char> symbols = new SortedSet<char>();
        SortedSet<Transition> _transitions = new SortedSet<Transition>();

        public Automata RegExToAutomata(RegExp regExp)
        {
            Automata automata = new Automata();
            //Nodig: Startpunten, eindpunten, symbolen en alle transities.
            SortedSet<Transition> v = GetTransitions(regExp);
            return automata;
        }

        //($ | a*b)
        public SortedSet<Transition> GetTransitions(RegExp regExp)
        {
            SortedSet<Transition> transitions = new SortedSet<Transition>();
            state startState = statenumber;
            state endState = statenumber;


            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:           //Laatste item in een arm van de tree
                    {
                        if (regExp.GetRegTerminals().Length >= 1)
                        {
                            foreach (char c in regExp.GetRegTerminals())
                            {
                                startState = endState;
                                endState = startState + 1;
                                transitions.Add(new Transition(startState.ToString(), c, endState.ToString()));
                            }
                            finalStates.Add(endState.ToString());
                            statenumber = endState; //set last used state as state number
                        }
                        else
                        {
                            throw new Exception("Thompson conversie messed up.");
                        }
                    } break;    
                case RegExp.Operator.PLUS: 
                    {
                        

                    } break;  //herhaal dit stuk volgens de plus wijze
                case RegExp.Operator.STAR:
                    {

            
                    } break;   //herhaal dit stuk volgens de keer wijze 
                case RegExp.Operator.OR:
                    {
                        //Add all transitions from left part of the or
                        //Add epsilon form this state to start state of the left part
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));
                        //After getting all transitions of top part, add another epsilon from end of the previous thingy to ending node of this thing.




                        //Add all transitions from right part of the or
                        transitions.UnionWith(GetTransitions(regExp.GetRightRegExp()));


                    } break;     //Dit is een or stuk
                case RegExp.Operator.DOT:
                    {
                        //We willen alle transitons van links en van rechts.
                        //transitions.Add(GetTransitions());


                    } break;    //Dit is een spatie ding
            }
            return transitions;
        }
    }
}
