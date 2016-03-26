using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.models
{
    [Serializable]
    class Wall : Drawer 
    {
        public Wall()
        {
            sign = '#';
            color = ConsoleColor.White;
        }
        public void setLevel(int level)
        {
            FileStream fs = new FileStream(string.Format(@"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\mySnake\Snake\Snake\levels\level{0}.txt", level), FileMode.Open, FileAccess.Read);
            //FileStream fs = new FileStream(string.Format(@"level{0}.txt", level), FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);
            string[] rows = sr.ReadToEnd().Split('\n');
            body.Clear();
            Console.Clear();
            for (int i = 0; i < rows.Length; ++i)
                for (int j = 0; j < rows[i].Length; ++j)
                    if (rows[i][j] == '#')
                    {
                        body.Add(new Point(j, i));
                        Console.ForegroundColor = color;
                        Console.SetCursorPosition(j, i);
                        Console.Write(sign);
                    }
            sr.Close();
            fs.Close();
        }
    }
}
