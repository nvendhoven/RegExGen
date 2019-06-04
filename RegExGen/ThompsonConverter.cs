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
                        //Save the start state so it can later be used to create an epsilon transiton for the OR's
                        startState = statenumber;

                        //Add transition from start point to the first state of the first OR
                        statenumber++;
                        transitions.Add(new Transition(startState.ToString(), statenumber.ToString()));

                        //Add all transitions from left part of the or
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));

                        //Save the last state of the first OR so it can later be used to create an epsilon transiton for the OR's
                        state lastStateOfFirstOR = statenumber;

                        //Ad transition from start point to the first state of the second OR
                        statenumber++;
                        transitions.Add(new Transition(startState.ToString(), statenumber.ToString()));

                        //Add all transitions from right part of the or
                        transitions.UnionWith(GetTransitions(regExp.GetRightRegExp()));

                        //Save the last state of the second OR so it can later be used to create an epsilon transiton for the OR's
                        state lastStateOfSecondOR = statenumber;

                        //Close the OR again
                        statenumber++;
                        transitions.Add(new Transition(lastStateOfFirstOR.ToString(), statenumber.ToString()));
                        transitions.Add(new Transition(lastStateOfSecondOR.ToString(), statenumber.ToString()));


                    } break;     //Dit is een or stuk
                case RegExp.Operator.DOT:
                    {
                        //Get the transitions of the first part and the second part.
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));
                        transitions.UnionWith(GetTransitions(regExp.GetRightRegExp()));
                    } break;    //Dit is een spatie ding
            }
            return transitions;
        }
    }
}
