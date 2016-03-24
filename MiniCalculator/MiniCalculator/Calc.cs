using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCalculator
{
    class Calc
    {
        public double A;
        public double B;
        public double res;
        public string operation;
        public void GetRes()
        {
            if (operation == "+")
                res = A + B;
            if (operation == "-")
                res = A - B;
            if (operation == "*")
                res = A * B;

            if (operation == "/")
            {
                try
                {
                    res = A / B;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
