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
        public static bool GameOver;

        public static void Init()
        {
            Console.SetWindowSize(80, 25);
            GameOver = false;

            Game.snake.body.Add(new Point(10, 10));
            Game.snake.body.Add(new Point(9, 10));
            Game.snake.body.Add(new Point(8, 10));

            Game.wall.setLevel(1);

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
