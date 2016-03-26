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
        public static Direction dir, prevDir;
        public static int period = 150;

        static void Main(string[] args)
        {
            Game.Init();

            Timer T = new Timer(Move);
            T.Change(0, period);
            
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
                        prevDir = dir;
                        Game.Save();
                        break;
                    case ConsoleKey.F2:
                        dir = prevDir;
                        Game.Resume();
                        break;
                }
            }
            End();
        }
        public static void Move(object state)
        {
            
            if(!Game.GameOver)
            {
                if (Game.PTS > 0 && Game.PTS % 4 == 0)
                {
                    period -= 25;
                    Game.level += 1;
                    Game.Init();
                    dir = Direction.right;
                }    
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
                
            }
            else End();
        }
        public static void End()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(25, 8);
            Console.WriteLine("You won {0} levels", Game.level - 1);
            Console.SetCursorPosition(25, 9);
            Console.WriteLine("You have {0} points", Game.PTS);
            Console.SetCursorPosition(25, 10);
            Console.ForegroundColor = ConsoleColor.Red; 
            Console.WriteLine("Game Over!");
        }
    }
}
