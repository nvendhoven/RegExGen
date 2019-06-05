using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class RegExParser
    {
        public static RegExp ParseRegExp(string regExpString)
        {
            RegExp regExp;
            regExpString = regExpString.Trim();
            //Loop through all characters of a regEx
            foreach (char c in regExpString)
            {
                switch (c)
                {
                    //case '(': break;
                    //case ')': break;
                    case '+': break;//doPlus
                    case '*': break;//doStar
                    case '|': break;//doOr
                    default:
                    {
                        //c is een char


                    } break; //itsALetter

                }
                





            }
            return null;
        }

    }
}
