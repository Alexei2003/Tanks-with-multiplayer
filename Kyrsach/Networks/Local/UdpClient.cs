using Kyrsach.Game_objects;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

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

            // Создание UDP сокета
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Привязка сокета к локальному IP-адресу и порту игры, если текущий экземпляр - клиент
            if (!server)
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_GAME));
            }

            // Создание конечной точки с указанным IP-адресом сервера и портом игры
            endPoint = new IPEndPoint(IPAddress.Parse(serverIP), Const.PORT_FOR_GAME);
        }

        public async void SendDate(Tank tank)
        {
            await socket.SendToAsync(new ArraySegment<byte>(BitConverter.GetBytes(Convert.ToInt32(tank.keyDirection))), SocketFlags.None, endPoint);
        }

        // Получение данных по UDP
        public async void GetData(Tank[] tanks, int numbTank, List<Shell> shells, object lockShell)
        {
            bytes = new byte[1024];
            await socket.ReceiveFromAsync(new ArraySegment<byte>(bytes), SocketFlags.None, endPoint);
            string str = Encoding.UTF8.GetString(bytes);

            // Разделение данных
            Queue<int> first = new Queue<int>();
            Queue<int> last = new Queue<int>();
            int i;
            for (i = 0; str[i] != '\0'; i++)
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

            // Обработка данных танков
            for (i = 0; i < CountTank; i++)
            {
                if (first.Count > 0 && last.Count > 0)
                {
                    string strTank = str.Substring(first.Peek(), last.Dequeue() - first.Dequeue() + 1);
                    Tank tank = JsonSerializer.Deserialize<Tank>(strTank);
                    tank.Initialization();
                    tanks[i] = tank;
                }
            }

            // Обработка данных снарядов
            lock (lockShell)
            {
                shells.Clear();
                while (first.Count > 0 && last.Count > 0)
                {
                    if (last.Peek() < first.Peek())
                    {
                        last.Dequeue();
                        continue;
                    }
                    string strShell = str.Substring(first.Peek(), last.Dequeue() - first.Dequeue() + 1);
                    Shell shell = JsonSerializer.Deserialize<Shell>(strShell);
                    shell.Initialization();
                    shells.Add(shell);
                }
            }
        }


        // Получение аутентификационных данных
        public void GetAuthenticationData()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_INFO));
                byte[] buff = new byte[sizeof(Int32) * 2];

                // Получение данных от удаленного хоста
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), Const.PORT_FOR_INFO);
                socket.ReceiveFrom(buff, ref remoteEndPoint);

                // Извлечение количества танков и номера танка из полученных данных
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
