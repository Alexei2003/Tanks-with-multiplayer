using System;
using System.Collections.Generic;
using System.Globalization;
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
            TankDirection = new TankGraphis[4];

            TankDirection[(int)Const.Direction.UP] = CreateUpFigure();
            TankDirection[(int)Const.Direction.RIGHT] = CreateRightFigure();
            TankDirection[(int)Const.Direction.DOWN] = CreateDownFigure();
            TankDirection[(int)Const.Direction.LEFT] = CreateLeftFigure();

        }
        public void Paint(Graphics graphics, Const.Direction direction, int x, int y)
        {

            Brush brushCaterpillar;
            Brush brushTrack;
            int offsetTrackX=0;
            int offsetTrackY=0;

            if (firstDark)
            {
                brushCaterpillar = brush;
                brushTrack = brushDark;
            }
            else
            {
                brushCaterpillar = brushDark;
                brushTrack = brush;
            }

            graphics.FillRectangle(brushCaterpillar, OffsetRectangle(TankDirection[(int)direction].caterpillar, x, y));
            graphics.FillRectangle(brushCaterpillar, OffsetRectangle(TankDirection[(int)direction].caterpillar2, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].caterpillar, x, y));
            graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].caterpillar2, x, y));

            for (int i = 0; i < COUNT_CATERPILLAR; i++)
            {
                for (int j = 0; j < COUNT_TRACK; j++)
                {
                    graphics.FillRectangle(brushTrack, OffsetRectangle(TankDirection[(int)direction].track, x+offsetTrackX, y+offsetTrackY));
                    graphics.DrawRectangle(pen, OffsetRectangle(TankDirection[(int)direction].track, x+offsetTrackX, y+offsetTrackY));
                    switch (direction)
                    {
                        case Const.Direction.UP:
                            offsetTrackY += 10;
                            break;
                        case Const.Direction.RIGHT:
                            offsetTrackX -= 10;
                            break;
                        case Const.Direction.DOWN:
                            offsetTrackY -= 10;
                            break;
                        case Const.Direction.LEFT:
                            offsetTrackX += 10;
                            break;
                    }
                }
                offsetTrackX = 0;
                offsetTrackY = 0;
                switch (direction)
                {
                    case Const.Direction.UP:
                        offsetTrackX += 30;
                        break;
                    case Const.Direction.RIGHT:
                        offsetTrackY += 30;
                        break;
                    case Const.Direction.DOWN:
                        offsetTrackX -= 30;
                        break;
                    case Const.Direction.LEFT:
                        offsetTrackY -= 30;
                        break;
                }
            }
            
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
        private const int COUNT_CATERPILLAR = 2;

        private const int COUNT_CORNERS_TOWER = 8;

        // Типы


        // Поля
        private bool firstDark = true;
        private Point[] changePoints = new Point[COUNT_CORNERS_TOWER];
        private Pen pen = new Pen(Color.Black, 1);
        private Brush brush = new SolidBrush(Color.Green);
        private Brush brushDark = new SolidBrush(Color.DarkGreen);

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

            up.gun = new Rectangle(-5, -20, 10, 10);

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

            right.gun = new Rectangle(10, -5, 10, 10);

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

            down.gun = new Rectangle(-5, 10, 10, 10);

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

            left.gun = new Rectangle(-20, -5, 10, 10);

            return left;
        }

        private Rectangle OffsetRectangle(Rectangle rect, int x, int y)
        {
            rect.Offset(x, y);
            return rect;
        }
        private Point[] OffsetPoints(Point[] points, int x, int y)
        {
            Array.Copy(points,changePoints,points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                changePoints[i].Offset(x, y);
            }
            return changePoints;
        }
    }
}
