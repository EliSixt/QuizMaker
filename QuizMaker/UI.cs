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
            do
            {
                int response = Convert.ToInt32(Console.ReadLine());
                if (response <= count)
                {
                    return response;
                }
                Console.WriteLine("Please enter a valid answer.");
            } while (true);
        }
        /// <summary>
        /// Asks user what the question they want to input, gets input.
        /// </summary>
        /// <returns>String Question from the Console.</returns>
        public static string GetQuestion()
        {
            Console.WriteLine("Enter the question.");
            string question = Console.ReadLine();
            return question;
        }
        /// <summary>
        ///  Asks user what the answer they want to input, gets input.
        /// </summary>
        /// <returns>string Answer from the Console.</returns>
        public static string GetAnswer()
        {
            Console.WriteLine("Enter the answer choice.");
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
            Console.WriteLine("Is that a correct answer? y/n");
            return GetUserResponse();
        }
        /// <summary>
        /// Asks the user if they want to add another answer.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool IsAddingAnswers() //Todo: add an if !null then excute this method.
        {
            Console.WriteLine("Do you want to add an answer choice? y/n");
            bool response = GetUserResponse();
            return response;
        }
        /// <summary>
        /// Asks the user if they want to create a new set of flashcards.
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool LoadSavedQuestions()
        {
            Console.WriteLine("Do you want to create a new set of flashcards? y/n");
            Console.WriteLine("Note: Stored flashcards will load.");
            return GetUserResponse();
        }
        public static void DisplayFlashCard(FlashCard card, List<Answer> answerChoices)
        {
            Console.Clear();
            Console.WriteLine(card.TheQuestion);
            Console.WriteLine("select all that apply:");
            for (int i = 0; i < answerChoices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {answerChoices[i]}");

                //Maybe put in a method for referencing card.randomizedAnswers??? 
            }

            //foreach (Answer item in card.RandomizedAnswers)
            //{
            //    Console.WriteLine(item);
            //}

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
            Console.WriteLine("Do you want to review through the questions you just got wrong? y/n");
            Console.WriteLine("Note: Your correct questions will be deleted.");
            return GetUserResponse();
        }
        /// <summary>
        /// Displays correct-questions out of number-of-questions were correct.
        /// </summary>
        /// <param name="score">The number of correct responses</param>
        /// <param name="flashCardCount">The number of flashcards in the questionair</param>
        public static void Score(int score, int flashCardCount)
        {
            Console.WriteLine();
            Console.WriteLine($"Your score: {score}/{flashCardCount}.");
            Console.WriteLine();
        }
    }
}
