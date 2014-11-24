namespace Program8
{
    partial class Form1
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
            this.EnterSearchTextLabel = new System.Windows.Forms.Label();
            this.SearchTextTextBox = new System.Windows.Forms.TextBox();
            this.SearchResultsListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.TotalRowsFoundLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnterSearchTextLabel
            // 
            this.EnterSearchTextLabel.AutoSize = true;
            this.EnterSearchTextLabel.Location = new System.Drawing.Point(13, 13);
            this.EnterSearchTextLabel.Name = "EnterSearchTextLabel";
            this.EnterSearchTextLabel.Size = new System.Drawing.Size(93, 13);
            this.EnterSearchTextLabel.TabIndex = 0;
            this.EnterSearchTextLabel.Text = "Enter Search Text";
            // 
            // SearchTextTextBox
            // 
            this.SearchTextTextBox.Location = new System.Drawing.Point(228, 13);
            this.SearchTextTextBox.Name = "SearchTextTextBox";
            this.SearchTextTextBox.Size = new System.Drawing.Size(194, 20);
            this.SearchTextTextBox.TabIndex = 1;
            // 
            // SearchResultsListBox
            // 
            this.SearchResultsListBox.FormattingEnabled = true;
            this.SearchResultsListBox.Location = new System.Drawing.Point(13, 47);
            this.SearchResultsListBox.Name = "SearchResultsListBox";
            this.SearchResultsListBox.Size = new System.Drawing.Size(644, 251);
            this.SearchResultsListBox.TabIndex = 2;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(61, 305);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(266, 305);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // TotalRowsFoundLabel
            // 
            this.TotalRowsFoundLabel.AutoSize = true;
            this.TotalRowsFoundLabel.Location = new System.Drawing.Point(61, 356);
            this.TotalRowsFoundLabel.Name = "TotalRowsFoundLabel";
            this.TotalRowsFoundLabel.Size = new System.Drawing.Size(100, 13);
            this.TotalRowsFoundLabel.TabIndex = 5;
            this.TotalRowsFoundLabel.Text = "Total Rows Found: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 452);
            this.Controls.Add(this.TotalRowsFoundLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchResultsListBox);
            this.Controls.Add(this.SearchTextTextBox);
            this.Controls.Add(this.EnterSearchTextLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnterSearchTextLabel;
        private System.Windows.Forms.TextBox SearchTextTextBox;
        private System.Windows.Forms.ListBox SearchResultsListBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label TotalRowsFoundLabel;
    }
}

