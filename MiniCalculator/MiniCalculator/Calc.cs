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
        public double memval;
        public bool eqClicked = false;
        public void init()
        {
            A = 0;
            B = 0;
            res = 0;
            operation = "";
            eqClicked = false;
        }
        public void Calculate()
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
            if (operation == "%")
                res = A / 100.0 * B;
            if (operation == "^") 
                res = Math.Pow(A, B);
        }
    }
}
