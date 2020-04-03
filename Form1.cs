using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace risovalka
{
    public partial class Form1 : Form
    {
        Bitmap pic; 
        int x1, y1;

        public Form1()
        {
            
            InitializeComponent();

            pic = new Bitmap(1000, 1000);   //создаем картинку и задаем ей размеры  
            x1 = y1 = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel);
            {
                textBox1.BackColor = colorDialog1.Color;
            }
            
        }



        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
                pic.Save(saveFileDialog1.FileName);

        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(textBox1.BackColor, trackBar1.Value);    //создаем карандаш цвета текстбокса и размера трэкбара


            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;  //задали наконечники для пллавной линии

            Graphics g;
            g = Graphics.FromImage(pic);     


            if (e.Button == MouseButtons.Left) //чтобы рисовалость, когда зажата левая кнопка мыши
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);  //проводит линию соединяющую две точки, задаваемые парами координат
                pictureBox2.Image = pic;    //записываем в пикчр бокс то, что нарисовали в графикс
            }
                x1 = e.X;
                y1 = e.Y;
            }  
    }   


    }

