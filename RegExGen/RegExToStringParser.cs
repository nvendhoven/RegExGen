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
            //Doe haakjes als er een OR is of als er een & is gevolgd door
            if (regExp.GetLeftRegExp() != null && (
                CheckDOT(regExp)
                ))
                output += "(" + TreeToString(regExp.GetLeftRegExp()) + ")";
            else if (regExp.GetRegOperator() == RegExp.Operator.OR)
            {
                output += "(" + TreeToString(regExp.GetLeftRegExp());
            }
            else if (regExp.GetLeftRegExp() != null)
                output += TreeToString(regExp.GetLeftRegExp());

            output += savedSymbol;

            if (regExp.GetRightRegExp() != null && (
                CheckDOT(regExp)
                ))
                output += "(" + TreeToString(regExp.GetRightRegExp()) + ")";
            else if (regExp.GetRightRegExp() != null)
                output += TreeToString(regExp.GetRightRegExp());


            if (regExp.GetRegOperator() == RegExp.Operator.OR)
            {
                output += ")";
            }

            return output;
        }

        //Returns True when it should be placing a ( and )
        public static bool CheckDOT(RegExp r)
        {
            if (r.GetRegOperator() == RegExp.Operator.ONE)//Only normal parts, so don't place ( and )
                return false;
            if (r.GetRegOperator() == RegExp.Operator.DOT)//And and, should only place a ( and a ) if
                return false;//CheckDOT(r.GetLeftRegExp()) && CheckDOT(r.GetRightRegExp());
            if (r.GetRegOperator() == RegExp.Operator.STAR)
                return r.GetLeftRegExp().GetRegOperator() != RegExp.Operator.ONE && r.GetLeftRegExp().GetRegOperator() != RegExp.Operator.OR; //r.GetLeftRegExp().GetRegOperator() == RegExp.Operator.DOT; //|| r.GetLeftRegExp().GetRegOperator() == RegExp.Operator.PLUS;//true; //als deze gevolgd word door een plus of ster, dan haakjes, anders niet
            if (r.GetRegOperator() == RegExp.Operator.PLUS)
                return r.GetLeftRegExp().GetRegOperator() != RegExp.Operator.ONE && r.GetLeftRegExp().GetRegOperator() != RegExp.Operator.OR; //false als er alleen 1 letter aan vast zit, anders doe true;
            if (r.GetRegOperator() == RegExp.Operator.OR)
                return false;
            else
                return false;
        }

    }
}
