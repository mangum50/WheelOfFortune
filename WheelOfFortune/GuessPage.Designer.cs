namespace WheelOfFortune
{
    partial class GuessPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuessPage));
            this.guessTextbox = new System.Windows.Forms.TextBox();
            this.confirmGuess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guessTextbox
            // 
            this.guessTextbox.Location = new System.Drawing.Point(12, 183);
            this.guessTextbox.Name = "guessTextbox";
            this.guessTextbox.Size = new System.Drawing.Size(260, 20);
            this.guessTextbox.TabIndex = 0;
            // 
            // confirmGuess
            // 
            this.confirmGuess.Location = new System.Drawing.Point(30, 218);
            this.confirmGuess.Name = "confirmGuess";
            this.confirmGuess.Size = new System.Drawing.Size(75, 23);
            this.confirmGuess.TabIndex = 1;
            this.confirmGuess.Text = "Confirm";
            this.confirmGuess.UseVisualStyleBackColor = true;
            this.confirmGuess.Click += new System.EventHandler(this.confirmGuess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(95, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Take a Guess";
            // 
            // GuessPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmGuess);
            this.Controls.Add(this.guessTextbox);
            this.Name = "GuessPage";
            this.Text = "GuessPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox guessTextbox;
        private System.Windows.Forms.Button confirmGuess;
        private System.Windows.Forms.Label label1;
    }
}