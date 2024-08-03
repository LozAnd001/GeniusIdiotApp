using GeniusIdiot.Common;

namespace GeniusIdiotConsoleApp
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("Введите ваше имя");
                var game = new Game(new User(Console.ReadLine()));
                while(!game.End())
                {
                    var currentQuestion = game.GetNextQuestion();
                    Console.WriteLine(game.GetQuestionNumberText());
                    Console.WriteLine(currentQuestion.Text);
                    var userAnswer = GetNumber();
                    game.AcceptAnswer(userAnswer);
                }
                var message = game.CalculateDiagnose();
                Console.WriteLine(message);
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
                userChoice = GetUserChoice("Хотите добавить удалить существующий вопрос?");
                if (userChoice)
                {
                    RemoveQuestion();
                }
                userChoice = GetUserChoice("Хотите начать сначала?");
                if(userChoice == false)
                {
                    break;
                }
            }
        }

        static void RemoveQuestion()
        {
            Console.WriteLine("Введите номер удаляемого вопроса");
            var questions = QuestionStorage.GetAll();
            for(int i = 0; i < questions.Count; ++i)
            {
                Console.WriteLine((i+1) + ". " + questions[i].Text);
            }
            var removeQuestionNumber = GetNumber();
            while(removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
            {
                Console.WriteLine("Введите число от 1 до " + questions.Count);
                removeQuestionNumber = GetNumber();
            }
            var removeQuestion = questions[removeQuestionNumber-1];
            QuestionStorage.Remove(removeQuestion);
           
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
           int number; string errorMessage;
           while (!InputValidator.TryParseToNumber(Console.ReadLine(), out number, out errorMessage))
           {
                Console.WriteLine(errorMessage);
           }
            return number;
        }
    }
}