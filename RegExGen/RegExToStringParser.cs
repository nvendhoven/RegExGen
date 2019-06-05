using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class RegExToStringParser
    {
        public string Parse(RegExp regExp)
        {
            /*
            string output = "";
            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:
                    {
                        output += "";
                    }
                    break;
                case RegExp.Operator.PLUS:
                    {
                        output += ".";
                    }
                    break;  
                case RegExp.Operator.STAR:
                    {
                        output += ".";
                    }
                    break;   
                case RegExp.Operator.OR:
                    {
                        output += ".";
                    }
                    break;     
                case RegExp.Operator.DOT:
                {

                    //output += Parse() + ".";
                }
                    break;
            }


            return output;
            */
            return TreeToString(regExp);
        }

        public string TreeToString(RegExp regExp)
        {
            string output = "";
            string savedSymbol = "";
            switch (regExp.GetRegOperator())
            {
                case RegExp.Operator.ONE:
                    output += regExp.GetRegTerminals();//als het deze wordt dan moeten er geen haakjes voor;
                    break;
                case RegExp.Operator.OR:
                    savedSymbol += "|";
                    break;
                case RegExp.Operator.DOT:
                    //output += ".";
                    break;
                case RegExp.Operator.PLUS:
                    savedSymbol = "+";
                    break;
                case RegExp.Operator.STAR:
                    savedSymbol =  "*";
                    break;
            }

            if (regExp.GetLeftRegExp() != null && regExp.GetLeftRegExp().GetRegOperator() == RegExp.Operator.ONE)
                output += TreeToString(regExp.GetLeftRegExp());
            else if(regExp.GetLeftRegExp() != null)
                output += "(" + TreeToString(regExp.GetLeftRegExp()) + ")";


            output += savedSymbol;

            if (regExp.GetRightRegExp() != null && regExp.GetRightRegExp().GetRegOperator() == RegExp.Operator.ONE)
                output += TreeToString(regExp.GetRightRegExp());
            else if (regExp.GetRightRegExp() != null)
                output += "(" + TreeToString(regExp.GetRightRegExp()) + ")";//() not neccesery on right, only on left, and only if it is followed by an operator.

            

            return output;
        }

    }
}
