using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
    [Serializable]
    public class Answer
    {
        public bool IsCorrect { get; set; }
        public string StoredAnswer { get; set; }

        public override string ToString()
        {
            return $"{StoredAnswer} - {IsCorrect}";
        }
    }
}
