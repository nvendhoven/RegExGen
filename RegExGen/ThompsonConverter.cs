using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class ThompsonConverter
    {
        public static int stateNumber = 0;

        public static Automata RegExToAutomata(RegExp regExp)
        {
            Automata automata = new Automata();
            SortedSet<char> symbols = new SortedSet<char>();
            SortedSet<Transition> transitions = new SortedSet<Transition>();
            SortedSet<string> startStates = new SortedSet<string>();
            SortedSet<string> finalStates = new SortedSet<string>(); 
            //Nodig: Startpunten, eindpunten, symbolen en alle transities.

            return automata;
        }
/*
//($ | a*b)
public static SortedSet<Transition> GetTransitions(RegExp regExp, string state)
{
    SortedSet<Transition> transitions = new SortedSet<Transition>();
    switch (regExp.GetRegOperator())
    {
        case RegExp.Operator.ONE:
        {
            string startstate = state;
            if (regExp.GetRegTerminals().Length == 1)//Als het maar 1 character is, maak dan 1 transitie.
            {
                Transition trans = new Transition(startstate, regExp.GetRegTerminals().ToCharArray()[0], endstate);
            }
            else if (regExp.GetRegTerminals().Length > 1) //Als het meer dan 1 character is, maak dan voor elk character een transitie.
            {
                foreach (char c in regExp.GetRegTerminals().ToCharArray())
                {
                    transitions.Add(new Transition(startstate, regExp.GetRegTerminals().ToCharArray()[0],endstate));
                    startstate = endstate;
                }
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
            

        } break;     //Dit is een or stuk
        case RegExp.Operator.DOT:
        {
            


        } break;    //Dit is een spatie ding
    }

    

    return transitions;
}
*/
}
}
