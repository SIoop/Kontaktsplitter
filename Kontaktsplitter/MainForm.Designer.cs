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
            this.AddTitelButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ConvertSalutationButton = new System.Windows.Forms.Button();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LetterSalutationTextBox = new System.Windows.Forms.TextBox();
            this.TitelComboBox = new System.Windows.Forms.ComboBox();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.TitelLabel = new System.Windows.Forms.Label();
            this.LetterSalutationLabel = new System.Windows.Forms.Label();
            this.SalutationLabel = new System.Windows.Forms.Label();
            this.SalutationComboBox = new System.Windows.Forms.ComboBox();
            this.ContactEntryLabel = new System.Windows.Forms.Label();
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
            this.ContactSplitGroupBox.Controls.Add(this.AddTitelButton);
            this.ContactSplitGroupBox.Controls.Add(this.CancelButton);
            this.ContactSplitGroupBox.Controls.Add(this.SaveButton);
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
            // AddTitelButton
            // 
            this.AddTitelButton.Location = new System.Drawing.Point(474, 288);
            this.AddTitelButton.Name = "AddTitelButton";
            this.AddTitelButton.Size = new System.Drawing.Size(134, 23);
            this.AddTitelButton.TabIndex = 17;
            this.AddTitelButton.Text = "Neuen Titel hinzufügen";
            this.AddTitelButton.UseVisualStyleBackColor = true;
            this.AddTitelButton.Click += new System.EventHandler(this.OnAddTitelButtonClick);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(695, 288);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 16;
            this.CancelButton.Text = "Abbrechen";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(614, 288);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Speichern";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // ConvertSalutationButton
            // 
            this.ConvertSalutationButton.Location = new System.Drawing.Point(413, 17);
            this.ConvertSalutationButton.Name = "ConvertSalutationButton";
            this.ConvertSalutationButton.Size = new System.Drawing.Size(123, 23);
            this.ConvertSalutationButton.TabIndex = 14;
            this.ConvertSalutationButton.Text = "Kontakt aufsplitten";
            this.ConvertSalutationButton.UseVisualStyleBackColor = true;
            this.ConvertSalutationButton.Click += new System.EventHandler(this.OnConvertSalutationButtonClick);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(555, 252);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.LastNameTextBox.TabIndex = 13;
            this.LastNameTextBox.Leave += new System.EventHandler(this.OnLastNameTextBoxLeave);
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(555, 226);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(215, 20);
            this.FirstNameTextBox.TabIndex = 12;
            this.FirstNameTextBox.Leave += new System.EventHandler(this.OnFirstNameTextBoxLeave);
            // 
            // LetterSalutationTextBox
            // 
            this.LetterSalutationTextBox.Location = new System.Drawing.Point(555, 146);
            this.LetterSalutationTextBox.Name = "LetterSalutationTextBox";
            this.LetterSalutationTextBox.Size = new System.Drawing.Size(215, 20);
            this.LetterSalutationTextBox.TabIndex = 11;
            this.LetterSalutationTextBox.Leave += new System.EventHandler(this.OnLetterSalutationTextBoxLeave);
            // 
            // TitelComboBox
            // 
            this.TitelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TitelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TitelComboBox.FormattingEnabled = true;
            this.TitelComboBox.Location = new System.Drawing.Point(555, 172);
            this.TitelComboBox.Name = "TitelComboBox";
            this.TitelComboBox.Size = new System.Drawing.Size(215, 21);
            this.TitelComboBox.TabIndex = 10;
            this.TitelComboBox.Leave += new System.EventHandler(this.OnTitelComboBoxLeave);
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "ohne",
            "weiblich",
            "männlich",
            "divers"});
            this.GenderComboBox.Location = new System.Drawing.Point(555, 199);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(215, 21);
            this.GenderComboBox.TabIndex = 9;
            this.GenderComboBox.Leave += new System.EventHandler(this.OnGenderComboBoxLeave);
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(346, 255);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(62, 13);
            this.LastNameLabel.TabIndex = 8;
            this.LastNameLabel.Text = "Nachname:";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(346, 229);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(52, 13);
            this.FirstNameLabel.TabIndex = 7;
            this.FirstNameLabel.Text = "Vorname:";
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(346, 202);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(64, 13);
            this.GenderLabel.TabIndex = 6;
            this.GenderLabel.Text = "Geschlecht:";
            // 
            // TitelLabel
            // 
            this.TitelLabel.AutoSize = true;
            this.TitelLabel.Location = new System.Drawing.Point(346, 175);
            this.TitelLabel.Name = "TitelLabel";
            this.TitelLabel.Size = new System.Drawing.Size(30, 13);
            this.TitelLabel.TabIndex = 5;
            this.TitelLabel.Text = "Titel:";
            // 
            // LetterSalutationLabel
            // 
            this.LetterSalutationLabel.AutoSize = true;
            this.LetterSalutationLabel.Location = new System.Drawing.Point(346, 149);
            this.LetterSalutationLabel.Name = "LetterSalutationLabel";
            this.LetterSalutationLabel.Size = new System.Drawing.Size(134, 13);
            this.LetterSalutationLabel.TabIndex = 4;
            this.LetterSalutationLabel.Text = "Standartisierte Briefanrede:";
            // 
            // SalutationLabel
            // 
            this.SalutationLabel.AutoSize = true;
            this.SalutationLabel.Location = new System.Drawing.Point(346, 122);
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
            this.SalutationComboBox.Location = new System.Drawing.Point(555, 119);
            this.SalutationComboBox.Name = "SalutationComboBox";
            this.SalutationComboBox.Size = new System.Drawing.Size(215, 21);
            this.SalutationComboBox.TabIndex = 2;
            this.SalutationComboBox.Leave += new System.EventHandler(this.OnSalutationComboBoxLeave);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 335);
            this.Controls.Add(this.ContactSplitGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 374);
            this.MinimumSize = new System.Drawing.Size(816, 374);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button AddTitelButton;
    }
}

