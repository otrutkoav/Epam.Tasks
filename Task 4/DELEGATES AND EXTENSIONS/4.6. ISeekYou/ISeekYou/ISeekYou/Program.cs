using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISeekYou
{
    public delegate bool Condition(int i);

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            array.FillIntArrayVoid();

            Condition condition = NoPositive;

            //Простой метод поиска 
            var positivItems = array.FindItems();

            //Передаем через экземпляр делегата
            var noPositivItems = FindItems(array, condition);

            //Передаем через анонимные методы
            var positivOddItems = array.FindItems(delegate(int i) 
                {
                    return (i > 0 && i % 2 != 0);
                }
            );

            //Передаем через лямбда выражение
            var positivEvenItems = array.FindItems((i) => i > 0 && i%2==0);

            //LINQ
            var evenItems = FindItems(array);

            Console.WriteLine("Изначальный массив {0} ",String.Join(", ", array));
            Console.WriteLine();
            Console.WriteLine("Положительные элементы массива {0} ", String.Join(", ", positivItems));
            Console.WriteLine();
            Console.WriteLine("Отрицательные элементы массива {0} ", String.Join(", ", noPositivItems));
            Console.WriteLine();
            Console.WriteLine("Положительные нечетные элементы массива {0} ", String.Join(", ", positivOddItems));
            Console.WriteLine();
            Console.WriteLine("Положительные четные элементы массива {0} ", String.Join(", ", positivEvenItems));
            Console.WriteLine();
            Console.WriteLine("Четные элементы массива {0} ", String.Join(", ", evenItems));
        }

        public static IEnumerable<int> FillArray(int length)
        {
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                yield return random.Next(-100,100);
            }
        }

        public static bool NoPositive(int i)
        {
            return i < 0;
        }

        public static IEnumerable<int> FindItems(int[] array, Condition condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition!=null)
                {
                    if (condition(array[i]))
                    {
                        yield return array[i];
                    }
                }
            }
        }

        public static IEnumerable<int> FindItems(int[] array)
        {
           var result=from item in array
                      where item%2==0
                      select item;

            return result;
        }
    }

    //Эксперименты для закрепления и интереса, вместо методов сделал расширения
    public static class Array
    {
        public static IEnumerable<int> FillIntArray(this int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                yield return random.Next(-100, 100);
            }
        }

        public static void FillIntArrayVoid(this int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i]= random.Next(-100, 100);
            }
        }

        public static IEnumerable<int> FindItems(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]>0)
                {
                    yield return array[i];
                }
            }
        }

        public static IEnumerable<int> FindItems(this int[] array, Predicate<int> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (condition!=null)
                {
                    if (condition(array[i]))
                    {
                        yield return array[i];
                    }
                }
            }
        }
    }
}
