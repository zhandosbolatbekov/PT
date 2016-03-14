using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE.Models
{
    public class Game
    {
        public static Snake snake = new Snake();
        public static Food food = new Food();
        public static Wall wall = new Wall();
        public bool Gameover = false;
        
        public Game()
        {
            while (!Gameover)
            {
                Draw();
                ConsoleKeyInfo button = Console.ReadKey();
                if (button.Key == ConsoleKey.UpArrow)
                    snake.move(0, -1);
                if (button.Key == ConsoleKey.RightArrow)
                    snake.move(1, 0);
                if (button.Key == ConsoleKey.DownArrow)
                    snake.move(0, 1);
                if (button.Key == ConsoleKey.LeftArrow)
                    snake.move(-1, 0);
                if (snake.anyCollision())
                    Gameover = true;
                if (button.Key == ConsoleKey.F1)
                    Save();
                if (button.Key == ConsoleKey.F2)
                    Resume();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Game Over");
            Console.ReadKey();
        }

        public void Draw()
        {
            Console.Clear();
            snake.Draw();
            wall.Draw();
            food.Draw();
        }

        public void Save()
        {
            snake.Save();
            wall.Save();
            food.Save();
        }

        public void Resume()
        {
            snake.Resume();
            wall.Resume();
            food.Resume();
        }
    }
}
