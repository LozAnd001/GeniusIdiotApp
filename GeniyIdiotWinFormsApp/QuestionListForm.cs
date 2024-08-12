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
            foreach(var question in questions)
            {
                questionsDataGridView.Rows.Add(question.Text, question.Answer);
            }
        }
    }
}
