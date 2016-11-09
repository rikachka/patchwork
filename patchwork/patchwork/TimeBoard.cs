using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace patchwork
{
	class TimeBoard
	{
		TableLayoutPanel panel_whole;
		Panel panel_board;
		Panel panel_prize;

		Graphics c;
		Bitmap POLE;

		int margin = 5,
			squares_number = 8;
		int panel_width, panel_height,
			board_length,
			square_length,
			margin_width, margin_height;

		Dictionary<Turn, int> time = new Dictionary<Turn, int>();

		enum Directions { RIGHT, DOWN, LEFT, UP };

		public TimeBoard(TableLayoutPanel panel_whole_)
		{
			panel_whole = panel_whole_;
			panel_board = (Panel)panel_whole.GetControlFromPosition(0, 0);
			panel_prize = (Panel)panel_whole.GetControlFromPosition(1, 1);
			time[Turn.PLAYER] = 0;
			time[Turn.OPPONENT] = 39;
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
			c.FillRectangle(new SolidBrush(Color.Blue), margin_width, margin_height, board_length, board_length);
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

			PaintBorders();
			PaintPlayersTokens();

			e.Graphics.DrawImage(POLE, 0, 0);
		}

		public void PaintBorders()
		{
			Directions direction = Directions.RIGHT;
			int active_squares_width = squares_number;
			int active_squares_height = squares_number - 1;
			Point point_start = new Point(0, 1);
			while (true)
			{
				Point point_end = new Point();
				point_end = point_start;
				if (direction == Directions.DOWN || direction == Directions.UP)
				{
					active_squares_height -= 1;
				}
				else
				{
					active_squares_width -= 1;
				}
				switch (direction)
				{
					case Directions.RIGHT:
						point_end.X = active_squares_width + point_start.X;
						break;
					case Directions.DOWN:
						point_end.Y = active_squares_height + point_start.Y;
						break;
					case Directions.LEFT:
						point_end.X = -active_squares_width + point_start.X;
						break;
					case Directions.UP:
						point_end.Y = -active_squares_height + point_start.Y;
						break;

				}
				if (point_start.Equals(point_end))
				{
					break;
				}
				c.DrawLine(new Pen(Color.White),
					margin_width + point_start.X * square_length,
					margin_height + point_start.Y * square_length,
					margin_width + point_end.X * square_length,
					margin_height + +point_end.Y * square_length);
				point_start = point_end;
				direction = (Directions)((int)(direction + 1) % 4);
			}
		}

		Size ShiftPointByDirection(Directions direction)
		{
			switch (direction)
			{
				case Directions.RIGHT:
					return new Size(1, 0);
				case Directions.DOWN:
					return new Size(0, 1);
				case Directions.LEFT:
					return new Size(-1, 0);
				case Directions.UP:
					return new Size(0, -1);
				default:
					return new Size(0, 0);
			}
		}

		Point DetermineTokensCoordinates(int time)
		{
			Point point = new Point(0, 0);
			Rectangle future_points = new Rectangle(0, 0, squares_number, squares_number);
			Directions direction = Directions.RIGHT;
			for (int i = 0; i < time; i++)
			{
				Size shift = ShiftPointByDirection(direction);
				while (!future_points.Contains(point + shift))
				{
					switch (direction)
					{
						case Directions.RIGHT:
							future_points.Height -= 1;
							future_points.Y += 1;
							break;
						case Directions.DOWN:
							future_points.Width -= 1;
							break;
						case Directions.LEFT:
							future_points.Height -= 1;
							break;
						case Directions.UP:
							future_points.Width -= 1;
							future_points.X += 1;
							break;
					}
					direction = (Directions)((int)(direction + 1) % 4);
					shift = ShiftPointByDirection(direction);
				}
				point = point + shift;
			}
			return point;
		}

		void PaintPlayersTokens()
		{
			PaintPlayerToken(Constants.playerTokenBrush, DetermineTokensCoordinates(time[Turn.PLAYER]));
			PaintPlayerToken(Constants.opponentTokenBrush, DetermineTokensCoordinates(time[Turn.OPPONENT]));
		}

		void PaintPlayerToken(Brush brush, Point point)
		{
			c.FillEllipse(brush,
					margin_width + point.X * square_length,
					margin_height + point.Y * square_length,
					square_length,
					square_length);
		}
	}
}
