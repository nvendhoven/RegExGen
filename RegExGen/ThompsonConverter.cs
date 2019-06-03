using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class ThompsonConverter<T> where T : IComparable
    {
        public static Automata<T> RegExToAutomata(RegExp regExp)
        {
            //krijg een input

            //Pak eerst expressie type
            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE: break;    //Laatste item in een arm van de tree
                case RegExp.Operator.PLUS: break;   //herhaal dit stuk volgens de plus wijze
                case RegExp.Operator.STAR: break;   //herhaal dit stuk volgens de keer wijze 
                case RegExp.Operator.OR: break;     //Dit is een or stuk
                case RegExp.Operator.DOT: break;    //Dit is een spatie ding
            }
            
            return null;
        }

    }
}
