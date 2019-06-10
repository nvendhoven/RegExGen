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
        /*
         * TODO: need to do an OR check to see if we can add another EndsWith or Starts With. Will need to combine Primary and secondary generation for that.
         * 
         */
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
            question.QuestionText = GenerateRegExpQuestionText();
            string a = GenerateRegExpString();
            question.RegExpAnswer = a;
            return question;
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
        public string RegExpAnswer { get; set; }
        public string QuestionText { get; set; }

        public Question()
        {
            
        }

    }
}
