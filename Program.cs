using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char userInput;
            Random random = new Random();
            List<QuizInformation> qnaList = new List<QuizInformation>();

            bool exit = false;

            while (!exit)
            {
                UIMethods.DisplayMode();

                userInput = UIMethods.InputKey();

                if (userInput == 'N') //exits the program
                {
                    exit = true;
                }
                else if (userInput == 'Y') //input questions for the quiz
                {
                    bool validInput;
                    QuizInformation qna;

                    UIMethods.DisplayQuestionInformation();

                    do
                    {
                        string inputQuestion = UIMethods.InputQuestion();
                        validInput = LogicMethods.SplitQuestion(inputQuestion);

                        if (validInput)
                        {
                            qna = LogicMethods.StoreQNAInput(inputQuestion);
                        }
                        else
                        {
                            UIMethods.DisplayInvalidQuestion();
                            continue;
                        }
                        qnaList.Add(qna);
                    }
                    while (!validInput);

                    LogicMethods.Serialize(qnaList);
                }
                else if (userInput == 'Q') // starts the quiz
                {
                    if (qnaList.Count > 0)
                    {
                        int scoreCount = 0;
                        LogicMethods.Deserialize();

                        while (qnaList.Count > 0)
                        {
                            // select a random question from the list
                            int index = random.Next(0, qnaList.Count);
                            QuizInformation randomQuestion = qnaList[index];

                            UIMethods.DisplayQuestion(randomQuestion);
                            UIMethods.DisplayAnswers(randomQuestion);
                            string answer = UIMethods.InputAnswer();

                            if (answer == randomQuestion.CorrectAnswer)
                            {
                                UIMethods.DisplayCorrectAnswer();
                                scoreCount++;
                            }
                            else
                            {
                                UIMethods.DisplayIncorrectAnswer(randomQuestion);
                            }

                            qnaList.RemoveAt(index); // remove the answered question from the qnaList

                            UIMethods.InputPressEnterKey();

                            if (qnaList.Count == 0) // check if all questions have been answered
                            {
                                UIMethods.DisplayScore(scoreCount);
                                UIMethods.InputPressEnterKey();
                            }
                        }
                    }
                    else
                    {
                        UIMethods.DisplayNoQuestionsAvailable();
                        UIMethods.InputPressEnterKey();
                    }
                }

            }

            UIMethods.DisplayExit();
            UIMethods.InputPressEnterKey();
        }
    }
}