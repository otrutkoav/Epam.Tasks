using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1.CUSTOM_SORT
{
    class Program
    {
        delegate bool TypeSort(dynamic firstItam, dynamic secondItem);

        static void Main(string[] args)
        {
            Random random = new Random();

            int[] arrInt = new int[10];

            double [] arrDouble = new double[10];

            char[] arrChar = new char [] { 'ю', 'п', 'к', 'л', 'д', 'е', 'р', 'ц', 'к' };

            FillArray(arrInt, random, 1, 100);
            FillArray(arrDouble, random, 1, 100);

            Regularize(arrInt, SortAbc);

            Regularize(arrDouble, DESC);

        }

        private static void FillArray(dynamic array, Random random, int minValue, int maxValue)
        {
            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(minValue, maxValue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удается заполнить массив типа {0} данными использую класс Random", array.GetType());
            }
          
        }

        static void Regularize(dynamic array, TypeSort typeSort)
        {
            if (typeSort==null)
            {
                throw new Exception("Нет ссылки на метод!");
            }
            else
            {
                try
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = i + 1; j < array.Length; j++)
                        {
                            if (typeSort(array[i], array[j]))
                            {
                                Swap(array, i, j);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Нужно перегрузить операции > и < для типа {0}", array.GetType());
                }
              
            }
        }

        private static void Swap(dynamic array, int i, int j)
        {
            dynamic temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static bool SortAbc(dynamic f, dynamic s)
        {
            return f > s ? true : false;
        }

        static bool DESC(dynamic f, dynamic s)
        {
            return f < s ? true : false;
        }
    }
}
