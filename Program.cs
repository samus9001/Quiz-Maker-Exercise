namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Questions questions = new Questions();

            Console.WriteLine("Enter questions along with correct and incorrect answers for them to be used for the quiz!\n");

            string questionAndAnswers = Console.ReadLine();
            questions.Answer = questionAndAnswers;

            Console.WriteLine(questions.Answer);
        }
    }
}