using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Антон", "Отрутько", "Вадимович", new DateTime(1994, 5, 30),"Системный администратор", new DateTime(2016, 6, 30));
            Console.WriteLine(employee);
        }
    }
}
