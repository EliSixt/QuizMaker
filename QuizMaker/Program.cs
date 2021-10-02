using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {

        static void Main(string[] args)
        {
            //Get from UI method
            int numberOfQuestions = 0;

            List<Question> quizList = new List<Question>();

            //TODO: use a loop of some sort to make questions.Add be able to store / add multiple questions.
            for (int i = 0; i < numberOfQuestions; i++)
            {
            quizList.Add(new Question
            {
                theQuestion = "TODO:Calls a methodForQuestion",
                CorrectChoice = "TODO:Calls methodForOneAnswer", 
                IncorrectChoice1 = "Todo:Calls methodForIncorrectChoice",
                IncorrectChoice2 = "same",
                IncorrectChoice3 ="same"
            });
            }
        }
        public class Question
        {
            public string theQuestion { get; set; }
            public string CorrectChoice { get; set; }
            public string IncorrectChoice1 { get; set; }
            public string IncorrectChoice2 { get; set; }

            public string IncorrectChoice3{ get; set; }

        }
    }
}

//        Quiz quiz = new Quiz();
//        quiz.Choices.Incorrect = "false";
//        quiz.Choices.Correct = "true";
//
//
//public class Quiz
//{
//    public string Question;
//    public MultipleChoice Choices = new MultipleChoice();
//}
//public class MultipleChoice
//{
//    public string Incorrect;
//    public string Correct;
//{