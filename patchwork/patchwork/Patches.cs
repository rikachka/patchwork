﻿using System;
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

		public Patch(int[,] info_, int price_, int time_, int income_)
		{
			info = info_;
			price = price_;
			time = time_;
			income = income_;
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

		public void Paint(Graphics graphics, SolidBrush patch_brush, int margin_width, int margin_height, int square_length)
		{
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
		}
	}

	class Patches
	{
		const int NOT_TAKEN = -1;

		Panel panel_patches;
		TableLayoutPanel table_layout_panel_main;
		Graphics graphics;
		Bitmap POLE;
		Patch[] patches;
		int taken_patch_index = NOT_TAKEN;
		Bitmap taken_patch_pole;
		Point mouse_position = new Point(0, 0);

		int margin = 5,
			squares_number_height = 5;
		int panel_width, panel_height,
			square_length,
			squares_number_width,
			board_width, board_height,
			margin_width, margin_height;

		public Patches(Panel panel_patches_, TableLayoutPanel table_layout_panel_main_)
		{
			panel_patches = panel_patches_;
			table_layout_panel_main = table_layout_panel_main_;
			CreatePatches();
			ShufflePatches();
		}

		void CreatePatches()
		{
			patches = new Patch[33];
			patches[0] = new Patch(new int[,] { { 1 }, { 1 } }, 2, 1, 0);
			patches[1] = new Patch(new int[,] { { 1, 1 }, { 1, 0 } }, 1, 3, 0);
			patches[2] = new Patch(new int[,] { { 1, 1 }, { 1, 0 } }, 3, 1, 0);
			patches[3] = new Patch(new int[,] { { 1, 1 }, { 1, 1 } }, 6, 5, 2);
			patches[4] = new Patch(new int[,] { { 1 }, { 1 }, { 1 } }, 2, 2, 0);
			patches[5] = new Patch(new int[,] { { 1 }, { 1 }, { 1 } }, 2, 2, 0);
			patches[6] = new Patch(new int[,] { { 1 }, { 1 }, { 1 }, { 1 } }, 3, 3, 1);
			patches[7] = new Patch(new int[,] { { 1, 0 }, { 1, 1 }, { 1, 1 } }, 7, 6, 3);
			patches[8] = new Patch(new int[,] { { 1, 0 }, { 1, 1 }, { 1, 1 } }, 3, 2, 1);
			patches[9] = new Patch(new int[,] { { 0, 1 }, { 1, 1 }, { 0, 1 } }, 2, 2, 0);
			patches[10] = new Patch(new int[,] { { 1, 1 }, { 0, 1 }, { 0, 1 } }, 4, 2, 1);
			patches[11] = new Patch(new int[,] { { 1, 1 }, { 0, 1 }, { 0, 1 } }, 4, 6, 2);
			patches[12] = new Patch(new int[,] { { 1, 1 }, { 0, 1 }, { 1, 1 } }, 1, 2, 0);
			patches[13] = new Patch(new int[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 1 } }, 5, 5, 2);
			patches[14] = new Patch(new int[,] { { 1, 0 }, { 1, 1 }, { 1, 0 }, { 1, 0 } }, 3, 4, 1);
			patches[15] = new Patch(new int[,] { { 1, 1 }, { 1, 0 }, { 1, 0 }, { 1, 0 } }, 10, 3, 2);
			patches[16] = new Patch(new int[,] { { 1, 0 }, { 1, 1 }, { 1, 1 } }, 2, 2, 2);
			patches[17] = new Patch(new int[,] { { 0, 0, 1 }, { 0, 1, 1 }, { 1, 1, 0 } }, 10, 4, 3);
			patches[18] = new Patch(new int[,] { { 1, 0 }, { 1, 0 }, { 1, 1 }, { 0, 1 } }, 2, 3, 1);
			patches[19] = new Patch(new int[,] { { 1, 0, 1 }, { 1, 1, 1 }, { 0, 1, 0 } }, 3, 6, 2);
			patches[20] = new Patch(new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 0, 1, 1 } }, 8, 6, 3);
			patches[21] = new Patch(new int[,] { { 1, 0 }, { 1, 0 }, { 1, 1 }, { 1, 1 } }, 10, 5, 3);
			patches[22] = new Patch(new int[,] { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }, 7, 2, 2);
			patches[23] = new Patch(new int[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 1, 1 }, { 0, 1, 0 } }, 2, 1, 0);
			patches[24] = new Patch(new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } }, 1, 2, 0);
			patches[25] = new Patch(new int[,] { { 1, 1 }, { 1, 0 }, { 1, 0 }, { 1, 1 } }, 1, 5, 1);
			patches[26] = new Patch(new int[,] { { 1, 1 }, { 1, 1 }, { 0, 1 }, { 0, 1 } }, 10, 5, 3);
			patches[27] = new Patch(new int[,] { { 0, 1 }, { 1, 1 }, { 1, 1 }, { 1, 0 } }, 4, 2, 0);
			patches[28] = new Patch(new int[,] { { 0, 1 }, { 1, 1 }, { 1, 1 }, { 0, 1 } }, 7, 4, 2);
			patches[29] = new Patch(new int[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } }, 0, 3, 1);
			patches[30] = new Patch(new int[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } }, 1, 4, 1);
			patches[31] = new Patch(new int[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 1, 1, 1 }, { 0, 1, 0 } }, 5, 3, 1);
			patches[32] = new Patch(new int[,] { { 1, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 } }, 2, 3, 0);
		}

		void ShufflePatches()
		{
			var random = new Random(123);
			patches = patches.OrderBy(x => random.Next()).ToArray();
			for (int i = 0; i < patches.Length; i++)
			{
				Patch patch = patches[i];
				if (patch.GetWidth() == 1 && patch.GetHeight() == 2)
				{
					patches[i] = patches[0];
					patches[0] = patch;
				}
			}
		}

		void CountDrawingInfo()
		{
			panel_width = panel_patches.Width - margin * 2;
			panel_height = panel_patches.Height - margin * 2;
			square_length = panel_height / squares_number_height;
			squares_number_width = panel_width / square_length;
			board_width = square_length * squares_number_width;
			board_height = square_length * squares_number_height;
			margin_width = (panel_width - board_width) / 2 + margin;
			margin_height = (panel_height - board_height) / 2 + margin;
		}

		public void Paint(PaintEventArgs e)
		{
			CountDrawingInfo();
			POLE = new Bitmap(panel_patches.Width, 2 * panel_patches.Height);
			graphics = Graphics.FromImage(POLE);
			//c.FillRectangle(new SolidBrush(Color.Green), margin_width, margin_height, board_width, board_height);
			PaintField(squares_number_width, squares_number_height, square_length,
				margin_width, margin_height, board_width, board_height);
			PaintPatches();

			e.Graphics.DrawImage(POLE, 0, 0);

			//PaintTakenPatch(e);
		}

		void PaintField(int squares_number_width, int squares_number_height, int square_length, 
			int margin_width, int margin_height, int board_width, int board_height)
		{
			for (int i = 0; i <= squares_number_width; i++)
			{
				graphics.DrawLine(new Pen(Color.Black),
					margin_width + i * square_length,
					margin_height,
					margin_width + i * square_length,
					margin_height + board_height);
			}
			for (int i = 0; i <= squares_number_height; i++)
			{
				graphics.DrawLine(new Pen(Color.Black),
					margin_width,
					margin_height + i * square_length,
					margin_width + board_width,
					margin_height + i * square_length);
			}
		}

		void PaintPatches()
		{
			int prev_squares_in_width = 0;
			for (int patch_index = 0; patch_index < patches.Length; patch_index++)
			{
				Patch patch = patches[patch_index];

				if (patch.GetWidth() + prev_squares_in_width > squares_number_width)
				{
					break;
				}

				PaintPatchInField(patch_index, prev_squares_in_width);

				prev_squares_in_width += patch.GetWidth() + 1;
			}
		}

		void PaintPatchInField(int patch_index, int prev_squares_in_width)
		{
			Patch patch = patches[patch_index];

			int margin_squares = 0;
			if (patch.GetHeight() <= 3)
			{
				margin_squares = 1;
			}

			SolidBrush patch_brush;
			if (taken_patch_index == patch_index)
			{
				patch_brush = new SolidBrush(Color.Red);
			}
			else
			{
				patch_brush = new SolidBrush(Color.Green);
			}

			patch.Paint(graphics, patch_brush,
				margin_width + prev_squares_in_width * square_length,
				margin_height + margin_squares * square_length,
				square_length);
		}

		void PaintPatchInField(int patch_index)
		{
			int prev_squares_in_width = CountPrevSquaresWidth(patch_index);
			PaintPatchInField(patch_index, prev_squares_in_width);
		}

			//void PaintPatches()
			//{
			//	for (int patch_index = 0; patch_index < patches.Length; patch_index++)
			//	{
			//		if (!PaintPatchInField(patch_index))
			//		{
			//			break;
			//		}
			//	}
			//}

			//bool PaintPatchInField(int patch_index)
			//{
			//	Patch patch = patches[patch_index];
			//	int prev_squares_in_width = CountPrevSquaresWidth(patch_index);

			//	if (patch.GetWidth() + prev_squares_in_width > squares_number_width)
			//	{
			//		return false;
			//	}

			//	int margin_squares = 0;
			//	if (patch.GetHeight() <= 3)
			//	{
			//		margin_squares = 1;
			//	}

			//	SolidBrush patch_brush;
			//	if (taken_patch_index == patch_index)
			//	{
			//		patch_brush = new SolidBrush(Color.Red);
			//	}
			//	else
			//	{
			//		patch_brush = new SolidBrush(Color.Green);
			//	}

			//	patch.Paint(graphics, patch_brush,
			//		margin_width + prev_squares_in_width * square_length,
			//		margin_height + margin_squares * square_length,
			//		square_length);

			//	return true;
			//}

		int CountPrevSquaresWidth(int patch_index)
		{
			int prev_squares_in_width = 0;
			for (int i = 0; i < patch_index; patch_index++)
			{
				//if (i >= patches.Length)
				//{
				//	break;
				//}
				prev_squares_in_width += patches[i].GetWidth() + 1;
			}
			return prev_squares_in_width;
		}


		public void TakeOne(int x, int y)
		{
			int prev_squares_in_width = 0;
			for (int patch_index = 0; patch_index < patches.Length; patch_index++)
			{
				Patch patch = patches[patch_index];
				if (margin_width + prev_squares_in_width * square_length < x && 
					x < margin_width + (prev_squares_in_width + patch.GetWidth()) * square_length)
				{
					taken_patch_index = patch_index;
					mouse_position = new Point(x, y);
					//PaintPatchInField(patch_index);
					break;
				}
				prev_squares_in_width += patch.GetWidth() + 1;
			}
		}

		public void PutOne(int x, int y)
		{
			taken_patch_index = NOT_TAKEN;
		}

		public void MoveOne(int x, int y)
		{
			mouse_position = new Point(x, y);
		}

		public void PaintTakenPatch(PaintEventArgs e)
		{
			//Patch patch = patches[taken_patch_index];
			//int patch_width = patch.GetWidth() * square_length,
			//	patch_height = patch.GetHeight() * square_length;
			//taken_patch_pole = new Bitmap(patch_width, patch_height);
			//Graphics patch_graphics = Graphics.FromImage(taken_patch_pole);
			//patch.Paint(patch_graphics, new SolidBrush(Color.Red),
			//	0,
			//	0,
			//	square_length);
			//e.Graphics.DrawImage(taken_patch_pole, 
			//	mouse_position.X - patch_width / 2, 
			//	mouse_position.Y - patch_height / 2);

			if (taken_patch_index != NOT_TAKEN)
			{
				Patch patch = patches[taken_patch_index];
				int patch_width = patch.GetWidth() * square_length,
					patch_height = patch.GetHeight() * square_length;

				taken_patch_pole = new Bitmap(table_layout_panel_main.Width, table_layout_panel_main.Height);
				Graphics patch_graphics = Graphics.FromImage(taken_patch_pole);

				//Bitmap taken_patch_pole = new Bitmap(table_layout_panel_main.Width, 
				//	table_layout_panel_main.Height, 
				//	System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				//taken_patch_pole.MakeTransparent();
				//Graphics patch_graphics = Graphics.FromImage(taken_patch_pole);


				patch.Paint(patch_graphics, new SolidBrush(Color.Red),
					mouse_position.X - patch_width / 2,
					mouse_position.Y - patch_height / 2,
					square_length);

				e.Graphics.Clear(Color.Lime);
				//e.Graphics.Flush();

				//e.Graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(700, 400));
				//e.Graphics.Dispose();
				//e.Graphics.SetClip(patch_graphics);
				//e.Graphics.ResetClip();
				//try
				//{
					e.Graphics.DrawImage(taken_patch_pole,
						0,
						0);
				//} catch (ArgumentException)
				//{

				//}
				//e.Graphics.Dispose();
			}
		}

		public bool IsPatchTaken()
		{
			return taken_patch_index != NOT_TAKEN;
		}
	}
}
