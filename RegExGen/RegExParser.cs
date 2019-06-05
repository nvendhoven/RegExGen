using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    public class RegExParser
    {
        public static string data;
        public static int index = 0;

        public static RegExp GetRegEx(string regExString)
        {
            data = AppendString(regExString);
            index = 0;
            return OrCheck();
        }

        public static string AppendString(string input)
        {
            string output = "";
            input = input.Replace(" ", string.Empty);
            CharEnumerator current, next;
            current = input.GetEnumerator();
            next = input.GetEnumerator();
            next.MoveNext();
            while (current.MoveNext())
            {
                output += current.Current;
                if (next.MoveNext() && (char.IsLetterOrDigit(current.Current) || current.Current == ')' || current.Current == '+' || current.Current == '*') && char.IsLetterOrDigit(next.Current))
                {
                    output += ".";//plaats een DOT achter de letters, sluitende haakjes, plusjes en sterretjes.
                }
            }
            return output;
        }

        public static char Peek()
        {
            return (index < data.Length) ? data[index] : '\0';
        }

        public static char Pop()
        {
            char current = Peek();

            if (index < data.Length)
                ++index;

            return current;
        }

        public static int Position()
        {
            return index;
        }

        //Returnt een RegEx met een letter.
        public static RegExp Character()
        {
            char data = Peek();// kijk naar de volgende letter

            if (char.IsLetterOrDigit(data) || data == '\0')
            {
                return new RegExp(Pop().ToString());
            }
            else
            {
                throw new SyntaxErrorException("Parse error: expected letter or number, got " + Peek() + " at " + Position());
            }
        }

        public static RegExp StarPlusCheck()
        {
            //Doe linkerkant van de expressie;
            RegExp left = HookCheck();

            //Indien er een STAR is, geef dan een star terug.
            if (Peek() == '*')
            {
                Pop();

                return left.star();
            }
            //indien er een PLUS is, geef dan een plus terug.
            else if (Peek() == '+')
            {
                Pop();

                return left.plus();
            }
            else
                return left;
        }

        public static RegExp DotCheck()
        {
            //Doe linkerkant van de expressie;
            RegExp left = StarPlusCheck();

            //Indien er een DOT is, haal dan rechterkant van de expressie op.
            if (Peek() == '.')
            {
                Pop();

                RegExp right = DotCheck();

                return left.dot(right);
            }
            else
                return left;
        }

        public static RegExp OrCheck()
        {
            //Doe linkerkant van de expressie.
            RegExp left = DotCheck();

            //indien er een OR is, haal dan de rechterkant van de expressie op.
            if (Peek() == '|')
            {
                Pop();

                RegExp right = OrCheck();

                return left.or(right); ;
            }
            else
                return left;

        }

        public static RegExp HookCheck()
        {
            RegExp atomNode;
            //Check of er een haakje komt, zo ja, start een nieuwe expressie.
            if (Peek() == '(')
            {
                Pop();

                atomNode = OrCheck();

                //De nieuwe expressie is afgelopen. Controleer of er een ) staat. Zo niet, dan error.
                if (Pop() != ')')
                {
                    throw new SyntaxErrorException("Parse error: expected ')'");
                }
            }
            else
            {
                atomNode = Character();
            }
            return atomNode;

        }
    }
}
