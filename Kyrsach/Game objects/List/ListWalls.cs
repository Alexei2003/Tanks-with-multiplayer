using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects.List
{
    internal class ListWalls
    {
        private Tank[] listWalls;
        private int countWall;

        public ListWalls(int countTank)
        {
            this.countWall = countTank;
            listWalls = new Tank[countTank];
        }

        public Tank this[int indexTank]
        {
            get
            {
                return listWalls[indexTank];
            }
            set
            {
                listWalls[indexTank] = value;
            }
        }
    }
}
