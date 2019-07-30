using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Антон", "Отрутько", "Вадимович", new DateTime(1994, 5, 30));
            user.GetInfo();
            Console.WriteLine();
            Console.WriteLine(user);
        }
    }
}
