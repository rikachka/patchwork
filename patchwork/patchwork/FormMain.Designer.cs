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
            this.MenuMain.SuspendLayout();
            this.TableLayoutPanelMain.SuspendLayout();
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
            // 
            // MenuItemGameSave
            // 
            this.MenuItemGameSave.Name = "MenuItemGameSave";
            this.MenuItemGameSave.Size = new System.Drawing.Size(152, 22);
            this.MenuItemGameSave.Text = "Save";
            // 
            // MenuItemGameExit
            // 
            this.MenuItemGameExit.Name = "MenuItemGameExit";
            this.MenuItemGameExit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemGameExit.Text = "Exit";
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
            this.MenuItemInfoRules.Size = new System.Drawing.Size(152, 22);
            this.MenuItemInfoRules.Text = "Rules";
            // 
            // MenuItemInfoAbout
            // 
            this.MenuItemInfoAbout.Name = "MenuItemInfoAbout";
            this.MenuItemInfoAbout.Size = new System.Drawing.Size(152, 22);
            this.MenuItemInfoAbout.Text = "About";
            // 
            // PanelPlayer
            // 
            this.PanelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.PanelPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPlayer.Location = new System.Drawing.Point(3, 111);
            this.PanelPlayer.Name = "PanelPlayer";
            this.PanelPlayer.Size = new System.Drawing.Size(222, 248);
            this.PanelPlayer.TabIndex = 1;
            this.PanelPlayer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPlayer_Paint);
            this.PanelPlayer.Layout += new System.Windows.Forms.LayoutEventHandler(this.PanelPlayer_Layout);
            // 
            // PanelOpponent
            // 
            this.PanelOpponent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PanelOpponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelOpponent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelOpponent.Location = new System.Drawing.Point(459, 111);
            this.PanelOpponent.Name = "PanelOpponent";
            this.PanelOpponent.Size = new System.Drawing.Size(222, 248);
            this.PanelOpponent.TabIndex = 2;
            // 
            // PanelBoard
            // 
            this.PanelBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PanelBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBoard.Location = new System.Drawing.Point(231, 111);
            this.PanelBoard.Name = "PanelBoard";
            this.PanelBoard.Size = new System.Drawing.Size(222, 248);
            this.PanelBoard.TabIndex = 2;
            // 
            // TableLayoutPanelMain
            // 
            this.TableLayoutPanelMain.ColumnCount = 3;
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelMain.Controls.Add(this.PanelOpponent, 2, 1);
            this.TableLayoutPanelMain.Controls.Add(this.PanelBoard, 1, 1);
            this.TableLayoutPanelMain.Controls.Add(this.PanelPlayer, 0, 1);
            this.TableLayoutPanelMain.Controls.Add(this.PanelPatches, 0, 0);
            this.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(3, 27, 3, 3);
            this.TableLayoutPanelMain.Name = "TableLayoutPanelMain";
            this.TableLayoutPanelMain.RowCount = 2;
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.PanelPatches.Size = new System.Drawing.Size(678, 78);
            this.PanelPatches.TabIndex = 3;
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
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.TableLayoutPanelMain.ResumeLayout(false);
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
    }
}

