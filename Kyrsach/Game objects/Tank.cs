﻿using Kyrsach.Game_objects.Base;
using System.Text.Json.Serialization;

namespace Kyrsach.Game_objects
{
    [Serializable]
    internal class Tank
    {
        // Интерфейс
        // Константы
        [JsonIgnore]
        public const int SIZE_HITBOX = 20;
        [JsonIgnore]
        public const int SIZE_MOVE = 5;

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
        [JsonIgnore]
        public Const.Direction keyDirection { get; set; } = Const.Direction.DEFAULT;

        public int RemainingTimeReload { get; set; }
        public int HP { get; set; } = 1;
        public int X { get; set; }
        public int Y { get; set; }
        public bool FirstDark { get; set; } = true;
        public Const.Direction Direction { get; set; }

        // Методы
        public Tank(int x, int y, Const.Direction direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;

            // Выполнение инициализации танка
            Initialization();

            RemainingTimeReload = timeReload;
        }


        public Tank()
        {
        }

        public void Initialization()
        {
            tankGraphis = new BaseTank();

            // Установка границ прямоугольной области столкновения танка
            X1 = this.X - SIZE_HITBOX;
            X2 = this.X + SIZE_HITBOX;
            Y1 = this.Y - SIZE_HITBOX;
            Y2 = this.Y + SIZE_HITBOX;
        }

        public void Paint(Graphics graphics)
        {
            tankGraphis.Paint(graphics, Direction, X, Y);
        }

        public void Move(Const.Direction direction)
        {
            // Изменение координат танка в зависимости от направления
            switch (direction)
            {
                case Const.Direction.UP:
                    Y -= speed;
                    break;
                case Const.Direction.RIGHT:
                    X += speed;
                    break;
                case Const.Direction.DOWN:
                    Y += speed;
                    break;
                case Const.Direction.LEFT:
                    X -= speed;
                    break;
            }

            // Обновление текущего направления танка
            this.Direction = direction;

            // Изменение состояния переменной FirstDark для анимации гусиниц танка
            FirstDark = !FirstDark;
            tankGraphis.FirstDark = FirstDark;

            // Обновление границ хитбокса танка
            X1 = X - SIZE_HITBOX;
            X2 = X + SIZE_HITBOX;
            Y1 = Y - SIZE_HITBOX;
            Y2 = Y + SIZE_HITBOX;
        }


        public Shell Shoot()
        {
            return new Shell(X, Y, Direction, damage, speed);
        }

        public void StartTankReload()
        {
            RemainingTimeReload = timeReload;
        }

        public void TankReload()
        {
            if (RemainingTimeReload > 0)
            {
                RemainingTimeReload--;

            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int LENGTH_GUN = 20;

        // Типы


        // Поля

        private int damage = 1;
        private int speed = 5;
        private int timeReload = 10;

        //техническая информация отображаемая
        private BaseTank tankGraphis;

        // Методы
    }
}
