using System.Diagnostics.Metrics;

namespace QuizMaker
{
    public class LogicMethods
    {
        /// <summary>
        /// Split the input string into question and answer parts
        /// </summary>
        /// <param name="qna"></param>
        public static bool QuestionSplit(Questions qna)
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
