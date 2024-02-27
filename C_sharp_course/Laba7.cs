using Laba3;
using System.Runtime.CompilerServices;

namespace C_sharp_course
{
    public enum Type //перечесление
    {
        Текущий,
        Сберегательный
    }
    public class BankAccount1
    {
        private int number;
        private Type type;
        private double balance;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public BankAccount1()
        {
        }

        public BankAccount1(int number, Type type, double balance)
        {
            this.number = number;
            this.type = type;
            this.balance = balance;
        }

        public override string? ToString()
        {
            return " Номер счета: "+number+"\n Тип: "+type+"\n Баланс: "+balance;
        }
    }


    public class BankAccount2
    {
        private static int number=0;
        private Type type;
        private double balance;

        public static void GenNumber()
        {
            number++;
        }
        public int Number
        {
            get { return number; }
            
        }       
        
        public BankAccount2()
        {
            GenNumber();
        }

        public BankAccount2( Type type, double balance)
        {
            GenNumber();
            this.type = type;
            this.balance = balance;
        }

        public Type Type
        {
            get { return type; }
            set { type = value; }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string Deposit(double value)
        {
            Balance += value;
            return $" Операция выполнена успешно. Баланс: {Balance}";
        }

        public string Withdraw(double value)
        {
            if (Balance - value >= 0)
            {
                Balance -= value;
                return $" Операция выполнена успешно. Баланс: {Balance}";
            }

            return $" Недостаточно средств. Операция не выполнена. Баланс:{Balance}";
        }

        public override string? ToString()
        {
            return " Номер счета: " + Number + "\n Тип: " + type + "\n Баланс: " + balance;
        }
    }

    public class Building
    {
        private static int number=0;//уникальный номер здания
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

        public Building() { 
            GenNumber();
        }

        public Building(int height, int floors, int apartments, int entrances)
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
    }

    public class Laba7
    {

        static void Main7(string[] args)
        {
            Console.WriteLine("Упражнение 7.1");
            BankAccount1 account1 = new BankAccount1();
            account1.Number = 1;
            account1.Type = Type.Текущий;
            account1.Balance = 9999.9999;
            //Console.WriteLine("Мы создали счет с номером " + account1.Number + ", тип : " + account1.Type + ". И положили на счет " + account1.Balance + " рублей");
            Console.WriteLine(account1.ToString());


            Console.WriteLine("\nУпражнение 7.2");
            BankAccount2 account2 = new BankAccount2();
            account2.Type = Type.Текущий;
            account2.Balance = 1.9999;
            Console.WriteLine(account2.ToString());

            BankAccount2 account3 = new BankAccount2(Type.Текущий, 2.9999);
            Console.WriteLine(account3.ToString());

            BankAccount2 account4 = new BankAccount2(Type.Сберегательный, 5);
            Console.WriteLine(account4.ToString());

            Console.WriteLine("\nУпражнение 7.3");
            Console.WriteLine(account4.Deposit(5));
            Console.WriteLine(account4.Withdraw(3));
            Console.WriteLine(account4.Withdraw(10));

            Console.WriteLine("\nДомашнее задание 7.1");
            Building zd1 = new Building(200,8,50,3);
            zd1.CalculateFloorHigh();
            zd1.CalculateNumberOfApartementInEntrance();
            zd1.CalculateNumberOfApartementOnFloor();
        }

    }

}

