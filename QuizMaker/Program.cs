using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace QuizMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            //Get from UI method. Ask how many questions they're planning on doing.
            int numberOfQuestions = 1;
            List<FlashCard> flashCards = new();
            string filePath = @"C:\TMP\text.xml";

            //if the file exists and the user doesnt want to create a new set of flashcards
            //it'll read the stored file.
            //else it'll create a new set of flashcards (from the user inputs) and create 
            //a new xml textfile.
            if (File.Exists(filePath) && !UI.LoadSavedQuestions())
            {
                //Both are lists so they should work coherently.
                flashCards = XmlReader<List<FlashCard>>(filePath);
            }
            else
            {
                ////TODO: use a loop of some sort to make quizlist.Add be able to store / add multiple questions.
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    FlashCard card = ProduceNewCard(); //methods naming?! and should jsut return one card
                    flashCards.Add(card);
                }

                //using the XmlWriter method to serialize.
                XmlWriter(flashCards, filePath);
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
                //to keep RandomizedAnswers from being randomized over and over, just create a new list and add those randomized answers
                //so it can be used as a reference without the randomization being called.
                //List<Answer> randomAnswers = new();
                //foreach (Answer item in card.RandomizedAnswers)
                //{
                //    randomAnswers.Add(item);
                //}

                //Maps a set of 'keys' to a set of 'values'. In this case it'll be an int to card.randomizedAnswers[i].
                Dictionary<int, Answer> keyValues = OpenWithNumberKey(card.RandomizedAnswers);

                // UI method to display question and also random choices
                UI.DisplayFlashCard(card, card.RandomizedAnswers);

                // Get response, insert response into object only if
                // the card.response doesnt contain the same one. Keeps the scoring log
                //accurate.
                int answerCount = card.RandomizedAnswers.Count;
                int playersChoice = UI.GetNumResponse(answerCount);
                card.Response.Add(keyValues[playersChoice]);

                //Keeps track of the player's score
                foreach (var item in card.Response)
                {
                    if (item.IsCorrect == true)
                    {
                        score++;
                    }
                }
                //card.Response.Remove(keyValues[playersChoice]);
            }

            //Todo: Create a 2 methods, one that returns a boolean asking the user whether they want to continue using the same flashcards, or
            //they want to generate a new list of just the ones they got wrong. The second method will loop through the flashcard list and 
            //delete any flashcards that the user got Correct if the first method passes.


            //using the XmlWriter method to serialize.
            //XmlWriter(flashCards, filePath);

            //Console.WriteLine($"your score is {score}!");
        }



        /// <summary>
        /// Creates a new FlashCard Card object and a List<FlashCard>. 
        /// Inserts the user's input 'Question' into the Card, inserts the user's input 'Answer choices' into the same Card,
        /// then adds the filled Card to the List<FlashCard>
        /// along with any additional 'Answer choices' to the Card.
        /// </summary>
        /// <returns>A user filled List<FlashCard> Object.</returns>
        static FlashCard ProduceNewCard()
        {
            FlashCard card = new();

            card.TheQuestion = UI.GetQuestion();

            while (UI.IsAddingAnswers())
            {

                card.Answers.Add(new Answer { StoredAnswer = UI.GetAnswer(), IsCorrect = UI.IsACorrectAnswer() });
            }


            return card;
        }
        /// <summary>
        /// Recieves a FlashCard object list and randomizes the order in that list. 
        /// </summary>
        /// <param name="orderedList">List<FlashCard> A list to shuffle.</param>
        /// <returns>Shuffled list.</returns>
        static List<T> ListRandomizer<T>(List<T> orderedList)
        {
            Random rng = new Random();
            return orderedList.OrderBy(i => rng.Next()).ToList();
        }
        /// <summary>
        /// Method that serializes a list<Object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <param name="listToStore">The list to serialize.</param>
        public static void XmlWriter<T>(List<T> listToStore, string aFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter tx = new StreamWriter(aFilePath))
            {
                xmlSerializer.Serialize(tx, listToStore);
            }

        }
        /// <summary>
        /// Generic method that deserializes a list<object>.
        /// </summary>
        /// <paramref name="aFilePath">The path of the stored xml file.</paramref>
        /// <typeparam name="T">The type of object of the list.</typeparam>
        /// <returns>A deserialized list object.</returns>
        public static T XmlReader<T>(string aFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader tx = new StreamReader(aFilePath))
            {
                return (T)xmlSerializer.Deserialize(tx);
            }
        }
        /// <summary>
        /// Maps a set of 'keys' to a set of 'values'. In this case it'll be an int to card.randomizedAnswers[i].
        /// Uses keys as a guide/references for values. Helpful when the user enters a multiplechoice answer.
        /// </summary>
        /// <param name="answerList">The List<Answer> to be assigned temp keys to.</param>
        /// <returns>A new list<Answer> but with all the values assigned a an int key. Starting from 1.</returns>
        public static Dictionary<int, Answer> OpenWithNumberKey(List<Answer> answerList)
        {
            Dictionary<int, Answer> keys = new Dictionary<int, Answer>();

            for (int i = 0; i < answerList.Count; i++)
            {
                keys.Add(i + 1, answerList[i]);
            }
            return keys;
        }
    }
}