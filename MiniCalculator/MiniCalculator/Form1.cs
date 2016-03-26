using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCalculator
{
    public partial class MiniCalc : Form
    {
        private Calc calc = new Calc();
        public MiniCalc()
        {
            InitializeComponent();
        }

        private void num_click(object sender, EventArgs e) {
            Button b = sender as Button;
            if (display.Text == "0" && b.Text != ",")
                display.Text = b.Text;
            else {
                if (b.Text == ",")
                {
                    bool exist = false;
                    foreach (char c in display.Text)
                        if (c == ',')
                            exist = true;
                    if (!exist)
                        display.Text += b.Text;
                }
                else
                {
                    display.Text += b.Text;
                }
            }
        }
        private void oper_click(object sender, EventArgs e) {
            Button b = sender as Button;
            calc.A = Convert.ToDouble(display.Text);
            calc.operation = b.Text;
            display.Text = "0";
        }
        private void factorial_click(object sender, EventArgs e) {
            double N = Convert.ToDouble(display.Text);
            calc.res = 1;
            for (int i = 1; i <= N; ++i)
                calc.res *= i;
            display.Text = Convert.ToString(calc.res);
        }
        private void getres_click(object sender, EventArgs e)
        {
            if (calc.eqClicked == true)
            {
                calc.A = calc.res;
                calc.Calculate();
            }
            else
            {
                calc.B = Convert.ToDouble(display.Text);
                calc.Calculate();
            }
            display.Text = Convert.ToString(calc.res);
            calc.eqClicked = true;
        }

        private void backspace_click(object sender, EventArgs e) {
            if (display.Text.Length == 1) {
                display.Text = "0";
            }
            else {
                string cur = "";
                for (int i = 0; i < display.Text.Length - 1; ++i)
                    cur += display.Text[i];
                display.Text = cur;
            }
        }
        private void sqrt_click(object sender, EventArgs e) {
            double x = Math.Sqrt(Convert.ToDouble(display.Text));
            display.Text = Convert.ToString(x);
        }
        private void clearAll(object sender, EventArgs e) {
            calc.init();
            display.Text = "0";
        }
        private void clearCur(object sender, EventArgs e) {
            display.Text = "0";
        }
        private void revValue_click(object sender, EventArgs e) {
            double x = Convert.ToDouble(display.Text);
            display.Text = Convert.ToString(1/x);
        }
        private void revSign_click(object sender, EventArgs e) {
            if (Convert.ToDouble(display.Text) == 0)
                return;
            string cur = "";
            if (display.Text[0] == '-') {
                for (int i = 1; i < display.Text.Length; ++i)
                    cur += display.Text[i];
                display.Text = cur;
            }
            else {
                cur = "-";
                for (int i = 0; i < display.Text.Length; ++i)
                    cur += display.Text[i];
                display.Text = cur;
            }
        }
        private void memory_click(object sender, EventArgs e) {
            Button b = sender as Button;
            switch (b.Text) {
                case "MS":
                    calc.memval = Convert.ToDouble(display.Text);
                    break;
                case "MR":
                    display.Text = Convert.ToString(calc.memval);
                    break;
                case "MC":
                    calc.memval = 0;
                    display.Text = "0";
                    break;
                case "M+":
                    calc.memval += Convert.ToDouble(display.Text);
                    break;
                case "M-":
                    calc.memval -= Convert.ToDouble(display.Text);
                    break;
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(display.Text);
            display.Text = Convert.ToString(x * x);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(display.Text);
            display.Text = Convert.ToString(x * x * x);
        }
    }
}
