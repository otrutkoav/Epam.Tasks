using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharDoubler
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstStr = "написать программу, которая";
            string secondStr = "описание";
            StringBuilder doubler = new StringBuilder();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < firstStr.Length; i++)
            {
                if (!IsSymbol(firstStr[i]))
                {
                    for (int j = 0; j < secondStr.Length; j++)
                    {
                        if (!SymbolAvailable(firstStr[i], doubler.ToString()))
                        {
                            if (secondStr[j] == firstStr[i])
                            {
                                doubler.Append(secondStr[j]);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < firstStr.Length; i++)
            {
                string str = firstStr[i].ToString();

                if (SymbolAvailable(firstStr[i], doubler.ToString()))
                {
                    str = new string(firstStr[i], 2);
                }

                result.Append(str);
            }

            Console.WriteLine(result.ToString());
        }

        private static bool SymbolAvailable(char symbol, string str)
        {
            return str.Contains(symbol);
        }

        private static bool IsSymbol(char symbol)
        {
            return (char.IsWhiteSpace(symbol) || char.IsPunctuation(symbol));
        }
    }
}
