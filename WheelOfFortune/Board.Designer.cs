namespace WheelOfFortune
{
    partial class Board
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
            this.guessButton = new System.Windows.Forms.Button();
            this.wordListView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // guessButton
            // 
            this.guessButton.Location = new System.Drawing.Point(335, 367);
            this.guessButton.Name = "guessButton";
            this.guessButton.Size = new System.Drawing.Size(75, 23);
            this.guessButton.TabIndex = 0;
            this.guessButton.Text = "Choose Letter";
            this.guessButton.UseVisualStyleBackColor = true;
            this.guessButton.Click += new System.EventHandler(this.guessButton_Click);
            // 
            // wordListView
            // 
            this.wordListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.wordListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordListView.GridLines = true;
            this.wordListView.Location = new System.Drawing.Point(109, 171);
            this.wordListView.Name = "wordListView";
            this.wordListView.Size = new System.Drawing.Size(543, 181);
            this.wordListView.TabIndex = 1;
            this.wordListView.TileSize = new System.Drawing.Size(40, 40);
            this.wordListView.UseCompatibleStateImageBehavior = false;
            this.wordListView.View = System.Windows.Forms.View.Tile;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WheelOfFortune.Properties.Resources.Wheel_of_fortune_logo;
            this.panel1.Location = new System.Drawing.Point(158, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 169);
            this.panel1.TabIndex = 2;
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WheelOfFortune.Properties.Resources.Wheel_of_Fortune_Puzzle_Board_3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(723, 402);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.wordListView);
            this.Controls.Add(this.guessButton);
            this.Name = "Board";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Board_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button guessButton;
        private System.Windows.Forms.ListView wordListView;
        private System.Windows.Forms.Panel panel1;
    }
}

