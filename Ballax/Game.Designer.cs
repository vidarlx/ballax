namespace Ballax
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.pBoardArea = new System.Windows.Forms.Panel();
            this.lbScoreText = new System.Windows.Forms.Label();
            this.lbScore = new System.Windows.Forms.Label();
            this.lbNextBallsText = new System.Windows.Forms.Label();
            this.panelBuffer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pBoardArea
            // 
            this.pBoardArea.Location = new System.Drawing.Point(183, 19);
            this.pBoardArea.Name = "pBoardArea";
            this.pBoardArea.Size = new System.Drawing.Size(416, 413);
            this.pBoardArea.TabIndex = 0;
            // 
            // lbScoreText
            // 
            this.lbScoreText.AutoSize = true;
            this.lbScoreText.Location = new System.Drawing.Point(12, 19);
            this.lbScoreText.Name = "lbScoreText";
            this.lbScoreText.Size = new System.Drawing.Size(35, 13);
            this.lbScoreText.TabIndex = 1;
            this.lbScoreText.Text = "Score";
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbScore.Location = new System.Drawing.Point(12, 43);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(35, 37);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "0";
            // 
            // lbNextBallsText
            // 
            this.lbNextBallsText.AutoSize = true;
            this.lbNextBallsText.Location = new System.Drawing.Point(12, 119);
            this.lbNextBallsText.Name = "lbNextBallsText";
            this.lbNextBallsText.Size = new System.Drawing.Size(53, 13);
            this.lbNextBallsText.TabIndex = 3;
            this.lbNextBallsText.Text = "Next balls";
            // 
            // panelBuffer
            // 
            this.panelBuffer.Location = new System.Drawing.Point(12, 155);
            this.panelBuffer.Name = "panelBuffer";
            this.panelBuffer.Size = new System.Drawing.Size(154, 53);
            this.panelBuffer.TabIndex = 7;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 444);
            this.Controls.Add(this.panelBuffer);
            this.Controls.Add(this.lbNextBallsText);
            this.Controls.Add(this.lbScore);
            this.Controls.Add(this.lbScoreText);
            this.Controls.Add(this.pBoardArea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Game";
            this.Text = "Ballax";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pBoardArea;
        private System.Windows.Forms.Label lbScoreText;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbNextBallsText;
        private System.Windows.Forms.Panel panelBuffer;
    }
}

