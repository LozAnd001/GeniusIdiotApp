namespace GeniusIdiotAndreyPerediiDZA
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
                var user = new User(userName);
                var countQuestions = questions.Count;
                var random = new Random();
                for (int i = 0; i < countQuestions; ++i)
                {
                    Console.WriteLine($"Вопрос №{i + 1}");
                    var randomQuestionIndex = random.Next(0, questions.Count);
                    Console.WriteLine(questions[randomQuestionIndex].Text);
                    var userAnswer = GetNumber();
                    var rightAnswer = questions[randomQuestionIndex].Answer;
                    if (userAnswer == rightAnswer)
                    {
                        user.AcceptRightAnswer();
                    }
                    questions.RemoveAt(randomQuestionIndex);
                }
                Console.WriteLine($"Количество правильных ответов: {user.CountRightAnswers}");
                var diagnose = CalculateDiagnoses(user.CountRightAnswers, countQuestions);
                user.Diagnose = diagnose;
                Console.WriteLine($"{userName}, ваш диагноз: {user.Diagnose}");
                UserResultsStorage.Save(user);
                var userChoice = GetUserChoice("Хотите посмотреть предыдущие результаты игры?");
                if(userChoice)
                {
                    ShowUserResults();
                }
                userChoice = GetUserChoice("Хотите добавить новый вопрос?");
                if (userChoice)
                {
                    AddNewQuestion();
                }
                userChoice = GetUserChoice("Хотите начать сначала?");
                if(userChoice == false)
                {
                    break;
                }
            }
        }

        static void AddNewQuestion()
        {
            Console.WriteLine("Введите текс вопроса");
            var text = Console.ReadLine();
            Console.WriteLine("Введите ответ на вопрос");
            var answer = GetNumber();
            var newQuestion = new Question(text, answer);
            QuestionStorage.Add(newQuestion);
        }

        static void ShowUserResults()
        {
            var users = UserResultsStorage.GetUserResults();
            
            Console.WriteLine("{0,-20}, {1,18}, {2,15}", "Имя", "Кол-во правильных ответов", "Диагноз");
            foreach (var user in users) 
            {
                Console.WriteLine("{0,-20}, {1,18}, {2,15}", user.Name, user.CountRightAnswers, user.Diagnose);
            }
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

        static int GetNumber()
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