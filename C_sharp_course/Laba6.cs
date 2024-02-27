using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C_sharp_course
{
    public class Laba6
    {
        String file = "C:\\Users\\nyura\\source\\repos\\C_sharp_course\\C_sharp_course\\Laba6.txt";
        
        static void kolvo_glas_soglas_bukv(char[] text)
        {   char[] vowels = "АЕЁИОУЫЭЮЯ".ToLower().ToCharArray(); //Гласные
            char[] consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray(); //Согласные
            int glasn = 0;
            int soglasn = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (vowels.Contains(char.ToLower(text[i])))
                        glasn++;
                    else if (consonants.Contains(char.ToLower(text[i])))
                    {
                        soglasn++;
                    }
                }
            }
            Console.WriteLine("1) Количество гласных букв = " + glasn + "\n   Количество согласных букв = " + soglasn);
        }


        static void print_matrix(int[,] a)
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++) s+=a[i, j] + " ";
                s += "\n";
            }
            Console.WriteLine(s.Remove(s.Length - 1));
        }


        static int[,] multiplication_matrix(int[,] a,int[,] b){
            if (a.GetLength(1) != b.GetLength(0)) { throw new Exception("Матрицы нельзя перемножить"); }

            int ma = a.GetLength(0);
            int mb = b.GetLength(0);
            int nb = b.GetLength(1);

            int[,] r = new int[ma, nb];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < nb; j++)
                {
                    for (int k = 0; k < mb; k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }

        static double[] average_temperature(int[,] t)
        {
            int sum = 0;
            double [] a = new double[t.GetLength(0)];
            for (int i = 0; i < t.GetLength(0); i++){
                sum = 0;
                for (int j = 0; j < t.GetLength(1); j++){
                    sum += t[i, j];
                }
                a[i] = sum/ t.GetLength(1);
            }
            return a;
        }


        static void print_matrix2(LinkedList<LinkedList<int>> matrix)
        {
            string s = "";
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    s+=element + " ";
                }
                s += "\n";
            }
            Console.WriteLine(s.Remove(s.Length - 1));
        }

        static LinkedList<LinkedList<int>> multiply_matrix2(LinkedList<LinkedList<int>> matrixA, LinkedList<LinkedList<int>> matrixB)
        {
            var resultMatrix = new LinkedList<LinkedList<int>>();
            int rowsA = matrixA.Count;
            int columnsA = matrixA.First.Value.Count;
            int columnsB = matrixB.First.Value.Count;

            for (int i = 0; i < rowsA; i++)
            {
                var newRow = new LinkedList<int>();
                for (int j = 0; j < columnsB; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < columnsA; k++)
                    {
                        sum += matrixA.ElementAt(i).ElementAt(k) * matrixB.ElementAt(k).ElementAt(j);
                    }
                    newRow.AddLast(sum);
                }
                resultMatrix.AddLast(newRow);
            }

            return resultMatrix;
        }

        static Dictionary<string,double> average_temperature2(Dictionary<string, int[]> t)
        {
            int sum = 0;
            Dictionary<string, double> a = new Dictionary<string, double>();
            foreach(var kvp in t)
            {
                string key = kvp.Key;
                int[] ints = kvp.Value;
                double value = ints.Sum()/ints.Length;
                a.Add(key, value);
            }
            return a;
        }

        static List<KeyValuePair<string, double>> sort_temperature2(Dictionary<string, double> avg)
        {
            var sortedTemperatures = new List<KeyValuePair<string, double>>(avg);

            sortedTemperatures.Sort((x, y) => x.Value.CompareTo(y.Value));

            return sortedTemperatures;
        }

        static void Main3(string[] args)
        {
            //1
            string path = args[0];
            string fileContent = File.ReadAllText(path, Encoding.UTF8);
            char[] text = fileContent.ToCharArray();
            Console.WriteLine(text);
            kolvo_glas_soglas_bukv(text);

            Console.WriteLine("2)");
            //2_____________________________________________________________________________________________________________________________
            int[,] mas1 = new int[2, 3] {{ 2, 3, 4 }, { 5, 6, 7 }};
            int[,] mas2 = new int[3, 2] {{ 0, 0 }, { 0, 1 }, {0 ,1 }};
            print_matrix(mas1);
            Console.WriteLine("*");
            print_matrix(mas2);
            Console.WriteLine("=");
            print_matrix(multiplication_matrix(mas1,mas2));


            Console.WriteLine();
            //3_____________________________________________________________________________________________________________________________
            Random rand = new Random();
            int[,] temperature = new int[12, 30];
            for (int i=0; i<temperature.GetLength(0);i++) {
                for(int j=0; j<temperature.GetLength(1);j++)
                {
                    temperature[i, j] = rand.Next(-40, 40);
                }
            }
            double[] avg = average_temperature(temperature);
            Console.WriteLine("3) Массив средних температур:");
            System.Array.Sort(avg);
            String str= "";
            foreach (int i in avg) str+=i+" ";
            Console.WriteLine(str);


            //дз1_____________________________________________________________________________________________________________________________
            List<char> consonants = new List<char> {'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'ч', 'ц', 'ч', 'ш', 'щ' };
            List<char> vowels = new List<char> { 'а', 'о', 'ы', 'и', 'у', 'э', 'ё', 'я', 'е', 'ю' };
            List<char> text2 = new List<char>(fileContent.ToCharArray());
           
            Console.WriteLine("\n1) Количество гласных букв = " + text2.FindAll(p => vowels.Contains(char.ToLower(p))).Count + 
                "\n   Количество согласных букв = " + text2.FindAll(p => consonants.Contains(char.ToLower(p))).Count);

            //дз2_____________________________________________________________________________________________________________________________
            Console.WriteLine("дз2)");
            var matrixA = new LinkedList<LinkedList<int>>();
            matrixA.AddLast(new LinkedList<int>(new int[] { 2, 3, 4 }));
            matrixA.AddLast(new LinkedList<int>(new int[] { 5, 6, 7 }));

            var matrixB = new LinkedList<LinkedList<int>>();
            matrixB.AddLast(new LinkedList<int>(new int[] { 0, 0 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 0, 1 }));
            matrixB.AddLast(new LinkedList<int>(new int[] { 0, 1 }));
        
            print_matrix2(matrixA);
            Console.WriteLine("*");
            print_matrix2(matrixB);

            var resultMatrix = multiply_matrix2(matrixA, matrixB);

            Console.WriteLine("=");
            print_matrix2(resultMatrix);


            //дз3_____________________________________________________________________________________________________________________________
            Dictionary<string, int[]> temperature2 = new Dictionary<string, int[]>();
            string[] month = new string []{ "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь", "декабрь" };
            
            foreach (string s in month)
            {   int[] t = new int[30];
                for (int j = 0; j < t.Length; j++)
                {
                    t[j] = rand.Next(-40, 40);
                }
                temperature2.Add(s, t);
            }
            Dictionary<string, double> avg2= average_temperature2(temperature2);

            Console.WriteLine("3) Отсортированные средние температуры за год:");
            foreach (var kvp in sort_temperature2(avg2))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}°C");
            }

        }
    }
}
