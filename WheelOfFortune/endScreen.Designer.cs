namespace WheelOfFortune
{
    partial class endScreen
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
            this.endProgramButton = new System.Windows.Forms.Button();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // endProgramButton
            // 
            this.endProgramButton.Location = new System.Drawing.Point(36, 180);
            this.endProgramButton.Name = "endProgramButton";
            this.endProgramButton.Size = new System.Drawing.Size(75, 23);
            this.endProgramButton.TabIndex = 0;
            this.endProgramButton.Text = "Close";
            this.endProgramButton.UseVisualStyleBackColor = true;
            this.endProgramButton.Click += new System.EventHandler(this.endProgramButton_Click);
            // 
            // playAgainButton
            // 
            this.playAgainButton.Location = new System.Drawing.Point(153, 180);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(75, 23);
            this.playAgainButton.TabIndex = 1;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = true;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.Color.Red;
            this.resultLabel.Location = new System.Drawing.Point(12, 22);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(87, 20);
            this.resultLabel.TabIndex = 2;
            this.resultLabel.Text = "Text Here";
            // 
            // endScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WheelOfFortune.Properties.Resources.winner;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.endProgramButton);
            this.Name = "endScreen";
            this.Text = "endScreen";
            this.Load += new System.EventHandler(this.endScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button endProgramButton;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Label resultLabel;
    }
}