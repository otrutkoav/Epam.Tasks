using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_1_LOST
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            int count = 0;

            count = InputData();

            list = FillData(count);

            list = GetLost(list);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static List<int> GetLost(List<int> list)
        {

            do
            {
                for (int i = 1; i < list.Count; i+=2)
                {
                    list.RemoveAt(i);
                }

            } while (list.Count>1);
           

            return list;
        }

        private static List<int> FillData(int count)
        {
            List<int> result = new List<int>();

            for (int i = 1; i < count; i++)
            {
                result.Add(i);
            }

            return result;
        }

        private static int InputData()
        {
            int result = 0;

            if (int.TryParse(Console.ReadLine(),out int value) && value>0)
            {
                result = value;
            }
            else
            {
                Console.WriteLine("Ошибка! Введите целое число больше 0");
                result = InputData();
            }

            return result;
        }
    }
}
