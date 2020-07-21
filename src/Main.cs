using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LaptopPropertlyTurningOffPromt
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string[] tb_t = textBox1.Lines;
            Array.Resize(ref tb_t, tb_t.Length + 2);
            tb_t[tb_t.Length - 2] = "Система автоматической диагностики Windows 8 обнаружила " + Program.npof.ToString() + " " + plural_format(Program.npof, "небезопасное завершение", "небезопасных завершения", "небезопасных завершений") + " работы Вашего компьютера с Windows 8.";
            tb_t[tb_t.Length - 1] = "    Windows 8, " + string.Format("{0:D} {0:t}", DateTime.Now);
            textBox1.Lines = tb_t;
            textBox1.SelectionStart = 0; textBox1.SelectionLength = 0;
        }

        string plural_format(int num,string num_1,string num_2,string num_5)
        {
            byte hundred = (byte)(num % 100); byte ten = (byte)(hundred % 10);
            if (hundred > 10 && hundred < 20)
            {
                return num_5;
            }
            else if (ten > 1 && ten < 5)
            {
                return num_2;
            }
            else if (ten == 1)
            {
                return num_1;
            }
            else
            {
                return num_5;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
