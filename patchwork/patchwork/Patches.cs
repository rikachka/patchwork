using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace patchwork
{
    class Patches
    {
        Panel panel_patches;
        Graphics c;
        Bitmap POLE;

        public Patches(Panel panel_patches_)
        {
            panel_patches = panel_patches_;
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
            c.FillRectangle(new SolidBrush(Color.Green), margin_width, margin_height, board_width, board_height);
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
