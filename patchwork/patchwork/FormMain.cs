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
        Bitmap POLE; 
        byte[,] Area = new byte[10, 21];

        PlayerBoard player_board;
        PlayerBoard opponent_board;
        Patches patches;

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
            this.PanelPlayer.Invalidate();
            this.PanelOpponent.Invalidate();
            this.PanelBoard.Invalidate();
            this.PanelPatches.Invalidate();
			patches.PaintTakenPatch(e);
		}

        private void PanelPlayer_Layout(object sender, LayoutEventArgs e)
        {
            player_board = new PlayerBoard(this.TableLayoutPanelPlayer);
            

            /*Cirpich = new Bitmap[COLR.Length];
            for (int i = 0; i < COLR.Length; i++)
            {
                Cirpich[i] = new Bitmap(21, 21);
                c = Graphics.FromImage(Cirpich[i]);
                c.FillRectangle(COLR[i], 0, 0, 21, 21);
                c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(1, 20), new Point(20, 20));
                c.DrawLine(new Pen(Color.FromArgb(70, Color.Black), 2), new Point(20, 20), new Point(20, 1));
            }*/
        }

        private void PanelPlayer_Paint(object sender, PaintEventArgs e)
        {
            player_board.Paint(e);
        }

        private void PanelOpponent_Layout(object sender, LayoutEventArgs e)
        {
            opponent_board = new PlayerBoard(this.TableLayoutPanelOpponent);
        }

        private void PanelOpponent_Paint(object sender, PaintEventArgs e)
        {
            opponent_board.Paint(e);
        }

        private void PanelPatches_Layout(object sender, LayoutEventArgs e)
        {
            patches = new Patches(this.PanelPatches, this.TableLayoutPanelMain);
        }

        private void PanelPatches_Paint(object sender, PaintEventArgs e)
        {
            patches.Paint(e);
        }

        private void PanelPatches_MouseDown(object sender, MouseEventArgs e)
        {
            patches.TakeOne(e.X, e.Y);
			this.PanelPatches.Invalidate();
		}

		private void PanelPatches_MouseUp(object sender, MouseEventArgs e)
		{
			patches.PutOne(e.X, e.Y);
			this.PanelPatches.Invalidate();
		}

		private void PanelPatches_MouseMove(object sender, MouseEventArgs e)
		{
			if (patches.IsPatchTaken()) {
				patches.MoveOne(e.X, e.Y);
				//this.PanelPatches.Invalidate();
				//this.TableLayoutPanelMain.Invalidate();
				Invalidate();
			}
		}

		private void TableLayoutPanelMain_Paint(object sender, PaintEventArgs e)
		{
			//patches.PaintTakenPatch(e);
		}
	}
}
