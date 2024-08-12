using GeniusIdiot.Common;
using GeniusIdiotWinFormsApp;

namespace GeniyIdiotWinFormsApp
{
    public partial class mainForm : Form
    {
        private Game game;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            var welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
            var user = new User(welcomeForm.userNameTextBox.Text);
            game = new Game(user);
            ShowNextQuestion();
        }

        private void ShowNextQuestion()
        {
            var currentQuestion = game.GetNextQuestion();
            questionTextLabel.Text = currentQuestion.Text;
            questionNumberLabel.Text = game.GetQuestionNumberText();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(userAnswerTextBox.Text, out int userAnswer, out string errorMessage);
            if (!parsed)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                game.AcceptAnswer(userAnswer);

                if (game.End())
                {
                    var message = game.CalculateDiagnose();
                    MessageBox.Show(message);
                    return;
                }
                ShowNextQuestion();
            }
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ğåñòàğòToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ïğåäûäóùèåĞåçóëüòàòûToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultForm = new ResultForm();
            resultForm.ShowDialog();
        }

        private void äîáàâèòüÂîïğîñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newQuestionForm = new AddNewQuestionForm();
            newQuestionForm.ShowDialog();
        }

        private void îòîáğàæåíèåÑïèñêàÂñåõÂîïğîñâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var questionListForm = new QuestionListForm();
            questionListForm.ShowDialog();
        }
    }
}
