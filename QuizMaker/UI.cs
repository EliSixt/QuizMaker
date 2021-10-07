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
            Console.WriteLine("Add a choice answer to the question");
            string answer = Console.ReadLine();
            return answer;
        }
    }
}
