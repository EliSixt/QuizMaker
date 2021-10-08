using System;

namespace QuizMaker
{
    public static class UI
    {
        public static string GetQuestion()
        {
            Console.WriteLine("Whats the question?");
            string question = Console.ReadLine();
            return question;
        }
        public static string GetAnswer()
        {
            Console.WriteLine("Add an answer to that question");
            string answer = Console.ReadLine();
            return answer;
        }
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
    }
}
