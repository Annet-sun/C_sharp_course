using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Collections.Generic;


namespace C_sharp_course
{
    public enum TypeSchet9 //перечесление
    {
        Текущий,
        Сберегательный
    }
    public class BankAccount9 : IDisposable
    {
        private static int number = 0;
        private TypeSchet9 type;
        private double balance;

        //закрытое поле типа System.Collections.Queue, которое будет хранить объекты класса
        //BankTransaction для данного банковского счета
        private readonly Queue<BankTransaction> transactions = new Queue<BankTransaction>();

        public static void GenNumber()
        {
            number++;
        }
        public int Number
        {
            get { return number; }

        }

        // Конструктор по умолчанию
        public BankAccount9()
        {
            GenNumber();
        }

        // Конструктор для заполнения поля баланс
        public BankAccount9(double balance)
        {
            GenNumber();
            this.balance = balance;
        }

        // Конструктор для заполнения поля типа банковского счета
        public BankAccount9(TypeSchet9 type)
        {
            GenNumber();
            this.type = type;
        }

        // Конструктор для заполнения баланса и типа банковского счета
        public BankAccount9(TypeSchet9 type, double balance)
        {
            GenNumber();
            this.type = type;
            this.balance = balance;
        }

        private TypeSchet9 Type
        {
            get { return type; }
            set { type = value; }
        }

        private double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public string Deposit(double value)
        {
            Balance+= value;

            BankTransaction transaction = new BankTransaction(value);
            transactions.Enqueue(transaction);

            return $" Операция выполнена успешно. Баланс: {Balance}";
        }

        public string Withdraw(double value)
        {
            if (Balance - value >= 0)
            {
                BankTransaction transaction = new BankTransaction(-value);
                transactions.Enqueue(transaction);

                Balance -= value;
                return $" Операция выполнена успешно. Баланс: {Balance}";
            }

            return $" Недостаточно средств. Операция не выполнена. Баланс:{Balance}";
        }

        public override string? ToString()
        {
            return " Номер счета: " + Number + "\n Тип: " + type + "\n Баланс: " + balance;
        }

        public string Transfer_from_one_account_to_another(ref BankAccount9 account_from, double sum)
        {
            if (account_from.Balance - sum >= 0)
            {
                BankTransaction transaction = new BankTransaction(sum);
                transactions.Enqueue(transaction);

                account_from.transactions.Enqueue(new BankTransaction(-sum));

                account_from.Balance -= sum;
                balance += sum;
                return $"Операция выполнена успешно. \nБаланс аккаунта с которого совершен перевод: {account_from.Balance}. \nБаланс аккаунта на который совершен перевод: {Balance}";
            }

            return $" Недостаточно средств. Операция не выполнена. Баланс аккаунта с которого должен был произойти перевод:{account_from.Balance}";
        }

        public IEnumerable<BankTransaction> GetTransactions()
        {
            return transactions;
        }


        public void SaveTransactionsToFile()
        {
            string directory = @"C:\\Users\\nyura\\source\\repos\\C_sharp_course\\C_sharp_course\\";
            string fileName = "transactions" + Number + ".txt";
            string filePath = directory + fileName;
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Транзакции для счета номер {this.Number}:");

                foreach (var transaction in transactions)
                {
                    writer.WriteLine($"Дата: {transaction.date}, Сумма: {transaction.sum}");
                }
            }
           
        }

        private bool disposed = false;

        // Метод Dispose для сохранения данных в файл
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождение управляемых ресурсов
                    SaveTransactionsToFile();
                }
                // Освобождение неуправляемых ресурсов 
                 disposed = true;
            }
        }


    }

    public class BankTransaction
    {

        public readonly DateTime date;
        public readonly double sum;

        public BankTransaction(double sum)
        {
            date = DateTime.Now;
            this.sum = sum;
        }
    }

    public class Song9
    {   
        public string Name { get; set; }
        public string Author { get; set; }
        public Song9 Prev { get; set; }

    
        public Song9(string name, string author ,Song9 prev = null)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }

        public Song9()
        {

        }


        // Метод для заполнения поля name
        public void SetName(string name)
        {
            Name = name;
        }

        // Метод для заполнения поля author
        public void SetAuthor(string author)
        {
            Author = author;
        }

        // Метод для заполнения поля prev
        public void SetPrev(Song9 prev)
        {
            Prev = prev;
        }

        // Метод для печати названия песни и ее исполнителя
        public string PrintSong()
        {
            return $"{Name} - {Author}";
        }

        // Переопределение метода Equals для сравнения двух песен
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Song9 otherSong = (Song9)obj;
            return Name == otherSong.Name && Author == otherSong.Author;
        }
    }


    public class Laba9
    {
        static void Main9(string[] args)
        {
            Console.WriteLine("Упражнение 9.1");
            //Использование конструктора по умолчанию
            BankAccount9 account1 = new BankAccount9();
            Console.WriteLine("Счет 1: " + account1);

            //Использование конструктора для заполнения баланса
            BankAccount9 account2 = new BankAccount9(1000.0);
            Console.WriteLine("\nСчет 2: " + account2);

            //Использование конструктора для заполнения типа банковского счета
            BankAccount9 account3 = new BankAccount9(TypeSchet9.Сберегательный);
            Console.WriteLine("\nСчет 3: " + account3);

            //Использование конструктора для заполнения баланса и типа банковского счета
            BankAccount9 account4 = new BankAccount9(TypeSchet9.Текущий, 500.0);
            Console.WriteLine("\nСчет 4:\n" + account4);


            Console.WriteLine("\n\nУпражнение 9.2");
        
            //Депозит и снятие со счета с созданием транзакций
            Console.WriteLine(account2.Deposit(200.0));
            Console.WriteLine(account2.Withdraw(300.0));

            //Перевод средств между счетами
            Console.WriteLine(account2.Transfer_from_one_account_to_another(ref account4, 150.0));

            //Информация о транзакциях для счета 2
            Console.WriteLine("\nТранзакции для счета 2:");
            foreach (var transaction in account2.GetTransactions())
            {
                Console.WriteLine($"Дата: {transaction.date}, Сумма: {transaction.sum}");
            }
            //Информация о транзакциях для счета 4
            Console.WriteLine("\nТранзакции для счета 4:");
            foreach (var transaction in account4.GetTransactions())
            {
                Console.WriteLine($"Дата: {transaction.date}, Сумма: {transaction.sum}");
            }


            Console.WriteLine("\nУпражнение 9.3");
            using (BankAccount9 account = new BankAccount9(1000.0))
            {
                // Операции на счете
                Console.WriteLine(account.Deposit(200.0));
                Console.WriteLine(account.Withdraw(300.0));

                // Перевод средств между счетами
                BankAccount9 account5 = new BankAccount9(TypeSchet9.Текущий,200);
                Console.WriteLine(account.Transfer_from_one_account_to_another(ref account5, 150.0));

                //Автоматически вызывается Dispose при выходе из блока using
            }

            BankAccount9 acc = null;
            try
            {
                acc = new BankAccount9(10);
                Console.WriteLine(acc.Transfer_from_one_account_to_another(ref account2, 1000.0));

            }
            finally
            {
                if (acc != null) ((IDisposable)acc).Dispose();
            }

            Console.WriteLine("\n\nДомашнее задание 9.1");
            //конструктор с параметрами
            Song9 firstSong = new Song9("Song1", "Author1");
            Console.WriteLine("1 Song: " + firstSong.PrintSong());

            //конструктор с параметрами и предыдущей песней
            Song9 secondSong = new Song9("Song2", "Author2", firstSong);
            Console.WriteLine("2 Song: " + secondSong.PrintSong());

            //конструктор по умолчанию
            Song9 mySong = new Song9();
            Console.WriteLine("My Song: " + mySong.PrintSong());
        }
    }
}
