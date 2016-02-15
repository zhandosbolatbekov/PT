using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FarManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirectoryInfo dir = new DirectoryInfo(path);
            List<FileSystemInfo> list = new List<FileSystemInfo>();
            list.AddRange(dir.GetDirectories());
            list.AddRange(dir.GetFiles());

            int index = 0;

            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();
            stack.Push(dir);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < list.Count; ++i)
                {
                    if (i == index)
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    if (list[i].GetType() == typeof(FileInfo))
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(list[i].Name);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        else
                            index = list.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index < list.Count - 1)
                            index++;
                        else
                            index = 0;
                        break;
                    case ConsoleKey.Enter:
                        if (list[index].GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(list[index].FullName);
                            stack.Push(dir);
                            index = 0;
                            list.Clear();
                            list.AddRange(dir.GetDirectories());
                            list.AddRange(dir.GetFiles());
                        }
                        else
                        {
                            Console.Clear();
                            int counter = 0;
                            string line;

                            // Read the file and display it line by line.
                            StreamReader file = new StreamReader(list[index].FullName);
                            while ((line = file.ReadLine()) != null)
                            {
                                System.Console.WriteLine(line);
                                counter++;
                            }

                            file.Close();
                            System.Console.WriteLine("There were {0} lines.", counter);
                            // Suspend the screen.
                            System.Console.ReadLine();
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (stack.Count > 1)
                        {
                            stack.Pop();
                            dir = stack.Peek();
                            index = 0;
                            list.Clear();
                            list.AddRange(dir.GetDirectories());
                            list.AddRange(dir.GetFiles());
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("Good bye!");
                        Console.ReadKey();
                        return;
                }
                Console.Clear();
            }
        }
    }
}
