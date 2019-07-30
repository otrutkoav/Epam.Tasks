using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_2_WORD_FREQUENCY
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> WordAndNumber = null;
            Dictionary<string, double> WordAndFrequency = null;

            string text ="The .NET Framework 4.5 is a highly compatible, in-place update to the .NET Framework 4."
+"By using the .NET Framework 4.5 together with the C#, Visual Basic, or F# programming language, you can write Windows apps."
+"The .NET Framework 4.5 includes significant language and framework enhancements for C#, Visual Basic, and F# (so that you can more easily write asynchronous code)," 
+"the blending of control flow in synchronous code, a responsive UI, and web app scalability." 
+"The .NET Framework 4.5 adds substantial improvements to other functional areas such as ASP.NET, Managed Extensibility Framework, Windows Communication Foundation,"
+"Windows Workflow Foundation, and Windows Identity Foundation. The .NET Framework 4.5 delivers better performance, reliability, and security.";

            string[] arrayWords = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Calculete(arrayWords, out WordAndNumber);
            CalculeteFrequency(arrayWords.Length, WordAndNumber, out WordAndFrequency);

        }

        private static void CalculeteFrequency(int length,Dictionary<string, int> wordAndNumber, out Dictionary<string, double> wordAndFrequency)
        {
            wordAndFrequency = new Dictionary<string, double>();

            foreach (var item in wordAndNumber)
            {
                double percent = ((double)item.Value / (double)length)*100;
                wordAndFrequency.Add(item.Key, Math.Round(percent, 2));
            }
        }

        private static void Calculete(string [] arrayWords, out Dictionary<string, int> wordAndNumber)
        {
            wordAndNumber= new Dictionary<string, int>();

            for (int i = 0; i < arrayWords.Length; i++)
            {
                if (double.TryParse(arrayWords[i], out double value) || Considered(arrayWords[i],wordAndNumber))
                {
                    continue;
                }

                int count = 0;

                for (int j = 0; j < arrayWords.Length; j++)
                {
                    if (Checked(arrayWords[i],arrayWords[j]))
                    {
                        count++;
                    }
                }
                wordAndNumber.Add(arrayWords[i], count);
            }
        }

        private static bool Checked(string firstValue, string secondValue)
        {
            int result = string.Compare(firstValue, secondValue, true);

            if (result!=0)
            {
                return false;
            }

            return true;
        }

        private static bool Considered(string text, Dictionary<string, int> wordAndNumber)
        {
            foreach (KeyValuePair<string,int> item in wordAndNumber)
            {
                if (Checked(text,item.Key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
