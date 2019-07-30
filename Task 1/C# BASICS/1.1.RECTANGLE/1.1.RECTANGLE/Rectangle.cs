using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1.RECTANGLE
{
    class Rectangle
    {
        static void Main(string[] args)
        {
            int length = 0;//длина прямоугольника
            int width = 0;//ширина прямоугольника
            int area = 0;//площадь прямоугольника

            Console.WriteLine("Введите значение длины и ширины прямоугольника (значения должны быть целыми числами)");

            Console.WriteLine("Значение длины");
            GetData(out length);

            Console.WriteLine("Значение ширины");
            GetData(out width);

            area=GetArea(length,width);

            Console.WriteLine($"Площадь прямоугольной фигуры с длиной {length} и шириной {width}: равна {area}");
        }

        /// <summary>
        /// Метод вычисляющий площадь прямоугольной фигуры
        /// </summary>
        /// <param name="length">Длина прямоугольной фигуры</param>
        /// <param name="width">Ширина прямоугольной фигуры</param>
        /// <returns>Полученная площадь фигуры</returns>
        private static int GetArea(int length, int width)
        {
            return length * width;
        }

        /// <summary>
        /// Присваивает введенное значение в консоли. Возвращает целочисленное значение, в случае успеха.
        /// </summary>
        /// <param name="value">Переменная, в которой будет содержаться возвращаемое значение</param>
        private static void GetData(out int value)
        {
            Console.Write("Вы ввели: ");

            if (int.TryParse(Console.ReadLine(),out int val))
            {
                if (val>0)
                {
                    value = val;
                    return;
                }
                Console.WriteLine("Ошибка!Значение должно быть больше 0");
            }
            else
            {
                Console.WriteLine("Вы ввели некоректное значение");
               
            }

            GetData(out value);
        }
    }
}
