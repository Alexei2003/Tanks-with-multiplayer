namespace Kyrsach.Game_objects
{
    internal class Wall
    {
        // Интерфейс
        // Константы        
        public const int SIZE = 15;

        // Типы


        // Поля
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public int X2 { get; set; }
        public int Y2 { get; set; }

        // Методы
        public Wall(int x, int y, int count, Const.Direction direction)
        {
            this.x = x;
            this.y = y;
            this.count = count;
            this.direction = direction;

            switch (direction)
            {
                case Const.Direction.RIGHT:
                    Y1 = y - SIZE;
                    Y2 = y + SIZE;
                    X1 = x - SIZE;
                    X2 = x + SIZE + (count-1)*Const.SIZE_CELL;
                    break;
                case Const.Direction.DOWN:
                    Y1 = y - SIZE;
                    Y2 = y + SIZE + (count - 1) * Const.SIZE_CELL;
                    X1 = x - SIZE;
                    X2 = x + SIZE;
                    break;
            }

            rect1.X = -Const.SIZE_CELL/2;
            rect1.Y = -Const.SIZE_CELL / 2;
            rect1.Width = 10;
            rect1.Height = 5;

            rect2.X = -Const.SIZE_CELL / 2;
            rect2.Y = -Const.SIZE_CELL / 2;
            rect2.Width = 10;
            rect2.Height = 10;

            line[0].X = -Const.SIZE_CELL / 2 + 5;
            line[0].Y = -Const.SIZE_CELL / 2 + 5;
            line[1].X = -Const.SIZE_CELL / 2 + 5;
            line[1].Y = -Const.SIZE_CELL / 2 + 9;
        }

        public void Paint(Graphics graphics)
        {
            switch (direction)
            {
                case Const.Direction.RIGHT:
                    for (int i = 0; i < count; i++)
                    {
                        PaintBlock(graphics,x+i*Const.SIZE_CELL,y);
                    }
                    break;
                case Const.Direction.DOWN:
                    for (int i = 0; i < count; i++)
                    {
                        PaintBlock(graphics, x, y + i * Const.SIZE_CELL);
                    }
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы
        private const int COUNT_BLOCK = Const.SIZE_CELL / 10;

        // Типы


        // Поля
        //техническая информация отображаемая
        private Pen pen = new Pen(Color.Black,1);
        private Brush brush = new SolidBrush(Color.Brown);
        private int count;
        private Const.Direction direction;
        private Point[] line = new Point[2];
        private Rectangle rect1 = new Rectangle();
        private Rectangle rect2 = new Rectangle();
        private Point[] changePoints = new Point[2];
        private int saveX;
        private int x;
        private int y;

        // Методы
        private void PaintBlock(Graphics graphics,int x, int y)
        {
            saveX = x;
            for (int i = 0; i < COUNT_BLOCK; i++)
            {
                for (int j = 0; j < COUNT_BLOCK; j++)
                {
                    graphics.FillRectangle(brush, OffsetRectangle(rect2, x, y));
                    graphics.DrawRectangle(pen, OffsetRectangle(rect1, x, y));
                    graphics.DrawPolygon(pen, OffsetPoints(line, x, y));
                    x += 10;
                }
                x = saveX;
                y += 10;
            }
        }

        private Rectangle OffsetRectangle(Rectangle rect, int x, int y)
        {
            rect.Offset(x, y);
            return rect;
        }
        private Point[] OffsetPoints(Point[] points, int x, int y)
        {
            Array.Copy(points, changePoints, points.Length);
            for (int i = 0; i < points.Length; i++)
            {
                changePoints[i].Offset(x, y);
            }
            return changePoints;
        }
    }
}
