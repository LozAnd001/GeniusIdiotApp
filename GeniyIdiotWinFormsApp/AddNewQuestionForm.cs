using GeniusIdiot.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeniusIdiotWinFormsApp
{
    public partial class AddNewQuestionForm : Form
    {
        public AddNewQuestionForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var parsed = InputValidator.TryParseToNumber(answerTextBox.Text, out int userANswer, out string errorMessage);
            if(!parsed)
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                var newQuestion = new Question(questionTextBox.Text, userANswer);
                QuestionStorage.Add(newQuestion);
            }
        }
    }
}
