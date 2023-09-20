// See https://aka.ms/new-console-template for more information

using ConsoleApplication.DecisionTree;
using ConsoleApplication.DecisionTree;
using ExtensionMethods;
using static ConsoleApplication.DecisionTree.TerminalQuestion;

public class QuestionAnswer
{
    static BooleanQuestion I = "That means you are a great programmer!".Boolean(TerminalQuestion.Success, Failure);
    static BooleanQuestion J = "Okay, Pack your bag".Boolean(Success, Failure);
    static RangeQuestion H = "How do you rate yourself in programming?".Range(Success.UpTo(0).Question(Success).UpTo(3)
        .Question(J).UpTo(7).Question(I).UpTo(10).Otherwise(Failure));
    static BooleanQuestion D = "Are you Rayan?".Boolean(Success, Failure);
    static BooleanQuestion C = "Are you boy?".Boolean(Success, Failure);
    static BooleanQuestion A = "Are you married?".Boolean(C, D);
    static BooleanQuestion B = "Do you have kids?".Boolean(A, Failure);
    static MultipleChoiceQuestion G =
        "Whats Your Name?".MultiQuestion(Success, "Arun".Question(H), "Mrinal".Question(I), "Rayan".Question(J));
    static NumericQuestion F = "Whats your age?".Numeric(G);
    static BooleanQuestion E = "Are you human?".Boolean(F, B);



    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the form");
        Question question = E.NextQuestion();

        while ((question is not null))
        {
            Console.WriteLine(question.GetQuestion());

            string? input = Console.ReadLine();
            var result = question.ParseUserInput(input);

            question.Be(result);
            question = E.NextQuestion();

        }
    }

}