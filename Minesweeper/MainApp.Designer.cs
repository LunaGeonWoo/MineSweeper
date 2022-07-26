namespace Minesweeper
{
    partial class MainApp
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OneVersusOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HTPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeTextBoxStrip = new System.Windows.Forms.ToolStripTextBox();
            this.MinesTexBoxStrip = new System.Windows.Forms.ToolStripTextBox();
            this.ServerConnectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerConnectStatusTextBoxStrip = new System.Windows.Forms.ToolStripTextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMenuItem,
            this.TimeTextBoxStrip,
            this.MinesTexBoxStrip,
            this.ServerConnectMenuItem,
            this.ServerConnectStatusTextBoxStrip});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(400, 33);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // MenuMenuItem
            // 
            this.MenuMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestartMenuItem,
            this.SettingMenuItem,
            this.OneVersusOneMenuItem,
            this.HTPMenuItem});
            this.MenuMenuItem.Name = "MenuMenuItem";
            this.MenuMenuItem.Size = new System.Drawing.Size(43, 29);
            this.MenuMenuItem.Text = "메뉴";
            // 
            // RestartMenuItem
            // 
            this.RestartMenuItem.Name = "RestartMenuItem";
            this.RestartMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RestartMenuItem.Size = new System.Drawing.Size(163, 22);
            this.RestartMenuItem.Text = "새로시작";
            this.RestartMenuItem.Click += new System.EventHandler(this.RestartMenuItem_Click);
            // 
            // SettingMenuItem
            // 
            this.SettingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyMenuItem,
            this.MediumMenuItem,
            this.HardMenuItem,
            this.CustomMenuItem});
            this.SettingMenuItem.Name = "SettingMenuItem";
            this.SettingMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SettingMenuItem.Text = "환경설정";
            // 
            // EasyMenuItem
            // 
            this.EasyMenuItem.Name = "EasyMenuItem";
            this.EasyMenuItem.Size = new System.Drawing.Size(188, 22);
            this.EasyMenuItem.Text = "초급 : 9 x 9, 10개";
            this.EasyMenuItem.Click += new System.EventHandler(this.EasyMenuItem_Click);
            // 
            // MediumMenuItem
            // 
            this.MediumMenuItem.Name = "MediumMenuItem";
            this.MediumMenuItem.Size = new System.Drawing.Size(188, 22);
            this.MediumMenuItem.Text = "중급 : 16 x 16, 40개";
            this.MediumMenuItem.Click += new System.EventHandler(this.MediumMenuItem_Click);
            // 
            // HardMenuItem
            // 
            this.HardMenuItem.Name = "HardMenuItem";
            this.HardMenuItem.Size = new System.Drawing.Size(188, 22);
            this.HardMenuItem.Text = "고급 : 30 x 16, 99개 ";
            this.HardMenuItem.Click += new System.EventHandler(this.HardMenuItem_Click);
            // 
            // CustomMenuItem
            // 
            this.CustomMenuItem.Name = "CustomMenuItem";
            this.CustomMenuItem.Size = new System.Drawing.Size(188, 22);
            this.CustomMenuItem.Text = "커스텀";
            this.CustomMenuItem.Click += new System.EventHandler(this.CustomMenuItem_Click);
            // 
            // OneVersusOneMenuItem
            // 
            this.OneVersusOneMenuItem.Name = "OneVersusOneMenuItem";
            this.OneVersusOneMenuItem.Size = new System.Drawing.Size(163, 22);
            this.OneVersusOneMenuItem.Text = "1대1 대결하기";
            this.OneVersusOneMenuItem.Visible = false;
            // 
            // HTPMenuItem
            // 
            this.HTPMenuItem.Name = "HTPMenuItem";
            this.HTPMenuItem.Size = new System.Drawing.Size(163, 22);
            this.HTPMenuItem.Text = "플레이 방법";
            this.HTPMenuItem.Click += new System.EventHandler(this.HTPMenuItem_Click);
            // 
            // TimeTextBoxStrip
            // 
            this.TimeTextBoxStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TimeTextBoxStrip.BackColor = System.Drawing.SystemColors.Window;
            this.TimeTextBoxStrip.Enabled = false;
            this.TimeTextBoxStrip.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.TimeTextBoxStrip.Name = "TimeTextBoxStrip";
            this.TimeTextBoxStrip.ReadOnly = true;
            this.TimeTextBoxStrip.Size = new System.Drawing.Size(80, 29);
            this.TimeTextBoxStrip.Text = "🕙";
            this.TimeTextBoxStrip.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinesTexBoxStrip
            // 
            this.MinesTexBoxStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MinesTexBoxStrip.Enabled = false;
            this.MinesTexBoxStrip.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MinesTexBoxStrip.Name = "MinesTexBoxStrip";
            this.MinesTexBoxStrip.ReadOnly = true;
            this.MinesTexBoxStrip.Size = new System.Drawing.Size(80, 29);
            this.MinesTexBoxStrip.Text = "🚩";
            this.MinesTexBoxStrip.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServerConnectMenuItem
            // 
            this.ServerConnectMenuItem.Name = "ServerConnectMenuItem";
            this.ServerConnectMenuItem.Size = new System.Drawing.Size(67, 29);
            this.ServerConnectMenuItem.Text = "서버연결";
            this.ServerConnectMenuItem.Click += new System.EventHandler(this.ServerConnectMenuItem_Click);
            // 
            // ServerConnectStatusTextBoxStrip
            // 
            this.ServerConnectStatusTextBoxStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ServerConnectStatusTextBoxStrip.ForeColor = System.Drawing.Color.Red;
            this.ServerConnectStatusTextBoxStrip.Name = "ServerConnectStatusTextBoxStrip";
            this.ServerConnectStatusTextBoxStrip.ReadOnly = true;
            this.ServerConnectStatusTextBoxStrip.Size = new System.Drawing.Size(19, 29);
            this.ServerConnectStatusTextBoxStrip.Text = "●";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "지뢰찾기";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainApp_FormClosing);
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EasyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediumMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomMenuItem;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ToolStripTextBox TimeTextBoxStrip;
        private System.Windows.Forms.ToolStripTextBox MinesTexBoxStrip;
        private System.Windows.Forms.ToolStripMenuItem HTPMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ServerConnectMenuItem;
        private System.Windows.Forms.ToolStripTextBox ServerConnectStatusTextBoxStrip;
        private System.Windows.Forms.ToolStripMenuItem OneVersusOneMenuItem;
    }
}

