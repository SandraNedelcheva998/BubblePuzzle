namespace Puzzle
{
    partial class frmBubblePuzzle
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
            this.components = new System.ComponentModel.Container();
            this.gbPuzzle = new System.Windows.Forms.GroupBox();
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.tmrTimeElapsed = new System.Windows.Forms.Timer(this.components);
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblMovesDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gbPuzzle
            // 
            this.gbPuzzle.BackColor = System.Drawing.Color.Lavender;
            this.gbPuzzle.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPuzzle.Location = new System.Drawing.Point(33, 25);
            this.gbPuzzle.Name = "gbPuzzle";
            this.gbPuzzle.Size = new System.Drawing.Size(444, 444);
            this.gbPuzzle.TabIndex = 1;
            this.gbPuzzle.TabStop = false;
            this.gbPuzzle.Text = "Puzzle Image";
            // 
            // btnEasy
            // 
            this.btnEasy.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnEasy.Enabled = false;
            this.btnEasy.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEasy.Location = new System.Drawing.Point(518, 111);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(136, 30);
            this.btnEasy.TabIndex = 2;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = false;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // btnMedium
            // 
            this.btnMedium.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMedium.Enabled = false;
            this.btnMedium.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedium.Location = new System.Drawing.Point(518, 157);
            this.btnMedium.Name = "btnMedium";
            this.btnMedium.Size = new System.Drawing.Size(136, 30);
            this.btnMedium.TabIndex = 3;
            this.btnMedium.Text = "Medium";
            this.btnMedium.UseMnemonic = false;
            this.btnMedium.UseVisualStyleBackColor = false;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);
            // 
            // btnHard
            // 
            this.btnHard.BackColor = System.Drawing.Color.Fuchsia;
            this.btnHard.Enabled = false;
            this.btnHard.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHard.Location = new System.Drawing.Point(518, 206);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(136, 30);
            this.btnHard.TabIndex = 4;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = false;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // gbImage
            // 
            this.gbImage.BackColor = System.Drawing.Color.Lavender;
            this.gbImage.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbImage.Location = new System.Drawing.Point(695, 25);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(300, 300);
            this.gbImage.TabIndex = 5;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Final Image";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Lavender;
            this.lblTimer.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(711, 390);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(531, 156);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "00:00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Lavender;
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(518, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(136, 38);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "New Game";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Lavender;
            this.btnAddImage.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.Location = new System.Drawing.Point(518, 286);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(136, 38);
            this.btnAddImage.TabIndex = 0;
            this.btnAddImage.Text = "New Image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // tmrTimeElapsed
            // 
            this.tmrTimeElapsed.Enabled = true;
            this.tmrTimeElapsed.Interval = 900;
            this.tmrTimeElapsed.Tick += new System.EventHandler(this.tmrTimeElapsed_Tick);
            // 
            // lblMoves
            // 
            this.lblMoves.AutoSize = true;
            this.lblMoves.BackColor = System.Drawing.Color.Lavender;
            this.lblMoves.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoves.Location = new System.Drawing.Point(557, 389);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(134, 156);
            this.lblMoves.TabIndex = 8;
            this.lblMoves.Text = "0";
            this.lblMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMovesDisplay
            // 
            this.lblMovesDisplay.AutoSize = true;
            this.lblMovesDisplay.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovesDisplay.Location = new System.Drawing.Point(555, 368);
            this.lblMovesDisplay.Name = "lblMovesDisplay";
            this.lblMovesDisplay.Size = new System.Drawing.Size(82, 33);
            this.lblMovesDisplay.TabIndex = 9;
            this.lblMovesDisplay.Text = "Moves";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(710, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 33);
            this.label2.TabIndex = 10;
            this.label2.Text = "Game Time";
            // 
            // frmBubblePuzzle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1030, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMovesDisplay);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.gbPuzzle);
            this.Controls.Add(this.btnAddImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBubblePuzzle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bubble Puzzle";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.frmBubblePuzzle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.GroupBox gbPuzzle;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Timer tmrTimeElapsed;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblMovesDisplay;
        private System.Windows.Forms.Label label2;
    }
}

