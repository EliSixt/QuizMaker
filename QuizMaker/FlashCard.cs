using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class FlashCard
    {

        public string TheQuestion { get; set; }

        //public List<Answer> Answers { get; set; } = new List<Answer>();

        private List<Answer> _answers = new List<Answer>();
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public Answer Response { get; set; }

    }
}

