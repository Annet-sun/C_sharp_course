using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_course
{
    public class Laba5
    {
        static int MaxInt(int a, int b)
        {
            return (a > b ? a : b);
        }
        static void Swap (ref int a,ref int b)
        {
            int tmp = a;
            a=b; 
            b=tmp;
        }

        static bool Fact(out int x, int n)
        {
            x = 0;
            checked
            { try
                {
                    int rez = 1;
                    int i = 1;
                    while (i <= n)
                    {
                        rez *= i; i++;
                    }
                    x = rez;
                    return true;
                    

                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка переполнения");
                    return false;
                }

            }     
        }

        static int Fact2(int a)
        {
            if (a == 1) return 1;
            return a*Fact2(a-1);
        }

        static int Nod(int a, int b)
        {
            if (a > b)
            {
               return Nod(a-b,b);
                
            }
            else if (b > a)
            {
                return Nod(b-a,a);
            }
            return a;
        }

        static int Nod(int a, int b, int c)
        {
            return Nod(Nod(a,b),c);
        }

        static int Fibonachi(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fibonachi(n-1)+Fibonachi(n-2);
        }



        static void Main2(string[] args)
        {   
            int a = 5;
            int b = 7;
            Console.WriteLine("1) Наибольшее число "+MaxInt(a, b));
            
            Swap(ref a,ref b);
            Console.WriteLine("2) a = "+a+" b = "+b);
            int x;
            int n = 4;
            Console.WriteLine("3) Факториал 1 \n"+ Fact(out x, n));
            Console.WriteLine(x);

            Console.WriteLine("4) Факториал 2 \n" + Fact2(14));

            Console.WriteLine("дз1) Нод двух чисел = "+ Nod(14,21));

            Console.WriteLine("дз1) Нод трех чисел = " + Nod(186, 465, 434));

            Console.WriteLine("дз2) Число Фибоначчи = " + Fibonachi(6));

        }
    }
}
