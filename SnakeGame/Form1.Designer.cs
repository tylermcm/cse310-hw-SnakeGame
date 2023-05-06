using System.Windows.Forms;

namespace SnakeGame
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
            this.components = new System.ComponentModel.Container();
            this.gameBoard = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.welcomeSubLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.difficultyMenu = new System.Windows.Forms.ToolStripComboBox();
            this.eatSound = new System.Media.SoundPlayer("collect.wav");
            this.dieSound = new System.Media.SoundPlayer("die.wav");
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // gameBoard
            // 
            this.gameBoard.BackColor = System.Drawing.Color.Blue;
            this.gameBoard.Location = new System.Drawing.Point(13, 100);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(1082, 1050);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.TabStop = false;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.updateGameState);
            //
            // difficultyLabel
            // 
            this.difficultyLabel = new System.Windows.Forms.ToolStripLabel();
            this.difficultyLabel.Text = "Difficulty:";
            this.difficultyLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficultyLabel.ForeColor = System.Drawing.Color.Black;
            //
            // toolStrip
            //
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.difficultyLabel, this.difficultyMenu });
            this.toolStrip.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(200, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip";
            this.Controls.Add(this.toolStrip);
            //
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Black;
            this.scoreLabel.Location = new System.Drawing.Point(450, 40); // Update the position
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(103, 32);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "Score:";
            this.Controls.Add(this.scoreLabel);
            //
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueLabel.ForeColor = System.Drawing.Color.Black;
            this.valueLabel.Location = new System.Drawing.Point(565, 40); // Update the position
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(49, 32);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "0";
            this.Controls.Add(this.valueLabel);
            //
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = false;
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameOverLabel.ForeColor = System.Drawing.Color.Black;
            this.gameOverLabel.BackColor = System.Drawing.Color.Blue;
            this.gameOverLabel.Size = new System.Drawing.Size(560, 560);
            this.gameOverLabel.Location = new System.Drawing.Point(275, 300);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.TabIndex = 3;
            this.gameOverLabel.Text = "";
            this.Controls.Add(this.gameOverLabel);
            //
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = false;
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.Black;
            this.welcomeLabel.BackColor = System.Drawing.Color.Blue;
            this.welcomeLabel.Size = new System.Drawing.Size(600, 75);
            this.welcomeLabel.Location = new System.Drawing.Point(260, 300);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.TabIndex = 3;
            this.welcomeLabel.Text = "";
            this.Controls.Add(this.welcomeLabel);
            // 
            // welcomeSubLabel
            // 
            this.welcomeSubLabel.AutoSize = false;
            this.welcomeSubLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.welcomeSubLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeSubLabel.ForeColor = System.Drawing.Color.Black;
            this.welcomeSubLabel.BackColor = System.Drawing.Color.Blue;
            this.welcomeSubLabel.Size = new System.Drawing.Size(600, 250);
            this.welcomeSubLabel.Location = new System.Drawing.Point(260, 350);
            this.welcomeSubLabel.Name = "welcomeSubLabel";
            this.welcomeSubLabel.TabIndex = 3;
            this.welcomeSubLabel.Text = "";
            this.Controls.Add(this.welcomeSubLabel);
            // 
            // difficultyMenu
            // 
            this.difficultyMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficultyMenu.BackColor = System.Drawing.Color.White; 
            this.difficultyMenu.ForeColor = System.Drawing.Color.Black; 
            this.difficultyMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
            this.difficultyMenu.Items.AddRange(new object[] {
            "Easy",
            "Normal",
            "Hard",
            "Insane",
            "Impossible"});
            this.difficultyMenu.Name = "difficultyMenu";
            this.difficultyMenu.Size = new System.Drawing.Size(175, 25);
            this.difficultyMenu.SelectedIndexChanged += new System.EventHandler(this.difficultySelector);
            this.difficultyMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.difficultyComboBox_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1110, 1163);
            this.Icon = new System.Drawing.Icon("snake.ico");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.welcomeSubLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.gameBoard);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Name = "Form1";
            this.Text = "Snake Game Tyler McMurtrey";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.PictureBox gameBoard;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label welcomeSubLabel;
        private System.Windows.Forms.ToolStripLabel difficultyLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripComboBox difficultyMenu;
        private System.Media.SoundPlayer eatSound;
        private System.Media.SoundPlayer dieSound;
    }
}

