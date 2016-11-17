using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace patchwork
{
	class Patch
	{
		public int[,] info;
		int price;
		int time;
		int income;
		Point position;
		Brush brush;
		bool taken;

		public Patch(int[,] info_, int price_, int time_, int income_)
		{
			info = info_;
			price = price_;
			time = time_;
			income = income_;
			taken = false;
		}

		public Patch()
		{
			info = new int[,] { { 1 } };
			price = 0;
			time = 0;
			income = 0;
			taken = false;
			brush = Constants.OnePatchBrush;
		}

		public int GetHeight()
		{
			return info.GetLength(0);
		}

		public int GetWidth()
		{
			return info.GetLength(1);
		}

		public bool IsSquarePartOfPatch(int i, int j)
		{
			return info[i, j] == 1;
		}

		public void Paint(Graphics graphics, Brush patch_brush, int margin_width, int margin_height, int square_length, bool border = false)
		{
			if (patch_brush == null)
			{
				patch_brush = brush;
			}
			for (int i = 0; i < GetHeight(); i++)
			{
				for (int j = 0; j < GetWidth(); j++)
				{
					if (IsSquarePartOfPatch(i, j))
					{
						graphics.FillRectangle(patch_brush,
							margin_width + j * square_length,
							margin_height + i * square_length,
							square_length,
							square_length);
					}
				}
			}
			if (border)
			{
				PaintBorder(graphics, patch_brush, margin_width, margin_height, square_length);
			}
			PaintPrice(graphics, patch_brush, margin_width, margin_height, square_length);
		}

		public void PaintBorder(Graphics graphics, Brush patch_brush, int margin_width, int margin_height, int square_length)
		{
			if (patch_brush == null)
			{
				patch_brush = brush;
			}
			for (int i = 0; i < GetHeight(); i++)
			{
				for (int j = 0; j < GetWidth(); j++)
				{
					if (IsSquarePartOfPatch(i, j))
					{
						Point[] points = {
							new Point(margin_width + j * square_length, margin_height + i * square_length),
							new Point(margin_width + (j + 1) * square_length, margin_height + i * square_length),
							new Point(margin_width + (j + 1) * square_length, margin_height + (i + 1) * square_length),
							new Point(margin_width + j * square_length, margin_height + (i + 1) * square_length),
							new Point(margin_width + j * square_length, margin_height + i * square_length)
						};
						graphics.DrawLines(new Pen(Color.Red, 3), points );
					}
				}
			}
		}

		public void PaintPrice(Graphics graphics, Brush patch_brush, int margin_width, int margin_height, int square_length)
		{
			int painted = 0;
			for (int i = 0; i < GetHeight(); i++)
			{
				for (int j = 0; j < GetWidth(); j++)
				{
					if (IsSquarePartOfPatch(i, j))
					{
						if (painted == 0) {
							if (price > 0)
							{
								graphics.DrawString(price.ToString(),
									new Font(Constants.PatchFont, square_length * 6 / 11),
									Constants.PatchPriceBrush,
									new Point(margin_width + j * square_length, margin_height + i * square_length));
							}
						}
						if (painted == 1)
						{
							if (time > 0)
							{
								graphics.DrawString(time.ToString(),
									new Font(Constants.PatchFont, square_length * 6 / 11),
									Constants.PatchTimeBrush,
									new Point(margin_width + j * square_length, margin_height + i * square_length));
							}
						}
						if (painted == 2)
						{
							if (income > 0)
							{
								graphics.DrawString(income.ToString(),
									new Font(Constants.PatchFont, square_length * 6 / 11),
									Constants.PatchIncomeBrush,
									new Point(margin_width + j * square_length, margin_height + i * square_length));
							}
						}
						painted++;
						if (painted == 3) // price, time and income
						{
							return;
						}
					}
				}
			}
		}

		public void RotateRight()
		{
			int[,] info_new = new int[GetWidth(), GetHeight()];
			for (int i = 0; i < GetWidth(); i++)
			{
				for (int j = 0; j < GetHeight(); j++)
				{
					info_new[i, j] = info[GetHeight() - 1 - j, i];
				}
			}
			info = info_new;
		}

		public void Reflect()
		{
			int[,] info_new = new int[GetHeight(), GetWidth()];
			for (int i = 0; i < GetHeight(); i++)
			{
				for (int j = 0; j < GetWidth(); j++)
				{
					info_new[i, j] = info[GetHeight() - 1 - i, j];
				}
			}
			info = info_new;
		}

		public void SetPosition(Point position_)
		{
			position = position_;
		}

		public Point GetPosition()
		{
			return position;
		}

		public void SetBrush(Brush brush_)
		{
			brush = brush_;
		}

		public void MarkTaken()
		{
			taken = true;
		}

		public bool IsTaken()
		{
			return taken;
		}

		public int GetPrice()
		{
			return price;
		}

		public int GetTime()
		{
			return time;
		}

		public int GetIncome()
		{
			return income;
		}
	}
}
