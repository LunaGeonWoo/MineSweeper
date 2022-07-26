namespace Minesweeper
{
    partial class CustomDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Column = new System.Windows.Forms.Label();
            this.Row = new System.Windows.Forms.Label();
            this.Mine = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.ColumnTrackBar = new System.Windows.Forms.TrackBar();
            this.ColumnLabel = new System.Windows.Forms.Label();
            this.RowTrackBar = new System.Windows.Forms.TrackBar();
            this.MineTrackBar = new System.Windows.Forms.TrackBar();
            this.RowLabel = new System.Windows.Forms.Label();
            this.MineLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColumnTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Column
            // 
            this.Column.AutoSize = true;
            this.Column.Location = new System.Drawing.Point(28, 22);
            this.Column.Name = "Column";
            this.Column.Size = new System.Drawing.Size(29, 12);
            this.Column.TabIndex = 1;
            this.Column.Text = "가로";
            // 
            // Row
            // 
            this.Row.AutoSize = true;
            this.Row.Location = new System.Drawing.Point(28, 85);
            this.Row.Name = "Row";
            this.Row.Size = new System.Drawing.Size(29, 12);
            this.Row.TabIndex = 3;
            this.Row.Text = "세로";
            // 
            // Mine
            // 
            this.Mine.AutoSize = true;
            this.Mine.Location = new System.Drawing.Point(28, 148);
            this.Mine.Name = "Mine";
            this.Mine.Size = new System.Drawing.Size(29, 12);
            this.Mine.TabIndex = 5;
            this.Mine.Text = "지뢰";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(189, 232);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 6;
            this.Start.Text = "시작하기";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // ColumnTrackBar
            // 
            this.ColumnTrackBar.Location = new System.Drawing.Point(12, 37);
            this.ColumnTrackBar.Maximum = 30;
            this.ColumnTrackBar.Minimum = 9;
            this.ColumnTrackBar.Name = "ColumnTrackBar";
            this.ColumnTrackBar.Size = new System.Drawing.Size(370, 45);
            this.ColumnTrackBar.TabIndex = 7;
            this.ColumnTrackBar.Value = 9;
            this.ColumnTrackBar.Scroll += new System.EventHandler(this.ColumnTrackBar_Scroll);
            // 
            // ColumnLabel
            // 
            this.ColumnLabel.AutoSize = true;
            this.ColumnLabel.Location = new System.Drawing.Point(404, 37);
            this.ColumnLabel.Name = "ColumnLabel";
            this.ColumnLabel.Size = new System.Drawing.Size(11, 12);
            this.ColumnLabel.TabIndex = 8;
            this.ColumnLabel.Text = "9";
            // 
            // RowTrackBar
            // 
            this.RowTrackBar.Location = new System.Drawing.Point(12, 100);
            this.RowTrackBar.Maximum = 24;
            this.RowTrackBar.Minimum = 9;
            this.RowTrackBar.Name = "RowTrackBar";
            this.RowTrackBar.Size = new System.Drawing.Size(370, 45);
            this.RowTrackBar.TabIndex = 9;
            this.RowTrackBar.Value = 9;
            this.RowTrackBar.Scroll += new System.EventHandler(this.RowTrackBar_Scroll);
            // 
            // MineTrackBar
            // 
            this.MineTrackBar.Location = new System.Drawing.Point(12, 163);
            this.MineTrackBar.Maximum = 64;
            this.MineTrackBar.Minimum = 10;
            this.MineTrackBar.Name = "MineTrackBar";
            this.MineTrackBar.Size = new System.Drawing.Size(370, 45);
            this.MineTrackBar.TabIndex = 10;
            this.MineTrackBar.Value = 10;
            this.MineTrackBar.Scroll += new System.EventHandler(this.MineTrackBar_Scroll);
            // 
            // RowLabel
            // 
            this.RowLabel.AutoSize = true;
            this.RowLabel.Location = new System.Drawing.Point(404, 100);
            this.RowLabel.Name = "RowLabel";
            this.RowLabel.Size = new System.Drawing.Size(11, 12);
            this.RowLabel.TabIndex = 11;
            this.RowLabel.Text = "9";
            // 
            // MineLabel
            // 
            this.MineLabel.AutoSize = true;
            this.MineLabel.Location = new System.Drawing.Point(404, 163);
            this.MineLabel.Name = "MineLabel";
            this.MineLabel.Size = new System.Drawing.Size(17, 12);
            this.MineLabel.TabIndex = 12;
            this.MineLabel.Text = "10";
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 267);
            this.Controls.Add(this.MineLabel);
            this.Controls.Add(this.RowLabel);
            this.Controls.Add(this.MineTrackBar);
            this.Controls.Add(this.RowTrackBar);
            this.Controls.Add(this.ColumnLabel);
            this.Controls.Add(this.ColumnTrackBar);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.Mine);
            this.Controls.Add(this.Row);
            this.Controls.Add(this.Column);
            this.Name = "CustomDialog";
            this.Text = "커스텀";
            ((System.ComponentModel.ISupportInitialize)(this.ColumnTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RowTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Column;
        private System.Windows.Forms.Label Row;
        private System.Windows.Forms.Label Mine;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TrackBar ColumnTrackBar;
        private System.Windows.Forms.Label ColumnLabel;
        private System.Windows.Forms.TrackBar RowTrackBar;
        private System.Windows.Forms.TrackBar MineTrackBar;
        private System.Windows.Forms.Label RowLabel;
        private System.Windows.Forms.Label MineLabel;
    }
}