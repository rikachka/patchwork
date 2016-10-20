﻿using System;
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
	enum Turn { PLAYER, OPPONENT };

	public partial class FormMain : Form
    {
        byte[,] Area = new byte[10, 21];

        PlayerBoard player_board;
        PlayerBoard opponent_board;
		//PlayerBoard[] player_boards = new PlayerBoard[2]; 
		Dictionary<Turn, PlayerBoard> player_boards = new Dictionary<Turn, PlayerBoard>();
		Dictionary<Turn, Panel> player_panels = new Dictionary<Turn, Panel>();
		Patches patches;
		Turn turn;

		//TranspCtrl PanelOver = new TranspCtrl();
		//ExtendedPanel PanelOver = new ExtendedPanel();
		//Panel PanelOver = new Panel();

		public FormMain()
        {
            InitializeComponent();

			player_panels[Turn.PLAYER] = this.PanelPlayer;
			player_panels[Turn.OPPONENT] = this.PanelOpponent;
			turn = Turn.PLAYER;
		}

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            this.PanelPlayer.Invalidate();
            this.PanelOpponent.Invalidate();
            this.PanelBoard.Invalidate();
            this.PanelPatches.Invalidate();
		}

		private void PanelPlayer_Layout(object sender, LayoutEventArgs e)
        {
            player_board = new PlayerBoard(this.TableLayoutPanelPlayer);
			player_boards[Turn.PLAYER] = player_board;
        }

        private void PanelPlayer_Paint(object sender, PaintEventArgs e)
        {
            player_board.Paint(e);
        }

        private void PanelOpponent_Layout(object sender, LayoutEventArgs e)
        {
            opponent_board = new PlayerBoard(this.TableLayoutPanelOpponent);
			player_boards[Turn.OPPONENT] = opponent_board;
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

		private void PanelPatches_MouseDown(object sender, MouseEventArgs e)
        {
            Patch patch = patches.TakeOne(e.X, e.Y);
			if (patches.IsPatchTaken())
			{
				player_boards[turn].AddNewPatch(patch);
			} else
			{
				player_boards[turn].DeleteNewPatch();
			}
			this.PanelPatches.Invalidate();
			player_panels[turn].Invalidate();
		}

		private void PanelPlayer_MouseDown(object sender, MouseEventArgs e)
		{
			player_boards[turn].TakePatch(new Point(e.X, e.Y));
		}

		private void PanelPlayer_MouseMove(object sender, MouseEventArgs e)
		{
			if (player_boards[turn].IsPatchTaken())
			{
				player_boards[turn].MovePatch(new Point(e.X, e.Y));
				player_panels[turn].Invalidate();
			}
		}

		private void PanelPlayer_MouseUp(object sender, MouseEventArgs e)
		{
			player_boards[turn].PutPatch();
		}

		private void FormMain_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
			{
				player_boards[turn].TransposePatch(e.KeyCode);
				player_panels[turn].Invalidate();
				return;
			}
			//switch (e.KeyCode)
			//{
			//	case Keys.Down:
			//		player_boards[turn].
			//		break;
			//	case Keys.Up:
			//		break;
			//	case Keys.Left:
			//		break;
			//	case Keys.Right:
			//		break;
			//}
			//if (e.KeyCode == Keys.Down)
			//{
			//	MessageBox.Show("Key up");
			//}
		}
	}
}
