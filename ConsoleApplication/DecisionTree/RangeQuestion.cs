using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.DecisionTree;
using Range = System.Range;

namespace ConsoleApplication.DecisionTree
{
    public class RangeQuestion : Question
    {
        private readonly Question _defaultAnswer;
        private readonly List<Range> _ranges;
        private int? _reply;
        private readonly string _question;

        public RangeQuestion(string question, List<Range> ranges)
        {
            _ranges = ranges;
            _question=question;
        }
        public void Be(object reply)
        {
            _reply = (int)reply;
        }

        public Question NextQuestion()
        {
            if (_reply == null) return this;
            return Range.NextQuestion(_defaultAnswer, _ranges, _reply);
        }

        public string GetQuestion()
        {
            return this._question;
        }
        public object ParseUserInput(string? input)
        {
            if (int.TryParse(input, out int result))
                return result;
            throw new ArgumentException("Invalid input,please enter a valid int input");

        }
    }

    public class RangeBuilder
    {
        
        private Question _question;
        private int _min;
        public  readonly List<Range> _ranges= new();

        internal RangeBuilder(Range range, int min)
        {
            _ranges.Add(range);
            _min = min;
        }

        public RangeBuilder UpTo(int max)
        {
            _ranges.Add(new Range(_question, _min, max));
            return this;
        }

        public RangeBuilder Question(Question question)
        {
            _question=question;
            return this;
        }

        public List<Range> Otherwise(Question question)
        {
            _ranges.Add(new Range(question,_min,Int32.MaxValue));
            return _ranges;
        }
    }
}