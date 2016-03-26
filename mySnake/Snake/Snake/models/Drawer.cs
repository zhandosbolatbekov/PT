using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SnakeGame.models
{
    [Serializable]
    class Drawer
    {
        public List<Point> body = new List<Point>();
        public char sign;
        public ConsoleColor color;
        public Drawer() { }
        public virtual void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
        public void Save()
        {
            string fname = "snake.ser";
            if (sign == '@')
                fname = "food.ser";
            if (sign == '#')
                fname = "wall.ser";
            string path = @"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\mySnake\Snake\Snake\ser\" + fname;
            //FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            //XmlSerializer xs = new XmlSerializer(GetType());
            //xs.Serialize(fs, this);
            //fs.Close();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }
        public void Resume()
        {
            string fname = "snake.ser";
            if (sign == '@')
                fname = "food.ser";
            if (sign == '#')
                fname = "wall.ser";
            string path = @"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\mySnake\Snake\Snake\ser\" + fname;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            if (sign == 'O')
            {
                updateConsole(color, ' ', ref Game.snake.body);
                Game.snake.body.Clear();
                Game.snake = bf.Deserialize(fs) as Snake;
                updateConsole(color, sign, ref Game.snake.body);
            }
            if (sign == '#')
            {
                updateConsole(color, ' ', ref Game.wall.body);
                Game.wall.body.Clear();
                Game.wall = bf.Deserialize(fs) as Wall;
                updateConsole(color, sign, ref Game.wall.body);
            }
            if (sign == '@')
            {
                updateConsole(color,' ', ref Game.food.body);
                Game.food.body.Clear();
                Game.food = bf.Deserialize(fs) as Food;
                updateConsole(color, sign, ref Game.food.body);
            }
            fs.Close();
        }
        public static void updateConsole(ConsoleColor color, char sign, ref List<Point> body)
        {
            Console.ForegroundColor = color;
            foreach(Point p in body){
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }
    }
}