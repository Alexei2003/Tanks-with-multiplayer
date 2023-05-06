using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsach.Game_objects
{
    internal class Shell
    {
        // Интерфейс
        // Константы


        // Типы


        // Поля


        // Методы
        public Shell(int x, int y, Const.Direction direction) 
        {
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Реализация
        // Константы


        // Типы


        // Поля
        private const int SIZE = 5;

        //статы
        private int damage;
        private int speed;

        //техническая информация отображаемая
        private int x;
        private int y;
        private int direction;
        private int predDirection;


        // Методы
    }
}
