using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_6_Ring
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Ring(0, 0, 5, 7);
            Console.WriteLine(r);
            r = Ring.ChangeRingSize(r,-2,-3);
            Console.WriteLine(r);
        }
    }
}
