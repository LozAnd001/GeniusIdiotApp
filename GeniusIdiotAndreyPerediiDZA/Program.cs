public class Mainclass
{
    internal class Program
    {
        static void Main()
        {
            int countQuestions = 5;
            string[] questions = GetQuestions(countQuestions);
            int[] answers = GetAnswers();
            int countRightAnswers = 0;

            for (int i = 0; i < countQuestions; ++i)
            {
                Console.WriteLine($"Вопрос №{i + 1}");
                Console.WriteLine(questions[i]);
                int userAnswer = Convert.ToInt32(Console.ReadLine());
                int rightAnswer = answers[i];
                if (userAnswer == rightAnswer)
                {
                    countRightAnswers++;
                }
            }
            string[] diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            Console.WriteLine($"Количество правильных ответов: {GetDiagones(countRightAnswers)}");
            Console.WriteLine($"Ваш диагноз: {diagnoses[countRightAnswers]}"); ;


        }

        private static string GetDiagones(int countRightAnswers)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            return diagnoses[countRightAnswers];
        }

        private static int[] GetAnswers()
        {
            int[] answers = { 6, 9, 25, 60, 2 };
            return answers;
        }

        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
    }
}