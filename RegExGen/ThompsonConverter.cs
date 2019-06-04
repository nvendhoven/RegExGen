using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using state = System.Int32;

namespace RegExGen
{
    class ThompsonConverter
    {
        public state statenumber = 0;

        public Automata RegExToAutomata(RegExp regExp)
        {
            Automata automata = new Automata();
            //Nodig: Startpunten, eindpunten, symbolen en alle transities.
            automata.defineAsStartState(statenumber.ToString());
            SortedSet<Transition> transitions = GetTransitions(regExp);
            automata.defineAsFinalState(statenumber.ToString());
            foreach (Transition t in transitions)
            {
                automata.addTransition(t);
            }

            return automata;
        }

        //($ | a*b)
        public SortedSet<Transition> GetTransitions(RegExp regExp)
        {
            SortedSet<Transition> transitions = new SortedSet<Transition>();
            state startState = statenumber;
            


            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:           //Laatste item in een arm van de tree
                    {
                        state endState = statenumber;
                        if (regExp.GetRegTerminals().Length >= 1)
                        {
                            foreach (char c in regExp.GetRegTerminals())
                            {
                                startState = endState;
                                endState = startState + 1;
                                transitions.Add(new Transition(startState.ToString(), c, endState.ToString()));
                            }
                            statenumber = endState; //set last used state as state number
                        }
                        else
                        {
                            throw new Exception("Thompson conversie messed up.");
                        }
                    } break;    
                case RegExp.Operator.PLUS:
                    {
                        //Save the start state so it can later be used to create an epsilon transiton from the endstate to the startstate.
                        startState = statenumber;

                        //Add all transitions from left part, only left side is used with the PLUS operator.
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));

                        //Add a transiton from the endstate to the startstate.
                        transitions.Add(new Transition(statenumber.ToString(), startState.ToString()));

                    } break;  //herhaal dit stuk volgens de plus wijze
                case RegExp.Operator.STAR:
                    {
                        //Save the start state so it can later be used to create an epsilon transiton from the endstate to the startstate.
                        startState = statenumber; //0

                        //Create an epsilon transiton from start to first state of the inside of STAR.
                        statenumber++;//1
                        transitions.Add(new Transition(statenumber.ToString(), startState.ToString()));//T1

                        //Save the start of the inside of the STAR, so we can create a epsilon transition later.
                        state startStateOfInsideSTAR = statenumber;//1

                        //Add all transitions from the inside of STAR, only left side is used with the STAR operator.
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));

                        //Save the end of the inside of the STAR, so we can create a epsilon transition later.
                        state endStateOfInsideSTAR = statenumber;//2

                        //Create an epsilon transition from the end of the inside of STAR, to the start of the inside of STAR.
                        transitions.Add(new Transition(endStateOfInsideSTAR.ToString(), startStateOfInsideSTAR.ToString()));

                        //Create an epsilon transition from the end of the inside of STAR, to the end of the STAR.
                        statenumber++;//3
                        transitions.Add(new Transition(endStateOfInsideSTAR.ToString(), statenumber.ToString()));

                        //Create an epsilon transition from the start of STAR, to the end of the STAR.
                        transitions.Add(new Transition(startState.ToString(), statenumber.ToString()));
                    }
                    break;   //herhaal dit stuk volgens de keer wijze 
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
