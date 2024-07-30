namespace GeniyIdiotWinFormsApp
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultsDataGridView = new DataGridView();
            UserNameColumn = new DataGridViewTextBoxColumn();
            CountRightAnswersColumn = new DataGridViewTextBoxColumn();
            DiagnoseColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new DataGridViewColumn[] { UserNameColumn, CountRightAnswersColumn, DiagnoseColumn });
            resultsDataGridView.Location = new Point(2, 12);
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.RowHeadersWidth = 51;
            resultsDataGridView.Size = new Size(430, 401);
            resultsDataGridView.TabIndex = 0;
            // 
            // UserNameColumn
            // 
            UserNameColumn.HeaderText = "Имя";
            UserNameColumn.MinimumWidth = 6;
            UserNameColumn.Name = "UserNameColumn";
            UserNameColumn.Width = 125;
            // 
            // CountRightAnswersColumn
            // 
            CountRightAnswersColumn.HeaderText = "Кол-во правильных ответов";
            CountRightAnswersColumn.MinimumWidth = 6;
            CountRightAnswersColumn.Name = "CountRightAnswersColumn";
            CountRightAnswersColumn.Width = 125;
            // 
            // DiagnoseColumn
            // 
            DiagnoseColumn.HeaderText = "Диагноз";
            DiagnoseColumn.MinimumWidth = 6;
            DiagnoseColumn.Name = "DiagnoseColumn";
            DiagnoseColumn.Width = 125;
            // 
            // ResultForm1cs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 418);
            Controls.Add(resultsDataGridView);
            Name = "ResultForm1cs";
            Text = "ResultForm1cs";
            Load += ResultForm1cs_Load;
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView resultsDataGridView;
        private DataGridViewTextBoxColumn UserNameColumn;
        private DataGridViewTextBoxColumn CountRightAnswersColumn;
        private DataGridViewTextBoxColumn DiagnoseColumn;
    }
}