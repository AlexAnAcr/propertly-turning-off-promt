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
    public partial class wait : Form
    {
        public wait()
        {
            InitializeComponent();
        }

        private void wait_Load(object sender, EventArgs e)
        {
            Left = -Width - 5;
        }
        private void wait_Shown(object sender, EventArgs e)
        {
            Hide();
        }
        private void wait_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.Application_ApplicationExit();
        }
    }
}
