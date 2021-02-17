using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2.CUSTOM_SORT_DEMO
{
    class Program
    {
        public delegate bool TypeSort<T>(T firstItam, T secondItem);

        static void Main(string[] args)
        {
            string[] words = { "Hello", "World", "It's", "2017", "Year", "ddasdasdsa5555", "2", "555555", "6666dd" };

            WriteDate(words);

            Regularize(words, SortStringAbs);

            WriteDate(words);

            Console.ReadKey();
        }

        static void WriteDate<T>(T [] array)
        {
            foreach (var item in array)
            {
                Console.Write(String.Format($"{item} "));
            }

            Console.WriteLine();
        }

        private static bool SortStringAbs(string firstItam, string secondItem)
        {
            if (firstItam.Length == secondItem.Length)
            {
                return string.Compare(firstItam, secondItem)>0?true:false;
            }

            return firstItam.Length > secondItem.Length;
        }

        private static void FillArray<T>(T [] array, Random random, int minValue, int maxValue)
        {
            try
            {
                for (int i = 0; i < array.Length; i++)
                {

                    array[i] = (T)(object)random.Next(minValue, maxValue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удается заполнить массив типа {0} данными использую класс Random", array.GetType());
            }

        }

        static void Regularize<T>(T [] array, TypeSort<T> typeSort)
        {
            if (typeSort == null)
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

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
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
