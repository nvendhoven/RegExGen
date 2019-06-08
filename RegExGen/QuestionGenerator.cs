using System;
using System.Collections.Generic;
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

        public Question GenerateReExpQuestion()
        {
            int length = 3;//Woudl make this higher that 4.
            return GenerateRegExpQuestion(GetRandomPrimaryParts(length), GetRandomSecondaryParts(length), GetRandomSymbols(length));
        }

        //Can have only one start and end, but multiple contains.
        private List<QuestionPrimaryParts> GetRandomPrimaryParts(int numberOf)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<QuestionPrimaryParts> parts = new List<QuestionPrimaryParts>();
            for (int i = 0; i < numberOf; i++)
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

        
        private List<QuestionSecondaryParts> GetRandomSecondaryParts(int numberOf)
        {
            List<QuestionSecondaryParts> parts = new List<QuestionSecondaryParts>();
            for (int i = 0; i < numberOf-1; i++)
            {
                parts.Add(GetRandomSecondaryQuestionPart());
            }
            parts.Add(QuestionSecondaryParts.NONE);
            return parts;
        }

        private List<string> GetRandomSymbols(int numberOf)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            List<string> words = new List<string>();
            for (int i = 0; i < numberOf; i++)
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
            return (QuestionSecondaryParts)new Random(DateTime.Now.Millisecond).Next(0, Enum.GetNames(typeof(QuestionSecondaryParts)).Length);
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

        //Generate the RegExp Question.
        private Question GenerateRegExpQuestion(List<QuestionPrimaryParts> questionStartParts, List<QuestionSecondaryParts> secondaryquestionParts, List<string> symbolen)
        {
            Question question = new Question();
            question.SetQuestionText(GenerateRegExpQuestionText(questionStartParts, secondaryquestionParts,symbolen));
            question.SetReExpAnswer(GenerateRegExp(questionStartParts, secondaryquestionParts, symbolen));
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


            string test = "";

            if (startRegExp != null)
            {
                test += "(" +  + ")";
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



        //Alle lijsten moeten even lang zijn., secondary moet eindigen met een NONE.
        private string GenerateRegExpQuestionText(List<QuestionPrimaryParts> questionStartParts, List<QuestionSecondaryParts> secondaryquestionParts, List<string> symbolen)
        {
            string questionText = "Give a Regular Expression that ";

            for(int i = 0; i < questionStartParts.Count; i++)
            {
                questionText += GetEnumText(questionStartParts[i]); 
                questionText += " " + symbolen[i];
                questionText += GetEnumText(secondaryquestionParts[i]);
            }

            questionText += ".";
            return questionText;
        }
    }

    class Question
    {
        private RegExp regExpAnswer;
        private string questionText;

        public Question()
        {
            
        }

        public void SetQuestionText(string text)
        {
            questionText = text;
        }

        public void SetReExpAnswer(RegExp regExp)
        {
            regExpAnswer = regExp;
        }
    }
}
