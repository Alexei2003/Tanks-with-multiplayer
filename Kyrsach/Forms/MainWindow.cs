using Kyrsach.Game_objects.Base;
using static Kyrsach.Game_objects.Base.BaseTank;
using Kyrsach.Game_objects;
using Kyrsach.Game_objects.List;

namespace Kyrsach
{
    public partial class MainWindow : Form
    {
        private ListTanks listTanks;

        public MainWindow()
        {
            InitializeComponent();
            listTanks = new ListTanks(4);
            listTanks[0] = new Tank(100, 200, false, Const.Direction.UP);
            listTanks[1] = new Tank(200, 200, false, Const.Direction.RIGHT);
            listTanks[2] = new Tank(300, 200, false, Const.Direction.DOWN);
            listTanks[3] = new Tank(400, 200, false, Const.Direction.LEFT);
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.White);
            listTanks[0].Paint(graphics);
            listTanks[1].Paint(graphics);
            listTanks[2].Paint(graphics);
            listTanks[3].Paint(graphics);
        }
    }
}