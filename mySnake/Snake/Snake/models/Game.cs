using SnakeGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Game
    {
        public static Snake snake = new Snake();
        public static Food food = new Food();
        public static Wall wall = new Wall();
        public static int level = 1;
        public static int PTS = 0;
        public static bool GameOver = false;

        public static void Init()
        {
            Console.SetWindowSize(80, 25);
            Console.CursorVisible = false;

            Game.wall.setLevel(level);

            Game.snake.body.Clear();
            Game.snake.body.Add(new Point(10, 10));
            Game.snake.body.Add(new Point(9, 10));
            Game.snake.body.Add(new Point(8, 10));
            

            Game.food.setNewPos();
        }

        public static void Save()
        {
            snake.Save();
            wall.Save();
            food.Save();
        }

        public static void Resume()
        {
            snake.Resume();
            wall.Resume();
            food.Resume();
        }
    }
}
