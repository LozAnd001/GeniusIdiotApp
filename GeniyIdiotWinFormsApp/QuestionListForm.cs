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
    public partial class QuestionListForm : Form
    {
        public QuestionListForm()
        {
            InitializeComponent();
        }

        private void QuestionListForm_Load(object sender, EventArgs e)
        {
                var questions = QuestionStorage.GetAll();
            foreach (var question in questions)
            {
                questionsDataGridView.Rows.Add(question.Text, question.Answer);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rows = questionsDataGridView.SelectedRows;
            if(rows.Count == 0)
            {
                MessageBox.Show("Вы не выбради строку");
                return;
            }
            var questionText = rows[0].Cells[0].Value.ToString();
            var questionAnswer = Convert.ToInt32(rows[0].Cells[1].Value);
            if(questionText != null)
            {
                QuestionStorage.Remove(new Question(questionText, questionAnswer));
            }
            Close();
        }
    }
}
