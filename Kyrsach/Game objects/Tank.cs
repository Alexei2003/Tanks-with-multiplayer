using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects
{
    internal class Tank
    {
        private const int SIZE = 30;
        private const int SIZE_HITBOX = 20;
        private const int LENGTH_GUN = 25;


        //статы
        private int hp;
        private int damage;
        private int speed;
        private int reload;

        //техническая информация отображаемая
        private int x;
        private int y;
        private int direction;
        private int predDirection;

        //техническая информация не отображаемая
        private bool bot;
    }
}
