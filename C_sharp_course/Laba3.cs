using System;
using System;
using System.Drawing;

namespace Laba3
{
    public enum BankSchet //перечесление
    {
        tekushii,
        sberegatelnii
    }

    public struct Schet
    {
        public int number;
        public int type;
        public double balance;

        public Schet(int number, int type, double balance)
        {
            this.number = number;
            this.type = type;
            this.balance = balance;
        }
    }


    public enum ВУЗ
    {
        КГУ, КАИ, КХТИ, КФУ
    }

    public struct Employee
    {
        public string name;
        public ВУЗ vuz;
    }

    class Program
    {

        // Main Method
        static void Main2(string[] args)
        {

            //Л_1.перечесление
            BankSchet rich; // объявление переменной
            rich = BankSchet.tekushii; // установка значения 
            Console.WriteLine("Сейчас открыт " + rich + " счет");
            rich = (BankSchet)1;
            Console.WriteLine("А сейчас уже открыт " + rich + " счет");

            Console.WriteLine("Л_2-------------------------------------------------------------------------------------");
            //Л_2.структура
            Schet my = new Schet(12345, 0, 12345.9999);
            Console.WriteLine("Мы создали счет с номером " + my.number + ", тип : " + (BankSchet)my.type + ". И положили на счет " + my.balance + " рублей");


            Console.WriteLine("Д_1-------------------------------------------------------------------------------------");
            //Д_1
            Console.WriteLine("Давайте добавим нового сотрудника!");
            Employee new_employee;
            Console.WriteLine("Введите ФИО:");
            new_employee.name = Console.ReadLine();
            Console.WriteLine("Введите цифру соответсвующую вузу: 1) КГУ, 2) КАИ, 3) КХТИ, 4) КФУ");
            new_employee.vuz = (ВУЗ)(Convert.ToInt32(Console.ReadLine()) - 1);
            Console.WriteLine("Добавлен новый сотрудник\nФИО: " + new_employee.name + "\nВУЗ: " + new_employee.vuz);
        }
    }
}
