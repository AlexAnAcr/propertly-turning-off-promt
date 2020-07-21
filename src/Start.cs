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
    public partial class Start : Form
    {
        Graphics pb_g; SolidBrush alpha_brush; byte color_num = 255; Bitmap bmp = new Bitmap(524, 400); byte cycles = 0; byte direction = 0;
        public Start()
        {
            InitializeComponent();
            pb_g = Graphics.FromImage(bmp);
            pb_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            timer1.Start();
        } 
        private void timer1_Tick(object sender, EventArgs e)
        {
            alpha_brush = new SolidBrush(Color.FromArgb(color_num, Color.LightGray.R, Color.LightGray.G, Color.LightGray.B));
            pb_g.FillRectangle(Brushes.LightGray,0,0, pictureBox1.Width, pictureBox1.Height);
            pb_g.DrawImage(Properties.Resources.windows_8_logo_large2,0,0,524,400);
            pb_g.FillRectangle(alpha_brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            if (direction == 0)
            {
                color_num -= 15;
                if (color_num == 0)
                {
                    if (cycles < 5)
                    {
                        direction = 1;
                        cycles++;
                    } else
                    {
                        timer1.Stop();
                        Program.Open_MainForm();
                        Close();
                    }
                }
            }
            else
            {
                color_num += 15;
                if (color_num == 135)
                {
                    direction = 0;
                }
            }
        }
    }
 }
