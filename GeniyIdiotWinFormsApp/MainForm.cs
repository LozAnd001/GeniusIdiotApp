using GeniusIdiot.Common;


namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private List<Question> questions;
        private Question currentQuestion;
        private int countQuestions;
        private User user;
        private int questionNumber;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            questions = QuestionStorage.GetAll();
            countQuestions = questions.Count;
            user = new User("Неизвестно");
            questionNumber = 0;
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var random = new Random();
            var randomIndex = random.Next(0, questions.Count);
            currentQuestion = questions[randomIndex];
            questionTextLabel.Text = currentQuestion.Text;
            questionNumber++;
            questionNumberLabel.Text = $"Вопрос №{questionNumber}";
            
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = currentQuestion.Answer;
            if(userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.Remove(currentQuestion);
            var endGame = questions.Count == 0;
            if(endGame)
            {
                user.Diagnose = Diagnose.Calculate(user.CountRightAnswers, countQuestions);
                MessageBox.Show(user.Diagnose);
                return;
            }
            ShowNextQuestion();
        }
    }
}
