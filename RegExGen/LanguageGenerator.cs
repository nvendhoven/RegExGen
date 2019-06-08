using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    static class LanguageGenerator
    {
        public static RegExp generateRegExpStartingWith(string data)
        {
            RegExp languageInRegex = null;

            //Create Alphabet.
            SortedSet<char> alphabet = new SortedSet<char>();
            foreach (char c in data)
            {
                alphabet.Add(c);
            }

            //Create a list of all needed regEx components
            List<RegExp> regExesBeginning = new List<RegExp>();
            foreach (char c in data)
            {
                regExesBeginning.Add(new RegExp(c.ToString()));
            }

            //Create the beginning of the regex.
            RegExp startRegExp = null;
            foreach (RegExp regEx in regExesBeginning)
            {
                if (startRegExp == null)
                {
                    startRegExp = regEx;
                }
                else
                {
                    startRegExp = startRegExp.dot(regEx);
                }
            }

            //Create a regex for every letter in the alphabet
            List<RegExp> regExesAlphabed = new List<RegExp>();
            foreach (char c in alphabet)
            {
                regExesAlphabed.Add(new RegExp(c.ToString()));
            }

            //Create a regEx which ors every letter of the alphabet
            RegExp orRegEx = null;
            foreach (RegExp regEx in regExesAlphabed)
            {
                if (orRegEx == null)
                {
                    orRegEx = regEx;
                }
                else
                {
                    orRegEx = orRegEx.or(regEx);
                }
            }

            //Make sure the or can be 0 or more times
            orRegEx = orRegEx.star();


            //Combine the start and the Or function
            languageInRegex = startRegExp.dot(orRegEx);

            return languageInRegex;
        }

        public static RegExp generateRegExpEndingWith(string data)
        {
            RegExp languageInRegex = null;

            //Create Alphabet.
            SortedSet<char> alphabet = new SortedSet<char>();
            foreach (char c in data)
            {
                alphabet.Add(c);
            }

            //Create a list of all needed regEx components
            List<RegExp> regExesEnding = new List<RegExp>();
            foreach (char c in data)
            {
                regExesEnding.Add(new RegExp(c.ToString()));
            }

            //Create the ending of the regex.
            RegExp endRegExp = null;
            foreach (RegExp regEx in regExesEnding)
            {
                if (endRegExp == null)
                {
                    endRegExp = regEx;
                }
                else
                {
                    endRegExp = endRegExp.dot(regEx);
                }
            }

            //Create a regex for every letter in the alphabet
            List<RegExp> regExesAlphabed = new List<RegExp>();
            foreach (char c in alphabet)
            {
                regExesAlphabed.Add(new RegExp(c.ToString()));
            }

            //Create a regEx which ors every letter of the alphabet
            RegExp orRegEx = null;
            foreach (RegExp regEx in regExesAlphabed)
            {
                if (orRegEx == null)
                {
                    orRegEx = regEx;
                }
                else
                {
                    orRegEx = orRegEx.or(regEx);
                }
            }

            //Make sure the or can be 0 or more times
            orRegEx = orRegEx.star();


            //Combine the start and the Or function
            languageInRegex = orRegEx.dot(endRegExp);

            return languageInRegex;
        }

    }
}
