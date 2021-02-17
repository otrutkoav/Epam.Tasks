using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToIntOrNotToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] listStr = new string[] {"45","-45","4f","dfs","4.5","4,5","f5","100" };

            for (int i = 0; i < listStr.Length; i++)
            {
                string str = listStr[i];

                if (str.IsPositiveInteger())
                {
                    Console.WriteLine("Число {0}", str);
                }
            }

            for (int i = 0; i < listStr.Length; i++)
            {
                string str = listStr[i];

                if (str.IsPositiveInt())
                {
                    Console.WriteLine("Число {0}", str);
                }
            }
        }
    }

    public static class StringExtension
    {

        public static bool IsPositiveInteger(this string str)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    result = true;
                    if (char.GetNumericValue(str[i]) == -1)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

        public static bool IsPositiveInt(this string str)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    result = true;
                    if (!char.IsDigit(str[i]))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
