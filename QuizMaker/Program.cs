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
                    TheQuestion = "TODO:Calls a methodForQuestion",
                    CorrectChoice = "TODO:Calls methodForOneAnswer",
                    IncorrectChoice1 = "Todo:Calls methodForIncorrectChoice",
                    IncorrectChoice2 = "same",
                    IncorrectChoice3 = "same",
                    Response = "UI method that inserts the response here to compare later." +
                    " (duplicates the choice here to compare later)"
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
                // UI method to display question and also random choices
                // Get response, insert response into object.
            }

        }

    }
}