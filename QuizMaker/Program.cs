using System;
using System.Collections.Generic;

namespace QuizMaker
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Quiz> questions = new List<Quiz>();
            //TODO: use a loop of some sort to make questions.Add be able to store / add multiple questions.
            questions.Add(new Quiz
            {
                Question = "TODO:methodForQuestion",
                IncorrectChoice = "TODO:methodForMultipleChoices",
                CorrectChoice = "TODO:methodForOneAnswer"
            });
        }
        public class Quiz
        {
            public string Question { get; set; }
            public string CorrectChoice { get; set; }
            public string IncorrectChoice { get; set; }

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