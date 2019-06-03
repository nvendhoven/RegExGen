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

        private SortedSet<string> startStates;
        private SortedSet<string> finalStates;
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
            state endState = statenumber + 1;


            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:
                {
                        if (regExp.GetRegTerminals().Length == 1)//Als het maar 1 character is, maak dan 1 transitie.
                        {
                            Transition trans = new Transition(startState.ToString(), regExp.GetRegTerminals().ToCharArray()[0], endState.ToString());
                            finalStates.Add(endState.ToString());
                        }
                        else if (regExp.GetRegTerminals().Length > 1) //Als het meer dan 1 character is, maak dan voor elk character een transitie.
                        {
                            foreach (char c in regExp.GetRegTerminals())
                            {
                                transitions.Add(new Transition(startState.ToString(), c, endState.ToString()));

                                startState = endState;
                                endState = startState + 1;
                            }
                            statenumber = endState;
                        }
                        else//Nu gaat het fout
                        {
                            throw new Exception("Thompson conversie messed up.");
                        }
                    } break;    //Laatste item in een arm van de tree
                case RegExp.Operator.PLUS: 
                    {
            

                    } break;  //herhaal dit stuk volgens de plus wijze
                case RegExp.Operator.STAR:
                    {

            
                    } break;   //herhaal dit stuk volgens de keer wijze 
                case RegExp.Operator.OR:
                    {
                        //Add all transitions from left part of the or
                        transitions.UnionWith(GetTransitions(regExp.GetLeftRegExp()));


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
