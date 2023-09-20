using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication.DecisionTree
{
    public class Range
    {
        private readonly Question _question;
        private readonly int _minimumValue;
        private readonly int _maximumValue;
      //  private System.Range _range=new System.Range();


        public Range(Question question, int minimumValue, int maximumValue)
        {
            _question = question;
            _minimumValue = minimumValue;
            _maximumValue = maximumValue;
        }

        public static Question NextQuestion(Question defaultAnswer, List<Range> ranges, int? reply) =>
            ranges.FirstOrDefault(range =>IsInRange(range,reply))?._question.NextQuestion()??defaultAnswer;

        public static bool IsInRange(Range range, int? reply) =>
            (range._minimumValue <= reply && range._maximumValue >= reply);
    }
}