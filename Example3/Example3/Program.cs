using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"c:\testfolder";
            DirectoryInfo d = new DirectoryInfo(startPath);
            int cnt = dfs(d);
            Console.WriteLine(cnt);
            Console.ReadKey();
        }
        static int dfs(DirectoryInfo d)
        {
            Stack<DirectoryInfo> st = new Stack<DirectoryInfo>();
            st.Push(d);
            int cnt_files = 0;
            while (st.Count > 0)
            {
                DirectoryInfo v = st.Peek();
                Console.WriteLine(v.FullName);
                st.Pop();
                FileInfo[] files = v.GetFiles();
                cnt_files += files.Length;
                DirectoryInfo[] dirs = v.GetDirectories();
                foreach(DirectoryInfo to in dirs) {
                    st.Push(to);
                }
            }

            return cnt_files;
        }
    }
}
