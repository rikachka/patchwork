namespace patchwork
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.MenuMain = new System.Windows.Forms.MenuStrip();
			this.MenuItemGame = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemGameNew = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemGameSave = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemGameExit = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemInfoRules = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuItemInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.PanelPlayer = new System.Windows.Forms.Panel();
			this.PanelOpponent = new System.Windows.Forms.Panel();
			this.PanelBoard = new System.Windows.Forms.Panel();
			this.TableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.PanelPatches = new System.Windows.Forms.Panel();
			this.TableLayoutPanelPlayer = new System.Windows.Forms.TableLayoutPanel();
			this.PanelPlayerPoints = new System.Windows.Forms.Panel();
			this.PanelPlayerPrize = new System.Windows.Forms.Panel();
			this.PanelPlayerIncome = new System.Windows.Forms.Panel();
			this.TableLayoutPanelBoard = new System.Windows.Forms.TableLayoutPanel();
			this.PanelBoardPrize = new System.Windows.Forms.Panel();
			this.TableLayoutPanelOpponent = new System.Windows.Forms.TableLayoutPanel();
			this.PanelOpponentPoints = new System.Windows.Forms.Panel();
			this.PanelOpponentPrize = new System.Windows.Forms.Panel();
			this.PanelOpponentIncome = new System.Windows.Forms.Panel();
			this.PanelButtonOk = new System.Windows.Forms.Panel();
			this.PanelButtonTime = new System.Windows.Forms.Panel();
			this.PictureBoxPrize = new System.Windows.Forms.PictureBox();
			this.PictureBoxPlayerPrize = new System.Windows.Forms.PictureBox();
			this.PictureBoxOpponentPrize = new System.Windows.Forms.PictureBox();
			this.MenuMain.SuspendLayout();
			this.TableLayoutPanelMain.SuspendLayout();
			this.TableLayoutPanelPlayer.SuspendLayout();
			this.PanelPlayerPrize.SuspendLayout();
			this.TableLayoutPanelBoard.SuspendLayout();
			this.PanelBoardPrize.SuspendLayout();
			this.TableLayoutPanelOpponent.SuspendLayout();
			this.PanelOpponentPrize.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxPrize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxPlayerPrize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpponentPrize)).BeginInit();
			this.SuspendLayout();
			// 
			// MenuMain
			// 
			this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGame,
            this.MenuItemInfo});
			this.MenuMain.Location = new System.Drawing.Point(0, 0);
			this.MenuMain.Name = "MenuMain";
			this.MenuMain.Size = new System.Drawing.Size(684, 24);
			this.MenuMain.TabIndex = 0;
			// 
			// MenuItemGame
			// 
			this.MenuItemGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemGameNew,
            this.MenuItemGameSave,
            this.MenuItemGameExit});
			this.MenuItemGame.Name = "MenuItemGame";
			this.MenuItemGame.Size = new System.Drawing.Size(50, 20);
			this.MenuItemGame.Text = "Game";
			// 
			// MenuItemGameNew
			// 
			this.MenuItemGameNew.Name = "MenuItemGameNew";
			this.MenuItemGameNew.Size = new System.Drawing.Size(152, 22);
			this.MenuItemGameNew.Text = "New";
			this.MenuItemGameNew.Click += new System.EventHandler(this.MenuItemGameNew_Click);
			// 
			// MenuItemGameSave
			// 
			this.MenuItemGameSave.Name = "MenuItemGameSave";
			this.MenuItemGameSave.Size = new System.Drawing.Size(98, 22);
			this.MenuItemGameSave.Text = "Save";
			// 
			// MenuItemGameExit
			// 
			this.MenuItemGameExit.Name = "MenuItemGameExit";
			this.MenuItemGameExit.Size = new System.Drawing.Size(152, 22);
			this.MenuItemGameExit.Text = "Exit";
			this.MenuItemGameExit.Click += new System.EventHandler(this.MenuItemGameExit_Click);
			// 
			// MenuItemInfo
			// 
			this.MenuItemInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemInfoRules,
            this.MenuItemInfoAbout});
			this.MenuItemInfo.Name = "MenuItemInfo";
			this.MenuItemInfo.Size = new System.Drawing.Size(40, 20);
			this.MenuItemInfo.Text = "Info";
			// 
			// MenuItemInfoRules
			// 
			this.MenuItemInfoRules.Name = "MenuItemInfoRules";
			this.MenuItemInfoRules.Size = new System.Drawing.Size(107, 22);
			this.MenuItemInfoRules.Text = "Rules";
			// 
			// MenuItemInfoAbout
			// 
			this.MenuItemInfoAbout.Name = "MenuItemInfoAbout";
			this.MenuItemInfoAbout.Size = new System.Drawing.Size(107, 22);
			this.MenuItemInfoAbout.Text = "About";
			// 
			// PanelPlayer
			// 
			this.PanelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PanelPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TableLayoutPanelPlayer.SetColumnSpan(this.PanelPlayer, 3);
			this.PanelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPlayer.Location = new System.Drawing.Point(3, 3);
			this.PanelPlayer.Name = "PanelPlayer";
			this.PanelPlayer.Size = new System.Drawing.Size(215, 193);
			this.PanelPlayer.TabIndex = 1;
			this.PanelPlayer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPlayer_Paint);
			this.PanelPlayer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseDoubleClick);
			this.PanelPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseDown);
			this.PanelPlayer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseMove);
			this.PanelPlayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseUp);
			// 
			// PanelOpponent
			// 
			this.PanelOpponent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.PanelOpponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TableLayoutPanelOpponent.SetColumnSpan(this.PanelOpponent, 3);
			this.PanelOpponent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelOpponent.Location = new System.Drawing.Point(3, 3);
			this.PanelOpponent.Name = "PanelOpponent";
			this.PanelOpponent.Size = new System.Drawing.Size(217, 193);
			this.PanelOpponent.TabIndex = 2;
			this.PanelOpponent.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelOpponent_Paint);
			this.PanelOpponent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseDoubleClick);
			this.PanelOpponent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseDown);
			this.PanelOpponent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseMove);
			this.PanelOpponent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelPlayer_MouseUp);
			// 
			// PanelBoard
			// 
			this.PanelBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PanelBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TableLayoutPanelBoard.SetColumnSpan(this.PanelBoard, 3);
			this.PanelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelBoard.Location = new System.Drawing.Point(3, 3);
			this.PanelBoard.Name = "PanelBoard";
			this.PanelBoard.Size = new System.Drawing.Size(216, 193);
			this.PanelBoard.TabIndex = 2;
			this.PanelBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBoard_Paint);
			this.PanelBoard.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PanelBoard_MouseDoubleClick);
			// 
			// TableLayoutPanelMain
			// 
			this.TableLayoutPanelMain.ColumnCount = 3;
			this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
			this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.TableLayoutPanelMain.Controls.Add(this.PanelPatches, 0, 0);
			this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelPlayer, 0, 1);
			this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelBoard, 1, 1);
			this.TableLayoutPanelMain.Controls.Add(this.TableLayoutPanelOpponent, 2, 1);
			this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
			this.TableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 27, 3, 3);
			this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
			this.TableLayoutPanelMain.RowCount = 2;
			this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
			this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
			this.TableLayoutPanelMain.Size = new System.Drawing.Size(684, 362);
			this.TableLayoutPanelMain.TabIndex = 3;
			// 
			// PanelPatches
			// 
			this.PanelPatches.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PanelPatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TableLayoutPanelMain.SetColumnSpan(this.PanelPatches, 3);
			this.PanelPatches.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPatches.Location = new System.Drawing.Point(3, 27);
			this.PanelPatches.Margin = new System.Windows.Forms.Padding(3, 27, 3, 3);
			this.PanelPatches.Name = "PanelPatches";
			this.PanelPatches.Size = new System.Drawing.Size(678, 96);
			this.PanelPatches.TabIndex = 3;
			this.PanelPatches.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPatches_Paint);
			this.PanelPatches.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelPatches_MouseDown);
			// 
			// TableLayoutPanelPlayer
			// 
			this.TableLayoutPanelPlayer.ColumnCount = 3;
			this.TableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.TableLayoutPanelPlayer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
			this.TableLayoutPanelPlayer.Controls.Add(this.PanelPlayer, 0, 0);
			this.TableLayoutPanelPlayer.Controls.Add(this.PanelPlayerPoints, 0, 1);
			this.TableLayoutPanelPlayer.Controls.Add(this.PanelPlayerPrize, 1, 1);
			this.TableLayoutPanelPlayer.Controls.Add(this.PanelPlayerIncome, 2, 1);
			this.TableLayoutPanelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanelPlayer.Location = new System.Drawing.Point(3, 129);
			this.TableLayoutPanelPlayer.Name = "TableLayoutPanelPlayer";
			this.TableLayoutPanelPlayer.RowCount = 2;
			this.TableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
			this.TableLayoutPanelPlayer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
			this.TableLayoutPanelPlayer.Size = new System.Drawing.Size(221, 230);
			this.TableLayoutPanelPlayer.TabIndex = 7;
			// 
			// PanelPlayerPoints
			// 
			this.PanelPlayerPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PanelPlayerPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelPlayerPoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPlayerPoints.Location = new System.Drawing.Point(3, 202);
			this.PanelPlayerPoints.Name = "PanelPlayerPoints";
			this.PanelPlayerPoints.Size = new System.Drawing.Size(67, 25);
			this.PanelPlayerPoints.TabIndex = 2;
			this.PanelPlayerPoints.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPlayerPoints_Paint);
			// 
			// PanelPlayerPrize
			// 
			this.PanelPlayerPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PanelPlayerPrize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelPlayerPrize.Controls.Add(this.PictureBoxPlayerPrize);
			this.PanelPlayerPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPlayerPrize.Location = new System.Drawing.Point(76, 202);
			this.PanelPlayerPrize.Name = "PanelPlayerPrize";
			this.PanelPlayerPrize.Padding = new System.Windows.Forms.Padding(3);
			this.PanelPlayerPrize.Size = new System.Drawing.Size(67, 25);
			this.PanelPlayerPrize.TabIndex = 3;
			// 
			// PanelPlayerIncome
			// 
			this.PanelPlayerIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PanelPlayerIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelPlayerIncome.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelPlayerIncome.Location = new System.Drawing.Point(149, 202);
			this.PanelPlayerIncome.Name = "PanelPlayerIncome";
			this.PanelPlayerIncome.Size = new System.Drawing.Size(69, 25);
			this.PanelPlayerIncome.TabIndex = 4;
			this.PanelPlayerIncome.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPlayerIncome_Paint);
			// 
			// TableLayoutPanelBoard
			// 
			this.TableLayoutPanelBoard.ColumnCount = 3;
			this.TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelBoard.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelBoard.Controls.Add(this.PanelBoard, 0, 0);
			this.TableLayoutPanelBoard.Controls.Add(this.PanelBoardPrize, 1, 1);
			this.TableLayoutPanelBoard.Controls.Add(this.PanelButtonOk, 0, 1);
			this.TableLayoutPanelBoard.Controls.Add(this.PanelButtonTime, 2, 1);
			this.TableLayoutPanelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanelBoard.Location = new System.Drawing.Point(230, 129);
			this.TableLayoutPanelBoard.Name = "TableLayoutPanelBoard";
			this.TableLayoutPanelBoard.RowCount = 2;
			this.TableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
			this.TableLayoutPanelBoard.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
			this.TableLayoutPanelBoard.Size = new System.Drawing.Size(222, 230);
			this.TableLayoutPanelBoard.TabIndex = 8;
			// 
			// PanelBoardPrize
			// 
			this.PanelBoardPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PanelBoardPrize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelBoardPrize.Controls.Add(this.PictureBoxPrize);
			this.PanelBoardPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelBoardPrize.Location = new System.Drawing.Point(77, 202);
			this.PanelBoardPrize.Name = "PanelBoardPrize";
			this.PanelBoardPrize.Padding = new System.Windows.Forms.Padding(3);
			this.PanelBoardPrize.Size = new System.Drawing.Size(68, 25);
			this.PanelBoardPrize.TabIndex = 3;
			this.PanelBoardPrize.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelBoardPrize_Paint);
			// 
			// TableLayoutPanelOpponent
			// 
			this.TableLayoutPanelOpponent.ColumnCount = 3;
			this.TableLayoutPanelOpponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelOpponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelOpponent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.TableLayoutPanelOpponent.Controls.Add(this.PanelOpponent, 0, 0);
			this.TableLayoutPanelOpponent.Controls.Add(this.PanelOpponentPoints, 0, 1);
			this.TableLayoutPanelOpponent.Controls.Add(this.PanelOpponentPrize, 1, 1);
			this.TableLayoutPanelOpponent.Controls.Add(this.PanelOpponentIncome, 2, 1);
			this.TableLayoutPanelOpponent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TableLayoutPanelOpponent.Location = new System.Drawing.Point(458, 129);
			this.TableLayoutPanelOpponent.Name = "TableLayoutPanelOpponent";
			this.TableLayoutPanelOpponent.RowCount = 2;
			this.TableLayoutPanelOpponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.66666F));
			this.TableLayoutPanelOpponent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
			this.TableLayoutPanelOpponent.Size = new System.Drawing.Size(223, 230);
			this.TableLayoutPanelOpponent.TabIndex = 9;
			// 
			// PanelOpponentPoints
			// 
			this.PanelOpponentPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.PanelOpponentPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelOpponentPoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelOpponentPoints.Location = new System.Drawing.Point(3, 202);
			this.PanelOpponentPoints.Name = "PanelOpponentPoints";
			this.PanelOpponentPoints.Size = new System.Drawing.Size(68, 25);
			this.PanelOpponentPoints.TabIndex = 3;
			this.PanelOpponentPoints.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelOpponentPoints_Paint);
			// 
			// PanelOpponentPrize
			// 
			this.PanelOpponentPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.PanelOpponentPrize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelOpponentPrize.Controls.Add(this.PictureBoxOpponentPrize);
			this.PanelOpponentPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelOpponentPrize.Location = new System.Drawing.Point(77, 202);
			this.PanelOpponentPrize.Name = "PanelOpponentPrize";
			this.PanelOpponentPrize.Padding = new System.Windows.Forms.Padding(3);
			this.PanelOpponentPrize.Size = new System.Drawing.Size(68, 25);
			this.PanelOpponentPrize.TabIndex = 4;
			// 
			// PanelOpponentIncome
			// 
			this.PanelOpponentIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.PanelOpponentIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelOpponentIncome.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelOpponentIncome.Location = new System.Drawing.Point(151, 202);
			this.PanelOpponentIncome.Name = "PanelOpponentIncome";
			this.PanelOpponentIncome.Size = new System.Drawing.Size(69, 25);
			this.PanelOpponentIncome.TabIndex = 5;
			this.PanelOpponentIncome.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelOpponentIncome_Paint);
			// 
			// PanelButtonOk
			// 
			this.PanelButtonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PanelButtonOk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelButtonOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PanelButtonOk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelButtonOk.Location = new System.Drawing.Point(3, 202);
			this.PanelButtonOk.Name = "PanelButtonOk";
			this.PanelButtonOk.Size = new System.Drawing.Size(68, 25);
			this.PanelButtonOk.TabIndex = 4;
			this.PanelButtonOk.Click += new System.EventHandler(this.PanelButtonOk_Click);
			this.PanelButtonOk.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelButtonOk_Paint);
			// 
			// PanelButtonTime
			// 
			this.PanelButtonTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PanelButtonTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.PanelButtonTime.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PanelButtonTime.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PanelButtonTime.Location = new System.Drawing.Point(151, 202);
			this.PanelButtonTime.Name = "PanelButtonTime";
			this.PanelButtonTime.Size = new System.Drawing.Size(68, 25);
			this.PanelButtonTime.TabIndex = 5;
			this.PanelButtonTime.Click += new System.EventHandler(this.PanelButtonTime_Click);
			this.PanelButtonTime.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelButtonTime_Paint);
			// 
			// PictureBoxPrize
			// 
			this.PictureBoxPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.PictureBoxPrize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxPrize.BackgroundImage")));
			this.PictureBoxPrize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PictureBoxPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBoxPrize.ErrorImage = null;
			this.PictureBoxPrize.InitialImage = null;
			this.PictureBoxPrize.Location = new System.Drawing.Point(3, 3);
			this.PictureBoxPrize.Name = "PictureBoxPrize";
			this.PictureBoxPrize.Size = new System.Drawing.Size(60, 17);
			this.PictureBoxPrize.TabIndex = 0;
			this.PictureBoxPrize.TabStop = false;
			// 
			// PictureBoxPlayerPrize
			// 
			this.PictureBoxPlayerPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.PictureBoxPlayerPrize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxPlayerPrize.BackgroundImage")));
			this.PictureBoxPlayerPrize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PictureBoxPlayerPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBoxPlayerPrize.ErrorImage = null;
			this.PictureBoxPlayerPrize.InitialImage = null;
			this.PictureBoxPlayerPrize.Location = new System.Drawing.Point(3, 3);
			this.PictureBoxPlayerPrize.Name = "PictureBoxPlayerPrize";
			this.PictureBoxPlayerPrize.Size = new System.Drawing.Size(59, 17);
			this.PictureBoxPlayerPrize.TabIndex = 1;
			this.PictureBoxPlayerPrize.TabStop = false;
			this.PictureBoxPlayerPrize.Visible = false;
			// 
			// PictureBoxOpponentPrize
			// 
			this.PictureBoxOpponentPrize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.PictureBoxOpponentPrize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxOpponentPrize.BackgroundImage")));
			this.PictureBoxOpponentPrize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.PictureBoxOpponentPrize.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBoxOpponentPrize.ErrorImage = null;
			this.PictureBoxOpponentPrize.InitialImage = null;
			this.PictureBoxOpponentPrize.Location = new System.Drawing.Point(3, 3);
			this.PictureBoxOpponentPrize.Name = "PictureBoxOpponentPrize";
			this.PictureBoxOpponentPrize.Size = new System.Drawing.Size(60, 17);
			this.PictureBoxOpponentPrize.TabIndex = 1;
			this.PictureBoxOpponentPrize.TabStop = false;
			this.PictureBoxOpponentPrize.Visible = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 362);
			this.Controls.Add(this.MenuMain);
			this.Controls.Add(this.TableLayoutPanelMain);
			this.MainMenuStrip = this.MenuMain;
			this.Name = "FormMain";
			this.Text = "Patchwork";
			this.TransparencyKey = System.Drawing.Color.Lime;
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
			this.MenuMain.ResumeLayout(false);
			this.MenuMain.PerformLayout();
			this.TableLayoutPanelMain.ResumeLayout(false);
			this.TableLayoutPanelPlayer.ResumeLayout(false);
			this.PanelPlayerPrize.ResumeLayout(false);
			this.TableLayoutPanelBoard.ResumeLayout(false);
			this.PanelBoardPrize.ResumeLayout(false);
			this.TableLayoutPanelOpponent.ResumeLayout(false);
			this.PanelOpponentPrize.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxPrize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxPlayerPrize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PictureBoxOpponentPrize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGame;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameNew;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGameExit;
        private System.Windows.Forms.Panel PanelPlayer;
        private System.Windows.Forms.Panel PanelOpponent;
        private System.Windows.Forms.Panel PanelBoard;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInfoRules;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInfoAbout;
        private System.Windows.Forms.Panel PanelPatches;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelPlayer;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelOpponent;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelBoard;
        private System.Windows.Forms.Panel PanelPlayerPoints;
        private System.Windows.Forms.Panel PanelPlayerPrize;
        private System.Windows.Forms.Panel PanelPlayerIncome;
        private System.Windows.Forms.Panel PanelOpponentPoints;
        private System.Windows.Forms.Panel PanelOpponentPrize;
        private System.Windows.Forms.Panel PanelOpponentIncome;
        private System.Windows.Forms.Panel PanelBoardPrize;
		private System.Windows.Forms.Panel PanelButtonOk;
		private System.Windows.Forms.Panel PanelButtonTime;
		private System.Windows.Forms.PictureBox PictureBoxPrize;
		private System.Windows.Forms.PictureBox PictureBoxPlayerPrize;
		private System.Windows.Forms.PictureBox PictureBoxOpponentPrize;
	}
}

