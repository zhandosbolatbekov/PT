using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        public enum Direction { right, down, left, up };
        public static Direction dir;

        static void Main(string[] args)
        {
            Game.Init();

            Thread T = new Thread(Move);
            T.Start();
            
            while (!Game.GameOver)
            {
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        dir = Direction.up;
                        break;
                    case ConsoleKey.DownArrow:
                        dir = Direction.down;
                        break;
                    case ConsoleKey.RightArrow:
                        dir = Direction.right;
                        break;
                    case ConsoleKey.LeftArrow:
                        dir = Direction.left;
                        break;
                    case ConsoleKey.Escape:
                        Game.GameOver = true;
                        break;
                    case ConsoleKey.F1:
                        Game.Save();
                        break;
                    case ConsoleKey.F2:
                        Game.Resume();
                        break;
                }
            }
            End();
            Console.ReadKey();
        }
        public static void Move(object state)
        {
            while (!Game.GameOver)
            {
                switch (dir)
                {
                    case Direction.up:
                        Game.snake.move(0, -1);
                        break;
                    case Direction.down:
                        Game.snake.move(0, 1);
                        break;
                    case Direction.right:
                        Game.snake.move(1, 0);
                        break;
                    case Direction.left:
                        Game.snake.move(-1, 0);
                        break;
                }
                Game.snake.Draw();
                Thread.Sleep(100);
            }
            End();
        }
        public static void End()
        {
            Console.Clear();
            Console.SetCursorPosition(20, 10);
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Game Over!");
        }
    }
}
