using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Enumerable.Range(1, 10).ToArray();
            int result = arr.SumItemArray();
            Console.WriteLine(result);
        }
    }

    public static class ArraySum
    {
        public static int SumItemArray(this int[] array)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                counter += array[i];
            }
            return counter;
        }
    }
}
