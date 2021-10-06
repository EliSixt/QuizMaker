using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public class FlashCard
    {

        public string TheQuestion { get; set; }

        //public List<Answer> Answers { get; set; } = new List<Answer>();

        private List<Answer> Answers = new List<Answer>();
        public List<Answer> MyProperty
        {
            get { return Answers; }
            set { Answers = value; }
        }

        public Answer Response { get; set; };

    }
}

