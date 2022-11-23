using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tarea4___FILTROS
{
     public partial class Form1 : Form
    {
        Image img;
        Bitmap current_bmp, reset_bmp;
        Color negativo, sepia, grises, blanco_negro,original;

        int op = 1;

        private void button3_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < current_bmp.Height; y++)
            {
                for (int x = 0; x < current_bmp.Width; x++)
                {
                    grises = current_bmp.GetPixel(x, y);
                    int average = ((int)grises.R + (int)grises.G + (int)grises.B) / 3;
                    current_bmp.SetPixel(x, y, Color.FromArgb(average, average, average));
                }
            }
            op = 3;
            Form1.ActiveForm.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < current_bmp.Height; y++)
            {
                for (int x = 0; x < current_bmp.Width; x++)
                {
                    sepia = current_bmp.GetPixel(x, y);

                    int a = sepia.A;
                    int r = sepia.R;
                    int g = sepia.G;
                    int b = sepia.B;

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    current_bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            op = 3;
            Form1.ActiveForm.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < current_bmp.Height; y++)
            {
                for (int x = 0; x < current_bmp.Width; x++)
                {
                    blanco_negro = current_bmp.GetPixel(x, y);
                    int average = ((int)blanco_negro.R + (int)blanco_negro.G + (int)blanco_negro.B) / 3;
                    int blackWhite = 0;
                    if (average > 50)
                    {
                        blackWhite = 255;
                    }
                    current_bmp.SetPixel(x, y, Color.FromArgb(blackWhite, blackWhite, blackWhite));
                }
            }
            op = 3;
            Form1.ActiveForm.Refresh();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            switch (op)
            {
                //Inicializa imagen
                case 1:
                    g.DrawImage(current_bmp, 210, 0, 330, 400);
                    break;
                //Imagen original
                case 2:
                    g.DrawImage(current_bmp, 210, 0, 330, 400);
                    break;
                //Aplicacion de filtros
                case 3:
                    g.DrawImage(current_bmp, 210, 0, 330, 400);
                    break;

            }
        }

        public Form1() 
        {
            InitializeComponent();

            img = Image.FromFile("C:/Users/HP/Desktop/Tarea4 - FILTROS/Image/image.jpg");
            current_bmp = (Bitmap)img;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image img2 = Image.FromFile("C:/Users/HP/Desktop/Tarea4 - FILTROS/Image/image.jpg");
            reset_bmp = (Bitmap)img2;
            current_bmp = reset_bmp;
            op = 2;
            Form1.ActiveForm.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < current_bmp.Height; y++)
            {
                for (int x = 0; x < current_bmp.Width; x++)
                {
                    negativo = Color.FromArgb(current_bmp.GetPixel(x, y).A, 255 - current_bmp.GetPixel(x, y).R, 255 - current_bmp.GetPixel(x, y).G, 255 - current_bmp.GetPixel(x, y).B);
                    current_bmp.SetPixel(x, y, negativo);
                }
            }
            op = 3;
            Form1.ActiveForm.Refresh();
        }
    }
}
