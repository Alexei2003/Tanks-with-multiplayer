using Kyrsach.Game_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void Paint(Graphics graphics)
        {
            graphics.Clear(Color.White);

            foreach (Tank tank in listTanks)
            {
                if (tank.HP > 0)
                {
                    tank.Paint(graphics);
                }
            }

            foreach(Wall wall in listWalls) 
            {
                wall.Paint(graphics);
            }

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

            foreach(Shell shell in shellRemove)
            {
                listShells.Remove(shell);
            }

            foreach(Shell shell in listShells)
            {
                shell.Paint(graphics);
            }
        }

        public void KeyDown(KeyEventArgs e, int indexTank)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    CheckTankCollision(indexTank, Const.Direction.UP);
                    break;
                case Keys.D:
                    CheckTankCollision(indexTank, Const.Direction.RIGHT);
                    break;
                case Keys.S:
                    CheckTankCollision(indexTank, Const.Direction.DOWN);
                    break;
                case Keys.A:
                    CheckTankCollision(indexTank, Const.Direction.LEFT);
                    break;
                case Keys.Space:
                    listShells.Add(listTanks[indexTank].Shoot());
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы


        // Типы


        // Поля
        private List<Wall> listWalls;
        private Tank[] listTanks;
        private List<Shell> listShells;

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

        private void CheckTankCollision(int indexTank, Const.Direction direction)
        {
            bool move = true;
            foreach (Wall wall in listWalls)
            {
                if (CheckCollision(listTanks[indexTank].X1, listTanks[indexTank].Y1, listTanks[indexTank].X2, listTanks[indexTank].Y2, direction, wall.X1, wall.Y1, wall.X2, wall.Y2))
                {
                    move = false;
                    break;
                }
            }

            foreach (Tank tank in listTanks)
            {
                if (tank != listTanks[indexTank] && CheckCollision(listTanks[indexTank].X1, listTanks[indexTank].Y1, listTanks[indexTank].X2, listTanks[indexTank].Y2, direction, tank.X1, tank.Y1, tank.X2, tank.Y2))
                {
                    move = false;
                    break;
                }
            }

            if (move)
            {
                listTanks[indexTank].Move(direction);
            }
        }
    }
}
