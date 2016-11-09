using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace patchwork
{
    class PlayerBoard
    {
        TableLayoutPanel panel_player;
        Panel panel_board;
        Panel panel_points;
        Panel panel_prize;
        Panel panel_income;

        Graphics c;
        Bitmap POLE;

		int margin = 5,
			squares_number = 9;
		int panel_width, panel_height,
			board_length,
			square_length,
			margin_width, margin_height;
		
		bool has_new_patch = false;
		bool is_patch_taken = false;
		Patch new_patch;

		List<Patch> patches = new List<Patch>();

		int points, time, income;

		public PlayerBoard(TableLayoutPanel panel_player_)
        {
            panel_player = panel_player_;
            panel_board = (Panel)panel_player.GetControlFromPosition(0, 0);
            panel_points = (Panel)panel_player.GetControlFromPosition(0, 1);
            panel_prize = (Panel)panel_player.GetControlFromPosition(1, 1);
            panel_income = (Panel)panel_player.GetControlFromPosition(2, 1);
			points = 7;
			time = 0;
			income = 0;
        }

		void CountDrawingInfo()
		{
			panel_width = panel_board.Width - margin * 2;
			panel_height = panel_board.Height - margin * 2;
			board_length = panel_width < panel_height ? panel_width : panel_height;
			square_length = board_length / squares_number;
			board_length = square_length * squares_number;
			margin_width = (panel_width - board_length) / 2 + margin;
			margin_height = (panel_height - board_length) / 2 + margin;
		}

        public void Paint(PaintEventArgs e)
        {
			CountDrawingInfo();

            POLE = new Bitmap(panel_board.Width, panel_board.Height);
            c = Graphics.FromImage(POLE);
            c.FillRectangle(new SolidBrush(Color.Green), margin_width, margin_height, board_length, board_length);
            for (int i = 0; i <= squares_number; i++)
            {
                c.DrawLine(new Pen(Color.Black),
                    margin_width + i * square_length,
                    margin_height,
                    margin_width + i * square_length,
                    margin_height + board_length);
            }
            for (int i = 0; i <= squares_number; i++)
            {
                c.DrawLine(new Pen(Color.Black),
                    margin_width,
                    margin_height + i * square_length,
                    margin_width + board_length,
                    margin_height + i * square_length);
            }
            e.Graphics.DrawImage(POLE, 0, 0);

			foreach (Patch patch in patches)
			{
				PaintPatch(e, patch, null);
			}

			if (has_new_patch)
			{
				PaintPatch(e, new_patch, Constants.NewPatchBrush, true);
			}
        }

		public void PaintPatch(PaintEventArgs e, Patch patch, Brush brush, bool border = false)
		{
			int patch_width = patch.GetWidth() * square_length,
				patch_height = patch.GetHeight() * square_length;
			Bitmap patch_pole = new Bitmap(patch_width, patch_height);
			Graphics patch_graphics = Graphics.FromImage(patch_pole);
			if (border)
			{
				patch.PaintBorder(patch_graphics, brush,
				0,
				0,
				square_length);
			} else
			{
				patch.Paint(patch_graphics, brush,
				0,
				0,
				square_length);
			}
			e.Graphics.DrawImage(patch_pole,
				margin_width + patch.GetPosition().X * square_length,
				margin_height + patch.GetPosition().Y * square_length);
		}

		public void AddNewPatch(Patch patch)
		{
			new_patch = patch;
			has_new_patch = true;
			new_patch.SetPosition(CalculatePatchPositionByCentrePoint(new Point(0, 0)));
		}

		public void DeleteNewPatch()
		{
			new_patch = null;
			has_new_patch = false;
		}

		public void TakePatch(Point mouse_position)
		{
			if (IsClickOnNewPatch(mouse_position))
			{
				is_patch_taken = true;
			}
		}

		public void MovePatch(Point mouse_position)
		{
			if (IsPatchTaken())
			{
				new_patch.SetPosition(CalculatePatchPositionByCentrePoint(mouse_position));
			}
		}

		public void PutPatch()
		{
			is_patch_taken = false;
		}

		public void TransposePatch(Keys key)
		{
			if (has_new_patch)
			{
				switch (key)
				{
					case Keys.Down:
						new_patch.Reflect();
						break;
					case Keys.Up:
						new_patch.Reflect();
						break;
					case Keys.Right:
						new_patch.RotateRight();
						break;
					case Keys.Left:
						new_patch.RotateRight();
						new_patch.RotateRight();
						new_patch.RotateRight();
						break;
					default:
						MessageBox.Show("ERROR! Can't transpose patch by this key.");
						break;
				}
				new_patch.SetPosition(CheckPatchInBoard(new_patch.GetPosition()));
			}
		}

		public bool IsPatchesIntersection()
		{
			bool[,] occupied_squares = new bool[squares_number, squares_number];
			for (int i = 0; i < occupied_squares.GetLength(0); i++)
			{
				for (int j = 0; j < occupied_squares.GetLength(1); j++)
				{
					occupied_squares[i, j] = false;
				}
			}
			foreach (Patch patch in patches)
			{
				for (int i = 0; i < patch.GetHeight(); i++)
				{
					for (int j = 0; j < patch.GetWidth(); j++)
					{
						if (patch.IsSquarePartOfPatch(i, j))
						{
							Point point = new Point(patch.GetPosition().X + j, patch.GetPosition().Y + i);
							occupied_squares[point.X, point.Y] = true;
						}
					}
				}
			}
			for (int i = 0; i < new_patch.GetHeight(); i++)
			{
				for (int j = 0; j < new_patch.GetWidth(); j++)
				{
					if (new_patch.IsSquarePartOfPatch(i, j))
					{
						Point point = new Point(new_patch.GetPosition().X + j, new_patch.GetPosition().Y + i);
						if (occupied_squares[point.X, point.Y])
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private bool HasEnoughMoney()
		{
			return (new_patch.GetPrice() <= points);
		}

		public bool FixPatch(Point mouse_position)
		{
			if (!IsPatchesIntersection() && HasEnoughMoney())
			{
				patches.Add(new_patch);
				points -= new_patch.GetPrice();
				time += new_patch.GetTime();
				income += new_patch.GetIncome();
				has_new_patch = false;
				return true;
			}
			return false;
		}

		public Rectangle GetNewPatchRectangle()
		{
			int patch_width = new_patch.GetWidth() * square_length,
				patch_height = new_patch.GetHeight() * square_length;
			return new Rectangle(
				margin_width + new_patch.GetPosition().X * square_length,
				margin_height + new_patch.GetPosition().Y * square_length,
				patch_width,
				patch_height
			);
		}

		public Point CalculatePatchPositionByCentrePoint(Point point_centre)
		{
			int patch_width = new_patch.GetWidth() * square_length,
				patch_height = new_patch.GetHeight() * square_length;
			Point point_topleft = point_centre - new Size(patch_width / 2, patch_height / 2);
			Point point_topleft_square_centre = point_topleft + new Size(square_length / 2, square_length / 2);
			Point topleft_square = new Point(
				(point_topleft_square_centre.X - margin_width) / square_length,
				(point_topleft_square_centre.Y - margin_height) / square_length);
			topleft_square = CheckPatchInBoard(topleft_square);
			return topleft_square;
		}

		public Point CheckPatchInBoard(Point patch_position)
		{
			return new Point(
				Math.Min(Math.Max(patch_position.X, 0), squares_number - new_patch.GetWidth()),
				Math.Min(Math.Max(patch_position.Y, 0), squares_number - new_patch.GetHeight()));
		}

		public bool IsPatchTaken()
		{
			return has_new_patch && is_patch_taken;
		}

		public bool IsClickOnNewPatch(Point mouse_position)
		{
			return has_new_patch && GetNewPatchRectangle().Contains(mouse_position);
		}

		public int GetPoints()
		{
			return points;
		}

		public int GetTime()
		{
			return time;
		}

		public void SpendTime(int time_spent)
		{
			time += time_spent;
			points += time_spent;
		}

		public int GetIncome()
		{
			return income;
		}

		public void PaintPoints(PaintEventArgs e)
		{
			int panel_width = panel_points.Width,
				panel_height = panel_points.Height;
			Bitmap pole = new Bitmap(panel_width, panel_height);
			Graphics graphics = Graphics.FromImage(pole);
			graphics.DrawString(points.ToString(),
					new Font(Constants.PatchFont, panel_height * 6 / 11),
					Constants.PatchPriceBrush,
					new Point(0, 0));
			e.Graphics.DrawImage(pole,
				0,
				0);
		}

		public void PaintIncome(PaintEventArgs e)
		{
			int panel_width = panel_income.Width,
				panel_height = panel_income.Height;
			Bitmap pole = new Bitmap(panel_width, panel_height);
			Graphics graphics = Graphics.FromImage(pole);
			graphics.DrawString(income.ToString(),
					new Font(Constants.PatchFont, panel_height * 6 / 11),
					Constants.PatchIncomeBrush,
					new Point(0, 0));
			e.Graphics.DrawImage(pole,
				0,
				0);
		}
	}
}
