namespace VBDartGame
{
    partial class VBDartGame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DrawPictureBox = new PictureBox();
            StartRoundButton = new Button();
            ReviewButton = new Button();
            ExitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).BeginInit();
            SuspendLayout();
            // 
            // DrawPictureBox
            // 
            DrawPictureBox.Location = new Point(12, 12);
            DrawPictureBox.Name = "DrawPictureBox";
            DrawPictureBox.Size = new Size(460, 426);
            DrawPictureBox.TabIndex = 0;
            DrawPictureBox.TabStop = false;
            // 
            // StartRoundButton
            // 
            StartRoundButton.Location = new Point(478, 270);
            StartRoundButton.Name = "StartRoundButton";
            StartRoundButton.Size = new Size(310, 52);
            StartRoundButton.TabIndex = 1;
            StartRoundButton.Text = "Start Round";
            StartRoundButton.UseVisualStyleBackColor = true;
            // 
            // ReviewButton
            // 
            ReviewButton.Location = new Point(478, 328);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(310, 52);
            ReviewButton.TabIndex = 2;
            ReviewButton.Text = "Review Round";
            ReviewButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(478, 386);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(310, 52);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += this.ExitButton_Click;
            // 
            // VBDartGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ExitButton);
            Controls.Add(ReviewButton);
            Controls.Add(StartRoundButton);
            Controls.Add(DrawPictureBox);
            Name = "VBDartGame";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DrawPictureBox;
        private Button StartRoundButton;
        private Button ReviewButton;
        private Button ExitButton;
    }
}
