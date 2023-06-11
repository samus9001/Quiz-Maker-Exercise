namespace QuizMaker
{
    public class UIMethods
    {

        /// <summary>
        /// sets the UI message for what the user would like to do
        /// </summary>
        public static void DisplayMode()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Quiz Maker!\n");
            Console.WriteLine("Press the (Y) key to input a question to be used in the quiz.\n");
            Console.WriteLine("Press the (Q) key to start the quiz.\n");
            Console.WriteLine("Press the (N) key to exit.\n");
        }

        /// <summary>
        /// checks the input key
        /// </summary>
        /// <returns></returns>
        public static char InputKey()
        {
            char userInput = Char.ToUpper(Console.ReadKey().KeyChar);
            return userInput;
        }

        /// <summary>
        /// sets the UI message for inputting a question
        /// </summary>
        public static void DisplayQuestionInformation()
        {
            Console.Clear();
            Console.WriteLine($"Input a question along with the answers and the correct answer.\n\nPress the (|) key after each input. Press the (*) key after the correct answer.\n");
            Console.WriteLine("Example: What colour is the sky? | red | blue* | green\n");
            Console.WriteLine("Press the (Enter) key to submit the question.\n");
        }

        /// <summary>
        /// stores the user input for the question
        /// </summary>
        /// <returns></returns>b 
        public static string InputQuestion()
        {
            string questionUserInput = Console.ReadLine();
            return questionUserInput;
        }

        public static void DisplayInvalidQuestion()
        {
            Console.WriteLine("\nInvalid input format. Please try again.\n");
        }

        /// <summary>
        /// sets the UI message to display the question to the user
        /// </summary>
        /// <param name="randomQuestion"></param>
        public static void DisplayQuestion(QuizInformation randomQuestion)
        {
            Console.Clear();
            Console.WriteLine(randomQuestion.Question);
        }

        /// <summary>
        /// sets the UI message to display the available answers
        /// </summary>
        public static void DisplayAnswers(QuizInformation randomQuestion)
        {
            for (int i = 0; i < randomQuestion.Answers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {randomQuestion.Answers[i]}");
            }
        }

        /// <summary>
        /// sets the UI message to prompt the user to input their answer
        /// </summary>
        public static string InputAnswer()
        {
            Console.WriteLine("\nInput your answer:");
            string userAnswer = Console.ReadLine();
            return userAnswer;
        }

        /// <summary>
        /// sets the UI message to display that the answer is correct
        /// </summary>
        /// <param name="userAnswer"></param>
        /// <param name="randomQuestion"></param>
        /// <param name="scoreCount"></param>
        public static void DisplayCorrectAnswer()
        {
            Console.WriteLine("\nThat is the correct answer!");
        }

        /// <summary>
        /// sets the UI message to display that the answer is incorrect
        /// </summary>
        /// <param name="randomQuestion"></param>
        public static void DisplayIncorrectAnswer(QuizInformation randomQuestion)
        {
            Console.WriteLine($"\n\nThat is incorrect! The correct answer is {randomQuestion.CorrectAnswer}");
        }

        /// <summary>
        /// sets the UI message to prompt the user to input any key
        /// </summary>
        public static void InputPressEnterKey()
        {
            Console.WriteLine("\nPress the (Enter) key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// sets the UI message to display the score once all questions have been answered
        /// </summary>
        /// <param name="scoreCount"></param>
        public static void DisplayScore(int scoreCount)
        {
            Console.Clear();
            Console.WriteLine("All questions have been answered.");
            Console.WriteLine($"\nYour final score is {scoreCount}!");
        }

        /// <summary>
        /// sets the UI message to display that there are no questions available for the quiz
        /// </summary>
        public static void DisplayNoQuestionsAvailable()
        {
            Console.WriteLine("\nNo questions available to start the quiz. Input questions first.");
        }
    }
}
