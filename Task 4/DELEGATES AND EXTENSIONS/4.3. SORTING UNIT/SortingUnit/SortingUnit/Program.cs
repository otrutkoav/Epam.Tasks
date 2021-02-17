using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingUnit
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();

            SortArray<int> sortArrayInt = new SortArray<int>(10);

            sortArrayInt.array = new int[] { 5, 2, 7, 10, 45, 89,23,67,56,89 };

            //sortArrayInt.EndSort += delegate (object sender, Message e)
            //{
            //    Console.WriteLine("Метод {0} сообщил, {1}", sender, e.msg);
            //};

            //sortArrayInt.EndSort += (object sender, Message e)=>
            //{
            //    Console.WriteLine("Метод {0} сообщил, {1}", sender, e.msg);
            //};

            sortArrayInt.EndSort += ((sender, e) => Console.WriteLine("Метод {0} сообщил, {1}", sender, e.msg));

            sortArrayInt.ShowArray();

            sortArrayInt.Sort(sortArrayInt.Ascending);

            sortArrayInt.SortThread(sortArrayInt.Descending,5);

        }

        //private static void DisplayMessage(object sender, Message e)
        //{
        //    Console.WriteLine("Метод {0} сообщил, {1}", sender, e.msg);
        //}

        public class Message
        {
            public readonly string msg;

            public Message(string message)
            {
                msg = message;
            }
        }

        public class SortArray<T>
        {
            public T[] array;

            public int Length { get; }

            public event EventHandler<Message> EndSort;             

            public SortArray(int length)
            {
                this.array = new T[length];
                this.Length = length;
            }

            public SortArray(T[] arr)
            {
                this.array = arr;
                this.Length = arr.Length;
            }

            public void Sort(Func<dynamic, dynamic, bool> сomparisonMethod)
            {
                for (int i = 0; i < this.array.Length; i++)
                {
                    for (int j = i + 1; j < this.array.Length; j++)
                    {
                        if (сomparisonMethod != null)
                        {
                            if (сomparisonMethod(array[i], this.array[j]))
                            {
                                Swap(i, j);
                            }
                        }
                    }

                    if (i==this.array.Length-1)
                    {
                        EndSort?.Invoke(this,new Message(string.Join(": ", new string[] { "Сортировка завершена", string.Join(", ", this.array) })));
                    }
                }
            }

            public void SortThread(Func<dynamic, dynamic, bool> сomparisonMethod, int timeSleepSeconds)
            {
                Thread thread = new Thread(()=> Sort(сomparisonMethod));
                Thread.Sleep(TimeSpan.FromSeconds(timeSleepSeconds));
                thread.Start();
            }

            void Swap(int first, int second)
            {
                var temp = this.array[first];
                this.array[first] = array[second];
                this.array[second] = temp;
            }

            public bool Ascending(dynamic first, dynamic second)
            {
                return first > second;
            }

            public bool Descending(dynamic first, dynamic second)
            {
                return first < second;
            }

            public void ShowArray() => Console.WriteLine(string.Join(", ", this.array));
        }
    }
}

