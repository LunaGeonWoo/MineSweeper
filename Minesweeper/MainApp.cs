using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainApp : Form
    {
        Dictionary<int, ToolStripMenuItem> VersusItems = new Dictionary<int, ToolStripMenuItem>();

        List<Mine> mines = new List<Mine>();
        int nx, ny, count, time, minecount;
        bool playing;
        CustomDialog CustomDlg = new CustomDialog();
        ClientSocket socket = new ClientSocket();
        int socketNum;
        int CompetitionWith = -1;
        bool connecting;

        public MainApp()
        {
            InitializeComponent();
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            MakeMineMap(9, 9, 10);
            ChangeServerConnectStatusColor(false);
        }

        private void ChangeServerConnectStatusColor(bool status)
        {
            if (status) ServerConnectStatusTextBoxStrip.ForeColor = Color.Blue;
            else ServerConnectStatusTextBoxStrip.ForeColor = Color.Red;
        }

        public void sendtomainThreadParsing(string data)
        {
            if (this.InvokeRequired)//부쓰레드냐?
            {
                this.BeginInvoke(new Action(() => sendtomainThreadParsing(data)));
                return;
            }
            Parsing(data);
        }

        private void Parsing(string data)
        {
            string[] words = data.Split('/');
            if (words.Length >= 2 && words[0] == "")
            {
                words = words[1].Split(' ');
                if (words.Length >= 2)
                {
                    switch (words[0])
                    {
                        case "ClientNum":
                            socketNum = Convert.ToInt32(words[1]);
                            OneVersusOneMenuItem.Visible = true;
                            this.Text = "지뢰찾기, " + socketNum.ToString() + "번 입니다.";
                            break;
                        case "OtherClientNum":
                            {
                                int n = Convert.ToInt32(words[1]);
                                MakeVersusItem(n);
                                break;
                            }
                        case "ClientLeft":
                            {
                                int n = Convert.ToInt32(words[1]);
                                DeleteVersusItem(n);
                                if (CompetitionWith == n)
                                {
                                    MessageBox.Show(CompetitionWith.ToString() + "번이 나갔습니다.");
                                    CompetitionWith = -1;
                                }
                                break;
                            }
                        case "Competition":

                            if (words[1] == "0")
                                EasyMenuItem.PerformClick();
                            else if (words[1] == "1")
                                MediumMenuItem.PerformClick();
                            else if (words[1] == "2")
                                HardMenuItem.PerformClick();
                            CompetitionWith = Convert.ToInt32(words[2]);
                            break;
                        case "EndCompetition":
                            CompetitionWith = -1;
                            if (words[1] == "Win") GameOver(true);
                            else if (words[1] == "Lose") GameOver(false);
                            break;
                    }
                }
                return;
            }
        }

        private void MakeVersusItem(int n)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();

            menuItem.Name = n.ToString();
            menuItem.Size = new System.Drawing.Size(188, 22);
            menuItem.Text = n.ToString() + "번과 대결";
            menuItem.Click += CompetitionWith_Click;

            VersusItems.Add(n, menuItem);

            foreach (ToolStripMenuItem item in VersusItems.Values)
            {
                OneVersusOneMenuItem.DropDownItems.Add(item);
            }
        }

        private void DeleteVersusItem(int n)
        {
            VersusItems[n].Dispose();
            VersusItems.Remove(n);

            foreach (ToolStripMenuItem item in VersusItems.Values)
            {
                OneVersusOneMenuItem.DropDownItems.Add(item);
            }
        }

        private void CompetitionWith_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            int n = Convert.ToInt32(menuItem.Name);
            socket.Send("/CompetitionWith " + n.ToString());
        }

        public void sendtomainThreadMakeMap(int column, int row, int mine)
        {
            if (this.InvokeRequired)//부쓰레드냐?
            {
                this.BeginInvoke(new Action(() => sendtomainThreadMakeMap(column, row, mine)));
                return;
            }
            CustomDlg.Close();
            MakeMineMap(column, row, mine);
        }

        private void ClearMines()
        {
            foreach (Mine m in mines)
            {
                Controls.Remove(m.Button);
                m.Clear();
            }
            mines.Clear();
        }

        private void MakeMineMap(int x, int y, int count)
        {
            if (CompetitionWith != -1)
            {
                socket.Send("/EndCompetition 0 " + CompetitionWith.ToString());
                CompetitionWith = -1;
            }
            ClearMines();
            nx = x; ny = y; this.count = count;

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Mine mine = new Mine();
                    mine.Button.MouseUp += MouseUp_Mine;
                    mine.Button.Location = new Point(j * mine.Button.Width, i * mine.Button.Height + menuStrip.Height);
                    Controls.Add(mine.Button);
                    mines.Add(mine);
                }
            }
            ClientSize = new Size(mines[0].Button.Width * nx, mines[0].Button.Height * ny + menuStrip.Height);

            for (int i = 0; i < count; i++)
                mines[i].Content = -1;
            Random rand = new Random();
            for (int i = 0; i < x * y; i++)
            {
                int n = rand.Next(0, x * y);

                int keep = mines[i].Content;
                mines[i].Content = mines[n].Content;
                mines[i].Num = i;
                mines[n].Content = keep;
            }

            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (mines[i * nx + j].Content != -1)
                        mines[i * nx + j].Content = NeighborMines(i * nx + j);
                }
            }

            time = 0;
            TimeTextBoxStrip.Text = "🕙 " + time.ToString();
            MinesTexBoxStrip.Text = "🚩 " + (minecount = count).ToString();

            playing = true;
            Timer.Start();
        }

        private void GameEnd()
        {
            playing = false;
            Timer.Stop();
        }

        private int NeighborMines(int n)
        {
            int cnt = 0;
            Point p = new Point(n % nx, n / nx);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int cy = p.Y + i;
                    int cx = p.X + j;
                    if (cy >= 0 && cy < ny && cx >= 0 && cx < nx)
                        if (mines[n + j + i * nx].Content == -1) cnt++;
                }
            }

            return cnt;
        }

        private void MineFind(bool chk)
        {
            if (chk) minecount--;
            else minecount++;
            MinesTexBoxStrip.Text = "🚩 " + minecount.ToString();
        }

        public void MouseUp_Mine(object sender, MouseEventArgs e)
        {
            if (playing == false) return;
            Button button = sender as Button;
            int n = Convert.ToInt32(button.Name);

            if (e.Button == MouseButtons.Left)
            {

                if (mines[n].Button.Text == "?" || mines[n].Button.Text == "🚩")
                {
                    return;
                }
                else if (mines[n].Button.Text == "")
                {
                    if (mines[n].Content == 0)
                    {
                        NeighborEmpty(n);
                    }
                    else if (mines[n].Content == -1)
                    {
                        GameOver(false);
                        return;
                    }
                    else
                    {
                        EmptyToCount(n);
                    }
                }
                else
                {
                    if (NeighborFlags(n) == Convert.ToInt32(mines[n].Button.Text))
                        NeighborClick(n);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (mines[n].Button.Text == "")
                {
                    mines[n].Button.Text = "🚩";
                    button.Font = new Font(button.Font.Name, 20, FontStyle.Regular);
                    MineFind(true);
                }
                else if (mines[n].Button.Text == "🚩")
                {
                    mines[n].Button.Text = "?";
                    MineFind(false);
                }
                else if (mines[n].Button.Text == "?")
                {
                    mines[n].Button.Text = "";
                    button.Font = new Font(button.Font.Name, 20, FontStyle.Bold);
                }
                else
                {
                    if (NeighborFlags(n) == Convert.ToInt32(mines[n].Button.Text))
                        NeighborClick(n);
                }
            }
            CheckWin();
        }

        private void EmptyToCount(int n)
        {
            mines[n].Button.Text = mines[n].Content.ToString();
            //mines[n].Button.BackColor = Color.FromArgb(204, 204, 204);
            switch (mines[n].Content)
            {
                case 1:
                    mines[n].Button.ForeColor = Color.FromArgb(0, 153, 255);
                    break;
                case 2:
                    mines[n].Button.ForeColor = Color.FromArgb(18, 175, 48);
                    break;
                case 3:
                    mines[n].Button.ForeColor = Color.FromArgb(255, 0, 0);
                    break;
                case 4:
                    mines[n].Button.ForeColor = Color.FromArgb(16, 32, 255);
                    break;
                case 5:
                    mines[n].Button.ForeColor = Color.FromArgb(128, 25, 0);
                    break;
                case 6:
                    mines[n].Button.ForeColor = Color.FromArgb(0, 158, 95);
                    break;
                case 7:
                    mines[n].Button.ForeColor = Color.FromArgb(197, 0, 160);
                    break;
                case 8:
                    mines[n].Button.ForeColor = Color.FromArgb(255, 137, 0);
                    break;
            }
        }

        private void CheckWin()
        {
            int cnt = 0;
            for (int i = 0; i < nx * ny; i++)
            {
                if (mines[i].Button.Enabled && (mines[i].Button.Text == "?" || mines[i].Button.Text == "🚩" || mines[i].Button.Text == "")) cnt++;
            }
            if (cnt == count)
            {
                GameOver(true);
            }
        }

        private int NeighborFlags(int n)
        {
            int cnt = 0;
            Point p = new Point(n % nx, n / nx);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int cy = p.Y + i;
                    int cx = p.X + j;
                    if (cy >= 0 && cy < ny && cx >= 0 && cx < nx)
                        if (mines[n + j + i * nx].Button.Text == "🚩") cnt++;
                }
            }

            return cnt;
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connecting) socket.Close();
        }

        private void NeighborClick(int n)
        {
            Point p = new Point(n % nx, n / nx);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int cy = p.Y + i;
                    int cx = p.X + j;
                    if (cy >= 0 && cy < ny && cx >= 0 && cx < nx)
                    {
                        if (mines[n + j + i * nx].Button.Text != "🚩" && (mines[n + j + i * nx].Button.Enabled && mines[n + j + i * nx].Button.Text == ""))
                        {
                            LeftClick(n + j + i * nx);
                        }
                    }
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
            TimeTextBoxStrip.Text = "🕙 " + time.ToString();
        }

        private void LeftClick(int n)
        {
            if (mines[n].Content == -1)
            {
                GameOver(false);
                return;
            }
            else
            {
                if (mines[n].Content == 0)
                {
                    NeighborEmpty(n);
                }
                else
                {
                    EmptyToCount(n);
                }
            }
        }

        private void GameOver(bool Win)
        {
            Color backColor;
            String msg;
            if (Win)
            {
                backColor = Color.SkyBlue;
                msg = "You Win!";
            }
            else
            {
                backColor = Color.Red;
                msg = "You Lose";
            }

            for (int i = 0; i < nx * ny; i++)
            {
                if (mines[i].Content == -1)
                {
                    mines[i].Button.BackColor = backColor;
                    mines[i].Button.Font = new Font(mines[i].Button.Font.Name, 20, FontStyle.Regular);
                    mines[i].Button.Text = "💣";
                }
            }
            GameEnd();

            if (CompetitionWith != -1)
            {
                if (Win)
                {
                    socket.Send("/EndCompetition 1 " + CompetitionWith.ToString());
                }
                else
                {
                    socket.Send("/EndCompetition 0 " + CompetitionWith.ToString());
                }
                CompetitionWith = -1;
            }
            MessageBox.Show(msg);
        }

        private void NeighborEmpty(int n)
        {
            mines[n].Button.Enabled = false;
            Point p = new Point(n % nx, n / nx);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    int cy = p.Y + i;
                    int cx = p.X + j;
                    if (cy >= 0 && cy < ny && cx >= 0 && cx < nx)
                    {
                        if (mines[n + j + i * nx].Content == 0 && mines[n + j + i * nx].Button.Enabled)
                        {
                            NeighborEmpty(n + j + i * nx);
                        }
                        else if (mines[n + j + i * nx].Content != 0)
                        {
                            EmptyToCount(n + j + i * nx);
                        }
                    }
                }
            }
        }

        private void ServerConnectMenuItem_Click(object sender, EventArgs e)
        {
            if (socket.ServerConnect())
            {
                ChangeServerConnectStatusColor(true);
                ServerConnectMenuItem.Enabled = false;
                connecting = true;
            }
            else
            {
                MessageBox.Show("서버와 연결을 실패했습니다.\n네트위크 상태를 확인해 주세요.");
            }
        }

        private void RestartMenuItem_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            MakeMineMap(nx, ny, count);
        }

        private void EasyMenuItem_Click(object sender, EventArgs e)
        {
            MakeMineMap(9, 9, 10);
        }

        private void MediumMenuItem_Click(object sender, EventArgs e)
        {
            MakeMineMap(16, 16, 40);
        }

        private void HardMenuItem_Click(object sender, EventArgs e)
        {
            MakeMineMap(30, 16, 99);
        }

        private void CustomMenuItem_Click(object sender, EventArgs e)
        {
            CustomDlg.ShowDialog();
        }

        private void HTPMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("플레이 방법은 그냥 지뢰가 없는 칸을 모두 찾아 클릭하면 된다.", "설명");
        }
    }
}
