using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizInformation qna = new QuizInformation();
            char userInput;
            bool validInput = true;
            string answer;
            Random random = new Random();
            int scoreCount = 0;

            XmlSerializer serializer = new XmlSerializer(typeof(List<QuizInformation>));
            var path = @"C:\QuestionsList.xml";
            List<QuizInformation> qnaList = new List<QuizInformation>();

            using (FileStream file = File.OpenRead(path))
            {
                if (File.Exists(path) && new FileInfo(path).Length > 0)
                {
                    qnaList = serializer.Deserialize(file) as List<QuizInformation>;
                }
            }

            while (true) // loops until the 'N' key is pressed on the Mode prompt
            {
                UIMethods.ClearScreen();
                UIMethods.Mode();

                userInput = UIMethods.Input();

                if (userInput == 'Y')
                {
                    UIMethods.ClearScreen();
                    UIMethods.Question();

                    while (true) // loops until the validInput variable is true
                    {
                        if (!validInput)
                        {
                            UIMethods.InvalidQuestion();
                        }

                        qna.Question = UIMethods.InputQuestion();
                        validInput = LogicMethods.QuestionSplit(qna);

                        if (validInput)
                        {
                            break;
                        }
                    }

                    qnaList.Add(qna);

                    using (FileStream file = File.Create(path))
                    {
                        serializer.Serialize(file, qnaList);
                    }
                }

                if (userInput == 'Q' && qnaList.Count > 0)
                {
                    while (qnaList.Count > 0)
                    {
                        UIMethods.ClearScreen();

                        // select a random question from the list
                        int index = random.Next(0, qnaList.Count);
                        QuizInformation randomQuestion = qnaList[index];

                        UIMethods.DisplayQuestion(randomQuestion);
                        UIMethods.DisplayAnswers(randomQuestion);
                        answer = UIMethods.InputAnswer();

                        if (answer == randomQuestion.CorrectAnswer)
                        {
                            UIMethods.CorrectAnswer();
                            scoreCount++;
                        }
                        else
                        {
                            UIMethods.IncorrectAnswer(randomQuestion);
                        }

                        // remove the answered question from the qnaList
                        qnaList.RemoveAt(index);

                        UIMethods.PressEnterKey();

                        // Check if all questions have been answered
                        if (qnaList.Count == 0)
                        {
                            UIMethods.ClearScreen();
                            UIMethods.DisplayScore(scoreCount);
                            UIMethods.PressEnterKey();
                            break;
                        }
                    }
                }
                else if (userInput == 'Q' && qnaList.Count == 0)
                {
                    UIMethods.NoQuestionsAvailable();
                    UIMethods.PressEnterKey();
                }

                if (userInput == 'N')
                {
                    return;
                }
            }
        }
    }
}