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
        static int index = 0;
        static bool fileOpened = false;
        static List<FileSystemInfo> list = new List<FileSystemInfo>();

        static void show()
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
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            //string path = Console.ReadLine();
            string path = "c:/";
            DirectoryInfo dir = new DirectoryInfo(@path);
            
            list.AddRange(dir.GetDirectories());
            list.AddRange(dir.GetFiles());

            Stack<DirectoryInfo> stack = new Stack<DirectoryInfo>();
            stack.Push(dir);

            while (true)
            {
                show();
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
                        if (list.Count == 0)
                            break;
                        else
                        {
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

                                // Read the file and display it line by line.
                                //StreamReader file = new StreamReader(@list[index].FullName);
                                Console.WriteLine(list[index].FullName);
                                /*string[] lines = System.IO.File.ReadAllLines(@list[index].FullName);
                                foreach (string s in lines)
                                    Console.WriteLine("\t" + s);
                            
                                fileOpened = true;*/
                            }
                            break;
                        }
                        
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
                        if (fileOpened == true)
                        {
                            show();
                            fileOpened = false;
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Good bye!");
                            Console.ReadKey();
                            return;
                        }
                        
                }
            }
        }
    }
}
