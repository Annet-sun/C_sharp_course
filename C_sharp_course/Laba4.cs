using System;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main2(string[] args)
        {

            ////Л
            //int d;
            //Console.WriteLine("Введите число от 1 до 365 (номер дня в году)");
            //d = Convert.ToInt32(Console.ReadLine());
            //if (d < 1 || d > 365) {
            //    //Console.WriteLine("Вы ввели неверное число!");
            //    string fault = "Вы ввели неверное число!";
            //    Console.WriteLine(fault);
            //    throw new InvalidTimeException(fault); 
            //}
            //int[] kol_day = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            //int i = 0;
            //for (; d > kol_day[i]; i++)
            //    d -= kol_day[i];
            //Console.WriteLine((i + 1)+" месяц, "+d+" день");

            //Д
            int[] kol_day = new[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Console.WriteLine("Введите число от 1 до 365 (номер дня в году)");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите год");
            int y = Convert.ToInt32(Console.ReadLine());
            if ((y % 4 == 0 && y % 100 != 0) || (y % 400 == 0)){
                kol_day[1] = 29;
            }
            if (d < 1 || d > kol_day.Sum())
            {
                //Console.WriteLine("Вы ввели неверное число!");
                string fault = "Вы ввели не верный день!";
                Console.WriteLine(fault);
                throw new InvalidTimeException(fault);
            }        
            int i = 0;
            for (; d > kol_day[i]; i++)
                d -= kol_day[i];
            Console.WriteLine((i + 1) + " месяц, " + d + " день, "+y+" год");

        }
    }

    [Serializable]
    internal class InvalidTimeException : Exception
    {
        public InvalidTimeException()
        {
        }

        public InvalidTimeException(string? message) : base(message)
        {
        }

        public InvalidTimeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidTimeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}