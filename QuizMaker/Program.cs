﻿using System;
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
            //Get from UI method. Ask how many questions they're planning on doing.
            int numberOfQuestions = 1;
            List<FlashCard> flashCards = new();
            string filePath = @"C:\TMP\text.xml";


            if (File.Exists(filePath) && UI.LoadSavedQuestions())
            {
                //Both are lists so they should work coherently.
                flashCards = XmlReader<FlashCard>(filePath);
            }
            else
            {

                ////TODO: use a loop of some sort to make quizlist.Add be able to store / add multiple questions.
                for (int i = 0; i < numberOfQuestions; i++)
                {
                    FlashCard card = ProduceNewCard(); //methods naming?! and should jsut return one card
                    flashCards.Add(card);

                }

                //XmlSerializer xmlSerializer = new XmlSerializer(typeof(FlashCard));
                //using (TextWriter tx = new StreamWriter(@"C:\TMP\text.xml"))
                //{
                //    xmlSerializer.Serialize(tx, flashCards);
                //}
                //trying to use the XmlWriter method to serialize instead.

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
        static List<FlashCard> ListRandomizer(List<FlashCard> orderedList)
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
        public static List<T> XmlReader<T>(string aFilePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader tx = new StreamReader(aFilePath))
            {
                return (List<T>)xmlSerializer.Deserialize(tx);
            }
        }
    }
}