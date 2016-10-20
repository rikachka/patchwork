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

		Point new_patch_centre_position;
		Point new_patch_position;
		bool has_new_patch = false;
		bool is_patch_taken = false;
		Patch new_patch;

		public PlayerBoard(TableLayoutPanel panel_player_)
        {
            panel_player = panel_player_;
            panel_board = (Panel) panel_player.GetControlFromPosition(0, 0);
            panel_points = (Panel)panel_player.GetControlFromPosition(0, 1);
            panel_prize = (Panel)panel_player.GetControlFromPosition(1, 1);
            panel_income = (Panel)panel_player.GetControlFromPosition(2, 1);
            //panel_info = panel_info_;
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

			if (has_new_patch)
			{
				PaintPatch(e, new_patch);
			}
        }

		public void PaintPatch(PaintEventArgs e, Patch patch)
		{
			int patch_width = patch.GetWidth() * square_length,
				patch_height = patch.GetHeight() * square_length;
			Bitmap patch_pole = new Bitmap(patch_width, patch_height);
			Graphics patch_graphics = Graphics.FromImage(patch_pole);
			patch.Paint(patch_graphics, new SolidBrush(Color.Red),
				0,
				0,
				square_length);
			//e.Graphics.DrawImage(patch_pole,
			//	new_patch_centre_position.X - patch_width / 2,
			//	new_patch_centre_position.Y - patch_height / 2);
			e.Graphics.DrawImage(patch_pole,
				margin_width + new_patch_position.X * square_length,
				margin_height + new_patch_position.Y * square_length);
		}

		public void AddNewPatch(Patch patch)
		{
			new_patch = patch;
			has_new_patch = true;
			new_patch_position = CalculatePatchPositionByCentrePoint(new Point(0, 0));
		}

		public void DeleteNewPatch()
		{
			new_patch = null;
			has_new_patch = false;
		}

		public void TakePatch(Point mouse_position)
		{
			if (has_new_patch)
			{
				if (GetNewPatchRectangle().Contains(mouse_position))
				{
					is_patch_taken = true;
				}
			}
		}

		public void MovePatch(Point mouse_position)
		{
			if (IsPatchTaken())
			{
				new_patch_position = CalculatePatchPositionByCentrePoint(mouse_position);
			}
		}

		public void PutPatch()
		{
			is_patch_taken = false;
		}

		public Rectangle GetNewPatchRectangle()
		{
			int patch_width = new_patch.GetWidth() * square_length,
				patch_height = new_patch.GetHeight() * square_length;
			return new Rectangle(
				margin_width + new_patch_position.X * square_length,
				margin_height + new_patch_position.Y * square_length,
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
			topleft_square = new Point(
				Math.Min(Math.Max(topleft_square.X, 0), squares_number - new_patch.GetWidth()),
				Math.Min(Math.Max(topleft_square.Y, 0), squares_number - new_patch.GetHeight()));
			return topleft_square;
		}

		public bool IsPatchTaken()
		{
			return has_new_patch && is_patch_taken;
		}
    }
}
