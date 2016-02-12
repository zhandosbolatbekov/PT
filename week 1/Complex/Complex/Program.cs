using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a, b;
        public Complex() { }
        public Complex(int x, int y)
        {
            a = x;
            b = y;
        }
        public static int gcd(int x, int y)
        {
            while (x > 0 && y > 0)
                if (x > y)
                    x %= y;
                else
                    y %= x;
            return x + y;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            int q = c1.b * c2.b;
            int p = c1.a * c2.b + c1.b * c2.a;
            int g = gcd(p, q);
            return new Complex(p / g, q / g);
        }
        public override string ToString()
        {
            return a + "/" + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex A = new Complex(4, 5);
            Complex B = new Complex(2, 3);
            Complex C = A + B;
            Console.WriteLine(C.ToString());
            Console.ReadKey();
        }
    }
}
