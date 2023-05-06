using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Square> snake = new List<Square>();
        private Square food = new Square();

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            this.KeyDown += keyDown;
            this.KeyUp += keyUp;
            this.KeyPreview = true;
        }


        private void InitializeGame()
        {
            new Settings();
            difficultyMenu.SelectedIndexChanged += difficultySelector;
            difficultyMenu.KeyDown += difficultyComboBox_KeyDown;
            gameTimer.Tick += updateScreen;
            gameTimer.Start();
            gameBoard.Paint += updateGameState;

            Settings.GameOver = true;
        }


        private void keyDown(object sender, KeyEventArgs e)
            {
                Input.changeState(e.KeyCode, true);
            }

        private void keyUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void difficultyComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Ignore arrow key presses
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // Check if the game has started, ended or is running, and display the appropriate information
        private void updateGameState(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            // Display the welcome message
            if (Settings.CurrentState == GameState.Welcome)
            {
                welcomeLabel.Visible = true;
                welcomeSubLabel.Visible = true;
                welcomeLabel.Text = "Welcome to Snake!";
                welcomeSubLabel.Text =  "Select a Difficulty and" +
                                        "\nPress Enter to Start or" +
                                        "\nPress Enter to Play" +
                                        "\nin Practice Mode";
                gameOverLabel.Visible = false;
            }
            // Display the game over message
            else if (Settings.CurrentState == GameState.GameOver)
            {
                welcomeLabel.Visible = false;
                welcomeSubLabel.Visible = false;
                gameOverLabel.Visible = true;
                gameOverLabel.Text = "Game Over\nYour final score is: " + Settings.Score + "\nPress Enter to try again";
            }
            // Color the snake for each body in the snake list
            else
            {
                welcomeLabel.Visible = false;
                welcomeSubLabel.Visible= false;
                gameOverLabel.Visible = false;

                for (int i = 0; i < snake.Count; i++)
                {
                    canvas.FillRectangle(Brushes.Yellow, new Rectangle(snake[i].X * Settings.Width, snake[i].Y * Settings.Height, Settings.Width, Settings.Height));
                }

                canvas.FillRectangle(Brushes.Red, new Rectangle(food.X * Settings.Width, food.Y * Settings.Height, Settings.Width, Settings.Height));
            }
        }

        // Start, end, or run the game 
        private void updateScreen(object sender, EventArgs e)
        {
            if (Input.KeyPress(Keys.Enter))
            {
                startGame();
            }

            if (Settings.GameOver)
            {
                GameOver();
            }
            else
            {
                UpdateDirection();
                movePlayer();
            }

            gameBoard.Invalidate();
        }

        // Allows for the difficulty to be changed when selecting the various options from the 
        // drop down combo box
        private void difficultySelector(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = (ToolStripComboBox)sender;
            int selectedIndex = comboBox.SelectedIndex;

            if (selectedIndex >= 0)
            {
                switch (selectedIndex)
                {
                    case 0:
                        Settings.SetDifficulty(Difficulty.Easy);
                        break;
                    case 1:
                        Settings.SetDifficulty(Difficulty.Normal);
                        break;
                    case 2:
                        Settings.SetDifficulty(Difficulty.Hard);
                        break;
                    case 3:
                        Settings.SetDifficulty(Difficulty.Insane);
                        break;
                    case 4:
                        Settings.SetDifficulty(Difficulty.Impossible);
                        break;
                }
                gameTimer.Interval = 1000 / Settings.Speed;
            }
        }

        // Clear the snake list, and initialize a new snake
        private void startGame()
        {
            new Settings();
            Settings.CurrentState = GameState.Playing;
            snake.Clear();
            Square head = new Square { X = 10, Y = 5 };

            // Initialize the snake with 5 body squares
            for (int i = 0; i < 5; i++)
            {
                Square body = new Square { X = 10 - i, Y = 5 };
                snake.Add(body);
            }

            valueLabel.Text = Settings.Score.ToString();

            // Generate the first food
            generateFood();
        }

        // Randomly generate a piece of food somehwhere on the game board
        private void generateFood()
        {
            int maxXpos = (gameBoard.Size.Width / Settings.Width) - 13;
            int maxYpos = (gameBoard.Size.Width / Settings.Height) - 13;
            Random rand = new Random();

            // Place the food at a random position within the game board
            food = new Square { X = rand.Next(0, maxXpos), Y = rand.Next(0, maxYpos) };
        }

        // Increase the length of the snake when a food is eaten, depending on the difficulty set
        private void eat()
        {
            eatSound.Play();
            int growth;
            switch (Settings.Difficulty)
            {
                case Difficulty.Easy:
                    growth = 2;
                    if (snake.Count >= 15)
                        growth = 5;
                    break;
                case Difficulty.Normal:
                    growth = 3;
                    if (snake.Count >= 35)
                        growth = 6;
                    break;
                case Difficulty.Hard:
                    growth = 4;
                    if (snake.Count >= 45)
                        growth = 7;
                    break;
                case Difficulty.Insane:
                    growth = 5;
                    if (snake.Count >= 55)
                        growth = 8;
                    break;
                case Difficulty.Impossible:
                    growth = 6;
                    if (snake.Count >= 65)
                        growth = 9;
                    break;
                default:
                    growth = 3;
                    break;
            }

            // Add the body squares to the snake
            for (int i = 0; i < growth; i++)
            {
                Square body = new Square
                {
                    X = snake[snake.Count - 1].X,
                    Y = snake[snake.Count - 1].Y
                };
                snake.Add(body);
            }

            // Update the score and display it
            Settings.Score += Settings.Points;
            valueLabel.Text = Settings.Score.ToString();

            // Generate a new food
            generateFood();
        }

        // Change the direction when an arrow key is pressed
        private void UpdateDirection()
        {
            if (Input.KeyPress(Keys.Right) && Settings.Direction != Directions.Left)
                Settings.Direction = Directions.Right;
            else if (Input.KeyPress(Keys.Left) && Settings.Direction != Directions.Right)
                Settings.Direction = Directions.Left;
            else if (Input.KeyPress(Keys.Up) && Settings.Direction != Directions.Down)
                Settings.Direction = Directions.Up;
            else if (Input.KeyPress(Keys.Down) && Settings.Direction != Directions.Up)
                Settings.Direction = Directions.Down;
        }

        // Move the player in the direction of the pressed key
        private void movePlayer()
        {
            for (int i = snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    // Move the head based on direction
                    switch (Settings.Direction)
                    {
                        case Directions.Right:
                            snake[i].X++;
                            break;
                        case Directions.Left:
                            snake[i].X--;
                            break;
                        case Directions.Up:
                            snake[i].Y--;
                            break;
                        case Directions.Down:
                            snake[i].Y++;
                            break;
                    }

                    CheckCollision();
                }
                else
                {
                    // Move the body
                    snake[i].X = snake[i - 1].X;
                    snake[i].Y = snake[i - 1].Y;
                }
            }
        }

        // Check if the player has collided with itself or a wall, or if it has made contact with a piece of food
        // and call the die or eat functions respectively
        private void CheckCollision()
        {
            int maxXpos = gameBoard.Size.Width / Settings.Width;
            int maxYpos = gameBoard.Size.Height / Settings.Height;

            // Check for collisions with the boundaries
            if (snake[0].X < 0 || snake[0].Y < 0 || snake[0].X > maxXpos || snake[0].Y > maxYpos)
            {
                die();
            }

            // Check for collisions with the body
            for (int j = 1; j < snake.Count; j++)
            {
                if (snake[0].X == snake[j].X && snake[0].Y == snake[j].Y)
                {
                    die();
                }
            }

            // Check for collisions with food
            if (snake[0].X == food.X && snake[0].Y == food.Y)
            {
                eat();
            }
        }

        // Play a 'death' sound and change the game over state
        private void die()
        {
            dieSound.Play();
            Settings.GameOver = true;
            Settings.CurrentState = GameState.GameOver;
        }
    
        // Change the game over state and allow the game to be restarted
        private void GameOver()
        {
            Settings.GameOver = true;
            if (Input.KeyPress(Keys.Enter))
            {
                startGame();
                Settings.GameOver = false;
            }
        }

    }
}
