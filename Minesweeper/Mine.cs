using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    internal class Mine
    {
        private Button button;
        private int content;
        private int num;

        public Mine()
        {
            button = new Button();
            button.Name = "Mine";
            button.Text = "";
            button.AutoSize = false;
            button.Size = new Size(40, 40);
            button.BackColor = Color.FromArgb(255, 255, 255);
            button.UseVisualStyleBackColor = true;
            button.Font = new Font(button.Font.Name, 20, FontStyle.Bold); 
            content = 0;
        }

        public void Clear()
        {
            button = null;
            content = 0;
            num = 0;
        }

        public int Content
        {
            get { return content; }
            set { content = value; }
        }

        public Button Button
        {
            get { return button; }
            set { button = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; button.Name = num.ToString(); }
        }
    }
}
