using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuizMaker
{
    [Serializable()]
    public class FlashCard /*: ISerializable*/
    {
        public string TheQuestion { get; set; }

        private List<Answer> _answers = new();
        public List<Answer> Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }

        public Answer Response { get; set; }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("Question", TheQuestion);
        //    info.AddValue("Answers", Answers);
        //    info.AddValue("Response", Response);
        //}

        //public FlashCard(SerializationInfo info, StreamingContext context)
        //{
        //    TheQuestion = (string)info.GetValue("Question", typeof(string));
        //    Answers = (List<Answer>)info.GetValue("Answers", typeof(List<Answer>));
        //    Response = (Answer)info.GetValue("Response", typeof(Answer));

        //}
    }
}

