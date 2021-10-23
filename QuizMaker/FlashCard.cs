using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace QuizMaker
{
    [Serializable]
    public class FlashCard
    {
        public string TheQuestion { get; set; }

        private List<Answer> _answers = new();
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }
        public List<Answer> Response { get; set; }

        public List<Answer> RandomizedAnswers
        {
            get { return ListRandomizer(_answers); }
        }


        /// <summary>
        /// Recieves a FlashCard object list and randomizes the order in that list. 
        /// </summary>
        /// <param name="orderedList">List<FlashCard> A list to shuffle.</param>
        /// <returns>Shuffled list.</returns>
        private List<T> ListRandomizer<T>(List<T> orderedList)
        {
            Random rng = new Random();

            return orderedList.OrderBy(i => rng.Next()).ToList();
        }
    }
}

