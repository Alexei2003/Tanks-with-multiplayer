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
            UP, RIGHT, DOWN, LEFT
        }

        public enum ListAction
        {
            FIND, NEXT
        }

        public const int SIZE_CELL = 30;
        public const int GAME_ZONE_TOP = 0;
        public const int GAME_ZONE_RIHT = 800;
        public const int GMAE_ZONE_DOWN = 600;
        public const int GAME_ZONE_LEFT = 0;
    }
}
