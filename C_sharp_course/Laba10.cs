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
    interface ICipher
    {
        string encode(string s);
        string decode(string s);
    }

    class ACipher : ICipher {

        public string encode(string s)
        {
            char[] a = s.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i]))
                {
                    if(a[i] == 'z' || a[i] == 'Z'){
                        a[i] = (char)(a[i] - 25);
                    }
                    else if(a[i] == 'я' || a[i] == 'Я')
                    {
                        a[i] = (char)(a[i] - 31);
                    }
                    else { a[i] = (char)(a[i] + 1); }
                  
                }
            }

            return new string(a);
        }

        public string decode(string s)
        {
            char[] a = s.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i]))
                {

                    if (a[i] == 'a' || a[i] == 'A')
                    {
                        a[i] = (char)(a[i] + 25);
                    }
                    else if (a[i] == 'а' || a[i] == 'А')
                    {
                        a[i] = (char)(a[i] + 31);
                    }
                    else { a[i] = (char)(a[i] - 1); }
                }
            }

            return new string(a);
        }

    }

    class BCipher : ICipher
    {
        private bool isRussian;

        public BCipher(bool isRussian = false)
        {
            this.isRussian = isRussian;
        }
        public string encode(string s)
        {
            char[] a = s.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i]))
                {
                    if (isRussian)
                    {
                        if (char.IsLower(a[i]))
                        {
                            a[i] = (char)('я' - (a[i] - 'а'));
                        }
                        else
                        {
                            a[i] = (char)('Я' - (a[i] - 'А'));
                        }
                    }
                    else
                    {
                        if (char.IsLower(a[i]))
                        {
                            a[i] = (char)('z' - (a[i] - 'a'));
                        }
                        else
                        {
                            a[i] = (char)('Z' - (a[i] - 'A'));
                        }
                    }
                }
            }

            return new string(a);
        }

        public string decode(string s)
        {
            char[] a = s.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i]))
                {
                    if (isRussian)
                    {
                        if (char.IsLower(a[i]))
                        {
                            a[i] = (char)(('я' - a[i]) + 'а');
                        }
                        else
                        {
                            a[i] = (char)(('Я' - a[i]) + 'А');
                        }
                    }
                    else
                    {
                        if (char.IsLower(a[i]))
                        {
                            a[i] = (char)(('z' - a[i]) + 'a');
                        }
                        else
                        {
                            a[i] = (char)(('Z' - a[i]) + 'A');
                        }
                    }
                }
            }

            return new string(a);
        }

    }

    public abstract class Figure
    {
        private string color;
        private bool isVisible;

        public Figure(string color, bool isVisible)
        {
            this.color = color;
            this.isVisible = isVisible;
        }

        public void move_horizontal(double distance)
        {
            Console.WriteLine($"Moving the figure {distance} horizontally.");
        }

        public void move_vertical(double distance)
        {
            Console.WriteLine($"Moving the figure {distance} vertically.");
        }

        public void change_color(string newColor)
        {
            color = newColor;
            Console.WriteLine($"Changing the color to {newColor}.");
        }

        public void change_visible()
        {
            isVisible = !isVisible;
            Console.WriteLine(isVisible ? "Figure is now visible." : "Figure is now invisible.");
        }

        public void print()
        {
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Visibility: {isVisible}");
        }
    }
    public class Point : Figure
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Point(int x, int y, string color, bool isVisible) : base(color, isVisible)
        {
            this.x = x;
            this.y = y;
        }

        public void move_horizontal(int distance)
        {
            Console.WriteLine($"Moving the point {distance} horizontally.");
            x += distance;
        }

        // Наследованный от Figure метод для передвижения по вертикали
        public void move_vertical(int distance)
        {
            Console.WriteLine($"Moving the point {distance} vertically.");
            y += distance;
        }

        public void move_to(int newX, int newY)
        {
            Console.WriteLine($"Moving point to coordinates: ({newX}, {newY}).");
            x = newX;
            y = newY;
        }

        public void print_Point()
        {
            Console.WriteLine($"Point Info:");
            Console.WriteLine($"Coordinates: ({x}, {y})");
            print();
        }
    }

    public class Circle : Point
    {
        protected double radius;

        public Circle(int x, int y, double radius, string color, bool isVisible) : base(x, y, color, isVisible)
        {
            this.radius = radius;
        }

        public double area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public void print()
        {
            Console.WriteLine($"Circle Info:");
            print_Point();
            Console.WriteLine($"Radius: {radius}");
            Console.WriteLine($"Area: {area()}");
        }
    }

    public class Rectangle : Point
    {
        protected double width;
        protected double height;

        public Rectangle(int x, int y, double width, double height, string color, bool isVisible) : base(x, y, color, isVisible)
        {
            this.width = width;
            this.height = height;
        }

        public double area()
        {
            return width * height;
        }

        public void print()
        {
            Console.WriteLine($"Rectangle Info:");
            print_Point();
            Console.WriteLine($"Width: {width}");
            Console.WriteLine($"Height: {height}");
            Console.WriteLine($"Area: {area()}");
        }
    }


    public class Laba10
    { 


        static void Main10(string[] args)
        {
            Console.WriteLine("Упражнение 10.1");

            //Класс шифрует строку посредством сдвига каждого символа на одну «алфавитную» позицию выше.
            //Например, в результате такого сдвига буква А становится буквой Б.
            ACipher cipher = new ACipher();

            string originalText = "Hello, World!";
            Console.WriteLine("Original Text: " + originalText);
            string encodedText = cipher.encode(originalText);
            Console.WriteLine("Encoded Text: " + encodedText);
            string decodedText = cipher.decode(encodedText);
            Console.WriteLine("Decoded Text: " + decodedText);

            string originalText1 = "Привет, мир!";
            Console.WriteLine("\nOriginal Text: " + originalText1);
            string encodedText1 = cipher.encode(originalText1);
            Console.WriteLine("Encoded Text: " + encodedText1);
            string decodedText1 = cipher.decode(encodedText1);
            Console.WriteLine("Decoded Text: " + decodedText1);


            Console.WriteLine("BCipher");
            //шифрует строку, выполняя замену каждой буквы, стоящей в алфавите на i-й позиции, на
            //букву того же регистра, расположенную в алфавите на i - й позиции с конца
            //алфавита.Например, буква В заменяется на букву Э.
            BCipher bcipher = new BCipher();

            string originalText2 = "Hello, World!";
            Console.WriteLine("\nOriginal Text: " + originalText2);
            string encodedText2 = bcipher.encode(originalText2);
            Console.WriteLine("Encoded Text: " + encodedText2);
            string decodedText2 = bcipher.decode(encodedText2);
            Console.WriteLine("Decoded Text: " + decodedText2);
            BCipher bcipher_ru = new BCipher(true);
            string originalText3 = "Привет, мир!";
            Console.WriteLine("\nOriginal Text: " + originalText3);
            string encodedText3 = bcipher_ru.encode(originalText3);
            Console.WriteLine("Encoded Text: " + encodedText3);
            string decodedText3 = bcipher_ru.decode(encodedText3);
            Console.WriteLine("Decoded Text: " + decodedText3);


            Console.WriteLine("\n\nДомашнее задание 10.1");

            Circle myCircle = new Circle(1, 2, 3.5, "Red", true);
            Rectangle myRectangle = new Rectangle(4, 5, 6, 7, "Blue", false);

            myCircle.print();
            myCircle.move_horizontal(5);
            myCircle.change_visible();
            Console.WriteLine("");
            myCircle.print();
      
            Console.WriteLine("");

            myRectangle.print();
            myRectangle.move_vertical(3);
            myRectangle.change_visible();
            Console.WriteLine("");
            myRectangle.print();

            //Интерфейс (IColored):

            //Метод: void ChangeColor(string newColor) -для изменения цвета.
            //Свойство: string Color -для получения текущего цвета.


            //Абстрактный класс(Figure):

            //Поле: string color -для хранения цвета фигуры.
            //Поле: bool isVisible -для состояния "видимо/невидимо".
            //Метод: abstract void print() - абстрактный метод для вывода информации о фигуре.
            //Метод: void visibility() - для изменения состояния видимости.
            //Метод: virtual void move horizontal(int distance) - виртуальный метод для передвижения по горизонтали.
            //Метод: virtual void move vertical(int distance) - виртуальный метод для передвижения по вертикали.


            //Класс Point (наследник от Figure):

            //Поле: int X, int Y - координаты точки.
            //Метод: void move to(int newX, int newY) - для перемещения точки в указанные координаты.
            //Перегрузка метода move horizontal и move vertical для точечной фигуры.


            //Класс Circle (наследник от Point):

            //Поле: double radius - радиус окружности.
            //Метод: double area() - для вычисления площади окружности.
            //Перегрузка метода print для отображения информации о круге.


            //Класс Rectangle (наследник от Point):

            //Поля: double width, double height - ширина и высота прямоугольника.
            //Метод: double area() - для вычисления площади прямоугольника.
            //Перегрузка метода print для отображения информации о прямоугольнике.
        }
    }
}
