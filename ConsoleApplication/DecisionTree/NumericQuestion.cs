using ConsoleApplication.DecisionTree;

namespace ConsoleApplication.DecisionTree;

public class NumericQuestion:Question
{
    public string _question;
    private readonly Question _answer;
    private int? _reply=null;
    public NumericQuestion(string question, Question answer)
    {
        _question = question;
        _answer = answer;
    }
    public void Be(object reply)
    {
        _reply = (int)reply;
    }
    public Question NextQuestion()
    {
        if (_reply == null) return this;
        return _answer.NextQuestion();
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