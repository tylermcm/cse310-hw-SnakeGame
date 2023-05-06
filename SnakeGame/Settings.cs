using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    };

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard,
        Insane,
        Impossible,
    };

    public enum GameState
    {
        Welcome,
        Playing,
        GameOver
    }

    class Settings
    {
        public static int Width = 16;
        public static int Height = 16;
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Difficulty Difficulty { get; set; }
        public static GameState CurrentState { get; set; }
        public static Directions Direction { get; set; }

        public Settings()
        {
            GameOver = false;
            Score = 0;
            Direction = Directions.Down;
            CurrentState = GameState.Welcome;
        }

        public static void SetDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    Speed = 10;
                    Points = 25;
                    break;
                case Difficulty.Normal:
                    Speed = 20;
                    Points = 50;
                    break;
                case Difficulty.Hard:
                    Speed = 30;
                    Points = 100;
                    break;
                case Difficulty.Insane:
                    Speed = 40;
                    Points = 200;
                    break;
                case Difficulty.Impossible:
                    Speed = 80;
                    Points = 500;
                    break;
            }
        }
    }
}
