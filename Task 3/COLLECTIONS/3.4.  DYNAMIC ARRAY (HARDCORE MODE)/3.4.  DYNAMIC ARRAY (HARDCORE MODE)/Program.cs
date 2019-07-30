using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> Arr = new DynamicArray<int>(20);

            for (int i = 1; i <=10; i++)
            {
                Arr.Add(i);
            }

            var res = Arr.ToArray();

        }
    }
}
