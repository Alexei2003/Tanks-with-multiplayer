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

            listShells = new List<Shell>();
        }

        public void Paint(Graphics graphics)
        {
            graphics.Clear(Color.White);

            foreach (Tank tank in listTanks)
            {
                tank.Paint(graphics);
            }

            foreach(Wall wall in listWalls) 
            {
                wall.Paint(graphics);
            }
        }

        public void KeyDown(KeyEventArgs e, int indexTank)
        {
            bool move = true; ;
            switch (e.KeyCode)
            {
                case Keys.W:
                    foreach (Wall wall in listWalls)
                    {
                        if (Check(indexTank, Const.Direction.UP, wall.X1, wall.Y1, wall.X2, wall.Y2))
                        {
                            move = false; 
                            break;
                        }
                    }
                    if (move)
                    {
                        listTanks[indexTank].Move(Const.Direction.UP);
                    }
                    break;
                case Keys.D:
                    foreach (Wall wall in listWalls)
                    {
                        if (Check(indexTank, Const.Direction.RIGHT, wall.X1, wall.Y1, wall.X2, wall.Y2))
                        {
                            move = false;
                            break;
                        }
                    }
                    if (move)
                    {
                        listTanks[indexTank].Move(Const.Direction.RIGHT);
                    }
                    break;
                case Keys.S:
                    foreach (Wall wall in listWalls)
                    {
                        if (Check(indexTank, Const.Direction.DOWN, wall.X1, wall.Y1, wall.X2, wall.Y2))
                        {
                            move = false;
                            break;
                        }
                    }
                    if (move)
                    {
                        listTanks[indexTank].Move(Const.Direction.DOWN);
                    }
                    break;
                case Keys.A:
                    foreach (Wall wall in listWalls)
                    {
                        if (Check(indexTank, Const.Direction.LEFT, wall.X1, wall.Y1, wall.X2, wall.Y2))
                        {
                            move = false;
                            break;
                        }
                    }
                    if (move)
                    {
                        listTanks[indexTank].Move(Const.Direction.LEFT);
                    }
                    break;
                case Keys.Space:

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
        private bool Check(int indexTank,Const.Direction direction, int X1, int Y1, int X2, int Y2)
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
            if (listTanks[indexTank].X2 + right >= X1 && listTanks[indexTank].X1 - left <= X2)
            {
                if (listTanks[indexTank].Y2 + down >= Y1 && listTanks[indexTank].Y1 - up <= Y2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
