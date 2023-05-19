using Kyrsach.Game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
using System.ComponentModel;

namespace Kyrsach.Mechanics
{
    internal class Logic
    {
        // Интерфейс
        // Константы
        

        // Типы


        // Поля

        // Методы
        public Logic(int CountTank)
        {
            listTanks = new Tank[CountTank];
            listTanks[0] = new Tank(300, 150, false, Const.Direction.UP);
            listTanks[1] = new Tank(300, 300, false, Const.Direction.UP);
            listTanks[2] = new Tank(300, 400, false, Const.Direction.UP);
            listTanks[3] = new Tank(300, 500, false, Const.Direction.UP);
            

            listWalls = new List<Wall>();   
            listWalls.Add(new Wall(15, 15, 30, Const.Direction.RIGHT));
            listWalls.Add(new Wall(15, 45, 28, Const.Direction.DOWN));
            listWalls.Add(new Wall(15, 15 + Const.SIZE_CELL*29, 30, Const.Direction.RIGHT));
            listWalls.Add(new Wall(15 + Const.SIZE_CELL * 29, 45, 28, Const.Direction.DOWN));

            listWalls.Add(new Wall(363, 45, 10, Const.Direction.DOWN));

            listShells = new List<Shell>();

            TimerCallback timerCallback = new TimerCallback(Logic_Thread);
            System.Threading.Timer timer = new System.Threading.Timer(timerCallback, null, TimeSpan.Zero, LOGIC_TIME);
            //timer.Dispose();
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

            foreach(Wall wall in listWalls) 
            {
                wall.Paint(graphics);
            }

            foreach(Shell shell in listShells)
            {
                shell.Paint(graphics);
            }
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    listTanks[indexTank].keyDirection = Const.Direction.UP;
                    break;
                case Keys.D:
                    listTanks[indexTank].keyDirection= Const.Direction.RIGHT;
                    break;
                case Keys.S:
                    listTanks[indexTank].keyDirection = Const.Direction.DOWN;
                    break;
                case Keys.A:
                    listTanks[indexTank].keyDirection = Const.Direction.LEFT;
                    break;
                case Keys.Space:
                    listTanks[indexTank].keyDirection = Const.Direction.SPACE;
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
                    listTanks[indexTank].keyDirection = Const.Direction.DEFAULT;
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private TimeSpan LOGIC_TIME = TimeSpan.FromMilliseconds(50);

        // Типы


        // Поля
        private List<Wall> listWalls;
        private Tank[] listTanks;
        private List<Shell> listShells;
        private int indexTank = 0;

        // Методы
        private bool CheckCollision(int x1, int y1, int x2, int y2,Const.Direction direction, int X1, int Y1, int X2, int Y2)
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
            foreach (Wall wall in listWalls)
            {
                if (CheckCollision(selectTank.X1, selectTank.Y1, selectTank.X2, selectTank.Y2, direction, wall.X1, wall.Y1, wall.X2, wall.Y2))
                {
                    move = false;
                    break;
                }
            }

            foreach (Tank tank in listTanks)
            {
                if (tank != selectTank && CheckCollision(selectTank.X1, selectTank.Y1, selectTank.X2, selectTank.Y2, direction, tank.X1, tank.Y1, tank.X2, tank.Y2))
                {
                    move = false;
                    break;
                }
            }

            if (move)
            {
                selectTank.Move(direction);
            }
        }
           
        private void Logic_Thread(object state)
        {
            MoveShells();
            ControlTanks();
        }
        
        private void MoveShells()
        {

            Stack<Shell> shellRemove = new Stack<Shell>();
            foreach (Shell shell in listShells)
            {
                shell.Move();
                switch (shell.direction)
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

            foreach (Shell shell in shellRemove)
            {
                listShells.Remove(shell);
            }
        }

        private void ControlTanks()
        {
            foreach(var tank in listTanks)
            {
                if (tank.HP < 1)
                {
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
                        listShells.Add(tank.Shoot());
                        break;
               }
            }
        }
    }
}
