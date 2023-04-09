using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects.List
{
    internal class ListTanks
    {
        private Tank[] listTanks;
        private int countTank;

        public ListTanks(int countTank)
        {
            this.countTank = countTank;
            listTanks = new Tank[countTank];
        }

        public Tank this[int indexTank]
        {
            get
            {
                return listTanks[indexTank];
            }
            set
            {
                listTanks[indexTank] = value;
            }
        }
    }
}
