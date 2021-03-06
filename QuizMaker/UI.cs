using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizMaker
{
    public static class UI
    {
        /// <summary>
        /// Gets a number response from the user.
        /// The number chosen is a key to an answer choice. 
        /// </summary>
        /// <param name="count">Limiting number count.</param>
        /// <returns>Int</returns>
        public static int GetNumResponse(int count)
        {
            int response = 0;
            bool validNum = false;
            do
            {
                validNum = int.TryParse(Console.ReadLine(), out response) && response <= count && response > 0;
                if (!validNum)
                {
                    Console.WriteLine("Please enter a valid answer.");

                }
            } while (!validNum);
            return response;

            //int response = 0;
            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    try
            //    {
            //        response = int.Parse(input);
            //        if (response <= count && response > 0)
            //        {
            //            return response;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Please enter a valid answer.");

            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //    }
            //}

            //do
            //{
            //    int response = Convert.ToInt32(Console.ReadLine()); //Exception handling required here for non-ints
            //    if (response <= count)
            //    {
            //return response;
            //    }
            //    Console.WriteLine("Please enter a valid answer.");
            //} while (true);
        }
        /// <summary>
        /// Asks user for a question to input, gets input.
        /// </summary>
        /// <returns>String Question from the Console.</returns>
        public static string GetQuestion()
        {
            Console.Clear();
            Console.WriteLine("Note: You will be asked to provide additional answer choices until one is a correct option.");
            Console.WriteLine();
            Console.WriteLine("Enter question:");
            string question = Console.ReadLine();
            return question;
        }
        /// <summary>
        ///  Asks user for an answer to input, gets input.
        /// </summary>
        /// <returns>string Answer from the Console.</returns>
        public static string GetAnswer()
        {
            Console.WriteLine("Enter answer choice:");
            string answer = Console.ReadLine();
            return answer;
        }
        /// <summary>
        /// Follow-up to GetAnswer(), asks if that answer is correct or not.
        /// Recieves input response converts it into a boolean.
        /// </summary>
        /// <returns>Bool if the answer is correct.</returns>
        public static bool IsACorrectAnswer()
        {
            Console.WriteLine("Is that a correct answer? y/n");
            return GetUserResponse();
        }
        /// <summary>
        /// Asks the user if they want to add another answer.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool AddAdditionalAnswers() //Todo: add an if !null then excute this method.
        {
            Console.WriteLine("Add another answer? y/n");
            bool response = GetUserResponse();
            return response;
        }
        /// <summary>
        /// Asks the user if they want to create a new set of flashcards.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool LoadSavedFlashcards()
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to create a new set of flashcards? y/n");
            Console.WriteLine("Note: Stored flashcards will be replaced by a new set.");
            return GetUserResponse();
        }
        /// <summary>
        /// Displays a flashcard along with the answer choices and their respective mapped keys.
        /// </summary>
        /// <param name="card">FlashCard card item to display</param>
        /// <param name="answerChoices">List of the answerChoices to display</param>
        public static void DisplayFlashCard(FlashCard card, List<Answer> answerChoices)
        {
            Console.Clear();
            Console.WriteLine(card.TheQuestion);
            Console.WriteLine("select all that apply:");
            for (int i = 0; i < answerChoices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answerChoices[i]}");
            }
        }
        /// <summary>
        /// Gets the Y/N response from the console and returns it as a boolean.
        /// </summary>
        /// <returns>Boolean.</returns>
        public static bool GetUserResponse()
        {
            do
            {
                string input = Console.ReadLine();
                if (input.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
                if (input.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            } while (true);

            //    while (Console.ReadKey().Key != ConsoleKey.N && Console.ReadKey().Key != ConsoleKey.Y)
            //    {
            //        Console.WriteLine("Please press Y or N.");
            //    }
            //    if (Console.ReadKey().Key == ConsoleKey.Y)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return true;
            //    }


            //do
            //{
            //    if (Console.ReadKey().Key == ConsoleKey.Y)
            //    {
            //        return true;
            //    }
            //    if (Console.ReadKey().Key == ConsoleKey.N)
            //    {
            //        return false;
            //    }
            //    Console.WriteLine("Please press Y or N.");
            //} while (Console.ReadKey().Key != ConsoleKey.N && Console.ReadKey().Key != ConsoleKey.Y);


            //string reponse = Console.ReadLine();
            //if (reponse.Equals("y", StringComparison.OrdinalIgnoreCase))
            //{
            //    return true;
            //}
            //return false;
        }
        /// <summary>
        /// Asks the user whether they want to continue using the same flashcards, or
        /// they want to generate a new list of just the ones they got wrong.
        /// </summary>
        /// <returns>Boolean.</returns>
        public static bool ReviewWrongAnswers()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to review the incorrect flashcards? y/n");
            Console.WriteLine("Note: Your correctly answered flashcards will be deleted.");
            return GetUserResponse();
        }
        /// <summary>
        /// Displays correct-questions of number-of-questions that are correct.
        /// </summary>
        /// <param name="score">The number of correct responses</param>
        /// <param name="flashCardCount">The number of flashcards in the questionair</param>
        public static void Score(int score, int flashCardCount)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Your score: {score}/{flashCardCount}!!");
            Console.WriteLine();
        }
        /// <summary>
        /// Shows the player their correctly answered Questions.
        /// </summary>
        /// <param name="AnsweredFlashCards">Flashcard list with the responses filled.</param>
        public static void DisplayCorrectlyAnswered(List<FlashCard> AnsweredFlashCards)
        {
            Console.WriteLine("Correctly Answered:");
            foreach (FlashCard card in AnsweredFlashCards)
            {
                if (card.Response.IsCorrect)
                {
                    Console.WriteLine($"{card.TheQuestion} => {card.Response}");
                }
            }
        }
        /// <summary>
        /// A losing message for no correct answers.
        /// </summary>
        public static void DisplayLosingMessage()
        {
            Console.WriteLine("You have no correct answers ):");
        }
    }
}
