namespace Kontaktsplitter
{
    partial class AddTitelForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ShortTitelTextBox = new System.Windows.Forms.TextBox();
            this.ShortTitel = new System.Windows.Forms.Label();
            this.TitelLabel = new System.Windows.Forms.Label();
            this.TitelTextBox = new System.Windows.Forms.TextBox();
            this.TitelGroupBox = new System.Windows.Forms.GroupBox();
            this.TitelGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(376, 132);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Abbrechen";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(295, 132);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Speichern";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.OnSaveButtonClick);
            // 
            // ShortTitelTextBox
            // 
            this.ShortTitelTextBox.Location = new System.Drawing.Point(216, 64);
            this.ShortTitelTextBox.Name = "ShortTitelTextBox";
            this.ShortTitelTextBox.Size = new System.Drawing.Size(215, 20);
            this.ShortTitelTextBox.TabIndex = 1;
            // 
            // ShortTitel
            // 
            this.ShortTitel.AutoSize = true;
            this.ShortTitel.Location = new System.Drawing.Point(6, 67);
            this.ShortTitel.Name = "ShortTitel";
            this.ShortTitel.Size = new System.Drawing.Size(61, 13);
            this.ShortTitel.TabIndex = 19;
            this.ShortTitel.Text = "Abkürzung:";
            // 
            // TitelLabel
            // 
            this.TitelLabel.AutoSize = true;
            this.TitelLabel.Location = new System.Drawing.Point(7, 30);
            this.TitelLabel.Name = "TitelLabel";
            this.TitelLabel.Size = new System.Drawing.Size(30, 13);
            this.TitelLabel.TabIndex = 19;
            this.TitelLabel.Text = "Titel:";
            // 
            // TitelTextBox
            // 
            this.TitelTextBox.Location = new System.Drawing.Point(216, 27);
            this.TitelTextBox.Name = "TitelTextBox";
            this.TitelTextBox.Size = new System.Drawing.Size(215, 20);
            this.TitelTextBox.TabIndex = 0;
            // 
            // TitelGroupBox
            // 
            this.TitelGroupBox.Controls.Add(this.CancelButton);
            this.TitelGroupBox.Controls.Add(this.TitelTextBox);
            this.TitelGroupBox.Controls.Add(this.SaveButton);
            this.TitelGroupBox.Controls.Add(this.TitelLabel);
            this.TitelGroupBox.Controls.Add(this.ShortTitel);
            this.TitelGroupBox.Controls.Add(this.ShortTitelTextBox);
            this.TitelGroupBox.Location = new System.Drawing.Point(12, 12);
            this.TitelGroupBox.Name = "TitelGroupBox";
            this.TitelGroupBox.Size = new System.Drawing.Size(457, 161);
            this.TitelGroupBox.TabIndex = 21;
            this.TitelGroupBox.TabStop = false;
            // 
            // AddTitelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(481, 192);
            this.Controls.Add(this.TitelGroupBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(497, 231);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(497, 231);
            this.Name = "AddTitelForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Titel hinzufügen";
            this.TopMost = true;
            this.TitelGroupBox.ResumeLayout(false);
            this.TitelGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox ShortTitelTextBox;
        private System.Windows.Forms.Label ShortTitel;
        private System.Windows.Forms.Label TitelLabel;
        private System.Windows.Forms.TextBox TitelTextBox;
        private System.Windows.Forms.GroupBox TitelGroupBox;
    }
}