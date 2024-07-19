using System.Text;

public partial class Mainclass
{
    class Program
    {
       
        static void Main()
        {
            while(true)
            {
                

                Console.WriteLine("Введите ваше имя");
                var userName = Console.ReadLine();
                var questions = QuestionStorage.GetAll();
 
                var countQuestions = questions.Count;
                var random = new Random();
                var countRightAnswers = 0;
                for (int i = 0; i < countQuestions; ++i)
                {
                    Console.WriteLine($"Вопрос №{i + 1}");
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex].Text);
                    var userAnswer = GetUserAnswer();
                    var rightAnswer = questions[randomQuestionIndex].Answer;
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    questions.RemoveAt(randomQuestionIndex);
                }
                Console.WriteLine($"Количество правильных ответов: {countRightAnswers}");
                var diagnose = CalculateDiagnoses(countRightAnswers, countQuestions);
                Console.WriteLine($"{userName}, ваш диагноз: {diagnose}");
                SaveUserResult(userName, countRightAnswers, diagnose);
                var userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты игры?");
                if(userChoice)
                {
                    ShowUserResults();
                }
                userChoice = GetUserChoice("Хотите начать сначала?");
                if(userChoice == false)
                {
                    break;
                }
            }
        }

        static void ShowUserResults()
        {
            var reader = new StreamReader("userResults.txt", Encoding.UTF8);
            Console.WriteLine("{0,-20}, {1,18}, {2,15}", "Имя", "Кол-во правильных ответов","Диагноз");
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split("#");
                var name = values[0];
                var countRightAnswers = Convert.ToInt32(values[1]);
                var diagnose = values[2];
                Console.WriteLine("{0,-20}, {1,18}, {2,15}", name, countRightAnswers, diagnose);

            }
            reader.Close();
        }

        static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            var value = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile("userResults.txt", value);
        }

        static void AppendToFile(string fileName, string value)
        {
            var writer = new StreamWriter(fileName, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();

        }

        static bool GetUserChoice(string message)
        {
            while(true)
            {
                Console.WriteLine(message + "Введите 'Да' или 'Нет' ");
                var userAnswer = Console.ReadLine();
                if(userAnswer.ToLower() == "да")
                {
                    return true;
                }
                else if(userAnswer.ToLower() == "нет")
                {
                    return false;
                }    
            }
        }

        static int GetUserAnswer()
        {
           while(true)
           {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException)
                {
                    Console.WriteLine("Введите число!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введите число от -2*10^9 до 2*10^9");
                }
            }
        }

        static string CalculateDiagnoses(int countRightAnswers, int countQuestions)
        {
            var diagnoses = GetDiagnoses();
            var percentRightAnswers = countRightAnswers * 100 / countQuestions;
            if(percentRightAnswers < 20)
            {
                return diagnoses[0];
            }
            if (percentRightAnswers < 40)
            {
                return diagnoses[1];
            }
            if (percentRightAnswers < 60)
            {
                return diagnoses[2];
            }
            if (percentRightAnswers < 80)
            {
                return diagnoses[3];
            }
            if (percentRightAnswers < 100)
            {
                return diagnoses[4];
            }
            return diagnoses[5];
        }

        static string[] GetDiagnoses()
        {
            var diagnoses = new string[6];
            diagnoses[0] = "кретин";
            diagnoses[1] = "идиот";
            diagnoses[2] = "дурак";
            diagnoses[3] = "нормальный";
            diagnoses[4] = "талант";
            diagnoses[5] = "гений";
            return diagnoses;
        }
    }
}