using System.Xml;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
        const string QuestionsFileName = @"../QuestionsList.xml";
        static XmlSerializer serializer = new XmlSerializer(typeof(List<QuizInformation>));

        /// <summary>
        /// deserializes the stored XML file
        /// </summary>
        /// <returns></returns>
        public static List<QuizInformation> Deserialize()
        {
            List<QuizInformation> qnaList = new List<QuizInformation>();

            if (File.Exists(QuestionsFileName) && new FileInfo(QuestionsFileName).Length > 0)
            {
                using (FileStream file = File.OpenRead(QuestionsFileName))
                {
                    qnaList = serializer.Deserialize(file) as List<QuizInformation>;
                }
            }
            return qnaList;
        }

        /// <summary>
        /// serializes the qnaList data into an XML file, which is then stored
        /// </summary>
        /// <param name="qnaList"></param>
        public static void Serialize(List<QuizInformation> qnaList)
        {
            using (FileStream file = File.Create(QuestionsFileName))
            {
                serializer.Serialize(file, qnaList);
            }
        }

        /// <summary>
        /// splits the question and answer input string then checks if it is valid
        /// </summary>
        /// <param name="Question"></param>
        /// <returns></returns>
        public static bool SplitQuestion(string Question)
        {
            string[] parts = Question.Split('|');
            if (parts.Length >= 3)
            {
                bool asterisk = false;
                string question = parts[0].Trim();
                if (!question.EndsWith("?"))
                {
                    return false;
                }

                for (int i = 1; i < parts.Length; i++)
                {
                    string answer = parts[i].Trim();
                    if (answer.EndsWith("*"))
                    {
                        asterisk = true;
                        break;
                    }
                }
                return asterisk;
            }
            return false;
        }

        /// <summary>
        /// stores the quetion and answer input string into the QuizInformation class variables
        /// </summary>
        /// <param name="Question"></param>
        /// <returns></returns>
        public static QuizInformation BuildQuizInformationFromInput(string Question)
        {
            QuizInformation qna = null;
            string[] parts = Question.Split('|');

            if (parts.Length >= 3)
            {
                qna = new QuizInformation();
                qna.Question = parts[0].Trim();
                qna.Answers = new List<string>();
                qna.CorrectAnswer = null;

                for (int i = 1; i < parts.Length; i++)
                {
                    string answer = parts[i].Trim();
                    if (answer.EndsWith("*"))
                    {
                        qna.CorrectAnswer = answer.Trim('*');
                        qna.Answers.Add(answer.Trim('*'));
                    }
                    else
                    {
                        qna.Answers.Add(answer);
                    }
                }
            }
            return qna;
        }
    }
}