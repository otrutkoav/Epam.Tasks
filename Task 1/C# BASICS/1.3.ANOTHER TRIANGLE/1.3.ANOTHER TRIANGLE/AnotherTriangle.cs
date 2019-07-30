using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.ANOTHER_TRIANGLE
{
    class AnotherTriangle
    {
        static void Main(string[] args)
        {
            char ch = '*';//символ из которого будет состоять строка
            int count = 0;//количество выводимых строк
            int countCh = 1;//количество символов в строке

            Console.WriteLine("Укажите количество строк(целое число больше 0)");

            count = GetData();

            WriteAnotherTriangle(ch,count,countCh);

            Console.ReadKey();

        }

        /// <summary>
        /// Выводит в консоль, заданное количество строк, 
        /// которые состоят из заданного количества указанного символа
        /// </summary>
        /// <param name="ch">Символ из которого будет состоять строка</param>
        /// <param name="count">Количество строк</param>
        /// <param name="countCh">Количество символов в строке</param>
        private static void WriteAnotherTriangle(char ch, int count, int countCh)
        {
            int countSpace = 0;//переменная для хранения количества пробелов в начале строки

            for (int i = 1; i <= count; i++, countCh += 2)
            {
                countSpace = count - i;
                string str = MyString(ch,countSpace, countCh);
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Возвращает новую строку, созданную на основе полученных значений
        /// </summary>
        /// <param name="ch">Символ из которого будет состоять строка</param>
        /// <param name="count"></param>
        /// <param name="countSpace">Количество пробелов в начале строки</param>
        /// <returns>Новая строка созданная согласно полученных данных</returns>
        private static string MyString(char ch, int countSpace, int countCh)
        {
            return new string(' ', countSpace) + new string(ch, countCh);
        }

        /// <summary>
        /// Считывает пользовательский ввод в консоли,
        /// затем преобразует строковое представление в целочисленное положительное значение 
        /// и в случае успеха возвращает его. В противном случае сообщает об ошибке
        /// и продолжит запрашивать пользовательский ввод, пока не будет введено уорректное значение.
        /// </summary>
        /// <returns>Положительное целочисленное значение</returns>
        private static int GetData()
        {
            Console.Write("Ввод: ");
            if (int.TryParse(Console.ReadLine(),out int value))
            {
                if (value>0)
                {
                    return value;
                }

                Console.WriteLine("Ошибка!Введите число больше 0");
            }
            else
            {
                Console.WriteLine("Ошибка!Введите целое положительное число");
            }

            return GetData();
        }
    }
}
