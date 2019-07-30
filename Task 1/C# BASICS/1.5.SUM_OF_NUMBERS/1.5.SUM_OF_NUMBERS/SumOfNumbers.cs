using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5.SUM_OF_NUMBERS
{
    class SumOfNumbers
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int sum1 = 0;

            for (int i = 1; i < 1000; i++)
            {
                sum += (i % 3 == 0 || i % 5 == 0) ? i : 0;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum1 += i;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(sum1);
        }
    }
}
