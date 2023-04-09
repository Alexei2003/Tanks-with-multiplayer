using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects
{
    internal class Shell
    {
        private const int SIZE = 5;

        //статы
        private int damage;
        private int speed;

        //техническая информация отображаемая
        private int x;
        private int y;
        private int direction;
        private int predDirection;
    }
}
