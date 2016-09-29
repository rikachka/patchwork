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
    public partial class FormMain : Form
    {
        Brush[] COLR = { Brushes.Aqua, Brushes.Orange, Brushes.Blue, Brushes.Red, Brushes.Green, Brushes.Azure, Brushes.Violet, Brushes.Tomato, Brushes.SteelBlue, Brushes.PapayaWhip };
        Bitmap[] Cirpich;
        Graphics c;
        Bitmap POLE; // = new Bitmap(300, 300);
        byte[,] Area = new byte[10, 21];

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
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

        private void FormMain_Paint(object sender, PaintEventArgs e)
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

        private void PanelPlayer_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(POLE, 0, 0);
        }

        private void PanelPlayer_Layout(object sender, LayoutEventArgs e)
        {
            int margin = 5;
            int panel_width = this.PanelPlayer.Width - margin * 2,
                panel_height = this.PanelPlayer.Height -  margin * 2,
                squares_number = 9;
            int board_length = panel_width < panel_height ? panel_width : panel_height;
            int square_length = board_length / squares_number;
            board_length = square_length * squares_number;
            int margin_width = (panel_width - board_length) / 2 + margin;
            int margin_height = (panel_height - board_length) / 2 + margin;

            POLE = new Bitmap(this.PanelPlayer.Width, this.PanelPlayer.Height);
            c = Graphics.FromImage(POLE);
            c.FillRectangle(new SolidBrush(Color.Green), margin_width, margin_height, board_length, board_length);
            for (int i = 0; i <= squares_number; i++) {
                c.DrawLine(new Pen(Color.Black), 
                    margin_width + i * square_length, 
                    margin_height, 
                    margin_width + i * square_length, 
                    margin_height + board_length);
            }
            for (int i = 0; i <= squares_number; i++) {
                c.DrawLine(new Pen(Color.Black), 
                    margin_width, 
                    margin_height + i * square_length, 
                    margin_width + board_length, 
                    margin_height + i * square_length);
            }
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
    }
}
