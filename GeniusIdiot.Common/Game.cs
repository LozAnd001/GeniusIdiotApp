using System;
using System.Collections.Generic;
using System.Threading;

namespace GeniusIdiot.Common
{
    public class Game
    {
        private User user;
        private List<Question> questions;
        private Question currentQuestion;
        private int questionNumber = 0;
        private int countQuestions;
        public Game(User user)
        {
            this.user = user;
            questions = QuestionStorage.GetAll();
            countQuestions = questions.Count;
        }
        public Question GetNextQuestion()
        {
            var random = new Random();  
            var randomQuestionIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomQuestionIndex];
            questionNumber++;
            return currentQuestion;
        }
        public void AcceptAnswer(int userAnswer)
        {
            int rightAnswer = currentQuestion.Answer;
            if(userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.Remove(currentQuestion);

        }
        public string GetQuestionNumberText()
        {
            return "Вопрос №" + questionNumber;
        }
        public bool End()
        {
            return questions.Count == 0;
        }
    }
}
