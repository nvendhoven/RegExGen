using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RegExGen
{
    public class RegExp
    {
        public enum Operator { PLUS, STAR, OR, DOT, ONE }

        private Operator regOperator;
        private string terminals;
        private RegExp left;
        private RegExp right;
        /*
        public static Comparer<string> compareByLength(string s1,string s2) // = new Comparer<string>();
        {
            if (s1.Length == s2.Length)
                { return s1.CompareTo(s2); }
            else
                { return s1.Length - s2.Length; }
        }
        */

        public bool Equals(RegExp regExp)
        {
            //Check of de operators gelijk zijn.
            if (this.GetRegOperator() != regExp.GetRegOperator())
            {
                return false;
            }

            //Indien do operators gelijk zijn, check of het een eindnode is. Als het een eindnode is, check dan of de terminals gelijk zijn.
            if (GetRegOperator() == Operator.ONE && this.GetRegTerminals() == regExp.GetRegTerminals())
            {
                return true;
            }

            //Bij deze hoeft alleen Left gecontroleerd te worden.
            if ((GetRegOperator() == Operator.STAR || GetRegOperator() == Operator.PLUS))
            {
                return left.Equals(regExp.left);
            }

            //Bij deze moeten left en right gecontroleerd te worden.
            if ((GetRegOperator() == Operator.OR || GetRegOperator() == Operator.DOT))
            {
                return left.Equals(regExp.left) && right.Equals(regExp.right);
            }

            return false;
        }

        public Operator GetRegOperator()
        {
            return regOperator;
        }

        public string GetRegTerminals()
        {
            return terminals;
        }

        public RegExp GetLeftRegExp()
        {
            return left;
        }

        public RegExp GetRightRegExp()
        {
            return right;
        }

        private class compareByLengthHelper : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                if (s1.Length == s2.Length)
                { return s1.CompareTo(s2); }
                else
                { return s1.Length - s2.Length; }
            }
        }

        public static IComparer<string> compareByLength = (IComparer<string>) new compareByLengthHelper();

        public RegExp()
        {
            regOperator = RegExp.Operator.ONE;
            terminals = "";
            left = null;
            right = null;
        }

        public RegExp(string p)
        {
            regOperator = RegExp.Operator.ONE;
            terminals = p;
            left = null;
            right = null;
        }

        public RegExp plus()
        {
            RegExp result = new RegExp();
            result.regOperator = RegExp.Operator.PLUS;
            result.left = this;
            return result;
        }

        public RegExp star()
        {
            RegExp result = new RegExp();
            result.regOperator = RegExp.Operator.STAR;
            result.left = this;
            return result;
        }

        public RegExp or(RegExp e2)
        {
            RegExp result = new RegExp();
            result.regOperator = RegExp.Operator.OR;
            result.left = this;
            result.right = e2;
            return result;
        }

        public RegExp dot(RegExp e2)
        {
            RegExp result = new RegExp();
            result.regOperator = RegExp.Operator.DOT;
            result.left = this;
            result.right = e2;
            return result;
        }

        public SortedSet<string> getLanguage(int maxSteps)
        {
            SortedSet<string> emptyLanguage = new SortedSet<string>(compareByLength);
            SortedSet<string> languageResult = new SortedSet<string>(compareByLength);

            SortedSet<string> languageLeft, languageRight;

            if (maxSteps < 1) return emptyLanguage;

            switch (this.regOperator) {
                case RegExp.Operator.ONE:
                    { languageResult.Add(terminals); }
                    break;

                case RegExp.Operator.OR:
                    languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.getLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    languageResult.UnionWith(languageRight);
                    break;
                

                case RegExp.Operator.DOT:
                    languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                    languageRight = right == null ? emptyLanguage : right.getLanguage(maxSteps - 1);
                    foreach (string s1 in languageLeft)
                        foreach (string s2 in languageRight)
                            { languageResult.Add(s1 + s2); }
                    break;

                case RegExp.Operator.STAR:
                case RegExp.Operator.PLUS:
                    languageLeft = left == null ? emptyLanguage : left.getLanguage(maxSteps - 1);
                    languageResult.UnionWith(languageLeft);
                    for (int i = 1; i < maxSteps; i++)
                    {
                        HashSet<string> languageTemp = new HashSet<string>(languageResult);
                        foreach (string s1 in languageLeft)
                        {
                            foreach (string s2 in languageTemp)
                            {
                                languageResult.Add(s1 + s2);
                            }
                        }
                    }
                    if (this.regOperator == RegExp.Operator.STAR)
                            { languageResult.Add(""); }
                    break;

                default:
                    Console.Write("getLanguage is nog niet gedefinieerd voor de operator: " + this.regOperator);
                    break;
            }


            return languageResult;
        }

        public override string ToString()
        {
            return new RegExToStringParser().Parse(this); ;
        }

        public void PrintTree(int offset)
        {
            for (int i = 0; i < offset; ++i)
                Console.Write(" ");

            switch (GetRegOperator())
            {
                case RegExp.Operator.ONE:
                    Console.WriteLine(terminals);
                    break;
                case RegExp.Operator.OR:
                    Console.WriteLine("|");
                    break;
                case RegExp.Operator.DOT:
                    Console.WriteLine(".");
                    break;
                case RegExp.Operator.PLUS:
                    Console.WriteLine("+");
                    break;
                case RegExp.Operator.STAR:
                    Console.WriteLine("*");
                    break;
            }

            if(left != null)
                left.PrintTree(offset + 8);
            if(right != null)
                right.PrintTree(offset + 8);
        }
    }
}
