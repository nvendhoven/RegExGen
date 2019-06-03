using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class ThompsonConverter<T> where T : IComparable
    {
        public static int stateNumber = 0;
        public static Automata<T> RegExToAutomata(RegExp regExp)
        {
            Automata<T> automata = new Automata<T>();
            SortedSet<char> symbols = new SortedSet<char>();
            //Nodig: Startpunten, eindpunten, symbolen en alle transities.



            return automata;
        }

        public static SortedSet<Transition<T>> GetTransitions(RegExp regExp)
        {
            SortedSet<Transition<T>> transitions = new SortedSet<Transition<T>>();
            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:
                {
                    //Deze gaat een transitie returnen.
                    Transition<string> trans = new Transition<string>("q"+stateNumber,"q");
                    regExp.GetRegTerminals();//Get the symbols


                } break;    //Laatste item in een arm van de tree
                case RegExp.Operator.PLUS: break;   //herhaal dit stuk volgens de plus wijze
                case RegExp.Operator.STAR: break;   //herhaal dit stuk volgens de keer wijze 
                case RegExp.Operator.OR:
                {
                    //krijg 2 transities, die meer transities bevatten


                } break;     //Dit is een or stuk
                case RegExp.Operator.DOT:
                {
                    //Krijg 1 transitie, die meer tranities bevatten



                } break;    //Dit is een spatie ding
            }

            

            return transitions;
        }


    }
}
