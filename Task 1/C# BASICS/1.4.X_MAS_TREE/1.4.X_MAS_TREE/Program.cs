using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4.X_MAS_TREE
{
    class Program
    {
        static void Main(string[] args)
        {
            char ch = '*';//символ из которого будет состоять строка
            int count =0;//количество треугольников для вывода на экран
            int countCh = 1;//переменная для храненяи количества символов в строке

            Console.WriteLine("Введите число треугольников для вывода на экране (целое число больше 0)");

            count = GetData();

            WriteXMasTree(ch,count,countCh);

            Console.ReadKey();
        }

        /// <summary>
        /// Выводит на экран консоли полученное "изображение"
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="count"></param>
        /// <param name="countCh"></param>
        private static void WriteXMasTree(char ch, int count,int countCh)
        {
            for (int i = 0; i < count; i++)
            {
                countCh = 1;
                for (int j = 0; j <= i; j++, countCh += 2)
                {
                    int countSpace = count - j;
                    string str = MyString(ch,countCh,countSpace); 
                    Console.WriteLine(str);
                }
            }
        }

        /// <summary>
        /// Создает новую строку согласно полученных значений
        /// </summary>
        /// <param name="ch">Символ из которого будет состоять тсрока</param>
        /// <param name="countCh">Количесвто символов в строке</param>
        /// <param name="countSpace">Количество пробелов в начале строки</param>
        /// <returns>Возвращает новую строку</returns>
        private static string MyString(char ch, int countCh, int countSpace)
        {
            return new string(' ', countSpace) + new string(ch, countCh);
        }

        /// <summary>
        /// Получает ввод от пользователя в консоли.
        /// Преобразует полученную строку в целочисленное значение больше 0.
        /// В случае успеха, возвращает это значение.
        /// </summary>
        /// <returns>Возвращает целое положительно число, неравное 0</returns>
        private static int GetData()
        {
            Console.WriteLine("Ввод: ");

            if (int.TryParse(Console.ReadLine(),out int value))
            {
                if (value>0)
                {
                    return value;
                }
                Console.WriteLine("Ошибка! Введите положительно число");
            }
            else
            {
                Console.WriteLine("Ошибка! Введите целое число больше 0");
            }

            return GetData();
        }
    }
}
