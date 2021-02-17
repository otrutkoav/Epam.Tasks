using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._6.FONT_ADJUSTMENT
{
    class FontAdjustment
    {
        static void Main(string[] args)
        {
            string[] commandList = new string[3];//массив который служит для хранения имеющихся параметров
            string[] formatList = new string[3];//массив который слуцжит для хранения параметров надписи

            commandList[0] = "bold";
            commandList[1] = "italic";
            commandList[2] = "underline";

            int idCommand = 0;//переменная для хранения идентификатора команд

            Console.WriteLine("Для выхода нажмите 'Ecs'");

            //цикл для формирования упарвляющего интерфейса

            do
            {

                WriteFormatList(formatList);

                Console.WriteLine();
                Console.WriteLine("Введите:");

                for (int i = 0; i < commandList.Length; i++)
                {
                    Console.WriteLine($"\t{i+1}: {commandList[i]}");
                }

                idCommand = GetIdCommand();


                ApplyCommand(idCommand,commandList,formatList);
               
                Console.WriteLine();

                WriteFormatList(formatList);

                Console.WriteLine("Для завершения программы нажмите 'Esc', для продолжения 'Enter'");

                Console.WriteLine("--------------------------------------------------------------------");

            } while (IsEnd());

            Environment.Exit(0);
        }

        /// <summary>
        /// Метод для вывода в консоль состояние надписи.
        /// </summary>
        /// <param name="formatList">Массив с параметрами надписи</param>
        private static void WriteFormatList(string [] formatList)
        {
            string result = String.Empty;

            Console.Write("Параметры надписи: ");
            for (int i = 0; i < formatList.Length; i++)
            {

                if (!string.IsNullOrEmpty(formatList[i]))
                {
                    result += formatList[i];
                }
            }

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result.Substring(0, result.Length - 2));
            }
        }

        /// <summary>
        /// Метод управляющий выбором команды форматирования.
        /// </summary>
        /// <param name="idCommand">Идентификатор команды</param>
        /// <param name="commandList">Массив имеющийся параметров форматирования</param>
        /// <param name="formatList">Массив параметров надписи</param>
        private static void ApplyCommand(int idCommand, string[] commandList, string[] formatList)
        {
            switch (idCommand)
            {
                case 1:
                    AddCommandForFormatList(idCommand, commandList, formatList);
                    break;
                case 2:
                    AddCommandForFormatList(idCommand, commandList, formatList);
                    break;
                case 3:
                    AddCommandForFormatList(idCommand, commandList, formatList);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Метод редактирующий параметры форматирования (добавляет или удаляет форматирование).
        /// Если такого параметра нет, то добавляет его, иначе удаляет.
        /// </summary>
        /// <param name="idCommand">Идентификатор команда</param>
        /// <param name="commandList">Массив со списком имеющихся параметров</param>
        /// <param name="formatList">Массив хранящий в себе параметры надписи</param>
        private static void AddCommandForFormatList(int idCommand, string[] commandList, string[] formatList)
        {
            if (string.IsNullOrEmpty(formatList[idCommand - 1]))
            {
                formatList[idCommand - 1] = commandList[idCommand - 1]+", ";
            }
            else
            {
                formatList[idCommand - 1] = string.Empty;
            }
        }

        /// <summary>
        /// Метод считывающий и возвращающий пользовательский ввод команды
        /// </summary>
        /// <returns>Целочисленное значение команды</returns>
        private static int GetIdCommand()
        {
            Console.Write("Команда: ");

            if (int.TryParse(Console.ReadLine(),out int value))
            {
                if (value>=1 & value<=3)
                {
                    return value;
                }
                Console.WriteLine("Ошибка введите введите номер команды из указанного списка");
            }
            else
            {
                Console.WriteLine("Ошибка!Введите целое число!");
            }

            return GetIdCommand();
        }

        /// <summary>
        /// Метод для управления работы программы. 
        /// Возвращает true, в случае продолжения работы с программой.
        /// Возвращает false, в случае завершения работы с программой.
        /// </summary>
        /// <returns>Булевое значение</returns>
        private static bool IsEnd()
        {
           
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

            if (consoleKeyInfo.Key==ConsoleKey.Escape)
            {
                return false;
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Ошибка!Нажмите 'Esc' для завершения программы или 'Enter' для продолжения");
                return IsEnd();
            }         
        }
    }
}
