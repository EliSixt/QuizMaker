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
            get { return ListRandomizer(_answers); }
            set { _answers = value; }
        }

        public Answer Response { get; set; }

        /// <summary>
        /// Recieves a FlashCard object list and randomizes the order in that list. 
        /// </summary>
        /// <param name="orderedList">List<FlashCard> A list to shuffle.</param>
        /// <returns>Shuffled list.</returns>
        static List<T> ListRandomizer<T>(List<T> orderedList)
        {
            Random rng = new Random();

            return orderedList.OrderBy(i => rng.Next()).ToList();
        }
    }
}

