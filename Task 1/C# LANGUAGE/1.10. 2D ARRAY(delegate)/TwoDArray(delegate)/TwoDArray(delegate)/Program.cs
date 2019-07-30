using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDArray_delegate_
{
    delegate void WorkWithElement(int [,]array, int xIndex,int yIndex);

    class Program
    {
        static Random Random = new Random();
        static int sum=0;
        static void Main(string[] args)
        {
            int[,] twoDArray = new int[3,3];

            int[] arraySize = new int[twoDArray.Rank];

            for (int i = 0; i < arraySize.Length; i++)
            {
                arraySize[i] = twoDArray.GetUpperBound(i)+1;
            }

            WorkWithElement workWithElement = null;

            WorkWithArray(twoDArray,arraySize,workWithElement=AssignValElem);

            WorkWithArray(twoDArray, arraySize, workWithElement = WriteValElem);

            Console.WriteLine();

            WorkWithArray(twoDArray, arraySize, workWithElement = CalculetSum);

            Console.WriteLine(sum);

            Console.ReadKey();
        }

        static void WorkWithArray(int [,] twoArray, int [] arraySize,WorkWithElement workWithElement)
        {
            for (int x = 0; x < arraySize[0]; x++)
            {
                for (int y = 0; y < arraySize[1]; y++)
                {
                    workWithElement(twoArray,x,y);
                }
                if (workWithElement==WriteValElem)
                {
                    Console.WriteLine();
                }           
            }

        }

        static void AssignValElem(int[,] twoArray, int x, int y)
        {
            twoArray[x, y] = Random.Next(-20,20);
        }

        static void WriteValElem(int[,] twoArray, int x, int y)
        {
            Console.Write($"{twoArray[x,y]} ");
        }

        static void CalculetSum(int[,] twoArray, int x, int y)
        {
            if (IsEven(x,y))
            {
                Console.WriteLine($"{sum}+{twoArray[x,y]} = {sum+=twoArray[x,y]}");
            }
        }

        private static bool IsEven(int x, int y)
        {
            return (x + y) % 2 == 0;
        }
    }
}
