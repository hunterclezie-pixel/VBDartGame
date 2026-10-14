namespace VBDartGame
{
    public partial class VBDartGame : Form
    {

        // Variables Below Here ------------------------------------------------------------
        Random randy = new Random();
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

        void Spirals()
        {
            Graphics g = DrawPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.FromArgb(GetNumberFrom(255), GetNumberFrom(255), GetNumberFrom(255)), 3);

            double x, y, oldX = 0, oldY = 0;

            for (int i = 0; i < 360; i++)
            {
                x = 100 * Math.Cos(45 * (Math.PI / 180));
                y = 100 * Math.Sin(45 * (Math.PI / 180));
                g.DrawLine(thePen, (int)oldX, (int)oldY, (int)x, (int)y);
                oldX = x;
                oldY = y;

            }
            g.Dispose();
            thePen.Dispose();
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
            Pen thePen = new Pen(Color.Black, 3);
            int size = 3;
            g.DrawEllipse(thePen, x - size / 2, y - size / 2, size, size);
            g.DrawLine(thePen, x - 10, y, x + 10, y);
            g.DrawLine(thePen, x, y - 10, x, y + 10);

            g.Dispose();
            thePen.Dispose();
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
