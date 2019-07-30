using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2.TRIANGLE
{
    class Triangle
    {

        static void Main(string[] args)
        {
            char ch = '*';//символ из которого будет состоять строка
            int count = 0;//количество сиволов в строке и строк в "треугольнике"

            Console.WriteLine("Введите целочисленное число больше 0");

            count = GetData();

            WriteTriangle(ch,count);


        }

        /// <summary>
        /// Выводит в консоль указанное количество символов и строк, состоящие из указанного символа.
        /// </summary>
        /// <param name="ch">Символ тз которого будет состоять строка</param>
        /// <param name="count">Количество символов в строке, и количество выводимых строк</param>
        private static void WriteTriangle(char ch, int count)
        {
            for (int i = 1; i <=count; i++)
            {
                string str = new string(ch,i);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Считывает пользовательский ввод в консоле, при вверном вводе вызвращает целое число.
        /// </summary>
        /// <returns>Возвращает целочисленное значение</returns>
        private static int GetData()
        {
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(),out int value))
            {
                if (value>0)
                {
                    return value;
                }
                Console.WriteLine("Введите положительное целое число!!!");
            }
            else
            {
                Console.WriteLine("Ошибка!Неккоректный ввод целого положительного числа!");
            }

            return GetData();
        }
    }
}
