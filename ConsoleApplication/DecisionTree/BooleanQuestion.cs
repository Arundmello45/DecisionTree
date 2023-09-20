using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.DecisionTree;

namespace ConsoleApplication.DecisionTree
{
    public class BooleanQuestion:Question
    {
        private readonly string _question;
        private readonly Question _trueAnswer;
        private readonly Question _falseAnswer;
        private bool? _reply=null;
        public BooleanQuestion(string question,Question trueAnswer, Question falseAnswer)
        {
            _question = question;
            _trueAnswer = trueAnswer;
            _falseAnswer = falseAnswer;
        }
        public void Be(object reply)
        {
            _reply = (bool)reply;
        }
        public Question NextQuestion()
        {
            if (_reply == null) return this;
            return (bool)(_reply) ? _trueAnswer.NextQuestion() : _falseAnswer.NextQuestion();
        }

        public string GetQuestion()
        {
            return this._question;
        }

        public object ParseUserInput(string? input)
        {
            if (bool.TryParse(input, out bool result))
                return result;
            throw new ArgumentException("Invalid input,please enter a valid boolean input");

        }
    }
}
