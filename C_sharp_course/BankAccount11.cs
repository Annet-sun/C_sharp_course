using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    public enum TypeSchet11 //перечесление
    {
        Текущий,
        Сберегательный
    }
    public class BankAccount11 : IDisposable
    {
        private static int totalAccounts = 0;  // Статическое поле для отслеживания общего количества счетов
        private int number = totalAccounts;
        private TypeSchet11 type;
        private double balance;

        //закрытое поле типа System.Collections.Queue, которое будет хранить объекты класса
        //BankTransaction для данного банковского счета
        private readonly Queue<BankTransaction11> transactions = new Queue<BankTransaction11>();

        public static void GenNumber()
        {
            ++totalAccounts;
        }
        public int Number
        {
            get { return number; }

        }

        // Конструктор по умолчанию
        internal BankAccount11()
        {
            GenNumber();
        }

        // Конструктор для заполнения поля баланс
        internal BankAccount11(double balance)
        {
            GenNumber();
            this.balance = balance;
        }

        // Конструктор для заполнения поля типа банковского счета
        internal BankAccount11(TypeSchet11 type)
        {
            GenNumber();
            this.type = type;
        }

        // Конструктор для заполнения баланса и типа банковского счета
        internal BankAccount11(TypeSchet11 type, double balance)
        {
            GenNumber();
            this.type = type;
            this.balance = balance;
        }

        private TypeSchet11 Type
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
            Balance += value;

            BankTransaction11 transaction = new BankTransaction11(value);
            transactions.Enqueue(transaction);

            return $" Операция выполнена успешно. Баланс: {Balance}";
        }

        public string Withdraw(double value)
        {
            if (Balance - value >= 0)
            {
                BankTransaction11 transaction = new BankTransaction11(-value);
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

        public string Transfer_from_one_account_to_another(ref BankAccount11 account_from, double sum)
        {
            if (account_from.Balance - sum >= 0)
            {
                BankTransaction11 transaction = new BankTransaction11(sum);
                transactions.Enqueue(transaction);

                account_from.transactions.Enqueue(new BankTransaction11(-sum));

                account_from.Balance -= sum;
                balance += sum;
                return $"Операция выполнена успешно. \nБаланс аккаунта с которого совершен перевод: {account_from.Balance}. \nБаланс аккаунта на который совершен перевод: {Balance}";
            }

            return $" Недостаточно средств. Операция не выполнена. Баланс аккаунта с которого должен был произойти перевод:{account_from.Balance}";
        }

        public IEnumerable<BankTransaction11> GetTransactions()
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

    public class BankTransaction11
    {

        public readonly DateTime date;
        public readonly double sum;

        public BankTransaction11(double sum)
        {
            date = DateTime.Now;
            this.sum = sum;
        }
    }
}
