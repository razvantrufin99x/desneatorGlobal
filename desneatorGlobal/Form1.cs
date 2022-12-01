using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace desneatorGlobal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g1;
        Pen pen1 = new Pen(Color.Black, 1);
        Pen penr = new Pen(Color.Red, 1);
        Pen peng = new Pen(Color.Green, 1);
        Pen penb = new Pen(Color.Blue, 1);
        Pen pen0 = new Pen(Color.White, 1);
        Pen pengr = new Pen(Color.Gray, 1);
        Pen penag = new Pen(Color.Silver, 1);
        Font f;
        Brush b;
        locatie prev = new locatie();
        locatie next = new locatie();
        locatie curent = new locatie();
        locatie mouse = new locatie();
        bool ismousedown = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            g1 = pictureBox1.CreateGraphics();
            f = Font;
            b = new SolidBrush(Color.Black);

        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            //cerculete
            float step = 6.0f;
            for (float i = 0.0f; i < 360.0f+step; i+=step)
            {

                g1.DrawEllipse(pen1, (int)i , (int)i , 4, 4);

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            


            Text = e.X.ToString() + " : " + e.Y.ToString();
           


            mouse.x = e.X;
            mouse.y = e.Y;

            if (ismousedown == true)
            {
                g1.DrawLine(pen1, prev.x, prev.y, mouse.x, mouse.y);
                prev.x = mouse.x;
                prev.y = mouse.y;
            }
            Text += " : ";
            Text += prev.x.ToString(); Text += " : ";
            Text += prev.y.ToString(); Text += " : ";
            Text += prev.z.ToString(); Text += " : ";
            Text += mouse.x.ToString(); Text += " : ";
            Text += mouse.y.ToString(); Text += " : ";
            Text += mouse.z.ToString(); Text += " : ";

            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //grila 
            int whg = 20;
            for(int i = 0; i< 90; i++)
            {
                g1.DrawLine(penag, i * whg, 0, i * whg, pictureBox1.Height);
            }
            for (int j = 0; j < 90; j++)
            {
                g1.DrawLine(pengr, 0, j * whg, pictureBox1.Width, j * whg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismousedown = true;
            prev.x = mouse.x;
            prev.y = mouse.y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismousedown = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //animatie cerc
            float rx = 100;
            float ry = 100;
            float posx = 200;
            float posy = 200;
            float rad = (float)(180 / Math.PI);

            curent.x = (float)Math.Cos(0 / rad) * rx + posx;
            curent.y = (float)Math.Sin(0 / rad) * ry + posy;
            prev.x = curent.x;
            prev.y = curent.y;

            for (int k = 1; k < 4; k++)
            {
                for (int i = 0; i < 361; i++)
                {
                    curent.x = (float)Math.Cos(i / rad) * rx + posx;
                    curent.y = (float)Math.Sin(i / rad) * ry + posy;

                    g1.DrawLine(pen1, curent.x, curent.y, prev.x, prev.y);

                    prev.x = curent.x;
                    prev.y = curent.y;

                    Thread.Sleep(2);
                }
                rx+=10; 
                ry+=10;

            }
        }


    }
}
