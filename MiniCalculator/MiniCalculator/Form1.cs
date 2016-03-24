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

        private void num_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if(textBox.Text == "0" && b.Text != ",")
                textBox.Text = b.Text;
            else
                textBox.Text += b.Text;
        }
        private void oper_click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            calc.A = Convert.ToDouble(textBox.Text);
            calc.operation = b.Text;
            textBox.Text = "0";
        }
        private void getres_click(object sender, EventArgs e)
        {
            calc.B = Convert.ToDouble(textBox.Text);
            calc.GetRes();
            textBox.Text = Convert.ToString(calc.res);
        }
    }
}
