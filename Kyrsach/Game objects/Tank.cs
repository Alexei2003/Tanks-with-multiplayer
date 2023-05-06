using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Kyrsach.Game_objects.Base;

namespace Kyrsach.Game_objects
{
    internal class Tank
    {
        // Интерфейс
        // Константы
        public const int SIZE_HITBOX = 20;
        public const int SIZE_MOVE = 5;

        // Типы


        // Поля
        public BaseTank TankGraphis { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }
        public int Y2 { get; set; }

        // Методы
        public Tank(int x, int y, bool bot, Const.Direction direction)
        {
            TankGraphis = new BaseTank();
            this.x = x;
            this.y = y;
            this.bot = bot;
            this.direction = direction;

            X1 = x - SIZE_HITBOX;
            X2 = x + SIZE_HITBOX;
            Y1 = y - SIZE_HITBOX;
            Y2 = y + SIZE_HITBOX;
        }

        public void Paint(Graphics graphics)
        {
            TankGraphis.Paint(graphics, direction, x, y);
        }

        public void Move(Const.Direction direction)
        {
            switch (direction)
            {
                case Const.Direction.UP:
                    y -= speed;
                    break;
                case Const.Direction.RIGHT:
                    x += speed;
                    break;
                case Const.Direction.DOWN:
                    y += speed;
                    break;
                case Const.Direction.LEFT:
                    x -= speed;
                    break;
            }
            this.direction = direction;
            TankGraphis.Move();
            X1 = x - SIZE_HITBOX;
            X2 = x + SIZE_HITBOX;
            Y1 = y - SIZE_HITBOX;
            Y2 = y + SIZE_HITBOX;
            this.direction = direction;
        }

        public Shell Shoot()
        {
            Shell shell = new Shell();
            return shell;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int LENGTH_GUN = 20;

        // Типы


        // Поля
        //статы
        private int hp = 1;
        private int damage = 1;
        private int speed = 3;
        private int reload = 1;

        //техническая информация отображаемая
        private int x;
        private int y;
        private Const.Direction direction;

        private bool bot;

        // Методы
    }
}
