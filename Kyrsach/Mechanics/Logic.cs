using Kyrsach.Game_objects;
using Kyrsach.Networks.Local;
using System.Net.Http.Headers;

namespace Kyrsach.Mechanics
{
    internal class Logic
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля

        // Методы
        public Logic(int countTank, string[] iPs, string serverIp, bool server)
        {
            this.server = server;
            TimerCallback timerCallback;
            if (!server)
            {
                udpClient = new UdpClient(serverIp,false);
                udpClient.GetAuthenticationData();
                numbTank = udpClient.NumbTank;
                countTank = udpClient.CountTank;
            }

            this.countTank = countTank;

            listTanks = new Tank[countTank];
            if(countTank > 0)
            {
                listTanks[0] = new Tank(300, 150, Const.Direction.UP);
                if (countTank > 1)
                {
                    listTanks[1] = new Tank(300, 300, Const.Direction.UP);
                    if (countTank > 2)
                    {
                        listTanks[2] = new Tank(300, 400, Const.Direction.UP);
                        if (countTank > 3)
                        {
                            listTanks[3] = new Tank(300, 500, Const.Direction.UP);
                        }
                    }
                }
            }

            listWalls = new List<Wall>();
            listWalls.Add(new Wall(15, 15, 30, Const.Direction.RIGHT));
            listWalls.Add(new Wall(15, 45, 28, Const.Direction.DOWN));
            listWalls.Add(new Wall(15, 15 + Const.SIZE_CELL * 29, 30, Const.Direction.RIGHT));
            listWalls.Add(new Wall(15 + Const.SIZE_CELL * 29, 45, 28, Const.Direction.DOWN));

            listWalls.Add(new Wall(363, 45, 10, Const.Direction.DOWN));

            listShells = new List<Shell>();           

            if (server)
            {
                udpServer = new UdpServer(countTank);
                numbTank = 0;
                udpServer.ClientsIP = iPs;
                udpServer.SetIPAddres();
                udpServer.SendAuthenticationData();


                timerCallback = new TimerCallback(ThreadNetworkServer);
                timerNetwork = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, LOGIC_TIME);

                timerCallback = new TimerCallback(ThreadLogic);
                timerLogic = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, LOGIC_TIME);
            }

            if (!server)
            {
                timerCallback = new TimerCallback(ThreadNetworkClient);
                timerNetwork = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, LOGIC_TIME);
            }
            timerCallback = new TimerCallback(ThreadMessage);
            timerMessage = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, MESSAGE_TIME);
        }

        public void Close()
        {
            if (server)
            {
                udpServer.Close();
            }
            else
            {
                udpClient.Close();
            }
        }

        public void Paint(Graphics graphics)
        {
            graphics.Clear(Color.White);

            foreach (Tank tank in listTanks)
            {

                if (tank.HP < 1)
                {
                    continue;
                }
                tank.Paint(graphics);
            }

            foreach (Wall wall in listWalls)
            {
                wall.Paint(graphics);
            }

            lock (lockShell)
            {
                foreach (Shell shell in listShells)
                {
                    shell.Paint(graphics);
                }
            }
            
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    listTanks[numbTank].keyDirection = Const.Direction.UP;
                    break;
                case Keys.D:
                    listTanks[numbTank].keyDirection = Const.Direction.RIGHT;
                    break;
                case Keys.S:
                    listTanks[numbTank].keyDirection = Const.Direction.DOWN;
                    break;
                case Keys.A:
                    listTanks[numbTank].keyDirection = Const.Direction.LEFT;
                    break;
                case Keys.Space:
                    listTanks[numbTank].keyDirection = Const.Direction.SPACE;
                    break;
            }
        }

        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.W:
                case Keys.D:
                case Keys.S:
                case Keys.A:
                case Keys.Space:
                    listTanks[numbTank].keyDirection = Const.Direction.DEFAULT;
                    break;
            }
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private TimeSpan LOGIC_TIME = TimeSpan.FromMilliseconds(50);
        private TimeSpan MESSAGE_TIME = TimeSpan.FromMilliseconds(100);

        // Типы


        // Поля
        private List<Wall> listWalls;
        private Tank[] listTanks;
        private List<Shell> listShells;
        private int numbTank;
        private System.Threading.Timer timerLogic;
        private System.Threading.Timer timerMessage;
        private System.Threading.Timer timerNetwork;
        private UdpClient udpClient;
        private UdpServer udpServer;
        private bool message = false;
        private int countTank;
        private bool server;

        private object lockShell = new object();


        // Методы
        private bool CheckCollision(int x1, int y1, int x2, int y2, Const.Direction direction, int X1, int Y1, int X2, int Y2)
        {
            int up = 0;
            int right = 0;
            int down = 0;
            int left = 0;

            switch (direction)
            {
                case Const.Direction.UP:
                    up = Tank.SIZE_MOVE;
                    break;
                case Const.Direction.RIGHT:
                    right = Tank.SIZE_MOVE;
                    break;
                case Const.Direction.DOWN:
                    down = Tank.SIZE_MOVE;
                    break;
                case Const.Direction.LEFT:
                    left = Tank.SIZE_MOVE;
                    break;
            }
            if (x2 + right >= X1 && x1 - left <= X2)
            {
                if (y2 + down >= Y1 && y1 - up <= Y2)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckTankCollision(Tank selectTank, Const.Direction direction)
        {
            bool move = true;

            // Проверка на столкновение с преградами (стенами)
            foreach (Wall wall in listWalls)
            {
                if (CheckCollision(selectTank.X1, selectTank.Y1, selectTank.X2, selectTank.Y2, direction, wall.X1, wall.Y1, wall.X2, wall.Y2))
                {
                    // Если произошло столкновение, остановить движение
                    move = false;
                    break;
                }
            }

            // Проверка на столкновение с другими танками
            foreach (Tank tank in listTanks)
            {
                if (tank != selectTank && CheckCollision(selectTank.X1, selectTank.Y1, selectTank.X2, selectTank.Y2, direction, tank.X1, tank.Y1, tank.X2, tank.Y2))
                {
                    // Если произошло столкновение, остановить движение
                    move = false;
                    break;
                }
            }

            // Если нет столкновений, переместить танк
            if (move)
            {
                selectTank.Move(direction);
            }
        }


        private void ThreadLogic(object state)
        {
            MoveShells();
            ControlTanks();
        }
        private void ThreadNetworkServer(object state)
        {
            udpServer.GetDate(listTanks);
            udpServer.SendData(listTanks,listShells);
        }

        private void ThreadNetworkClient(object state)
        {
            udpClient.SendDate(listTanks[numbTank]);
            udpClient.GetData(listTanks,numbTank,listShells,lockShell);
        }

        private void ThreadMessage(object state)
        {
            int countDied = 0;

            foreach(Tank tank in listTanks)
            {
                if (tank.HP < 1)
                {
                    countDied++;
                }
            }

            if (listTanks[numbTank].HP < 1 && !message)
            {
                message = true;
                MessageBox.Show("Вы проиграли", "Помёр", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                timerMessage.Dispose();
            }
            else
            {
                if (countDied == countTank - 1 && !message)
                {
                    message = true;
                    MessageBox.Show("Вы выиграли", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    timerMessage.Dispose();
                }
            }
        }

        private void MoveShells()
        {

            Stack<Shell> shellRemove = new Stack<Shell>();
            foreach (Shell shell in listShells)
            {
                shell.Move();
                switch (shell.Direction)
                {
                    case Const.Direction.UP:
                        foreach (Tank tank in listTanks)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.UP, tank.X1, tank.Y1, tank.X2, tank.Y2))
                            {
                                tank.HP -= shell.Damage;
                                shellRemove.Push(shell);
                                break;
                            }
                        }

                        foreach (Wall wall in listWalls)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.UP, wall.X1, wall.Y1, wall.X2, wall.Y2))
                            {
                                shellRemove.Push(shell);
                                break;
                            }
                        }
                        break;
                    case Const.Direction.RIGHT:
                        foreach (Tank tank in listTanks)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.RIGHT, tank.X1, tank.Y1, tank.X2, tank.Y2))
                            {
                                tank.HP -= shell.Damage;
                                shellRemove.Push(shell);
                                break;
                            }
                        }

                        foreach (Wall wall in listWalls)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.RIGHT, wall.X1, wall.Y1, wall.X2, wall.Y2))
                            {
                                shellRemove.Push(shell);
                                break;
                            }
                        }
                        break;
                    case Const.Direction.DOWN:
                        foreach (Tank tank in listTanks)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.DOWN, tank.X1, tank.Y1, tank.X2, tank.Y2))
                            {
                                tank.HP -= shell.Damage;
                                shellRemove.Push(shell);
                                break;
                            }
                        }

                        foreach (Wall wall in listWalls)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.DOWN, wall.X1, wall.Y1, wall.X2, wall.Y2))
                            {
                                shellRemove.Push(shell);
                                break;
                            }
                        }
                        break;
                    case Const.Direction.LEFT:
                        foreach (Tank tank in listTanks)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.LEFT, tank.X1, tank.Y1, tank.X2, tank.Y2))
                            {
                                tank.HP -= shell.Damage;
                                shellRemove.Push(shell);
                                break;
                            }
                        }

                        foreach (Wall wall in listWalls)
                        {
                            if (CheckCollision(shell.X1, shell.Y1, shell.X2, shell.Y2, Const.Direction.LEFT, wall.X1, wall.Y1, wall.X2, wall.Y2))
                            {
                                shellRemove.Push(shell);
                                break;
                            }
                        }
                        break;
                }
            }

            lock (lockShell)
            {
                foreach (Shell shell in shellRemove)
                {
                    listShells.Remove(shell);
                }
            }

        }

        private void ControlTanks()
        {
            foreach (var tank in listTanks)
            {
                if (tank.HP < 1)
                {
                    tank.X = -100;
                    tank.Y = -100;
                    continue;
                }
                switch (tank.keyDirection)
                {
                    case Const.Direction.UP:
                        CheckTankCollision(tank, Const.Direction.UP);
                        break;
                    case Const.Direction.RIGHT:
                        CheckTankCollision(tank, Const.Direction.RIGHT);
                        break;
                    case Const.Direction.DOWN:
                        CheckTankCollision(tank, Const.Direction.DOWN);
                        break;
                    case Const.Direction.LEFT:
                        CheckTankCollision(tank, Const.Direction.LEFT);
                        break;
                    case Const.Direction.SPACE:
                        if (tank.RemainingTimeReload == 0)
                        {
                            listShells.Add(tank.Shoot());
                            tank.StartTankReload();
                        }
                        break;
                }

                tank.TankReload();
            }
        }
    }
}
