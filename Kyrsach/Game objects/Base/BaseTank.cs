using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects.Base
{
    internal class BaseTank
    {
        private const int COUNT_TRACK = 4;
        private const int SIZE_TRACK = 5;

        private const int COUNT_CORNERS_CATERPILLAR = 4;
        private const int COUNT_CORNERS_TRACK = 4;
        private const int COUNT_CORNERS_BODY = 4;
        private const int COUNT_CORNERS_TOWER = 8;
        private const int COUNT_CORNERS_GUN = 4;

        private bool firstDark;

        private struct Square
        {
            public int x1; 
            public int y1;
            public int x2;
            public int y2;

            public void SetCoordinates(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
        }

        private struct Point
        {
            public int x;
            public int y;

            public void SetCoordinates(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private struct Figures
        {
            public Square caterpillar;
            public Square caterpillar2;
            public Square track;
            public Square body;
            public Point[] tower;
            public Square gun;

            public Figures()
            {
                caterpillar = new Square();
                caterpillar2 = new Square();
                track = new Square();
                body = new Square();
                tower = new Point[COUNT_CORNERS_TOWER];
                gun = new Square();
            }
        }

        public BaseTank()
        {
            firstDark = true;

            Figures up = CreateUpFigure();
            Figures right = CreateRightFigure();
            Figures down = CreateDownFigure();
            Figures left = CreateLeftFigure();

        }

        private Figures CreateUpFigure()
        {
            Figures up = new Figures();

            up.caterpillar.SetCoordinates(-20, 20, -10, -20);
            up.caterpillar2.SetCoordinates(10, 20, 20, -20);
            up.track.SetCoordinates(-20, 20, -10, 15);

            up.body.SetCoordinates(-15, 15, 15, -15);
            up.tower[0].SetCoordinates(-5, 10);
            up.tower[1].SetCoordinates(-10, 5);
            up.tower[2].SetCoordinates(-10, -5);
            up.tower[3].SetCoordinates(-5, -10);
            up.tower[4].SetCoordinates(5, -10);
            up.tower[5].SetCoordinates(10, -5);
            up.tower[6].SetCoordinates(10, 5);
            up.tower[7].SetCoordinates(5, 10);

            up.gun.SetCoordinates(-5, 25, 5, 10);

            return up;
        }

        private Figures CreateRightFigure()
        {
            Figures right = new Figures();

            right.caterpillar.SetCoordinates(-20,20,20,10);
            right.caterpillar2.SetCoordinates(-20,-10,20,-20);
            right.track.SetCoordinates(15,20,20,10);

            right.body.SetCoordinates(-15, 15, 15, -15);
            right.tower[0].SetCoordinates(-5, 10);
            right.tower[1].SetCoordinates(-10, 5);
            right.tower[2].SetCoordinates(-10, -5);
            right.tower[3].SetCoordinates(-5, -10);
            right.tower[4].SetCoordinates(5, -10);
            right.tower[5].SetCoordinates(10, -5);
            right.tower[6].SetCoordinates(10, 5);
            right.tower[7].SetCoordinates(5, 10);

            right.gun.SetCoordinates(10,5,25,-5);

            return right;
        }

        private Figures CreateDownFigure()
        {
            Figures down = new Figures();

            down.caterpillar.SetCoordinates(-20,20,-10,-20);
            down.caterpillar2.SetCoordinates(10,20,-20,10);
            down.track.SetCoordinates(10,-15,20,-20);

            down.body.SetCoordinates(-15, 15, 15, -15);
            down.tower[0].SetCoordinates(-5, 10);
            down.tower[1].SetCoordinates(-10, 5);
            down.tower[2].SetCoordinates(-10, -5);
            down.tower[3].SetCoordinates(-5, -10);
            down.tower[4].SetCoordinates(5, -10);
            down.tower[5].SetCoordinates(10, -5);
            down.tower[6].SetCoordinates(10, 5);
            down.tower[7].SetCoordinates(5, 10);

            down.gun.SetCoordinates(-5,-10,5,-25);

            return down;
        }

        private Figures CreateLeftFigure()
        {
            Figures left = new Figures();

            left.caterpillar.SetCoordinates(-20,20,20,10);
            left.caterpillar2.SetCoordinates(-20,-10,20,-20);
            left.track.SetCoordinates(-20,-10,20,-20);

            left.body.SetCoordinates(-15, 15, 15, -15);
            left.tower[0].SetCoordinates(-5, 10);
            left.tower[1].SetCoordinates(-10, 5);
            left.tower[2].SetCoordinates(-10, -5);
            left.tower[3].SetCoordinates(-5, -10);
            left.tower[4].SetCoordinates(5, -10);
            left.tower[5].SetCoordinates(10, -5);
            left.tower[6].SetCoordinates(10, 5);
            left.tower[7].SetCoordinates(5, 10);

            left.gun.SetCoordinates(-25,5,-10,-5);

            return left;
        }

        public void Move()
        {
            firstDark = !firstDark;
        }

        public void Paint(int direction, int x, int y)
        {
      
        }
    }
}
