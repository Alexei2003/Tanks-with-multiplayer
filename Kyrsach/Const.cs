using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach
{
    internal class Const
    {
        public enum Direction
        {
            UP, RIGHT, DOWN, LEFT,SPACE, DEFAULT
        }

        public enum ListAction
        {
            FIND, NEXT
        }

        public const int SIZE_CELL = 30;
        public const int PORT_FOR_GAME = 9999;
        public const int PORT_FOR_INFO = 9998;
    }
}
