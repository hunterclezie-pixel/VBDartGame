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

        void DrawLine(int x, int y)
        {
            Graphics g = DrawPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.FromArgb(GetNumberFrom(255), GetNumberFrom(255), GetNumberFrom(255)), 3);
            g.DrawLine(thePen, 0, 0, x, y);

            g.Dispose();
            thePen.Dispose();
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
            if (throwCount < 3)
            {
                int x = GetNumberFrom(DrawPictureBox.Width);
                int y = GetNumberFrom(DrawPictureBox.Height);
                dartPositions[throwCount] = new Point(x, y);
                DrawDart(x, y);
                throwCount++;
                ThrowLabel.Text = $"Darts: {throwCount} / 3";
            }
            else
            {
                MessageBox.Show("You have already thrown 3 darts. Start a new round.");
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
            Spirals();
            DrawLine(x, y);
            DrawDart(x, y);
        }
    }
}
