using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNAKE.Models
{
    public class Wall : Drawer
    {
        public Wall() 
        {
            color = ConsoleColor.Red;
            sign = '#';
            setLevel(2);
        }
        public void setLevel(int level)
        {
            string filename = string.Format(@"C:\Users\Zhandos\Documents\Visual Studio 2012\Projects\SNAKE\SNAKE\level{0}.txt", level);
            
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string all = sr.ReadToEnd();
            string[] rows = all.Split('\n');
            
            body.Clear();
            for (int i = 0; i < rows.Length; ++i)
                for (int j = 0; j < rows[i].Length; ++j)
                    if (rows[i][j] == '#')
                        body.Add(new Point(j, i));

            sr.Close();
            fs.Close();
        }
    }
}
