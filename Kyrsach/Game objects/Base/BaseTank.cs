using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects.Base
{
    internal class BaseTank
    {
        // Интерфейс
        // Константы

        // Типы
        public struct TankGraphis
        {
            public Rectangle caterpillar;
            public Rectangle caterpillar2;
            public Rectangle track;
            public Rectangle body;
            public Point[] tower;
            public Rectangle gun;

            public TankGraphis()
            {
                caterpillar = new Rectangle();
                caterpillar2 = new Rectangle();
                track = new Rectangle();
                body = new Rectangle();
                tower = new Point[COUNT_CORNERS_TOWER];
                gun = new Rectangle();
            }
        }

        // Поля
        public TankGraphis[] TankDirection { get; set; }


        // Методы
        public BaseTank()
        {
            firstDark = true;

            TankDirection = new TankGraphis[4];

            TankDirection[(int)Const.Direction.UP] = CreateUpFigure();
            TankDirection[(int)Const.Direction.RIGHT] = CreateRightFigure();
            TankDirection[(int)Const.Direction.DOWN] = CreateDownFigure();
            TankDirection[(int)Const.Direction.LEFT] = CreateLeftFigure();

        }
        public void Paint(Graphics graphics, Const.Direction direction, int x, int y)
        {
            Pen pen = new Pen(Color.Black, 2);
            Brush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, OffsetRectangle(TankDirection[(int)direction].caterpillar, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].caterpillar, x, y));
            graphics.FillRectangle(brush, OffsetRectangle(TankDirection[(int)direction].caterpillar2, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].caterpillar2, x, y));

            graphics.FillRectangle(brush, OffsetRectangle(TankDirection[(int)direction].track, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].track, x, y));

            graphics.FillRectangle(brush, OffsetRectangle(TankDirection[(int)direction].body, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].body, x, y));
            graphics.FillRectangle(brush, OffsetRectangle(TankDirection[(int)direction].gun, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].gun, x, y));
            
            graphics.DrawPolygon(pen, OffsetPoints(TankDirection[(int)direction].tower,x,y));

        }
        public void Move()
        {
            firstDark = !firstDark;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int COUNT_TRACK = 4;
        private const int SIZE_TRACK = 5;

        private const int COUNT_CORNERS_CATERPILLAR = 4;
        private const int COUNT_CORNERS_TRACK = 4;
        private const int COUNT_CORNERS_BODY = 4;
        private const int COUNT_CORNERS_TOWER = 8;
        private const int COUNT_CORNERS_GUN = 4;

        // Типы


        // Поля
        private bool firstDark;

        // Методы
        private TankGraphis CreateUpFigure()
        {
            TankGraphis up = new TankGraphis();

            up.caterpillar = new Rectangle(-20, -20, 10, 40);
            up.caterpillar2 = new Rectangle(10, -20, 10, 40);
            up.track = new Rectangle(-20, -20, 10, 5);

            up.body = new Rectangle(-15, -15, 30, 30);
            up.tower[0] = new Point(-5, -10);
            up.tower[1] = new Point(-10, -5);
            up.tower[2] = new Point(-10, 5);
            up.tower[3] = new Point(-5, 10);
            up.tower[4] = new Point(5, 10);
            up.tower[5] = new Point(10, 5);
            up.tower[6] = new Point(10, -5);
            up.tower[7] = new Point(5, -10);

            up.gun = new Rectangle(-5, -25, 10, 15);

            return up;
        }

        private TankGraphis CreateRightFigure()
        {
            TankGraphis right = new TankGraphis();

            right.caterpillar = new Rectangle(-20, -20, 40, 10);
            right.caterpillar2 = new Rectangle(-20, 10, 40, 10);
            right.track = new Rectangle(15, -20, 5, 10);

            right.body = new Rectangle(-15, -15, 30, 30);
            right.tower[0] = new Point(10, -5);
            right.tower[1] = new Point(5, -10);
            right.tower[2] = new Point(-5, -10);
            right.tower[3] = new Point(-10, -5);
            right.tower[4] = new Point(-10, 5);
            right.tower[5] = new Point(-5, 10);
            right.tower[6] = new Point(5, 10);
            right.tower[7] = new Point(10, 5);

            right.gun = new Rectangle(10, -5, 15, 10);

            return right;
        }

        private TankGraphis CreateDownFigure()
        {
            TankGraphis down = new TankGraphis();

            down.caterpillar = new Rectangle(-20, -20, 10, 40);
            down.caterpillar2 = new Rectangle(10, -20, 10, 40);
            down.track = new Rectangle(10, 15, 10, 5);

            down.body = new Rectangle(-15, -15, 30, 30);
            down.tower[0] = new Point(5,10);
            down.tower[1] = new Point(10,5);
            down.tower[2] = new Point(10,-5);
            down.tower[3] = new Point(5,-10);
            down.tower[4] = new Point(-5,-10);
            down.tower[5] = new Point(-10,-5);
            down.tower[6] = new Point(-10,5);
            down.tower[7] = new Point(-5,10);

            down.gun = new Rectangle(-5, 10, 10, 15);

            return down;
        }

        private TankGraphis CreateLeftFigure()
        {
            TankGraphis left = new TankGraphis();

            left.caterpillar = new Rectangle(-20, -20, 40, 10);
            left.caterpillar2 = new Rectangle(-20, 10, 40, 10);
            left.track = new Rectangle(-20, 10, 5, 10);

            left.body = new Rectangle(-15, -15, 30, 30);
            left.tower[0] = new Point(-10,5);
            left.tower[1] = new Point(-5,10);
            left.tower[2] = new Point(5,10);
            left.tower[3] = new Point(10,5);
            left.tower[4] = new Point(10,-5);
            left.tower[5] = new Point(5,-10);
            left.tower[6] = new Point(-5,-10);
            left.tower[7] = new Point(-10, -5);

            left.gun = new Rectangle(-25, -5, 15, 10);

            return left;
        }

        private Rectangle OffsetRectangle(Rectangle rect, int x, int y)
        {
            rect.Offset(x, y);
            return rect;
        }
        private Point[] OffsetPoints(Point[] points, int x, int y)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].Offset(x, y);
            }
            return points;
        }
    }
}
