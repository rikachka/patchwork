using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace patchwork
{
	class TimeSpot
	{
		public int length;
		public bool income;
		public bool patch;
		
		public TimeSpot(int length_, bool income_, bool patch_)
		{
			length = length_;
			income = income_;
			patch = patch_;
		}

		public TimeSpot()
		{
			length = 1;
			income = false;
			patch = false;
		}
	}

	class TimeBoard
	{
		TableLayoutPanel panel_whole;
		Panel panel_board;
		Panel panel_prize;
		int time_spots_number = 54;
		TimeSpot[] time_spots;

		Graphics c;
		Bitmap POLE;

		int margin = 5,
			squares_number = 8;
		int panel_width, panel_height,
			board_length,
			square_length,
			margin_width, margin_height;

		Dictionary<Turn, int> times = new Dictionary<Turn, int>();

		enum Directions { RIGHT, DOWN, LEFT, UP };

		public TimeBoard(TableLayoutPanel panel_whole_)
		{
			panel_whole = panel_whole_;
			panel_board = (Panel)panel_whole.GetControlFromPosition(0, 0);
			panel_prize = (Panel)panel_whole.GetControlFromPosition(1, 1);
			times[Turn.PLAYER] = 0;
			times[Turn.OPPONENT] = 0;

			CreateTimeSpots();
		}

		void CreateTimeSpots()
		{
			time_spots = new TimeSpot[time_spots_number];
			for (int i = 0; i < time_spots_number; i++)
			{
				time_spots[i] = new TimeSpot();
			}
			time_spots[0] = new TimeSpot(3, false, false);
			time_spots[5] = new TimeSpot(1, true, false);
			time_spots[10] = new TimeSpot(2, false, false);
			time_spots[11] = new TimeSpot(1, true, false);
			time_spots[17] = new TimeSpot(1, true, false);
			time_spots[20] = new TimeSpot(2, false, true);
			time_spots[23] = new TimeSpot(1, true, false);
			time_spots[26] = new TimeSpot(1, false, true);
			time_spots[29] = new TimeSpot(1, true, false);
			time_spots[30] = new TimeSpot(2, false, false);
			time_spots[32] = new TimeSpot(1, false, true);
			time_spots[35] = new TimeSpot(1, true, false);
			time_spots[40] = new TimeSpot(2, false, false);
			time_spots[41] = new TimeSpot(1, true, false);
			time_spots[44] = new TimeSpot(1, false, true);
			time_spots[47] = new TimeSpot(1, true, false);
			time_spots[50] = new TimeSpot(2, false, true);
			time_spots[53] = new TimeSpot(4, true, false);
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

			PaintTimeSpots();
			PaintBorders();

			e.Graphics.DrawImage(POLE, 0, 0);
		}

		Size ShiftPointByDirection(Directions direction, int length)
		{
			switch (direction)
			{
				case Directions.RIGHT:
					return new Size(length, 0);
				case Directions.DOWN:
					return new Size(0, length);
				case Directions.LEFT:
					return new Size(-length, 0);
				case Directions.UP:
					return new Size(0, -length);
				default:
					return new Size(0, 0);
			}
		}

		Size ShiftPointByDirection(Directions direction)
		{
			return ShiftPointByDirection(direction, 1);
		}

		void PaintTimeSpots()
		{
			Point point = new Point(0, 0);
			Rectangle future_points = new Rectangle(0, 0, squares_number, squares_number);
			Directions direction = Directions.RIGHT,
				next_direction = Directions.RIGHT;
			for (int i = 0; i < time_spots_number - 1; i++)
			{
				int time_spot_length = time_spots[i].length - 1;
				Size shift = ShiftPointByDirection(direction, time_spot_length);
				Point point_end = point + shift;

				Size additional_shift = ShiftPointByDirection(direction);
				while (!future_points.Contains(point_end + additional_shift))
				{
					next_direction = (Directions)((int)(next_direction + 1) % 4);
					switch (next_direction)
					{
						case Directions.RIGHT:
							future_points.Height -= 1;
							additional_shift = ShiftPointByDirection(next_direction);
							break;
						case Directions.DOWN:
							future_points.X += 1;
							future_points.Y += 1;
							future_points.Width -= 1;
							future_points.Height -= 1;
							additional_shift = ShiftPointByDirection(next_direction);
							break;
						case Directions.LEFT:
							additional_shift = new Size(0, 0);
							break;
						case Directions.UP:
							future_points.Width -= 1;
							additional_shift = new Size(0, 0);
							break;
					}
				}
				
				if (next_direction == Directions.RIGHT || next_direction == Directions.DOWN)
				{
					direction = next_direction;
				}

				Size point_end_shift = new Size();
				switch (direction)
				{
					case Directions.RIGHT:
					case Directions.DOWN:
						point_end_shift = new Size(1, 1);
						break;
					case Directions.LEFT:
						point_end_shift = new Size(-1, 1);
						break;
					case Directions.UP:
						point_end_shift = new Size(-1, -1);
						break;
				}
				Point[] points = {
					new Point(margin_width + point.X * square_length, margin_height + point.Y * square_length),
					new Point(margin_width + (point_end + point_end_shift).X * square_length, margin_height + point.Y * square_length),
					new Point(margin_width + (point_end + point_end_shift).X * square_length, margin_height + (point_end + point_end_shift).Y * square_length),
					new Point(margin_width + point.X * square_length, margin_height + (point_end + point_end_shift).Y * square_length),
					new Point(margin_width + point.X * square_length, margin_height + point.Y * square_length)
				};
				c.DrawLines(new Pen(Color.Black, 2), points);

				Point point_min = new Point(Math.Min(point.X, (point_end + point_end_shift).X), Math.Min(point.Y, (point_end + point_end_shift).Y));
				if (i == times[Turn.PLAYER])
				{
					PaintPlayerToken(Constants.playerTokenBrush, point_min);
				}
				if (i == times[Turn.OPPONENT])
				{
					PaintPlayerToken(Constants.opponentTokenBrush, point_min);
				}

				point = point_end + additional_shift;
				direction = next_direction;
			}
		}

		void PaintPlayerToken(Brush brush, Point point)
		{
			c.FillEllipse(brush,
					margin_width + point.X * square_length,
					margin_height + point.Y * square_length,
					square_length,
					square_length);
		}

		void PaintBorders()
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

		public void SetTime(Turn turn, int time)
		{
			times[turn] = time;
		}

		public int MoveForward(Turn turn)
		{
			times[turn] = times[(Turn)(1 - (int)turn)] + 1;
			return times[turn];
		}
	}
}
