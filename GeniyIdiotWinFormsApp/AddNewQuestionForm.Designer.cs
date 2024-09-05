namespace GeniusIdiotWinFormsApp
{
    partial class AddNewQuestionForm
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
            label1 = new Label();
            label2 = new Label();
            questionTextBox = new TextBox();
            answerTextBox = new TextBox();
            addButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(72, 50);
            label1.Name = "label1";
            label1.Size = new Size(141, 28);
            label1.TabIndex = 0;
            label1.Text = "Текс вопроса";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(72, 106);
            label2.Name = "label2";
            label2.Size = new Size(155, 28);
            label2.TabIndex = 1;
            label2.Text = "Ответ вопроса";
            // 
            // questionTextBox
            // 
            questionTextBox.Location = new Point(235, 50);
            questionTextBox.Name = "questionTextBox";
            questionTextBox.Size = new Size(340, 27);
            questionTextBox.TabIndex = 2;
            // 
            // answerTextBox
            // 
            answerTextBox.Location = new Point(235, 110);
            answerTextBox.Name = "answerTextBox";
            answerTextBox.Size = new Size(340, 27);
            answerTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addButton.Location = new Point(184, 164);
            addButton.Name = "addButton";
            addButton.Size = new Size(288, 60);
            addButton.TabIndex = 4;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // AddNewQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addButton);
            Controls.Add(answerTextBox);
            Controls.Add(questionTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddNewQuestionForm";
            Text = "AddNewQuestionForm";
            Load += AddNewQuestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox questionTextBox;
        private TextBox answerTextBox;
        private Button addButton;
    }
}