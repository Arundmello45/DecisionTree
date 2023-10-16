using System.ComponentModel;
using ConsoleApplication.DecisionTree;

namespace ConsoleApplication.DecisionTree;

public class TerminalQuestion : Question
{
    public static TerminalQuestion Success = new TerminalQuestion();
    public static TerminalQuestion Failure = new TerminalQuestion();
    public void Be(object reply) => throw new InvalidOperationException("No More Questions, You are done");
    public Question NextQuestion() => this;
    public string GetQuestion()
    {
        throw new InvalidOperationException("No More Questions, You are done");
    }
    public object ParseUserInput(string? input)
    {
        throw new InvalidOperationException("Reached the terminal condition!");
    }
}

