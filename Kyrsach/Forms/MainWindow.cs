using Kyrsach.Game_objects.Base;
using static Kyrsach.Game_objects.Base.BaseTank;
using Kyrsach.Game_objects;
using Kyrsach.Mechanics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

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

            tbIP1.Text = GetIPAddress();
            tbClientIP.Text = tbIP1.Text;
        }

        private void Repaint(object state)
        {
            pbGameZone.Invalidate();
        }

        private void pbGameZone_Paint(object sender, PaintEventArgs e)
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
                string[] iPs = new string[countPlayers];
                bool flag = false;

                if (countPlayers > 0)
                {
                    iPs[0] = tbIP1.Text;
                    if (iPs[0] == "")
                    {
                        flag = true;
                    }
                    if (countPlayers > 1)
                    {
                        iPs[1] = tbIP2.Text;
                        if (iPs[1] == "")
                        {
                            flag = true;
                        }
                        if (countPlayers > 2)
                        {
                            iPs[2] = tbIP3.Text;
                            if (iPs[2] == "")
                            {
                                flag = true;
                            }
                            if (countPlayers > 3)
                            {
                                iPs[3] = tbIP4.Text;
                                if (iPs[3] == "")
                                {
                                    flag = true;
                                }
                            }
                        }
                    }
                }

                if (!flag)
                {
                    this.Text = "������";
                    pServer.Visible = false;
                    this.Focus();
                    pGameInfo.Visible = true;
                    pbGameZone.Visible = true;

                    logic = new Logic(countPlayers, iPs, iPs[0], true);

                    startGame = true;
                }
            }
        }

        private void bStartGameClient_Click(object sender, EventArgs e)
        {
            if (tbClientIP.Text != "")
            {
                this.Text = "������";
                logic = new Logic(0, null, tbServerIp.Text, false);
                pClient.Visible = false;
                this.Focus();
                pGameInfo.Visible = true;
                pbGameZone.Visible = true;

                startGame = true;
            }
        }
        private static string GetIPAddress()
        {
            string ipAddress = string.Empty;

            // �������� ��� ������� ���������� ����������
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // ��������� ������ �������� ������� ����������, �� ����������� � �� ��������
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Unknown &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                {
                    // �������� IP-������ ��� ������� ����������
                    IPInterfaceProperties properties = networkInterface.GetIPProperties();
                    foreach (UnicastIPAddressInformation address in properties.UnicastAddresses)
                    {
                        // �������� IPv4-������, ���������� ��������� � ��������� ������
                        if (address.Address.AddressFamily == AddressFamily.InterNetwork &&
                            !IPAddress.IsLoopback(address.Address) &&
                            !address.Address.Equals(IPAddress.None) &&
                            !address.Address.Equals(IPAddress.Any))
                        {
                            ipAddress = address.Address.ToString();
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(ipAddress))
                    {
                        break;
                    }
                }
            }
            return ipAddress;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bServer_Click(object sender, EventArgs e)
        {
            pServer.Visible = true;
            pMainMenu.Visible = false;
        }

        private void bClient_Click(object sender, EventArgs e)
        {
            pClient.Visible = true;
            pMainMenu.Visible = false;
        }

        private void bServerBack_Click(object sender, EventArgs e)
        {
            pServer.Visible = false;
            pMainMenu.Visible = true;
        }

        private void bClientBack_Click(object sender, EventArgs e)
        {
            pClient.Visible = false;
            pMainMenu.Visible = true;
        }

        private void bGameInfoBack_Click(object sender, EventArgs e)
        {
            pGameInfo.Visible = false;
            pMainMenu.Visible = true;
            pbGameZone.Visible = false;
            logic.Close();
        }


    }
}