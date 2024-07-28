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
            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
            questions = QuestionStorage.GetAll();
            countQuestions = questions.Count;
            user = new User(welcomeForm.userNameTextBox.Text);
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
            questionNumberLabel.Text = $"Âîïðîñ ¹{questionNumber}";

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var userAnswer = Convert.ToInt32(userAnswerTextBox.Text);
            var rightAnswer = currentQuestion.Answer;
            if (userAnswer == rightAnswer)
            {
                user.AcceptRightAnswer();
            }
            questions.Remove(currentQuestion);
            var endGame = questions.Count == 0;
            if (endGame)
            {
                user.Diagnose = Diagnose.Calculate(user.CountRightAnswers, countQuestions);
                UserResultsStorage.Save(user);
                MessageBox.Show(user.Name + ":" + user.Diagnose);
                return;
            }
            ShowNextQuestion();
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ðåñòàðòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ïðåäûäóùèåÐåçóëüòàòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultForm = new ResultForm();
            resultForm.ShowDialog();

        }
    }
}
