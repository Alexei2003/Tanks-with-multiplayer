using Kyrsach.Game_objects.Base;
using static Kyrsach.Game_objects.Base.BaseTank;
using Kyrsach.Game_objects;
using Kyrsach.Mechanics;

namespace Kyrsach
{
    public partial class MainWindow : Form
    {
        Logic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new Logic(4);
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            logic.Paint(graphics);
            this.Invalidate();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            logic.KeyDown(e);
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            logic.KeyUp(e);
        }
    }
}