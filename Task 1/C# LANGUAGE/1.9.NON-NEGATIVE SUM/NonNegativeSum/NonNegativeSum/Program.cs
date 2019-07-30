using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonNegativeSum
{
    delegate void WorkArrayElement(int []array, int index);

    class Program
    {
        static Random Random= new Random();

        static int sum = 0;

        static void Main(string[] args)
        {
            int[] array = new int[10];

            WorkArrayElement workArrayElement = null;

            CycleForWorkArray(array,workArrayElement=AssignValueElement);

            CycleForWorkArray(array, workArrayElement = WriteElement);

            Console.WriteLine();

            CycleForWorkArray(array, workArrayElement = CalculetAmount);

            Console.WriteLine($"Сумма положительных элементов массива равна: {sum}");
        }

        /// <summary>
        /// Метод для работы с элементами одномерного массива в цикле.
        /// Характер работа зависет от значения делегата.
        /// </summary>
        /// <param name="array">Целочисленный одномерный массив</param>
        /// <param name="workArrayElement">Делегат хранящий ссылку на метод для работы с элементом</param>
        private static void CycleForWorkArray(int[] array, WorkArrayElement workArrayElement)
        {
            for (int i = 0; i < array.Length; i++)
            {
                workArrayElement(array,i);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Метод присваивающий элементу массива по указанному индексу случайное целочисленное значение от -15 до 15
        /// </summary>
        /// <param name="array">Целочисленный одномерный массив</param>
        /// <param name="index">Индекс элемента</param>
        private static void AssignValueElement(int [] array,int index)
        {
            array[index] = Random.Next(-15,15);
        }

        /// <summary>
        /// Метод вычисляющий сумму положительных элементов целочисленного одномерного массива
        /// </summary>
        /// <param name="array">Целочисленный одномерный массив</param>
        /// <param name="index">Индекс элемента</param>
        private static void CalculetAmount(int[] array, int index)
        {
            if (array[index]>0)
            {
                Console.WriteLine($"{sum}+{array[index]} = {sum += array[index]}");           
            }
        }

        /// <summary>
        /// Метод выводящий на экран консоли значение элемента массива по указанному индексу
        /// </summary>
        /// <param name="array">Целочисленный одномерный массив</param>
        /// <param name="index">Индекс элемента</param>
        private static void WriteElement(int[] array, int index)
        {
            Console.Write($"{array[index]} ");
        }
    }
}
