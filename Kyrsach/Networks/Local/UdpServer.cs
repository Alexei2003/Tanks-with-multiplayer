using Kyrsach.Game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Unicode;

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

            bytes = new byte[sizeof(Int32)];

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_GAME));
        }

        public async void SendData(Tank[] listTank)
        {
            string str = "";
            for (int i = 0; i < countTank; i++)
            {
                str += JsonSerializer.Serialize<Tank>(listTank[i]);
            }
            for (int i = 1; i < countTank; i++)
            {
                await socket.SendToAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(str)), SocketFlags.None, endPoints[i]);
            }
        }

        public async void GetDate(Tank[] listTank)
        {
            for (int i = 1; i < countTank; i++)
            {
                EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(ClientsIP[i]), Const.PORT_FOR_GAME);

                await socket.ReceiveFromAsync(new ArraySegment<byte>(bytes), SocketFlags.None, remoteEndPoint);

                listTank[i].keyDirection = (Const.Direction)BitConverter.ToInt32(bytes);
            }
        }

        public void SetIPAddres()
        {
            for (int i = 1; i < countTank; i++)
            {
                endPoints[i] = new IPEndPoint(IPAddress.Parse(ClientsIP[i]), Const.PORT_FOR_GAME);
            }
        }

        public void SendAuthenticationData()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Bind(new IPEndPoint(IPAddress.Any, Const.PORT_FOR_INFO));
                byte[] buffer = new byte[sizeof(Int32) * 2];
                for (int i = 1; i < countTank; i++)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes(countTank), 0, buffer, 0, sizeof(int));
                    Buffer.BlockCopy(BitConverter.GetBytes(i), 0, buffer, sizeof(int), sizeof(int));
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
