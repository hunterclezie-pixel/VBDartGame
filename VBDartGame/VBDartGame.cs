using Microsoft.VisualBasic.ApplicationServices;

namespace VBDartGame
{
    public partial class VBDartGame : Form
    {

        // Variables Below Here ------------------------------------------------------------
        Point[] dartPositions = new Point[3];
        List<string> savedRounds = new List<string>();

        int roundNumber = 0;
        int throwCount = 0;
        bool reviewMode = false;
        bool roundStarted = false;

        ToolTip tips = new ToolTip();

        // Location of the log file
        string logFile = Path.GetFullPath(Path.Combine(
            Application.StartupPath, "..", "..", "..", "DartGame.log"));

        public VBDartGame()
        {
            InitializeComponent();

            // Form setup
            this.Text = "Dart Game Simulator";
            this.KeyPreview = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            DrawPictureBox.BackColor = Color.White;
            RoundListBox.Visible = false;

            RoundLabel.Text = "Round: -";
            ThrowLabel.Text = "Darts: 0 / 3";
            ModeLabel.Text = "Mode: Play";
        }

        int GetNumberFrom(int max, int min = 0)
        {
            Random randy = new Random();
            return randy.Next(min, max + 1);
        }

        void DrawDart(int x, int y)
        {
            Graphics g = DrawPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.Black, 2);
            int size = 10;
            g.DrawEllipse(thePen, x - size / 2, y - size / 2, size, size);
            g.DrawLine(thePen, x - 10, y, x + 10, y);
            g.DrawLine(thePen, x, y - 10, x, y + 10);

            g.Dispose();
            thePen.Dispose();
        }

        void ThrowDart()
        {
            if (!roundStarted || reviewMode)
            {
                MessageBox.Show("Please start a new round before throwing darts.");
                return;
            }


            if (throwCount < 3)
            {
                int margin = 10;
                int x = GetNumberFrom(DrawPictureBox.Width - margin - 1, margin);
                int y = GetNumberFrom(DrawPictureBox.Height - margin - 1, margin);
                dartPositions[throwCount] = new Point(x, y);
                DrawDart(x, y);
                throwCount++;
                ThrowLabel.Text = $"Darts: {throwCount} / 3";
            }
            if (throwCount == 3)
            {
                MessageBox.Show("You have thrown 3 darts. Start a new round.");
                SaveRound();
            }
        }

        void LoadRounds()
        {
            savedRounds.Clear();
            RoundListBox.Items.Clear();

            try
            {
                if (File.Exists(logFile))
                {
                    File.WriteAllText(logFile, "");
                }

                string[] lines = File.ReadAllLines(logFile);
                List<int> roundNumbers = new List<int>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 7)
                    {
                        continue;
                    }

                    int[] numbers = new int[7];
                    bool valid = true;

                    for (int i = 0; i < 7; i++)
                    {
                        if (!int.TryParse(parts[i], out numbers[i]) || numbers[i] < 0)
                        {
                            valid = false;
                            break;
                        }
                    }

                    if (!valid || numbers[0] == 0 || roundNumbers.Contains(numbers[0]))
                    {
                        continue;
                    }

                    roundNumbers.Add(numbers[0]);
                    savedRounds.Add(line);
                    RoundListBox.Items.Add($"Round {numbers[0]}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rounds: " + ex.Message);
            }
        }

        void SaveRound()
        {
            if (throwCount == 3)
            {
                string roundData = $"{roundNumber}";
            }
            
            for (int i = 0; i < 3; i++)
            {
                roundData += $",{dartPositions[i].X},{dartPositions[i].Y}";
            }

            try
            {
                File.AppendAllText(logFile, roundData + Environment.NewLine);

                roundStarted = false;

                MessageBox.Show($"Round {roundNumber} saved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving round: " + ex.Message);
            }
        }

        int GetNextRound()
        {
            int lastRound = 0;
            if (!File.Exists(logFile))
            {
                File.WriteAllText(logFile, "");
            }

            string[] lines = File.ReadAllLines(logFile);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 7)
                {
                    int savedNumber;

                    if (int.TryParse(parts[0], out savedNumber))
                    {
                        if (savedNumber > lastRound)
                        {
                            lastRound = savedNumber;
                        }
                    }
                }
            }

            return lastRound + 1;
        }

        private void VBDartGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                ThrowDart();
            }
        }

        // Event handlers here ------------------------------------------------------------

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DrawPictureBox_Click(object sender, EventArgs e)
        {
            int x = GetNumberFrom(DrawPictureBox.Width);
            int y = GetNumberFrom(DrawPictureBox.Height);
            DrawDart(x, y);
        }

        private void StartRoundButton_Click(object sender, EventArgs e)
        {
            if (!roundStarted)
            {
                try
                {
                    roundNumber = GetNextRound();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while starting the round.");
                    return;
                }

                throwCount = 0;
                roundStarted = true;
                reviewMode = false;

                RoundLabel.Text = $"Round: {roundNumber}";
                ThrowLabel.Text = $"Darts: {throwCount} / 3";
                ModeLabel.Text = "Mode: Play";
            }
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            if (roundStarted)
            {
                DialogResult result = MessageBox.Show(
                    "Discard the current round?",
                    "Confirm",
                    MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            reviewMode = !reviewMode;
            roundStarted = false;
            throwCount = 0;

            RoundListBox.Visible = reviewMode;

            if (reviewMode)
            {
                ModeLabel.Text = "Mode: Review";
                ReviewButton.Text = "&Back to Play";
                LoadRounds();
            }
            else
            {
                ModeLabel.Text = "Mode: Play";
                ReviewButton.Text = "&Review Rounds";
            }

            RoundLabel.Text = "Round: -";
            ThrowLabel.Text = "Darts: 0 / 3";
        }
    }
}
