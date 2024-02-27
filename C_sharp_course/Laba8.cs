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
    public enum TypeSchet //перечесление
    {
        Текущий,
        Сберегательный
    }
    public class BankAccount
    {
        private static int number = 0;
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

        public BankAccount()
        {
            GenNumber();
        }

        public BankAccount(Type type, double balance)
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

        public string Transfer_from_one_account_to_another(ref BankAccount account_from, double sum)
        {
            if (account_from.Balance - sum >= 0)
            {
                account_from.Balance -= sum;
                balance += sum;
                return $"Операция выполнена успешно. \nБаланс аккаунта с которого совершен перевод: {account_from.Balance}. \nБаланс аккаунта на который совершен перевод: {Balance}";
            }

            return $" Недостаточно средств. Операция не выполнена. Баланс аккаунта с которого должен был произойти перевод:{Balance}";
        }
    }

    public class Song
    {

        public Song(string name, string author, Song prev = null)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }

            public Song()
        {
        }

        public string Name { get; set; }
        public string Author { get; set; }
        public Song Prev { get; set; }

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
        public void SetPrev(Song prev)
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

            Song otherSong = (Song)obj;
            return Name == otherSong.Name && Author == otherSong.Author;
        }
    }


    public class Laba8
    {

        public static string reverse_string(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

            //char[] charArray = input.ToCharArray();
            //int left = 0;
            //int right = charArray.Length - 1;
            //while (left < right)
            //{
            //    char temp = charArray[left];
            //    charArray[left] = charArray[right];
            //    charArray[right] = temp;
            //    left++;
            //    right--;
            //}
            //return new string(charArray);
        }

        static void checkIFormattable(object o)
        {
            if (o is IFormattable)
            {
                IFormattable formattable = o as IFormattable;
                Console.WriteLine("Объект реализует интерфейс IFormattable.");
            }
            else
            {
                Console.WriteLine("Объект не реализует интерфейс IFormattable.");
            }
        }

        public static void SearchMail(ref string s)
        {
            string[] parts = s.Split('#');
            s = parts[1].Trim();
        }

        static void Main8(string[] args)
        {
            Console.WriteLine("Упражнение 8.1");
            BankAccount account1 = new BankAccount();
            account1.Type = Type.Текущий;
            account1.Balance = 1.9999;
            Console.WriteLine(account1.ToString()+"\n");

            BankAccount account2 = new BankAccount(Type.Сберегательный, 10);
            Console.WriteLine(account2.ToString() + "\n");

            Console.WriteLine(account1.Transfer_from_one_account_to_another(ref account2, 5));

            Console.WriteLine("\n\nУпражнение 8.2");
            string input = "!dlroW ,olleH";
            string reversed = reverse_string(input);
            Console.WriteLine(reversed);

            Console.WriteLine("\n\nУпражнение 8.3");
            Console.Write("Введите имя файла: \n");
            string? file = "z8_3.txt";
            Console.WriteLine(file);
            string projectDirectory = @"C:\\Users\\nyura\\source\\repos\\C_sharp_course\\C_sharp_course\\";
            string fullPath = projectDirectory+file;

            if (File.Exists(fullPath))
            {
                string output_file = "output.txt";

                try
                {
                    //z_8_3.txt
                    string text = File.ReadAllText(fullPath);
                    string upper_text = text.ToUpper();
 
                    File.WriteAllText(projectDirectory + output_file, upper_text);
                    Console.WriteLine($"Файл успешно обработан. Результат сохранен в {output_file}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Произошла ошибка при обработке файла: " + e.Message);
                }
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }

            Console.WriteLine("\n\nУпражнение 8.4");
            object obj = 9.5;
            checkIFormattable(obj);
            checkIFormattable(account1);


            Console.WriteLine("\n\nДомашнее задание 8.1");
            string directory = @"C:\\Users\\nyura\\source\\repos\\C_sharp_course\\C_sharp_course\\";
            string fileName = "dz8_1.txt";
            string path = directory + fileName;
            if (File.Exists(path))
            {
                string mails = "";
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        SearchMail(ref line);
                        mails += line + "\n";
                    }
                }
                string out_file = "dz8_1_out.txt";
                File.WriteAllText(directory + out_file, mails);
                Console.WriteLine($"Файл успешно обработан. Результат сохранен в {out_file}");
            }
            else
            {
                Console.WriteLine("Файл не существует.");
            }


            Console.WriteLine("\n\nДомашнее задание 8.2");
            List<Song> songs = new List<Song>();
            for (int i = 0; i < 4; i++){
                Song song = new Song();
                song.SetName("Song " + (i + 1));
                song.SetAuthor("Author " + (i + 1));
                if (i > 0){
                    song.SetPrev(songs[i - 1]);
                }
                songs.Add(song);
            }

            foreach (Song song in songs){
                Console.WriteLine(song.PrintSong());
            }
          
            bool areEqual = songs[0].Equals(songs[1]);
            if (areEqual){
                Console.WriteLine("Первая и вторая песни идентичны.");
            }
            else{
                Console.WriteLine("Первая и вторая песни различны.");
            }
        }
    }
}
