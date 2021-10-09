using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuizMaker
{
    [Serializable()]
    public class FlashCard : ISerializable
    {
        public string TheQuestion { get; set; }

        private List<Answer> _answers = new();
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public Answer Response { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Question", TheQuestion);
            info.AddValue("Answers", _answers);
            info.AddValue("Response", Response);
        }
    }
}

