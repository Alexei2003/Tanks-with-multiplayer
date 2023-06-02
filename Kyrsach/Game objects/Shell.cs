using Kyrsach.Game_objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Kyrsach.Game_objects.Base.BaseTank;

namespace Kyrsach.Game_objects
{
    [Serializable]
    internal class Shell
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля

        [JsonIgnore]
        public int X1 { get; set; }
        [JsonIgnore]
        public int Y1 { get; set; }
        [JsonIgnore]
        public int X2 { get; set; }
        [JsonIgnore]
        public int Y2 { get; set; }

        public Const.Direction Direction { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        // Методы
        public Shell(int x, int y, Const.Direction direction, int damage, int speed)
        {
            // Установка урона, направления и скорости снаряда
            this.Damage = damage;
            this.Direction = direction;
            this.Speed = speed * 2;

            // Установка начальных координат снаряда в зависимости от направления
            switch (direction)
            {
                case Const.Direction.UP:
                    this.X = x;
                    this.Y = y - 25;
                    break;
                case Const.Direction.RIGHT:
                    this.X = x + 25;
                    this.Y = y;
                    break;
                case Const.Direction.DOWN:
                    this.X = x;
                    this.Y = y + 25;
                    break;
                case Const.Direction.LEFT:
                    this.X = x - 25;
                    this.Y = y;
                    break;
            }
        }


        public Shell()
        {
        }

        public void Initialization()
        {
            X1 = this.X - 5;
            Y1 = this.Y - 5;
            X2 = this.X + 5;
            Y2 = this.Y + 5;
        }

        public void Paint(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black);
            int x = this.X;
            int y = this.Y;
            graphics.FillEllipse(brush, x-5, y-5, 10, 10);
            graphics.DrawEllipse(pen, x-5, y-5, 10, 10);
        }

        public void Move()
        {
            switch(Direction)
            {
                case Const.Direction.UP:
                    Y -= Speed;
                    break;
                case Const.Direction.RIGHT:
                    X += Speed;
                    break;
                case Const.Direction.DOWN:
                    Y += Speed;
                    break;
                case Const.Direction.LEFT:
                    X -= Speed;
                    break;
            }
            X1 = X - 5;
            Y1 = Y - 5;
            X2 = X + 5;
            Y2 = Y + 5;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int SIZE = 5;

        // Типы

        // Поля

        // Методы
    }
}
