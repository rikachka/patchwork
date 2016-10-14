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
	public class ExtendedPanel : Panel
	{
		private const int WS_EX_TRANSPARENT = 0x20;
		public ExtendedPanel()
		{
			SetStyle(ControlStyles.Opaque, true);
		}

		//private int opacity = 50;
		//[DefaultValue(50)]
		//public int Opacity
		//{
		//	get
		//	{
		//		return this.opacity;
		//	}
		//	set
		//	{
		//		if (value < 0 || value > 100)
		//			throw new ArgumentException("value must be between 0 and 100");
		//		this.opacity = value;
		//	}
		//}
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
				return cp;
			}
		}
		//protected override void OnPaint(PaintEventArgs e)
		//{
		//	using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
		//	{
		//		e.Graphics.FillRectangle(brush, this.ClientRectangle);
		//	}
		//	base.OnPaint(e);
		//}
	}

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

		ExtendedPanel PanelOver = new ExtendedPanel();
		//Panel PanelOver = new Panel();

		public FormMain()
        {
            InitializeComponent();
			

			PanelOver.BackColor = Color.Blue;
			//PanelOver.Opacity = 5;
			//PanelOver.TransparencyKey = Color.Blue;
			//PanelOver.BackColor = Color.FromArgb(0, Color.Red);
			PanelOver.Size = new Size(this.Width, this.Height);
			//PanelOver.SetStyle(ControlStyles.Opaque, true);
			PanelOver.Paint += new PaintEventHandler(this.PanelOver_Paint);
			//this.Controls.Add(PanelOver);
			//PanelOver.BringToFront();
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

			//Panel PanelOver = new Panel();
			//PanelOver.BackColor = Color.Transparent;
			//PanelOver.Size = new Size(this.Width, this.Height);
			////PanelOver.Invalidate();
			//this.Controls.Add(PanelOver);
			//PanelOver.BringToFront();
			//patches.PaintTakenPatch(e);
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
			//if (patches.IsPatchTaken())
			//{
			//	patches.PaintTakenPatch(e);
			//}
			//else
			//{
				patches.Paint(e);
			//}
		}

		private void PanelOver_Paint(object sender, PaintEventArgs e)
		{
			patches.PaintTakenPatch(e);
		}

		private void PanelPatches_MouseDown(object sender, MouseEventArgs e)
        {
            patches.TakeOne(e.X, e.Y);
			//this.PanelPatches.Invalidate();

			this.Controls.Add(PanelOver);
			PanelOver.BringToFront();
			//PanelOver.Invalidate();
		}

		private void PanelPatches_MouseUp(object sender, MouseEventArgs e)
		{
			patches.PutOne(e.X, e.Y);
			//this.PanelPatches.Invalidate();


			this.Controls.Remove(PanelOver);
			//PanelOver.BringToFront();
			//PanelOver.Invalidate();
		}

		private void PanelPatches_MouseMove(object sender, MouseEventArgs e)
		{
			if (patches.IsPatchTaken()) {
				patches.MoveOne(e.X, e.Y);
				//this.PanelPatches.Invalidate();

				//this.Controls.Remove(PanelOver);
				//this.Controls.Add(PanelOver);
				//PanelOver.BringToFront();
				PanelOver.Invalidate();
				//Invalidate();
			}
		}

		private void TableLayoutPanelMain_Paint(object sender, PaintEventArgs e)
		{
			//patches.PaintTakenPatch(e);
		}
	}
}
