using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(4, 6, 9);
            triangle.GetInfo();
        }
    }
}
