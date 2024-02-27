using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BildingSystem
{
    public class Creator
    {
        private static readonly Hashtable buildings = new Hashtable();

        private Creator() { } // закрытый конструктор

        public static Building CreateBuilding()
        {
            Building building = new Building();
            buildings[building.Nunber] = building;
            return building;
        }

        public static Building CreateBuilding(int height, int floors, int apartments, int entrances)
        {
            Building building = new Building(height, floors, apartments, entrances);
            buildings[building.Nunber] = building;
            return building;
        }

        public static void RemoveBuilding(int buildingNumber)
        {
            if (buildings.ContainsKey(buildingNumber))
            {
                buildings.Remove(buildingNumber);
                Console.WriteLine($"Building {buildingNumber} removed successfully.");
            }
            else
            {
                Console.WriteLine($"Building {buildingNumber} not found.");
            }
        }
        public static Building GetBuilding(int buildingNumber)
        {
            if (buildings.ContainsKey(buildingNumber))
            {
                return buildings[buildingNumber] as Building;
            }
            return null;
        }
    }
}
