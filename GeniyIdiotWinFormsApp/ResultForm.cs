using GeniusIdiot.Common;

namespace GeniyIdiotWinFormsApp
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }



        private void ResultForm1cs_Load(object sender, EventArgs e)
        {
            var results = UserResultsStorage.GetUserResults();
            foreach (var result in results)
            {
                resultsDataGridView.Rows.Add(result.Name, result.CountRightAnswers, result.Diagnose);
            }
        }

        private void resultsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
