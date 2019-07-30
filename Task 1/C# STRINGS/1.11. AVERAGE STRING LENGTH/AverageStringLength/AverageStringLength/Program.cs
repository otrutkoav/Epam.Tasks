using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageStringLength
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Написать  программу, которая определяет среднюю длину слова во             введённой текстовой строке."
                         + "Учесть, что символы пунктуации на   длину слов влиять не должны.Регулярные выражения не"
                         + "использовать.И   не пытайтесь прописать  все ручками. Используйте стандартные методы классаString.";

            //string str = "Привет мир";
            int symbolCount = 0;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in str)
            {
                if (!char.IsPunctuation(item))
                {
                    stringBuilder.Append(item);

                    if (!char.IsWhiteSpace(item))
                    {
                        symbolCount++;
                    }
                }
            }

            string[] words = stringBuilder.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int avgLengthWord = symbolCount / words.Length;

            Console.WriteLine($"Среднаяя длина слова {avgLengthWord}");

            Console.ReadKey();

        }
    }
}
