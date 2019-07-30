using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPositive
{
    //определяем делегат, который будет ссылаться на методы для работы с элементом трехмерного массива
    delegate void ItemArrayMod(int x, int y, int z, int[,,] array);

    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int[,,] threeDimensionalArray = new int[2,3,5];

            int[] arraySize = new int[threeDimensionalArray.Rank];//массива для хранения блины, каждого измерения массива

            for (int i = 0; i < arraySize.Length; i++)
            {
                arraySize[i] = threeDimensionalArray.GetUpperBound(i) + 1;
            }

            ItemArrayMod itemArrayMod = null;

            WorkWithArray(threeDimensionalArray, arraySize, itemArrayMod= PutValueInItemArray);

            WorkWithArray(threeDimensionalArray, arraySize, itemArrayMod = ShowValArray);

            WorkWithArray(threeDimensionalArray, arraySize, itemArrayMod =PutZero);

            WorkWithArray(threeDimensionalArray, arraySize, itemArrayMod = ShowValArray);

            Console.ReadKey();

        }

        /// <summary>
        /// Метод присваивающий элементу трехмерного массива случайно целое число от -10 до 10
        /// </summary>
        /// <param name="x">Строка</param>
        /// <param name="y">Столбец</param>
        /// <param name="z">Номер записи</param>
        /// <param name="array">Трехмерный массив</param>
        private static void PutValueInItemArray(int x, int y, int z,  int[,,] array)
        {
            array[x, y, z] = random.Next(-10, 10);
        }

        /// <summary>
        /// Массив присваивающий значение 0, положительному элементу данного массива
        /// </summary>
        /// <param name="x">Строка</param>
        /// <param name="y">Столбец</param>
        /// <param name="z">Номер записи</param>
        /// <param name="array">Трехмерный массив</param>
        private static void PutZero(int x, int y, int z, int[,,] array)
        {
            if (array[x,y,z]>0)
            {
                array[x, y, z] = 0;
            }
        }

        /// <summary>
        /// Метод для вывода на экран консоли значение элемента массива
        /// </summary>
        /// <param name="x">Строка</param>
        /// <param name="y">Столбец</param>
        /// <param name="z">Номер записи</param>
        /// <param name="array">Трехмерный массив</param>
        private static void ShowValArray(int x, int y, int z, int[,,] array)
        {
            Console.Write($"{array[x, y, z]} ");
        }

        /// <summary>
        /// Метод для работы с элементом трехмерного массива, в котором мы циклически работаем с каждым его элементом. 
        /// Характер действий производимых над элементом, зависит от того на какой метод ссылается делегат.
        /// </summary>
        /// <param name="threeDimensionalArray">Трехмерный массив целых чисел</param>
        /// <param name="arraySize">Массив хранящий длину измерений трехмерного массива</param>
        /// <param name="itemArrayMod">Переменная типа делегат, хранаящая ссылку на метод для работы с элементом данного массива</param>
        private static void WorkWithArray(int [,,] threeDimensionalArray, int [] arraySize, ItemArrayMod itemArrayMod)
        {
            for (int x = 0; x < arraySize[0]; x++)
            {
                for (int y = 0; y < arraySize[1]; y++)
                {
                    for (int z = 0; z < arraySize[2]; z++)
                    {
                        itemArrayMod(x, y, z, threeDimensionalArray);
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
