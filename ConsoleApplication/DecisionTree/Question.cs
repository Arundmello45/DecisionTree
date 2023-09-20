namespace ConsoleApplication.DecisionTree;

public interface Question
{
    void Be(object reply);
        
    Question NextQuestion();

    string GetQuestion();

    public object ParseUserInput(string? input);

}
