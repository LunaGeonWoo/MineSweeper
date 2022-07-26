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
    public partial class CustomDialog : Form
    {
        private int column, row, mine;

        private void ColumnTrackBar_Scroll(object sender, EventArgs e)
        {
            column = ColumnTrackBar.Value;
            ColumnLabel.Text = column.ToString();
            MineTrackBarMaximun_Change();
        }

        private void RowTrackBar_Scroll(object sender, EventArgs e)
        {
            row = RowTrackBar.Value;
            RowLabel.Text = row.ToString();
            MineTrackBarMaximun_Change();
        }

        private void MineTrackBarMaximun_Change()
        {
            if (MineTrackBar.Value > (ColumnTrackBar.Value - 1) * (RowTrackBar.Value - 1))
            {
                MineTrackBar.Value = (ColumnTrackBar.Value - 1) * (RowTrackBar.Value - 1);
                mine = MineTrackBar.Value;
                MineLabel.Text = mine.ToString();
            }
            MineTrackBar.Maximum = (ColumnTrackBar.Value - 1) * (RowTrackBar.Value - 1);
        }

        private void MineTrackBar_Scroll(object sender, EventArgs e)
        {
            mine = MineTrackBar.Value;
            MineLabel.Text = mine.ToString();
        }

        public CustomDialog()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            MainApp cf = Application.OpenForms["MainApp"] as MainApp;
            if (cf == null) return;
            cf.sendtomainThreadMakeMap(column, row, mine);
        }
    }
}
