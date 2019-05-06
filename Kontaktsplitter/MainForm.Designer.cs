namespace Kontaktsplitter
{
    partial class MainForm
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
            this.ContactEntryTextBox = new System.Windows.Forms.TextBox();
            this.ContactSplitGroupBox = new System.Windows.Forms.GroupBox();
            this.TitelLabel = new System.Windows.Forms.Label();
            this.LetterSalutationLabel = new System.Windows.Forms.Label();
            this.SalutationLabel = new System.Windows.Forms.Label();
            this.SalutationComboBox = new System.Windows.Forms.ComboBox();
            this.ContactEntryLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.TitelComboBox = new System.Windows.Forms.ComboBox();
            this.LetterSalutationTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.ConvertSalutationButton = new System.Windows.Forms.Button();
            this.ContactSplitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactEntryTextBox
            // 
            this.ContactEntryTextBox.Location = new System.Drawing.Point(75, 19);
            this.ContactEntryTextBox.Name = "ContactEntryTextBox";
            this.ContactEntryTextBox.Size = new System.Drawing.Size(323, 20);
            this.ContactEntryTextBox.TabIndex = 0;
            // 
            // ContactSplitGroupBox
            // 
            this.ContactSplitGroupBox.Controls.Add(this.ConvertSalutationButton);
            this.ContactSplitGroupBox.Controls.Add(this.LastNameTextBox);
            this.ContactSplitGroupBox.Controls.Add(this.FirstNameTextBox);
            this.ContactSplitGroupBox.Controls.Add(this.LetterSalutationTextBox);
            this.ContactSplitGroupBox.Controls.Add(this.TitelComboBox);
            this.ContactSplitGroupBox.Controls.Add(this.GenderComboBox);
            this.ContactSplitGroupBox.Controls.Add(this.LastNameLabel);
            this.ContactSplitGroupBox.Controls.Add(this.FirstNameLabel);
            this.ContactSplitGroupBox.Controls.Add(this.GenderLabel);
            this.ContactSplitGroupBox.Controls.Add(this.TitelLabel);
            this.ContactSplitGroupBox.Controls.Add(this.LetterSalutationLabel);
            this.ContactSplitGroupBox.Controls.Add(this.SalutationLabel);
            this.ContactSplitGroupBox.Controls.Add(this.SalutationComboBox);
            this.ContactSplitGroupBox.Controls.Add(this.ContactEntryLabel);
            this.ContactSplitGroupBox.Controls.Add(this.ContactEntryTextBox);
            this.ContactSplitGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ContactSplitGroupBox.Name = "ContactSplitGroupBox";
            this.ContactSplitGroupBox.Size = new System.Drawing.Size(776, 317);
            this.ContactSplitGroupBox.TabIndex = 1;
            this.ContactSplitGroupBox.TabStop = false;
            // 
            // TitelLabel
            // 
            this.TitelLabel.AutoSize = true;
            this.TitelLabel.Location = new System.Drawing.Point(311, 175);
            this.TitelLabel.Name = "TitelLabel";
            this.TitelLabel.Size = new System.Drawing.Size(30, 13);
            this.TitelLabel.TabIndex = 5;
            this.TitelLabel.Text = "Titel:";
            // 
            // LetterSalutationLabel
            // 
            this.LetterSalutationLabel.AutoSize = true;
            this.LetterSalutationLabel.Location = new System.Drawing.Point(311, 149);
            this.LetterSalutationLabel.Name = "LetterSalutationLabel";
            this.LetterSalutationLabel.Size = new System.Drawing.Size(134, 13);
            this.LetterSalutationLabel.TabIndex = 4;
            this.LetterSalutationLabel.Text = "Standartisierte Briefanrede:";
            // 
            // SalutationLabel
            // 
            this.SalutationLabel.AutoSize = true;
            this.SalutationLabel.Location = new System.Drawing.Point(311, 122);
            this.SalutationLabel.Name = "SalutationLabel";
            this.SalutationLabel.Size = new System.Drawing.Size(44, 13);
            this.SalutationLabel.TabIndex = 3;
            this.SalutationLabel.Text = "Anrede:";
            // 
            // SalutationComboBox
            // 
            this.SalutationComboBox.FormattingEnabled = true;
            this.SalutationComboBox.Items.AddRange(new object[] {
            "Frau",
            "Frau Dr.",
            "Frau Prof.",
            "Herrn",
            "Herrn Dr.",
            "Herrn Prof."});
            this.SalutationComboBox.Location = new System.Drawing.Point(520, 119);
            this.SalutationComboBox.Name = "SalutationComboBox";
            this.SalutationComboBox.Size = new System.Drawing.Size(215, 21);
            this.SalutationComboBox.TabIndex = 2;
            // 
            // ContactEntryLabel
            // 
            this.ContactEntryLabel.AutoSize = true;
            this.ContactEntryLabel.Location = new System.Drawing.Point(6, 22);
            this.ContactEntryLabel.Name = "ContactEntryLabel";
            this.ContactEntryLabel.Size = new System.Drawing.Size(64, 13);
            this.ContactEntryLabel.TabIndex = 1;
            this.ContactEntryLabel.Text = "Briefanrede:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(311, 202);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(64, 13);
            this.GenderLabel.TabIndex = 6;
            this.GenderLabel.Text = "Geschlecht:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(311, 229);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(52, 13);
            this.FirstNameLabel.TabIndex = 7;
            this.FirstNameLabel.Text = "Vorname:";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(311, 255);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(62, 13);
            this.LastNameLabel.TabIndex = 8;
            this.LastNameLabel.Text = "Nachname:";
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "ohne",
            "weiblich",
            "männlich",
            "divers"});
            this.GenderComboBox.Location = new System.Drawing.Point(520, 199);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(215, 21);
            this.GenderComboBox.TabIndex = 9;
            // 
            // TitelComboBox
            // 
            this.TitelComboBox.FormattingEnabled = true;
            this.TitelComboBox.Location = new System.Drawing.Point(520, 172);
            this.TitelComboBox.Name = "TitelComboBox";
            this.TitelComboBox.Size = new System.Drawing.Size(215, 21);
            this.TitelComboBox.TabIndex = 10;
            // 
            // LetterSalutationTextBox
            // 
            this.LetterSalutationTextBox.Location = new System.Drawing.Point(520, 146);
            this.LetterSalutationTextBox.Name = "LetterSalutationTextBox";
            this.LetterSalutationTextBox.Size = new System.Drawing.Size(215, 20);
            this.LetterSalutationTextBox.TabIndex = 11;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(520, 226);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.FirstNameTextBox.TabIndex = 12;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(520, 252);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.LastNameTextBox.TabIndex = 13;
            // 
            // ConvertSalutationButton
            // 
            this.ConvertSalutationButton.Location = new System.Drawing.Point(421, 17);
            this.ConvertSalutationButton.Name = "ConvertSalutationButton";
            this.ConvertSalutationButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertSalutationButton.TabIndex = 14;
            this.ConvertSalutationButton.Text = "Klick mich";
            this.ConvertSalutationButton.UseVisualStyleBackColor = true;
            this.ConvertSalutationButton.Click += new System.EventHandler(this.OnConvertSalutationButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContactSplitGroupBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Kontaktsplitter";
            this.ContactSplitGroupBox.ResumeLayout(false);
            this.ContactSplitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ContactEntryTextBox;
        private System.Windows.Forms.GroupBox ContactSplitGroupBox;
        private System.Windows.Forms.Label TitelLabel;
        private System.Windows.Forms.Label LetterSalutationLabel;
        private System.Windows.Forms.Label SalutationLabel;
        private System.Windows.Forms.ComboBox SalutationComboBox;
        private System.Windows.Forms.Label ContactEntryLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LetterSalutationTextBox;
        private System.Windows.Forms.ComboBox TitelComboBox;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Button ConvertSalutationButton;
    }
}

