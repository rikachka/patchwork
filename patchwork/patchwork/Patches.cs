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
        int[,] info;
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
    }

    class Patches
    {
        Panel panel_patches;
        Graphics c;
        Bitmap POLE;
        Patch[] patches;

        public Patches(Panel panel_patches_)
        {
            panel_patches = panel_patches_;
            CreatePatches();
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

        public void Paint(PaintEventArgs e)
        {
            int margin = 5;
            int panel_width = panel_patches.Width - margin * 2,
                panel_height = panel_patches.Height - margin * 2,
                squares_number_height = 5,
                square_length = panel_height / squares_number_height,
                squares_number_width = panel_width / square_length,
                board_width = square_length * squares_number_width,
                board_height = square_length * squares_number_height,
                margin_width = (panel_width - board_width) / 2 + margin,
                margin_height = (panel_height - board_height) / 2 + margin;

            POLE = new Bitmap(panel_patches.Width, panel_patches.Height);
            c = Graphics.FromImage(POLE);
            //c.FillRectangle(new SolidBrush(Color.Green), margin_width, margin_height, board_width, board_height);
            for (int i = 0; i <= squares_number_width; i++)
            {
                c.DrawLine(new Pen(Color.Black),
                    margin_width + i * square_length,
                    margin_height,
                    margin_width + i * square_length,
                    margin_height + board_height);
            }
            for (int i = 0; i <= squares_number_height; i++)
            {
                c.DrawLine(new Pen(Color.Black),
                    margin_width,
                    margin_height + i * square_length,
                    margin_width + board_width,
                    margin_height + i * square_length);
            }
            e.Graphics.DrawImage(POLE, 0, 0);
        }
    }
}
