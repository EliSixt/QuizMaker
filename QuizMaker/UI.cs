﻿using System;
using System.Linq;

namespace QuizMaker
{
    public static class UI
    {
        /// <summary>
        /// Asks user what the question they want to input, gets input.
        /// </summary>
        /// <returns>String Question from the Console.</returns>
        public static string GetQuestion()
        {
            Console.WriteLine("Whats the question?");
            string question = Console.ReadLine();
            return question;
        }
        /// <summary>
        ///  Asks user what the answer they want to input, gets input.
        /// </summary>
        /// <returns>string Answer from the Console.</returns>
        public static string GetAnswer()
        {
            Console.WriteLine("Add an answer to that question");
            string answer = Console.ReadLine();
            return answer;
        }
        /// <summary>
        /// Follow-up to GetAnswer(), asks if that answer is correct or not.
        /// Recieves input response converts it into a boolean.
        /// </summary>
        /// <returns>Bool of the player's choice, if the answer is correct.</returns>
        public static bool IsACorrectAnswer()
        {
            Console.WriteLine("Is that a correct answer? yes/no");
            string isCorrect = Console.ReadLine();
            if (isCorrect.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Asks the user if they want to add another answer.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool IsAddingAnswers()
        {
            Console.WriteLine("Add an answer? yes/no");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Asks the user if they want to create a new set of flashcards.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool LoadSavedQuestions()
        {
            Console.WriteLine("Do you want to create a new set of flashcards? yes/no");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                return false;
            }
            return true;
        }
        //public static void DisplayFlashCard(FlashCard card)
        //{
        //    Console.WriteLine(card.TheQuestion);
        //    Random rng = new Random();
            
        //    Answer newList = card.Answers.OrderBy(i => rng.Next()).ToList();
        //}
    }
}
