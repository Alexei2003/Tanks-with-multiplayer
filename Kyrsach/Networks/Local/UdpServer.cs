using Kyrsach.Game_objects;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Kyrsach.Networks.Local
{
    internal class UdpServer
    {
        // Интерфейс
        // Константы

        // Типы

        // Поля
        public string[] ClientsIP { get; set; }

        // Методы
        public UdpServer(int countTank)
        {
            ClientsIP = new string[countTank];
            endPoints = new IPEndPoint[countTank];
            this.countTank = countTank;

            // Создание буфера для получения данных
            bytes = new byte[sizeof(Int32)];

            // Создание UDP сокета
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Привязка сокета к локальному адресу и порту
            socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_GAME));
        }

        public async void SendData(Tank[] listTank, List<Shell> listShell)
        {
            // Создание пустой строки для сериализации данных
            string str = "";

            // Сериализация данных о танках
            for (int i = 0; i < countTank; i++)
            {
                str += JsonSerializer.Serialize<Tank>(listTank[i]);
            }

            // Сериализация данных о снарядах
            for (int i = 0; i < listShell.Count; i++)
            {
                str += JsonSerializer.Serialize<Shell>(listShell[i]);
            }

            // Отправка данных каждому клиенту, начиная с индекса 1
            for (int i = 1; i < countTank; i++)
            {
                // Преобразование строки в массив байтов и отправка данных по UDP
                await socket.SendToAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(str)), SocketFlags.None, endPoints[i]);
            }
        }


        public async void GetDate(Tank[] listTank)
        {
            // Получение данных от каждого клиента, начиная с индекса 1
            for (int i = 1; i < countTank; i++)
            {
                // Создание объекта EndPoint для получения данных от конкретного клиента
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ClientsIP[i]), Const.PORT_FOR_GAME);

                // Асинхронное получение данных по UDP
                await socket.ReceiveFromAsync(new ArraySegment<byte>(bytes), SocketFlags.None, remoteEndPoint);

                // Преобразование полученных данных в направление движения и сохранение в объекте танка
                listTank[i].keyDirection = (Const.Direction)BitConverter.ToInt32(bytes);
            }
        }


        public void SetIPAddres()
        {
            // Установка IP-адресов для каждого клиента, начиная с индекса 1
            for (int i = 1; i < countTank; i++)
            {
                // Создание объекта IPEndPoint с использованием IP-адреса клиента и порта
                endPoints[i] = new IPEndPoint(IPAddress.Parse(ClientsIP[i]), Const.PORT_FOR_GAME);
            }
        }


        public void SendAuthenticationData()
        {
            // Создание нового сокета для отправки данных
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                // Привязка сокета к адресу и порту
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_INFO));

                // Создание буфера для данных
                byte[] buffer = new byte[sizeof(Int32) * 2];

                // Отправка аутентификационных данных каждому клиенту
                for (int i = 1; i < countTank; i++)
                {
                    // Запись количества танков и идентификатора клиента в буфер
                    Buffer.BlockCopy(BitConverter.GetBytes(countTank), 0, buffer, 0, sizeof(int));
                    Buffer.BlockCopy(BitConverter.GetBytes(i), 0, buffer, sizeof(int), sizeof(int));

                    // Отправка буфера по указанному IP-адресу и порту
                    socket.SendTo(buffer, new IPEndPoint(IPAddress.Parse(ClientsIP[i]), Const.PORT_FOR_INFO));
                }
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
        private IPEndPoint[] endPoints;
        private int countTank;
        private byte[] bytes;
        private Socket socket;

        // Методы
    }
}
