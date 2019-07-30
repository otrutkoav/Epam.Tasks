using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDArray
{
    class Program
    {
        readonly static Random Random = new Random();
        static int sum = 0;

        static void Main(string[] args)
        {
            int[,] twoArray = new int[3,5];

            int[] arraySize = new int[twoArray.Rank];

            for (int i = 0; i <arraySize.Length; i++)
            {
                arraySize[i] = twoArray.GetUpperBound(i)+1;
            }

            AssignValue(twoArray,arraySize);

            WriteArray(twoArray);

            CalculetAmount(twoArray, arraySize);

            Console.WriteLine(sum);
        }

        private static void CalculetAmount(int[,] twoArray, int[] arraySize)
        {
            Console.WriteLine("______________________________________________________________");
            for (int x = 0; x < arraySize[0]; x++)
            {
                for (int y = 0; y < arraySize[1]; y++)
                {
                    if (IsEven(x,y))
                    {
                        Console.WriteLine($"{sum}+{twoArray[x, y]}={ sum += twoArray[x, y]}");
                    }
                }
            }
            Console.WriteLine("______________________________________________________________");
        }

        private static bool IsEven(int x, int y)
        {
            return (x + y) % 2 == 0;
        }

        private static void WriteArray(int[,] twoArray)
        {
            foreach (var item in twoArray)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        static void AssignValue(int [,] twoArray,int [] arraySize)
        {
            for (int x = 0; x < arraySize[0]; x++)
            {
                for (int y = 0; y < arraySize[1]; y++)
                {
                    twoArray[x,y] = Random.Next(-10,10);
                }
            }
        }
    }
}
