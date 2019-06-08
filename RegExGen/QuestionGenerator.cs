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
            int length = 2;
            return GenerateRegExpQuestion(GetRandomPrimaryParts(length), GetRandomSecondaryParts(length), GetRandomSymbols(length));
        }

        private List<QuestionPrimaryParts> GetRandomPrimaryParts(int numberOf)
        {
            List<QuestionPrimaryParts> parts = new List<QuestionPrimaryParts>();
            for (int i = 0; i < numberOf; i++)
            {
                parts.Add(GetRandomPrimaryQuestionPart());
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

        private QuestionPrimaryParts GetRandomPrimaryQuestionPart()
        {
            return (QuestionPrimaryParts) new Random(DateTime.Now.Millisecond).Next(0, Enum.GetNames(typeof(QuestionPrimaryParts)).Length);
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
            

            for (int i = 0; i < questionPrimaryParts.Count; i++)
            {
                //Create a list of all needed regEx components
                List<RegExp> regExes = new List<RegExp>();
                foreach (char c in symbolen[i])
                {
                    regExes.Add(new RegExp(c.ToString()));
                }

                switch (questionPrimaryParts[i])
                {
                    case QuestionPrimaryParts.STARTWITH:
                    {
                        
                    } break;
                    case QuestionPrimaryParts.ENDWITH:
                    {
                        
                    } break;
                    case QuestionPrimaryParts.CONTAINS:
                    {
                        
                    } break;
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
