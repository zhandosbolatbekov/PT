using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SNAKE.Models
{
    public class Drawer
    {
        public List<Point> body = new List<Point>();
        public ConsoleColor color;
        public char sign;

        public Drawer() { }
        public void Draw()
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
            string fname = "snake.xml";
            if (sign == '@')
                fname = "food.xml";
            if (sign == '#')
                fname = "wall.xml";
            string path = @"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\SNAKE\SNAKE\SNAKE\xml\" + fname;
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(GetType());
            xs.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            string fname = "snake.xml";
            if (sign == '@')
                fname = "food.xml";
            if (sign == '#')
                fname = "wall.xml";
            string path = @"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\SNAKE\SNAKE\SNAKE\xml\" + fname;
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(GetType());

            if (sign == 'o')
            {
                Game.snake.body.Clear();
                Game.snake = xs.Deserialize(fs) as Snake;
            }
            if (sign == '#')
            {
                Game.wall.body.Clear();
                Game.wall = xs.Deserialize(fs) as Wall;
            }
            if (sign == '@')
            {
                Game.food.body.Clear();
                Game.food = xs.Deserialize(fs) as Food;
            }
            fs.Close();
        }
    }
}
