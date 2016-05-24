using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MathDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int Sum(int a,int b)
        {
            Console.WriteLine("{0}+{1}={2}",a,b,a+b);
            return a + b;
        }
    }
}
