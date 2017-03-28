using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidTest
{
    public partial class AsteroidsForm : Form
    {
        public static int WIDTH = 15;
        public static int HEIGHT = 25;
        public static int SCALE = 30;

        private Timer timer;

        public Graphics mainGraphics;
        public BufferedGraphicsContext mainContext;
        public BufferedGraphics mainBuffer;

        private Ship mainShip;

        private Point moveUp;
        private Point moveDown;
        private Point moveLeft;
        private Point moveRight;

        public AsteroidsForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(WIDTH * SCALE + 100, HEIGHT * SCALE);
            pbMain.ClientSize = new Size(WIDTH * SCALE, HEIGHT * SCALE);
            pbMain.BackColor = Color.LightGray;

            mainGraphics = pbMain.CreateGraphics();
            mainContext = new BufferedGraphicsContext();
            mainBuffer = mainContext.Allocate(mainGraphics, new Rectangle(0, 0, pbMain.Width, pbMain.Height));

            timer = new Timer();

            moveUp = new Point(0, -5);
            moveDown = new Point(0, 5);
            moveLeft = new Point(-1, 0);
            moveRight = new Point(1, 0);
        }

        public void RepaintForm(BufferedGraphics mainBuffer)
        {
            mainBuffer.Graphics.Clear(Color.LightGray);

            mainShip.PaintShip(mainBuffer);
            mainBuffer.Render();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            RepaintForm(mainBuffer);
        }


        private void AsteroidsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                mainShip = new Ship(10, 10);
                timer.Interval = 16;
                timer.Tick += Timer_Tick;

                timer.Enabled = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                mainShip.Move(moveUp);
            }

            if (e.KeyCode == Keys.Down)
            {
                mainShip.Move(moveDown);
            }

            if (e.KeyCode == Keys.Left)
            {
                mainShip.Ratate(Direction.Left);
            }

            if (e.KeyCode == Keys.Right)
            {
                mainShip.Ratate(Direction.Right);
            }
        }
    }
}
