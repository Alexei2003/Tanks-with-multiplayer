using Kyrsach.Game_objects.Base;
using static Kyrsach.Game_objects.Base.BaseTank;
using Kyrsach.Game_objects;
using Kyrsach.Mechanics;
using System.Drawing;
using System.Net.NetworkInformation;

namespace Kyrsach
{
    public partial class MainWindow : Form
    {
        private Logic logic;
        private System.Threading.Timer timer;
        private TimeSpan FRAME_TIME = TimeSpan.FromMilliseconds(1000 / 60);
        private const int MAX_COUNT_PLAYERS = 4;
        private TextBox[] numbPlayer = new TextBox[MAX_COUNT_PLAYERS];
        private TextBox[] numbPlayerIP = new TextBox[MAX_COUNT_PLAYERS];
        private int countPlayers = 0;

        private bool startGame;
        public MainWindow()
        {
            InitializeComponent();
            TimerCallback timerCallback = new TimerCallback(Repaint);
            timer = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, FRAME_TIME);

            numbPlayer[0] = tbPlayer1;
            numbPlayer[1] = tbPlayer2;
            numbPlayer[2] = tbPlayer3;
            numbPlayer[3] = tbPlayer4;

            numbPlayerIP[0] = tbIP1;
            numbPlayerIP[1] = tbIP2;
            numbPlayerIP[2] = tbIP3;
            numbPlayerIP[3] = tbIP4;

            startGame = false;

            cbCountPlayers.SelectedIndex = 0;
        }

        private void Repaint(object state)
        {
            Invalidate();
        }

        private async void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            if (startGame)
            {
                logic.Paint(e.Graphics);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            logic.KeyDown(e);
        }

        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            logic.KeyUp(e);
        }

        private void cbCountPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < MAX_COUNT_PLAYERS; i++)
            {
                numbPlayer[i].Visible = false;
                numbPlayerIP[i].Visible = false;
            }
            countPlayers = cbCountPlayers.SelectedIndex + 1;
            for (int i = 0; i < countPlayers; i++)
            {
                numbPlayer[i].Visible = true;
                numbPlayerIP[i].Visible = true;
            }
        }

        private void bStartGame_Click(object sender, EventArgs e)
        {
            if (countPlayers != 0)
            {
                this.Text = "Сервер";
                pClient.Visible = false;
                pServer.Visible = false;
                this.Focus();
                this.Size = new Size(950, 950);

                string[] iPs = new string[countPlayers];

                if (countPlayers > 0)
                {
                    iPs[0] = tbIP1.Text;
                    if (countPlayers > 1)
                    {
                        iPs[1] = tbIP2.Text;
                        if (countPlayers > 2)
                        {
                            iPs[2] = tbIP3.Text;
                            if (countPlayers > 3)
                            {
                                iPs[3] = tbIP4.Text;
                            }
                        }
                    }
                }

                logic = new Logic(countPlayers, iPs, iPs[0],true);

                startGame = true;
            }
        }

        private void bStartGameClient_Click(object sender, EventArgs e)
        {
            this.Text = "Клиент";
            pClient.Visible = false;
            pServer.Visible = false;
            this.Focus();
            this.Size = new Size(950, 950);

            logic = new Logic(0, null, tbServerIp.Text,false);

            startGame = true;
        }
    }
}