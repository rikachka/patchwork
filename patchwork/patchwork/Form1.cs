using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patchwork
{
    public partial class Form1 : Form
    {
        Brush[] COLR = { Brushes.Aqua, Brushes.Orange, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Azure, Brushes.Violet, Brushes.Tomato, Brushes.SteelBlue, Brushes.PapayaWhip };
        Bitmap[] Cirpich;
        Graphics c;
        Bitmap POLE = new Bitmap(300, 300);
        byte[,] Area = new byte[10, 21];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //c = Graphics.FromImage(POLE);
            //c.FillRectangle(new SolidBrush(Color.FromArgb(0, 45, 45)), 0, 0, 210 + 4, 420 + 4);
            //for (int x = 0; x < 11; x++) { c.DrawLine(new Pen(Color.FromArgb(0, 70, 70)), x * 21 + 1, 1, x * 21, 420 + 3); }
            //for (int x = 0; x < 21; x++) { c.DrawLine(new Pen(Color.FromArgb(0, 70, 70)), 1, x * 21 + 1, 210 + 3, x * 21); }
            //Cirpich = new Bitmap[COLR.Length];
            //for (int i = 0; i < COLR.Length; i++)
            //{
            //    Cirpich[i] = new Bitmap(21, 21);
            //    c = Graphics.FromImage(Cirpich[i]);
            //    c.FillRectangle(COLR[i], 0, 0, 21, 21);
            //    c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(1, 20), new Point(20, 20));
            //    c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(20, 20), new Point(20, 1));
            //}
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(POLE, 0, 0);
            //if (fig != null)
            //{
            //    for (int x = 0; x < 4; x++)
            //        for (int y = 0; y < 4; y++)
            //        {
            //            if (fig.pic[x, y])
            //                e.Graphics.DrawImage(Cirpich[fig.Col], (fig.x + x) * 21 + 1, (fig.y + y) * 21 + 1);
            //        }
            //}
            //for (int x = 0; x < 9; x++)
            //{
            //    for (int y = 0; y < 9; y++)
            //    {
            //        if (Area[x, y] > 0)
            //        {
            //            e.Graphics.DrawImage(Cirpich[Area[x, y]], x * 21 + 1, y * 21 + 1);
            //        }
            //    }
            //}
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_opponent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
