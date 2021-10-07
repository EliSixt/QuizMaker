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
        public static bool IsACorrectAnswer()
        {
            Console.WriteLine("Is the answer a correct choice? yes/no");
            string isCorrect = Console.ReadLine();
            if (isCorrect == "Yes" || isCorrect == "yes" || isCorrect == "YES")
            {
                return true;
            }
            return false;
        }
        public static bool IsAddingAnswers()
        {
            Console.WriteLine("Add another answer? yes/no");
            string response = Console.ReadLine();
            if (response == "Yes" || response == "yes" || response == "YES")
            {
                return true;
            }
            return false;
        }
    }
}
