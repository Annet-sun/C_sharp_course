using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using BankingSystem;

namespace C_sharp_course
{
   
    public class Laba11
    {
        static void printAccountInfo(int accountNumber, BankAccountFactory factory)
        {
            BankAccount11 account = factory.GetAccount(accountNumber);
            if (account != null)
            {
                // Выводим информацию о счете
                Console.WriteLine(account.ToString());
            }
            else
            {
                Console.WriteLine($"Account {accountNumber} not found.");
            }
        }

        static void Main11(string[] args)
        {
            Console.WriteLine("Упражнение 11.1");

            //cd C:\Users\nyura\source\repos\C_sharp_course\C_sharp_course\bin\Debug\net6.0

            //C:\Users\nyura\.nuget\packages\microsoft.netcore.ildasm\6.0.0\runtimes\native\ildasm.exe C_sharp_course.dll /out= msilapp.il

            // Или C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools
            // cd C:\Program Files (x86)\Microsoft SDKs\Wind
            // ildasm.exe C: \Users\nyura\source\repos\C_sharp_course\C_sharp_course\bin\Debug\net6.0\C_sharp_course.dll

            // Создаем фабрику банковских счетов
            BankAccountFactory accountFactory = new BankAccountFactory();

            // Создаем счета с разными параметрами
            int accountNumber1 = accountFactory.CreateAccount();
            int accountNumber2 = accountFactory.CreateAccount(1000.0);
            int accountNumber3 = accountFactory.CreateAccount(TypeSchet11.Сберегательный);
            int accountNumber4 = accountFactory.CreateAccount(TypeSchet11.Текущий, 5000.0);

            // Выводим информацию о счетах
            printAccountInfo(accountNumber1, accountFactory);
            printAccountInfo(accountNumber2, accountFactory);
            printAccountInfo(accountNumber3, accountFactory);
            printAccountInfo(accountNumber4, accountFactory);

            // Закрываем один из счетов
            accountFactory.CloseAccount(accountNumber2);

            // Попытка вывести информацию о закрытом счете вызовет сообщение об ошибке
            printAccountInfo(accountNumber2, accountFactory);

        }
    }
}
