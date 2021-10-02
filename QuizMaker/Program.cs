using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker
{
    class Program
    {

        static void Main(string[] args)
        {
            //Get from UI method. Ask how many questions they're planning on doing.
            int numberOfQuestions = 0;

            List<Question> quizList = new List<Question>();

            //TODO: use a loop of some sort to make quizlist.Add be able to store / add multiple questions.
            for (int i = 0; i < numberOfQuestions; i++)
            {
            quizList.Add(new Question
            {
                //Todo: UI method that gets called to ask for question answer and 3 incorrectChoices.
                theQuestion = "TODO:Calls a methodForQuestion",
                CorrectChoice = "TODO:Calls methodForOneAnswer", 
                IncorrectChoice1 = "Todo:Calls methodForIncorrectChoice",
                IncorrectChoice2 = "same",
                IncorrectChoice3 ="same"
            });
            }

            //TODO:
            //After quizlist is filled.
            // Ask each question (UI methods) in quizlist at random. Get response,  
            // figure out if the response is the answer or not. 
            // Keep track of score.

            Random rng = new Random();
            var randomOrderQuizList = quizList.OrderBy(i => rng.Next());

            foreach (var i in randomOrderQuizList)
            {
                // UI method to display question and choices
                // Get response
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