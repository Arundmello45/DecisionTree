// See https://aka.ms/new-console-template for more information

using ConsoleApplication.DecisionTree;
using ExtensionMethods;
using static ConsoleApplication.DecisionTree.TerminalQuestion;

public class QuestionAnswer
{
   
    static BooleanQuestion I = "Do you follow coding tutorials and online courses?".Boolean(Success, Failure);

    static BooleanQuestion H = "Have you ever built a personal coding project from scratch?.".Boolean(Success, Failure);

    static RangeQuestion J = "Rate your interest in coding on a scale of 1 to 10".Range(
        Success.UpTo(0).Question(Success).UpTo(3)
            .Question(I).UpTo(7).Question(I).UpTo(10).Otherwise(Failure)
    );

    static BooleanQuestion D = "Do you have a favorite programming language?".Boolean(H, Failure);

    static BooleanQuestion B = "Have you ever attended coding meetups or events?".Boolean(D, Failure);

    static BooleanQuestion A = "Do you enjoy learning new programming languages?".Boolean(B, H);

    static BooleanQuestion C = "Do you like to code as a hobby?".Boolean(Success, Failure);

    static MultipleChoiceQuestion G =
        "Which is your favorite programming language?".MultiQuestion(
            Failure,
            "Python".Question(C),
            "JavaScript".Question(I),
            "C#".Question(J)
        );

    static NumericQuestion F = "On average, how many hours per week do you spend coding?".Numeric(G);

    static BooleanQuestion E = "Do You like Coding".Boolean(F, A);



    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the form");
        Question question = E.NextQuestion();

        while (question is not TerminalQuestion)
        {
            Console.WriteLine(question.GetQuestion());

            string? input = Console.ReadLine();
            var result = question.ParseUserInput(input);

            question.Be(result);
            question = E.NextQuestion();

        }
        if (question == TerminalQuestion.Success)
        {
            Console.WriteLine("Congratulations! You have successfully completed the survey.");
        }
        else if (question == TerminalQuestion.Failure)
        {
            Console.WriteLine("Thank you for participating in the survey.");
        }
    }

}