using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects
{
    internal class Shell
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля
        public Const.Direction direction { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }
        public int Y2 { get; set; }

        // Методы
        public Shell(int x, int y, Const.Direction direction, int damage, int speed) 
        {
            this.damage = damage;
            this.direction = direction;
            this.speed = speed * 2;
            switch (direction)
            {
                case Const.Direction.UP:
                    this.x = x;
                    this.y = y - 25;
                    break;
                case Const.Direction.RIGHT:
                    this.x = x+25;
                    this.y = y;
                    break;
                case Const.Direction.DOWN:
                    this.x = x;
                    this.y = y+25;
                    break;
                case Const.Direction.LEFT:
                    this.x = x-25;
                    this.y = y;
                    break;
            }
            X1 = x - 5;
            Y1 = y - 5;
            X2 = x + 5;
            Y2 = y + 5;
        }

        public void Paint(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(Color.Black);
            graphics.FillEllipse(brush, x-5, y-5, 10, 10);
            graphics.DrawEllipse(pen, x-5, y-5, 10, 10);
        }

        public void Move()
        {
            switch(direction)
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
            X1 = x - 5;
            Y1 = y - 5;
            X2 = x + 5;
            Y2 = y + 5;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int SIZE = 5;

        // Типы


        // Поля
        //статы
        private int damage;
        private int speed;

        //техническая информация отображаемая
        private int x;
        private int y;


        // Методы
    }
}
