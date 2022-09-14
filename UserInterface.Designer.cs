namespace Ksu.Cis300.Klondike
{
    partial class UserInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.uxMenuBar = new System.Windows.Forms.ToolStrip();
            this.uxNewGame = new System.Windows.Forms.ToolStripButton();
            this.uxSeedLabel = new System.Windows.Forms.ToolStripLabel();
            this.uxSeed = new System.Windows.Forms.NumericUpDown();
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxStockFoundationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxTableauPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.uxMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSeed)).BeginInit();
            this.uxBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuBar
            // 
            this.uxMenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNewGame,
            this.uxSeedLabel});
            this.uxMenuBar.Location = new System.Drawing.Point(0, 0);
            this.uxMenuBar.Name = "uxMenuBar";
            this.uxMenuBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.uxMenuBar.Size = new System.Drawing.Size(1204, 34);
            this.uxMenuBar.TabIndex = 0;
            this.uxMenuBar.Text = "toolStrip1";
            // 
            // uxNewGame
            // 
            this.uxNewGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxNewGame.Image = ((System.Drawing.Image)(resources.GetObject("uxNewGame.Image")));
            this.uxNewGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxNewGame.Name = "uxNewGame";
            this.uxNewGame.Size = new System.Drawing.Size(102, 29);
            this.uxNewGame.Text = "New Game";
            this.uxNewGame.Click += new System.EventHandler(this.uxNewGame_Click);
            // 
            // uxSeedLabel
            // 
            this.uxSeedLabel.Name = "uxSeedLabel";
            this.uxSeedLabel.Size = new System.Drawing.Size(55, 29);
            this.uxSeedLabel.Text = "Seed:";
            // 
            // uxSeed
            // 
            this.uxSeed.Location = new System.Drawing.Point(174, 5);
            this.uxSeed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxSeed.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.uxSeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.uxSeed.Name = "uxSeed";
            this.uxSeed.Size = new System.Drawing.Size(111, 26);
            this.uxSeed.TabIndex = 1;
            this.uxSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.uxSeed.ThousandsSeparator = true;
            this.uxSeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // uxBoard
            // 
            this.uxBoard.AutoSize = true;
            this.uxBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxBoard.Controls.Add(this.uxStockFoundationPanel);
            this.uxBoard.Controls.Add(this.uxTableauPanel);
            this.uxBoard.Enabled = false;
            this.uxBoard.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.uxBoard.Location = new System.Drawing.Point(18, 60);
            this.uxBoard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(83, 174);
            this.uxBoard.TabIndex = 2;
            // 
            // uxStockFoundationPanel
            // 
            this.uxStockFoundationPanel.AutoSize = true;
            this.uxStockFoundationPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxStockFoundationPanel.Location = new System.Drawing.Point(4, 5);
            this.uxStockFoundationPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxStockFoundationPanel.MinimumSize = new System.Drawing.Size(75, 77);
            this.uxStockFoundationPanel.Name = "uxStockFoundationPanel";
            this.uxStockFoundationPanel.Size = new System.Drawing.Size(75, 77);
            this.uxStockFoundationPanel.TabIndex = 0;
            // 
            // uxTableauPanel
            // 
            this.uxTableauPanel.AutoSize = true;
            this.uxTableauPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.uxTableauPanel.Location = new System.Drawing.Point(4, 92);
            this.uxTableauPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxTableauPanel.MinimumSize = new System.Drawing.Size(75, 77);
            this.uxTableauPanel.Name = "uxTableauPanel";
            this.uxTableauPanel.Size = new System.Drawing.Size(75, 77);
            this.uxTableauPanel.TabIndex = 1;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1204, 445);
            this.Controls.Add(this.uxBoard);
            this.Controls.Add(this.uxSeed);
            this.Controls.Add(this.uxMenuBar);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Klondike";
            this.uxMenuBar.ResumeLayout(false);
            this.uxMenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSeed)).EndInit();
            this.uxBoard.ResumeLayout(false);
            this.uxBoard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip uxMenuBar;
        private System.Windows.Forms.ToolStripButton uxNewGame;
        private System.Windows.Forms.ToolStripLabel uxSeedLabel;
        private System.Windows.Forms.NumericUpDown uxSeed;
        private System.Windows.Forms.FlowLayoutPanel uxBoard;
        private System.Windows.Forms.FlowLayoutPanel uxStockFoundationPanel;
        private System.Windows.Forms.FlowLayoutPanel uxTableauPanel;
    }
}

