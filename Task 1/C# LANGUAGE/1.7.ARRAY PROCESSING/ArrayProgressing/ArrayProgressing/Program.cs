using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProgressing
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1,10);
            }

            Console.WriteLine("Неотсортированный массив");
            ShowArrayVal(array);

            GetMinVal(array);

            GetMaxVal(array);

            SortArray(ref array);

            Console.WriteLine("Отсортированный массив");
            ShowArrayVal(array);

            Console.ReadKey();
        }

        /// <summary>
        /// Метод соритрующий массив в порядке возрастания
        /// </summary>
        /// <param name="array">Массив элементов</param>
        private static void SortArray(ref int[] array)
        {
            for (int i = 0; i<=array.Length-2; i++)
            {
                int indexMin = i;
                for (int j = i+1; j <=array.Length-1; j++)
                {
                    if (array[j]<array[indexMin])
                    {
                        indexMin = j;
                    }
                }
                if (indexMin!=i)
                {
                    int buffer = array[i];
                    array[i] = array[indexMin];
                    array[indexMin] = buffer;
                }
            }
        }

        /// <summary>
        /// Метод который находит и показывает максимальное значение среди элементов массива
        /// </summary>
        /// <param name="array">Массив элементов</param>
        private static void GetMaxVal(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                max = array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    if (max < array[j])
                    {
                        max = array[j];
                    }
                }
            }

            Console.WriteLine($"Максимальный элемент массива {max}");
        }

        /// <summary>
        /// Метод который находит и выводит на экран минимальное значение среди элементов массива
        /// </summary>
        /// <param name="array">Массив элементов</param>
        private static void GetMinVal(int[] array)
        {
            int min = 0;
            for (int i = 0; i < array.Length; i++)
            {
                min = array[i];
                for (int j = 0; j < array.Length; j++)
                {
                    if (min>array[j])
                    {
                        min = array[j];
                    }
                }
            }

            Console.WriteLine($"Минимальный элемент массива {min}");
        }

        /// <summary>
        /// Метод выводящий элементы массива
        /// </summary>
        /// <param name="array">Массив элементов</param>
        private static void ShowArrayVal(int [] array)
        {
            string result = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                result += $"{array[i]}, ";
            }

            Console.WriteLine(result.TrimEnd(',',' '));
        }
    }
}
