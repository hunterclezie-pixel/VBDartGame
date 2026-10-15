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
            components = new System.ComponentModel.Container();
            DrawPictureBox = new PictureBox();
            StartRoundButton = new Button();
            ReviewButton = new Button();
            ExitButton = new Button();
            RoundListBox = new ListBox();
            RoundLabel = new Label();
            ThrowLabel = new Label();
            ModeLabel = new Label();
            DisplayGroupBox = new GroupBox();
            ToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).BeginInit();
            DisplayGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // DrawPictureBox
            // 
            DrawPictureBox.Location = new Point(12, 12);
            DrawPictureBox.Name = "DrawPictureBox";
            DrawPictureBox.Size = new Size(460, 426);
            DrawPictureBox.TabIndex = 0;
            DrawPictureBox.TabStop = false;
            ToolTip.SetToolTip(DrawPictureBox, "Press the Spacebar to throw a dart");
            // 
            // StartRoundButton
            // 
            StartRoundButton.Location = new Point(478, 270);
            StartRoundButton.Name = "StartRoundButton";
            StartRoundButton.Size = new Size(310, 52);
            StartRoundButton.TabIndex = 1;
            StartRoundButton.Tag = "Start a new round of three darts";
            StartRoundButton.Text = "Start Round";
            StartRoundButton.UseVisualStyleBackColor = true;
            StartRoundButton.Click += StartRoundButton_Click;
            // 
            // ReviewButton
            // 
            ReviewButton.Location = new Point(478, 328);
            ReviewButton.Name = "ReviewButton";
            ReviewButton.Size = new Size(310, 52);
            ReviewButton.TabIndex = 2;
            ReviewButton.Text = "Review Round";
            ToolTip.SetToolTip(ReviewButton, "Switch between Play mode and Review mode");
            ReviewButton.UseVisualStyleBackColor = true;
            ReviewButton.Click += ReviewButton_Click;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(478, 386);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(310, 52);
            ExitButton.TabIndex = 3;
            ExitButton.Text = "Exit";
            ToolTip.SetToolTip(ExitButton, "Quit the game");
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // RoundListBox
            // 
            RoundListBox.FormattingEnabled = true;
            RoundListBox.Location = new Point(478, 12);
            RoundListBox.Name = "RoundListBox";
            RoundListBox.Size = new Size(310, 104);
            RoundListBox.TabIndex = 4;
            ToolTip.SetToolTip(RoundListBox, "Select a past round to see its darts");
            // 
            // RoundLabel
            // 
            RoundLabel.AutoSize = true;
            RoundLabel.Location = new Point(6, 23);
            RoundLabel.Name = "RoundLabel";
            RoundLabel.Size = new Size(92, 20);
            RoundLabel.TabIndex = 5;
            RoundLabel.Text = "Round Label";
            // 
            // ThrowLabel
            // 
            ThrowLabel.AutoSize = true;
            ThrowLabel.Location = new Point(6, 60);
            ThrowLabel.Name = "ThrowLabel";
            ThrowLabel.Size = new Size(90, 20);
            ThrowLabel.TabIndex = 6;
            ThrowLabel.Text = "Throw Label";
            // 
            // ModeLabel
            // 
            ModeLabel.AutoSize = true;
            ModeLabel.Location = new Point(6, 93);
            ModeLabel.Name = "ModeLabel";
            ModeLabel.Size = new Size(88, 20);
            ModeLabel.TabIndex = 7;
            ModeLabel.Text = "Mode Label";
            // 
            // DisplayGroupBox
            // 
            DisplayGroupBox.Controls.Add(ThrowLabel);
            DisplayGroupBox.Controls.Add(ModeLabel);
            DisplayGroupBox.Controls.Add(RoundLabel);
            DisplayGroupBox.Location = new Point(478, 122);
            DisplayGroupBox.Name = "DisplayGroupBox";
            DisplayGroupBox.Size = new Size(310, 142);
            DisplayGroupBox.TabIndex = 8;
            DisplayGroupBox.TabStop = false;
            // 
            // VBDartGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DisplayGroupBox);
            Controls.Add(RoundListBox);
            Controls.Add(ExitButton);
            Controls.Add(ReviewButton);
            Controls.Add(StartRoundButton);
            Controls.Add(DrawPictureBox);
            Name = "VBDartGame";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DrawPictureBox).EndInit();
            DisplayGroupBox.ResumeLayout(false);
            DisplayGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox DrawPictureBox;
        private Button StartRoundButton;
        private Button ReviewButton;
        private Button ExitButton;
        private ListBox RoundListBox;
        private Label RoundLabel;
        private Label ThrowLabel;
        private Label ModeLabel;
        private GroupBox DisplayGroupBox;
        private ToolTip ToolTip;
    }
}
