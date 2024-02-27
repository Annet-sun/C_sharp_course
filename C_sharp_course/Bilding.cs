using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BildingSystem
{
    public class Building
    {
        private static int number = 0;//уникальный номер здания
        public int Nunber
        {
            get { return number; }
        }

        public int Height { get; set; } //высота
        public int Floors { get; set; } //этажность
        public int Apartments { get; set; } //количество квартир
        public int Entrances { get; set; } //подъездов

        public static void GenNumber()
        {
            number++;
        }

        internal Building()
        {
            GenNumber();
        }

        internal Building(int height, int floors, int apartments, int entrances)
        {
            GenNumber();
            Height = height;
            Floors = floors;
            Apartments = apartments;
            Entrances = entrances;
        }

        public int CalculateFloorHigh()
        {
            int floorhigh = Height / Floors;
            Console.WriteLine($" Высота этажа = {floorhigh}");
            return floorhigh;
        }

        public int CalculateNumberOfApartementInEntrance()
        {
            int appentrance = Apartments / Entrances;
            Console.WriteLine($" Квартир в одном подъезде = {appentrance}");
            return appentrance;
        }

        public int CalculateNumberOfApartementOnFloor()
        {
            int appfloor = (Apartments / Entrances) / Floors;
            Console.WriteLine($" Квартир на одном этаже = {appfloor}");
            return appfloor;
        }

        public void printBuilding()
        {
            Console.WriteLine($"Информация о здании #{number}:");
            Console.WriteLine($"Высота: {Height} м");
            Console.WriteLine($"Этажность: {Floors} этажей");
            Console.WriteLine($"Количество квартир: {Apartments}");
            Console.WriteLine($"Количество подъездов: {Entrances}");
        }
    }
}
