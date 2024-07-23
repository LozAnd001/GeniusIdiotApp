using GeniusIdiotConsoleApp;

namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int countQuestions;
        private User user;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetAll();
            countQuestions = questions.Count;
            user = new User("Неизвестно");
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionTextLabel.Text = currentQuestion.Text;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = currentQuestion.Answer;
            if(userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            var endGame = questions.Count == 0;
            if(endGame)
            {
                user.Diagnose = 

            }
            questions.Remove(currentQuestion);
            ShowNextQuestion();

        }
    }
}
