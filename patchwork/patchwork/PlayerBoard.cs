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
        Panel panel_player;
        Graphics c;
        Bitmap POLE;

        public PlayerBoard(Panel panel_player_)
        {
            panel_player = panel_player_;
        }

        public void Paint(PaintEventArgs e)
        {
            int margin = 5;
            int panel_width = panel_player.Width - margin * 2,
                panel_height = panel_player.Height - margin * 2,
                squares_number = 9;
            int board_length = panel_width < panel_height ? panel_width : panel_height;
            int square_length = board_length / squares_number;
            board_length = square_length * squares_number;
            int margin_width = (panel_width - board_length) / 2 + margin;
            int margin_height = (panel_height - board_length) / 2 + margin;

            POLE = new Bitmap(panel_player.Width, panel_player.Height);
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
        }
    }
}
