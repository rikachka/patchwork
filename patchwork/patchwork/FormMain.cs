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
			//SetStyle(ControlStyles.UserPaint, true);
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
				cp.ExStyle |= WS_EX_TRANSPARENT;
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



	public class TranspCtrl : Panel
	{
		public bool drag = false;
		public bool enab = false;
		private int m_opacity = 100;

		private int alpha;
		public TranspCtrl()
		{
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.Opaque, true);
			this.BackColor = Color.Transparent;
		}

		public int Opacity
		{
			get
			{
				if (m_opacity > 100)
				{
					m_opacity = 100;
				}
				else if (m_opacity < 1)
				{
					m_opacity = 1;
				}
				return this.m_opacity;
			}
			set
			{
				this.m_opacity = value;
				if (this.Parent != null)
				{
					Parent.Invalidate(this.Bounds, true);
				}
			}
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle = cp.ExStyle | 0x20;
				return cp;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

			Color frmColor = this.Parent.BackColor;
			Brush bckColor = default(Brush);

			alpha = (m_opacity * 255) / 100;

			if (drag)
			{
				Color dragBckColor = default(Color);

				if (BackColor != Color.Transparent)
				{
					int Rb = BackColor.R * alpha / 255 + frmColor.R * (255 - alpha) / 255;
					int Gb = BackColor.G * alpha / 255 + frmColor.G * (255 - alpha) / 255;
					int Bb = BackColor.B * alpha / 255 + frmColor.B * (255 - alpha) / 255;
					dragBckColor = Color.FromArgb(Rb, Gb, Bb);
				}
				else
				{
					dragBckColor = frmColor;
				}

				alpha = 255;
				bckColor = new SolidBrush(Color.FromArgb(alpha, dragBckColor));
			}
			else
			{
				bckColor = new SolidBrush(Color.FromArgb(alpha, this.BackColor));
			}

			if (this.BackColor != Color.Transparent | drag)
			{
				g.FillRectangle(bckColor, bounds);
			}

			bckColor.Dispose();
			//g.Dispose();
			base.OnPaint(e);
		}

		protected override void OnBackColorChanged(EventArgs e)
		{
			if (this.Parent != null)
			{
				Parent.Invalidate(this.Bounds, true);
			}
			base.OnBackColorChanged(e);
		}

		protected override void OnParentBackColorChanged(EventArgs e)
		{
			this.Invalidate();
			base.OnParentBackColorChanged(e);
		}
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

		//TranspCtrl PanelOver = new TranspCtrl();
		ExtendedPanel PanelOver = new ExtendedPanel();
		//Panel PanelOver = new Panel();

		public FormMain()
        {
            InitializeComponent();
			

			PanelOver.BackColor = Color.Blue;
			//PanelOver.Opacity = 50;
			//PanelOver.TransparencyKey = Color.Blue;
			//PanelOver.BackColor = Color.FromArgb(0, Color.Red);
			PanelOver.Size = new Size(this.Width, this.Height);
			//PanelOver.SetStyle(ControlStyles.Opaque, true);
			PanelOver.Paint += new PaintEventHandler(this.PanelOver_Paint);
			//this.Controls.Add(PanelOver);
			//PanelOver.BringToFront();

			this.Controls.Add(PanelOver);
			PanelOver.BringToFront();
			PanelOver.Hide();
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

			//PanelOver.BringToFront();
			//this.PanelOver.Invalidate();

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

			PanelOver.Show();
			//this.Controls.Add(PanelOver);
			PanelOver.BringToFront();

			//PanelOver.BringToFront();
			//PanelOver.Invalidate();
			//Invalidate();
		}

		private void PanelPatches_MouseUp(object sender, MouseEventArgs e)
		{
			patches.PutOne(e.X, e.Y);
			//this.PanelPatches.Invalidate();

			PanelOver.Hide();
			Invalidate();
			//this.Controls.Remove(PanelOver);
			//PanelOver.BringToFront();
			//PanelOver.Invalidate();
		}

		private void PanelPatches_MouseMove(object sender, MouseEventArgs e)
		{
			if (patches.IsPatchTaken()) {
				patches.MoveOne(e.X, e.Y);
				//if (PanelOver.BackColor == Color.Transparent)
				//{
				//	PanelOver.BackColor = Color.Blue;
				//	PanelOver.BackColor = Color.Transparent;
				//} else
				//{
				//	PanelOver.BackColor = Color.Transparent;
				//}
				//this.PanelPatches.Invalidate();

				//this.Controls.Remove(PanelOver);
				//this.Controls.Add(PanelOver);
				//PanelOver.BringToFront();
				//PanelOver.Invalidate();

				//if (PanelOver.Visible == true)
				//{
				//	PanelOver.Hide();
				//} else
				//{
				//	PanelOver.Show();
				//} 
				//PanelOver.Hide();
				//PanelOver.Show();
				//this.Invalidate();
				//Invalidate();
				PanelOver.Invalidate();

				//PanelOver.Invalidate();

				//Invalidate();
				//PanelOver.Invalidate();
			}
		}

		private void TableLayoutPanelMain_Paint(object sender, PaintEventArgs e)
		{
			//patches.PaintTakenPatch(e);
		}
	}
}
