using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._7._VECTOR_GRAPHICS_EDITOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать!Для выхода из программы нажмите 'Escape'");

            do
            {
                Console.WriteLine("Для создания фигуры введите её номер. ");
                Console.WriteLine("1. Линия.");
                Console.WriteLine("2. Окружность.");
                Console.WriteLine("3. Прямоугольник.");
                Console.WriteLine("4. Круг.");
                Console.WriteLine("5. Кольцо.");

                int val = GetDate();

                switch (val)
                {
                    case 1:
                        Console.WriteLine("Для создания фигуры 'Линия'. Введите координаты начала (X,Y) и введите координаты конца (X,Y)");
                        Line line = new Line(GetValue(), GetValue(), GetValue(), GetValue());
                        Console.WriteLine(line);
                        break;

                    case 2:
                        Console.WriteLine("Для создания фигуры 'Окружность'. Введите координаты центра окружности (X,Y) и радиус");
                        Circle circle= new Circle(GetValue(), GetValue(), GetValue());
                        Console.WriteLine(circle);
                        break;

                    case 3:
                        Console.WriteLine("Для создания фигуры 'Прямоугольник'. Введите координаты вершины А (X,Y), высоту и ширину");
                        Rectangle rectangle= new Rectangle(GetValue(), GetValue(), GetValue(), GetValue());
                        Console.WriteLine(rectangle);
                        break;

                    case 4:
                        Console.WriteLine("Для создания фигуры 'Круг'. Введите координаты центра круга (X,Y) и радиус");
                        Disk disk= new Disk(GetValue(), GetValue(), GetValue());
                        Console.WriteLine(disk);
                        break;

                    case 5:
                        Console.WriteLine("Для создания фигуры 'Кольцо'. Введите координаты центра окружности (X,Y), внутренний и внешний радиус");
                        Ring ring= new Ring(GetValue(), GetValue(), GetValue(), GetValue());
                        Console.WriteLine(ring);
                        break;
                }


            } while (Console.ReadKey().Key!=ConsoleKey.Escape);
        }

        private static double GetValue()
        {
            double result = 0.0;

            if (double.TryParse(Console.ReadLine(),out double value))
            {
                result = value;
            }
            else
            {
                Console.WriteLine("Ошибка!Введите число!");
                result = GetValue();
            }

            return result;
        }

        private static int GetDate()
        {
            int result = 0;

           

            if (int.TryParse(Console.ReadLine(), out int value))
            {
                if (value > 0 && value < 6)
                {
                    result = value;
                }
                else
                {
                    Console.WriteLine("Ошибка!Введите целое число от 1 до 5");
                    result = GetDate();
                }
            }
            else
            {
                Console.WriteLine("Ошибка!Введите целое число от 1 до 5");
                result=GetDate();
            }

            return result;
        }
    }
}
