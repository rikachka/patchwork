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
		Dictionary<Turn, PlayerBoard> player_boards = new Dictionary<Turn, PlayerBoard>();
		Dictionary<Turn, Panel> player_panels = new Dictionary<Turn, Panel>();
		Patches patches;
		Turn turn;

		TimeBoard time_board;

		public FormMain()
        {
            InitializeComponent();

			StartNewGame();
		}

		private void StartNewGame()
		{
			player_panels[Turn.PLAYER] = this.PanelPlayer;
			player_panels[Turn.OPPONENT] = this.PanelOpponent;
			turn = Turn.PLAYER;

			player_board = new PlayerBoard(this.TableLayoutPanelPlayer);
			player_boards[Turn.PLAYER] = player_board;

			opponent_board = new PlayerBoard(this.TableLayoutPanelOpponent);
			player_boards[Turn.OPPONENT] = opponent_board;

			patches = new Patches(this.PanelPatches, this.TableLayoutPanelMain);

			time_board = new TimeBoard(this.TableLayoutPanelBoard);

			this.PictureBoxPrize.Show();

			this.Invalidate();
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

        private void PanelPatches_Paint(object sender, PaintEventArgs e)
        {
			patches.SetInfoAboutActivePlayer(player_boards[turn].GetPoints());
			patches.Paint(e);
		}

		private void PanelPatches_MouseDown(object sender, MouseEventArgs e)
        {
			patches.PutOne();
			Patch patch = patches.TakeOne(e.X, e.Y);
			if (patches.IsPatchTaken() && player_boards[turn].HasEnoughMoney(patch))
			{
				player_boards[turn].AddNewPatch(patch);
			}
			else
			{
				player_boards[turn].DeleteNewPatch();
				patches.PutOne();
			}
			this.PanelPatches.Invalidate();
			player_panels[turn].Invalidate();
			CheckButtonOk();
			this.PanelButtonOk.Invalidate();
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

		private void CheckPrizeReceiving()
		{
			if (this.PictureBoxPrize.Visible)
			{
				if (player_boards[turn].CheckPrizeReceivingCondition())
				{
					this.PictureBoxPrize.Hide();
				}
			}
		}

		private void FixPatch()
		{
			int taken_patch_time = player_boards[turn].GetNewPatchTime();
			if (player_boards[turn].FixPatch())
			{
				patches.MarkTakenPatch();
				player_boards[turn].PutPatch();
				TimeChange time_change = time_board.SetTime(turn, player_boards[turn].GetTime() + taken_patch_time);
				player_boards[turn].SpendTime(time_change);
				CheckPrizeReceiving();
				this.PanelPatches.Invalidate();
				InvalidateTableLayoutPanelMain();
				GiveTurnToNextPlayer();
			}
		}

		private void PanelPlayer_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if ((sender as Panel) == player_panels[turn])
			{
				if (player_boards[turn].IsClickOnNewPatch(new Point(e.X, e.Y)))
				{
					FixPatch();
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
			CheckButtonOk();
			this.PanelButtonOk.Invalidate();
		}

		private void GiveTurnToNextPlayer()
		{
			turn = time_board.GetNextPlayer(turn);
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

		private void MoveFurther()
		{
			TimeChange time_change = time_board.MoveForward(turn);
			player_boards[turn].SpendTime(time_change, true);
			player_boards[turn].DeleteNewPatch();
			patches.PutOne();
			GiveTurnToNextPlayer();
			InvalidateTableLayoutPanelMain();
			this.PanelPatches.Invalidate();
		}

		private void PanelBoard_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			MoveFurther();
		}

		private void PanelBoardPrize_Paint(object sender, PaintEventArgs e)
		{

		}

		private void CheckButtonOk()
		{
			if (player_boards[turn].CheckPatch())
			{
				this.PanelButtonOk.Enabled = true;
			}
			else
			{
				this.PanelButtonOk.Enabled = false;
			}
		}

		private void PanelButtonOk_Paint(object sender, PaintEventArgs e)
		{
			int panel_width = this.PanelButtonOk.Width,
				panel_height = this.PanelButtonOk.Height;
			Bitmap pole = new Bitmap(panel_width, panel_height);
			Graphics graphics = Graphics.FromImage(pole);
			graphics.DrawString("Ok",
					new Font(Constants.MainFont, panel_height * 6 / 11),
					Constants.ButtonBrush,
					new Point(0, 0));
			e.Graphics.DrawImage(pole,
				0,
				0);
		}

		private void PanelButtonOk_Click(object sender, EventArgs e)
		{
			FixPatch();
		}

		private void PanelButtonTime_Paint(object sender, PaintEventArgs e)
		{
			int panel_width = this.PanelButtonOk.Width,
				panel_height = this.PanelButtonOk.Height;
			Bitmap pole = new Bitmap(panel_width, panel_height);
			Graphics graphics = Graphics.FromImage(pole);
			graphics.DrawString("Move",
					new Font(Constants.MainFont, panel_height * 6 / 11),
					Constants.ButtonBrush,
					new Point(0, 0));
			e.Graphics.DrawImage(pole,
				0,
				0);
		}

		private void PanelButtonTime_Click(object sender, EventArgs e)
		{
			MoveFurther();
		}

		private void MenuItemGameNew_Click(object sender, EventArgs e)
		{
			StartNewGame();
		}

		private void MenuItemGameExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
