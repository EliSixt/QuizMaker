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
            int numberOfQuestions = 2;


            ////TODO: use a loop of some sort to make quizlist.Add be able to store / add multiple questions.
            List<FlashCard> flashCards = new List<FlashCard>();

            for (int i = 0; i < numberOfQuestions; i++)
            {
                List<FlashCard> quizList = GetTestQuestions();
                flashCards.AddRange(quizList);

            }

            //TODO:
            //After quizlist is filled.
            // Ask each question (UI methods) in quizlist at random. Get response,  
            // figure out if the response is the answer or not. 
            // Keep track of score.

            //Random rng = new Random();
            //var randomOrderQuizList = quizList.OrderBy(i => rng.Next());

            //foreach (var i in randomOrderQuizList)
            //{
            //    // UI method to display question and also random choices
            //    // Get response, insert response into object.
            //}

        }

        static List<FlashCard> GetTestQuestions()
        {
            List<FlashCard> quizList = new();

            FlashCard card = new FlashCard();

            card.TheQuestion = UI.GetQuestion();

            while (UI.IsAddingAnswers())
            {

                card.Answers.Add(new Answer { StoredAnswer = UI.GetAnswer(), IsCorrect = UI.IsACorrectAnswer() });
                quizList.Add(card);

            }


            return quizList;
        }
    }
}