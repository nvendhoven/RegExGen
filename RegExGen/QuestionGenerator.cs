using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExGen
{
    class QuestionGenerator
    {
        private enum QuestionPrimaryParts { STARTWITH, ENDWITH, CONTAINS}
        private enum QuestionSecondaryParts { AND, OR , NONE}
        private List<char> usableCharacters = new List<char>(){ 'a', 'b', 'c' };
        private int numberOfParts = 1;
        private int index = 0;
        private List<QuestionPrimaryParts> primaryParts = new List<QuestionPrimaryParts>();
        private List<QuestionSecondaryParts> secondaryParts = new List<QuestionSecondaryParts>();
        private List<string> words = new List<string>();

        //Advise agains using a higher difficulty than 5.
        public Question GenerateReExpQuestion(int difficulty)
        {
            index = 0;
            numberOfParts = difficulty;
            primaryParts = GetRandomPrimaryParts();
            secondaryParts = GetRandomSecondaryParts();
            words = GetRandomSymbols();
            return GenerateRegExpQuestion();
        }

        #region RandomGenerators
        //Can have only one start and end, but multiple contains.
        private List<QuestionPrimaryParts> GetRandomPrimaryParts()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<QuestionPrimaryParts> parts = new List<QuestionPrimaryParts>();
            for (int i = 0; i < numberOfParts; i++)
            {

                if (parts.Contains(QuestionPrimaryParts.STARTWITH) && parts.Contains(QuestionPrimaryParts.ENDWITH))
                {
                    parts.Add(QuestionPrimaryParts.CONTAINS);
                }
                else if (parts.Contains(QuestionPrimaryParts.STARTWITH))
                {
                    if (rnd.Next(0, 1) == 0)
                    {
                        parts.Add(QuestionPrimaryParts.ENDWITH);
                    }
                    else
                    {
                        parts.Add(QuestionPrimaryParts.CONTAINS);
                    }
                }
                else if (parts.Contains(QuestionPrimaryParts.ENDWITH))
                {
                    if (rnd.Next(0, 1) == 0)
                    {
                        parts.Add(QuestionPrimaryParts.STARTWITH);
                    }
                    else
                    {
                        parts.Add(QuestionPrimaryParts.CONTAINS);
                    }
                }
                else
                {
                    int random = rnd.Next(0, 2);
                    if (random == 0)
                    {
                        parts.Add(QuestionPrimaryParts.STARTWITH);
                    }
                    else if (random ==1)
                    {
                        parts.Add(QuestionPrimaryParts.ENDWITH);
                    }
                    else
                    {
                        parts.Add(QuestionPrimaryParts.CONTAINS);
                    }
                }
            }
            return parts;
        }

        private List<QuestionSecondaryParts> GetRandomSecondaryParts()
        {
            List<QuestionSecondaryParts> parts = new List<QuestionSecondaryParts>();
            for (int i = 0; i < numberOfParts - 1; i++)
            {
                parts.Add(GetRandomSecondaryQuestionPart());
            }
            parts.Add(QuestionSecondaryParts.NONE);
            return parts;
        }

        private List<string> GetRandomSymbols()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<string> words = new List<string>();
            for (int i = 0; i < numberOfParts; i++)
            {
                string word = "";
                int random = rnd.Next(1, 6);
                for (int j = 0; j < random; j++)
                {
                    word += usableCharacters[rnd.Next(0, usableCharacters.Count)];
                }
                words.Add(word);
            }
            return words;
        }

        private QuestionSecondaryParts GetRandomSecondaryQuestionPart()
        {
            return (QuestionSecondaryParts)new Random(DateTime.Now.Millisecond).Next(0, Enum.GetNames(typeof(QuestionSecondaryParts)).Length-1);
        }

        private string GetEnumText(QuestionPrimaryParts qp)
        {
            switch (qp)
            {
                case QuestionPrimaryParts.STARTWITH: return "starts with";
                case QuestionPrimaryParts.ENDWITH: return "ends with";
                case QuestionPrimaryParts.CONTAINS: return "contains";
                default: return "";
            }
        }

        private string GetEnumText(QuestionSecondaryParts qp)
        {
            switch (qp)
            {
                case QuestionSecondaryParts.AND: return " and ";
                case QuestionSecondaryParts.OR: return " or ";
                case QuestionSecondaryParts.NONE: return "";
                default: return "";
            }
        }

        #endregion

        //Generate the RegExp Question.
        private Question GenerateRegExpQuestion()
        {
            Question question = new Question();
            question.SetQuestionText(GenerateRegExpQuestionText());
            string a = GenerateRegExpString();
            question.SetRegExpAnswer(a);
            return question;
        }

        //Generates the RegExp Based on the input.
        private RegExp GenerateRegExp(List<QuestionPrimaryParts> questionPrimaryParts, List<QuestionSecondaryParts> secondaryquestionParts, List<string> symbolen)
        {
            RegExp regExp = null;

            //Create Alphabet.
            SortedSet<char> alphabet = new SortedSet<char>();
            foreach (var word in symbolen)
            {
                foreach (char c in word)
                {
                    alphabet.Add(c);
                }
            }

            //Create a regex for every letter in the alphabet
            List<RegExp> regExesAlphabet = new List<RegExp>();
            foreach (char c in alphabet)
            {
                regExesAlphabet.Add(new RegExp(c.ToString()));
            }

            //Create a regEx which ors every letter of the alphabet
            RegExp orRegEx = null;
            foreach (RegExp regEx in regExesAlphabet)
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

            //Get the indexes of the starts with and ends with. Also build those regExperssions.
            int startWithIndex = -1;
            RegExp startRegExp = null;
            int endWithIndex = -1;
            RegExp endRegExp = null;
            for (int i = 0; i < questionPrimaryParts.Count; i++)
            {
                if (questionPrimaryParts[i] == QuestionPrimaryParts.STARTWITH)
                {
                    startWithIndex = i;
                    //Create a list of all needed regEx components
                    List<RegExp> regExpParts = new List<RegExp>();
                    foreach (char c in symbolen[i])
                    {
                        regExpParts.Add(new RegExp(c.ToString()));
                    }

                    //Create the full regExp Part
                    RegExp regExpPart = null;
                    foreach (RegExp regEx in regExpParts)
                    {
                        if (regExpPart == null)
                        {
                            regExpPart = regEx;
                        }
                        else
                        {
                            regExpPart = regExpPart.dot(regEx);
                        }
                    }
                    startRegExp = regExpPart;
                }

                if (questionPrimaryParts[i] == QuestionPrimaryParts.ENDWITH)
                {
                    endWithIndex = i;
                    //Create a list of all needed regEx components
                    List<RegExp> regExpParts = new List<RegExp>();
                    foreach (char c in symbolen[i])
                    {
                        regExpParts.Add(new RegExp(c.ToString()));
                    }

                    //Create the full regExp Part
                    RegExp regExpPart = null;
                    foreach (RegExp regEx in regExpParts)
                    {
                        if (regExpPart == null)
                        {
                            regExpPart = regEx;
                        }
                        else
                        {
                            regExpPart = regExpPart.dot(regEx);
                        }
                    }
                    endRegExp = regExpPart;
                }
            }

            //Add the start part of the regexp.
            if (startRegExp != null)
            {
                regExp = startRegExp;
            }

            //Start looking into the contains
            for (int i = 0; i < questionPrimaryParts.Count; i++)
            {
                //If necessety, build the Contains part.
                if (questionPrimaryParts[i] == QuestionPrimaryParts.CONTAINS) { 

                    //Create a list of all needed regEx components
                    List<RegExp> regExpParts = new List<RegExp>();
                    foreach (char c in symbolen[i])
                    {
                        regExpParts.Add(new RegExp(c.ToString()));
                    }

                    //Create the full regExp Part
                    RegExp regExpPart = null;
                    foreach (RegExp regEx in regExpParts)
                    {
                        if (regExpPart == null)
                        {
                            regExpPart = regEx;
                        }
                        else
                        {
                            regExpPart = regExpPart.dot(regEx);
                        }
                    }
                }

                switch (secondaryquestionParts[i])
                {
                    case QuestionSecondaryParts.AND:
                    {

                    } break;
                    case QuestionSecondaryParts.OR:
                    {

                    } break;
                    case QuestionSecondaryParts.NONE:
                    { 
                            //DONE
                    } break;
                }
            }

            //Add the end part of the regexp
            if (endRegExp != null)
            {
                regExp = regExp.dot(endRegExp);
            }

            return regExp;
        }

        private RegExp GetAllLettersRegex()
        {
            RegExp orRegEx = null;
            foreach (var word in words)
            {
                foreach (char c in word)
                {
                    if (orRegEx == null)
                    {
                        orRegEx = new RegExp(c.ToString());
                    }
                    else
                    {
                        orRegEx = orRegEx.or(new RegExp(c.ToString()));
                    }
                }
            }
            return orRegEx.star();
        }

        private RegExp GenerateRegExp2()
        {
            //Create the return RegExp
            RegExp returnRegExp = null;

            //Build de RegExp
            List<RegExp> regExpParts = new List<RegExp>();
            List<RegExp> containstList = new List<RegExp>();
            RegExp currentRegExp = null;
            QuestionSecondaryParts previouSecondaryPart = QuestionSecondaryParts.NONE;
            RegExp leftOfOr = null;
            for (int i = 0; i < numberOfParts; i++)
            {
                //Put all parts of the new word together
                RegExp newRegExp = null;
                foreach (char c in words[i])
                {
                    if (newRegExp == null)
                    {
                        newRegExp = new RegExp(c.ToString());
                    }
                    else
                    {
                        newRegExp = newRegExp.dot(new RegExp(c.ToString()));
                    }
                }


                //Als dit de eerste keer door de loop is, wijs dan de net aangemaakt expressie toe als de start expressie.
                if (currentRegExp == null)
                {
                    currentRegExp = newRegExp;
                }



                //Check type of primary action.
                switch (primaryParts[i])
                {
                    case QuestionPrimaryParts.STARTWITH:
                    {
                            //Voor de first part?
                    }
                        break;
                    case QuestionPrimaryParts.ENDWITH:
                    {
                            //Voor de final part?
                    }
                        break;
                    case QuestionPrimaryParts.CONTAINS:
                    {
                        //Voor de middle part?
                        //containstList.Add();
                    }
                        break;
                }

                //Check type of secondary action that has been saved.
                switch (previouSecondaryPart)
                {
                    case QuestionSecondaryParts.OR:
                    {
                        //Vorig loop was een or
                        //alles wat nu komt is weer een nieuwe expressie die met de current expressie geor't moet worden.

                    }
                        break;
                    case QuestionSecondaryParts.AND:
                    {
                        //Vorige loop was een and, dus blijf de current expressie aan elkaar dotten.
                        currentRegExp.dot(newRegExp);
                    }
                        break;
                    case QuestionSecondaryParts.NONE:
                    {
                        //DONE
                    }
                        break;
                }



                //Save the Secondary Question Part
                switch (secondaryParts[i])
                {
                    case QuestionSecondaryParts.OR:
                    {
                        previouSecondaryPart = QuestionSecondaryParts.OR;
                        //Alles wat hiervoor was is een aparte expressie. Wat hierna komt is ook een aparte expressie.
                    }
                        break;
                    case QuestionSecondaryParts.AND:
                    {
                        previouSecondaryPart = QuestionSecondaryParts.AND;
                        //Blijf dot doen
                    }
                        break;
                    case QuestionSecondaryParts.NONE:
                    {
                        //Done met de riedel, Hij zal stoppen met loopen.
                    }
                        break;
                }
            }
            return returnRegExp;
        }

        private string GetOrLettersString()
        {
            string s = "";

            SortedSet<char> letters = new SortedSet<char>();
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    letters.Add(letter);
                }
            }

            foreach (char letter in letters)
            {
                s += letter + "*";
            }

            return s;
        }
        
        //Kinda works, but its not in proper order Yet
        private string GenerateRegExpString()
        {
            string leftRegExp = "";
            string regExp = "";
            string endsWith = "";
            string startsWith = "";
            
            //regExp += "(";
            for (;index < numberOfParts; index++)
            {
                switch (primaryParts[index])
                {
                    case QuestionPrimaryParts.STARTWITH:
                        {
                            //Voor de first part?
                            startsWith += "(" + words[index];
                            startsWith += GetOrLettersString() + ")";
                        }
                        break;
                    case QuestionPrimaryParts.ENDWITH:
                        {
                            //Voor de final part?
                            endsWith += "(" + GetOrLettersString();
                            endsWith += " " + words[index] + ")";
                        }
                        break;
                    case QuestionPrimaryParts.CONTAINS:
                        {
                            //voor t contains Part?
                            regExp += "(" + words[index];
                            regExp += GetOrLettersString() + ")";
                        }
                        break;
                }

                //Check type of secondary action that has been saved.
                switch (secondaryParts[index])
                {
                    case QuestionSecondaryParts.OR:
                        {
                            //Bij deze moeten we echt dieper
                            Debug.WriteLine(startsWith + "_" + regExp + "_" +endsWith);
                            leftRegExp += "(" +startsWith + regExp + endsWith + ")|";
                            Debug.WriteLine(leftRegExp);
                            startsWith = "";
                            regExp = "";
                            endsWith = "";

                        }
                        break;
                    case QuestionSecondaryParts.AND:
                        {   
                            regExp += "";
                        }
                        break;
                    case QuestionSecondaryParts.NONE:
                        {
                            //DONE
                        }
                        break;
                }
            }
            //regExp += ")";
            Debug.WriteLine("Full "+startsWith + "_" + regExp + "_" + endsWith);
            leftRegExp += startsWith + regExp + endsWith;
            Debug.WriteLine("Full "+leftRegExp);
            return leftRegExp;
        }




        //Alle lijsten moeten even lang zijn., secondary moet eindigen met een NONE.
        private string GenerateRegExpQuestionText()
        {
            string questionText = "Give a Regular Expression that ";

            for(int i = 0; i < primaryParts.Count; i++)
            {
                questionText += GetEnumText(primaryParts[i]); 
                questionText += " " + words[i];
                questionText += GetEnumText(secondaryParts[i]);
            }

            questionText += ".";
            return questionText;
        }
    }

    class Question
    {
        private string regExpAnswer;
        private string questionText;

        public Question()
        {
            
        }

        public void SetQuestionText(string text)
        {
            questionText = text;
        }

        public void SetRegExpAnswer(string regExpString)
        {
            regExpAnswer = regExpString;
        }
    }
}
