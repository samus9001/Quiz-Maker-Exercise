using System.Diagnostics.Metrics;

namespace QuizMaker
{
    public class LogicMethods
    {
        /// <summary>
        /// Split the input string into question and answer parts
        /// </summary>
        /// <param name="qna"></param>
        /// <param name="counter"></param>
        public static void QuestionSplit(Questions qna, int counter)
        {
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
                    }
                    else
                    {
                        qna.Answers.Add(answer);
                    }
                }
            }
            else
            {
                UIMethods.QuestionInvalid();
                counter--;
            }
        }
    }
}
