using System.Diagnostics.Metrics;
using System.IO;
using System.Xml.Serialization;

namespace QuizMaker
{
    public class LogicMethods
    {
        /// <summary>
        /// deserializes the stored XML file
        /// </summary>
        /// <param name="QuestionsFileName"></param>
        /// <param name="qnaList"></param>
        /// <param name="serializer"></param>
        public static void Deserialize(string QuestionsFileName, List<QuizInformation> qnaList, XmlSerializer serializer)
        {
            if (File.Exists(QuestionsFileName) && new FileInfo(QuestionsFileName).Length > 0)
            {
                using (FileStream file = File.OpenRead(QuestionsFileName))
                {
                    qnaList = serializer.Deserialize(file) as List<QuizInformation>;
                }
            }
        }

        /// <summary>
        /// serializes the qnaList data into an XML file, which is then stored
        /// </summary>
        /// <param name="QuestionsFileName"></param>
        /// <param name="serialize"></param>
        /// <param name="qnaList"></param>
        public static void Serialize(string QuestionsFileName, XmlSerializer serializer, List<QuizInformation> qnaList)
        {
            using (FileStream file = File.Create(QuestionsFileName))
            {
                serializer.Serialize(file, qnaList);
            }
        }

        /// <summary>
        /// splits the input string into question and answers that are stored in the QuizInformation class variables
        /// </summary>
        /// <param name="qna"></param>
        public static bool SplitQuestion(QuizInformation qna)
        {
            bool validInput = true;
            string[] parts = qna.Question.Split('|');

            if (parts.Length >= 3)
            {
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
            else
            {
                validInput = false;
            }
            return validInput;
        }
    }
}