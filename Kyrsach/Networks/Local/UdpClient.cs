using Kyrsach.Game_objects;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace Kyrsach.Networks.Local
{
    internal class UdpClient
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля
        public int NumbTank { get; set; } = -1;
        public int CountTank { get; set; } = -1;


        // Методы
        public UdpClient(string serverIP, bool server)
        {
            this.serverIP = serverIP;

            Tank obj = new Tank(0, 0, Const.Direction.LEFT);
            string str = JsonSerializer.Serialize<Tank>(obj);
            bytes = new byte[128];

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            if (!server)
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_GAME));
            }
            endPoint = new IPEndPoint(IPAddress.Parse(serverIP), Const.PORT_FOR_GAME);
        }

        public async void SendDate(Tank tank)
        {
            await socket.SendToAsync(new ArraySegment<byte>(BitConverter.GetBytes(Convert.ToInt32(tank.keyDirection))), SocketFlags.None, endPoint);
        }

        public async void GetData(Tank[] tanks,int numbTank)
        {
            await socket.ReceiveFromAsync(new ArraySegment<byte>(bytes), SocketFlags.None, endPoint);
            string str = Encoding.UTF8.GetString(bytes);
            Queue<int> first = new Queue<int>();
            Queue<int> last = new Queue<int>();
            for (int i = 0; str[i] != '\0'; i++)
            {
                if (str[i] == '{')
                {
                    first.Enqueue(i);
                }
                else if (str[i] == '}')
                {
                    last.Enqueue(i);
                }
            }
            for (int i = 0; i < CountTank; i++)
            {
                if (first.Count > 0 && last.Count > 0)
                {
                    string strTank = str.Substring(first.Peek(), last.Dequeue() - first.Dequeue() + 1);
                    Tank tank = JsonSerializer.Deserialize<Tank>(strTank);
                    tank.Initialization();
                    tanks[i] = tank;
                }
            }
        }

        public void GetAuthenticationData()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_INFO));
                byte[] buff = new byte[sizeof(Int32) * 2];

                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), Const.PORT_FOR_INFO);
                socket.ReceiveFrom(buff, ref remoteEndPoint);
                CountTank = BitConverter.ToInt32(buff, 0);
                NumbTank = BitConverter.ToInt32(buff, sizeof(Int32));
            }
        }

        public void Close()
        {
            socket.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы


        // Типы


        // Поля
        private string serverIP;
        private IPEndPoint endPoint;
        private byte[] bytes;
        private Socket socket;

        // Методы
    }
}
