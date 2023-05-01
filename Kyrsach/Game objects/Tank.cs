using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyrsach.Game_objects.Base;

namespace Kyrsach.Game_objects
{
    internal class Tank
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля
        public BaseTank TankGraphis { get; set; }

        // Методы
        public Tank(int x, int y, bool bot, Const.Direction direction)
        {
            TankGraphis = new BaseTank();
            this.x = x;
            this.y = y;
            this.bot = bot;
            this.direction = direction;
        }

        public void Paint(Graphics graphics)
        {
            TankGraphis.Paint(graphics, direction, x,y);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int SIZE = 30;
        private const int SIZE_HITBOX = 20;
        private const int LENGTH_GUN = 25;

        // Типы


        // Поля
        //статы
        private int hp = 1;
        private int damage = 1;
        private int speed = 1;
        private int reload = 1;

        //техническая информация отображаемая
        private int x;
        private int y;
        private Const.Direction direction;
        private Const.Direction predDirection;

        private bool bot;

        // Методы
    }
}
