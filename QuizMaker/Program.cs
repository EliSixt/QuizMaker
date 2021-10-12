using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;


namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get from UI method. Ask how many questions they're planning on doing.
            int numberOfQuestions = 1;

            

            ////TODO: use a loop of some sort to make quizlist.Add be able to store / add multiple questions.
            List<FlashCard> flashCards = new List<FlashCard>();
            for (int i = 0; i < numberOfQuestions; i++)
            {
                List<FlashCard> quizList = GetTestQuestions(); //methods naming?! and should jsut return one card
                flashCards.AddRange(quizList);

            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<FlashCard>));
            using (TextWriter tx = new StreamWriter(@"C:\TMP\text.xml"))
            {
                xmlSerializer.Serialize(tx, flashCards);              
            }


                //TODO:
                //After quizlist is filled.
                // Ask each question (UI methods) in quizlist at random. Get response,  
                // figure out if the response is the answer or not. 
                // Keep track of score.

                //Random rng = new Random();
                //var randomOrderQuizList = flashCards.OrderBy(i => rng.Next());

                List<FlashCard> shuffledFlashCards = ListRandomizer(flashCards);

            foreach (var card in shuffledFlashCards)
            {
                // UI method to display question and also random choices
                // Get response, insert response into object.
            }

        }
        /// <summary>
        /// Creates a new FlashCard Card object and a List<FlashCard>. 
        /// Inserts the user's input 'Question' into the Card, inserts the user's input 'Answer choices' into the same Card,
        /// then adds the filled Card to the List<FlashCard>
        /// along with any additional 'Answer choices' to the Card.
        /// </summary>
        /// <returns>A user filled List<FlashCard> Object.</returns>
        static List<FlashCard> GetTestQuestions()
        {
            List<FlashCard> quizList = new();

            FlashCard card = new();

            card.TheQuestion = UI.GetQuestion();

            while (UI.IsAddingAnswers())
            {

                card.Answers.Add(new Answer { StoredAnswer = UI.GetAnswer(), IsCorrect = UI.IsACorrectAnswer() });
                quizList.Add(card);

            }


            return quizList;
        }
        /// <summary>
        /// Recieves a FlashCard object list and randomizes the order in that list. 
        /// </summary>
        /// <param name="orderedList">List<FlashCard> A list to shuffle.</param>
        /// <returns>Shuffled list.</returns>
        static List<FlashCard> ListRandomizer(List<FlashCard> orderedList)
        {
            Random rng = new Random();

            return orderedList.OrderBy(i => rng.Next()).ToList();
        }

   

    }
}