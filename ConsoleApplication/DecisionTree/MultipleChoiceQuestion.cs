using ConsoleApplication.DecisionTree;

namespace ConsoleApplication.DecisionTree;

public class MultipleChoiceQuestion : Question
{
    private string _question;
    private readonly Question _defaultAnswer;
    private readonly List<Option> _options;
    private string? _reply;
    public MultipleChoiceQuestion(string question, Question defaultAnswer, List<Option> options)
    {
        _question = question;
        _defaultAnswer = defaultAnswer;
        _options = options;
    }
    public void Be(object reply)
    {
        _reply = (string)reply;
    }
    public Question NextQuestion()
    {
       
        if (_reply == null) return this;
        return Option.NextQuestion(_options, _reply, _defaultAnswer);
    }
    public string GetQuestion()
    {
        return this._question;
    }
    public object ParseUserInput(string? input)
    {
        if(input != null) 
            return input;
        throw new ArgumentException("Invalid input,please enter a valid string input");

    }
}