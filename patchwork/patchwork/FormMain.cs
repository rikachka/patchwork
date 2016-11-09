using System;
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

		TimeBoard time_board;

		//TranspCtrl PanelOver = new TranspCtrl();
		//ExtendedPanel PanelOver = new ExtendedPanel();
		//Panel PanelOver = new Panel();

		public FormMain()
        {
            InitializeComponent();

			player_panels[Turn.PLAYER] = this.PanelPlayer;
			player_panels[Turn.OPPONENT] = this.PanelOpponent;
			turn = Turn.PLAYER;

			player_board = new PlayerBoard(this.TableLayoutPanelPlayer);
			player_boards[Turn.PLAYER] = player_board;

			opponent_board = new PlayerBoard(this.TableLayoutPanelOpponent);
			player_boards[Turn.OPPONENT] = opponent_board;

			time_board = new TimeBoard(this.TableLayoutPanelBoard);
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

		private void FormMain_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
			{
				player_boards[turn].TransposePatch(e.KeyCode);
				player_panels[turn].Invalidate();
				return;
			}
		}

        private void PanelPlayer_Paint(object sender, PaintEventArgs e)
        {
            player_board.Paint(e);
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
			patches.Paint(e);
		}

		private void PanelPatches_MouseDown(object sender, MouseEventArgs e)
        {
			patches.PutOne();
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
			if ((sender as Panel) == player_panels[turn])
			{
				player_boards[turn].TakePatch(new Point(e.X, e.Y));
			}
		}

		private void PanelPlayer_MouseMove(object sender, MouseEventArgs e)
		{
			if ((sender as Panel) == player_panels[turn])
			{
				if (player_boards[turn].IsPatchTaken())
				{
					player_boards[turn].MovePatch(new Point(e.X, e.Y));
					player_panels[turn].Invalidate();
				}
			}
		}

		private void PanelPlayer_MouseUp(object sender, MouseEventArgs e)
		{
			if ((sender as Panel) == player_panels[turn])
			{
				player_boards[turn].PutPatch();
			}
		}

		private void PanelPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if ((sender as Panel) == player_panels[turn])
			{
				if (player_boards[turn].IsClickOnNewPatch(new Point(e.X, e.Y)))
				{
					if (player_boards[turn].FixPatch(new Point(e.X, e.Y)))
					{
						patches.MarkTakenPatch();
						player_boards[turn].PutPatch();
						time_board.SetTime(turn, player_boards[turn].GetTime());
						this.PanelPatches.Invalidate();
						InvalidateTableLayoutPanelMain();
						GiveTurnToNextPlayer();
					}
				}
			}
		}

		private void InvalidateTableLayoutPanelMain()
		{
			this.PanelPlayer.Invalidate();
			this.PanelPlayerPoints.Invalidate();
			this.PanelPlayerPrize.Invalidate();
			this.PanelPlayerIncome.Invalidate();

			this.PanelOpponent.Invalidate();
			this.PanelOpponentPoints.Invalidate();
			this.PanelOpponentPrize.Invalidate();
			this.PanelOpponentIncome.Invalidate();

			this.PanelBoard.Invalidate();
		}

		private void GiveTurnToNextPlayer()
		{
			if (turn == Turn.PLAYER)
			{
				turn = Turn.OPPONENT;
			} 
			else
			{
				turn = Turn.PLAYER;
			}
		}

		private void PanelPlayerPoints_Paint(object sender, PaintEventArgs e)
		{
			player_boards[Turn.PLAYER].PaintPoints(e);
		}

		private void PanelPlayerIncome_Paint(object sender, PaintEventArgs e)
		{
			player_boards[Turn.PLAYER].PaintIncome(e);
		}

		private void PanelOpponentPoints_Paint(object sender, PaintEventArgs e)
		{
			player_boards[Turn.OPPONENT].PaintPoints(e);
		}

		private void PanelOpponentIncome_Paint(object sender, PaintEventArgs e)
		{
			player_boards[Turn.OPPONENT].PaintIncome(e);
		}

		private void PanelBoard_Paint(object sender, PaintEventArgs e)
		{
			time_board.Paint(e);
		}

		private void PanelBoard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int time = time_board.MoveForward(turn);
			player_boards[turn].SpendTime(time);
			GiveTurnToNextPlayer();
			InvalidateTableLayoutPanelMain();
		}
	}
}
