using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public new  IEnumerator<T> GetEnumerator()
        {
            return new CycledDynamicArrayEnumerator<T>(myArray);
        }
    }


    class CycledDynamicArrayEnumerator<T> : IEnumerator<T>
    {
        T[] array;
        int position = -1;

        public CycledDynamicArrayEnumerator(T[] array)
        {
            this.array = array;
        }

        public T Current
        {
            get
            {
                if (position==-1 || position>array.Length-1)
                {
                    throw new InvalidOperationException();
                }

                return array[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < array.Length-1)
            {
                position++;
                return true;
            }
            else
            {
                position = 0;
                return true;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }

}
