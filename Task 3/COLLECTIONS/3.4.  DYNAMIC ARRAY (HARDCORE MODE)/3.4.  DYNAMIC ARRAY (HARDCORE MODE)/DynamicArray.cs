using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._4.DYNAMIC_ARRAY__HARDCORE_MODE_
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {

        private T[] myArray;
        int capacity;
        int length;

        public int Length
        {
            get
            {
                return this.length;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            set
            {
                if (value<=0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.capacity = value;

                if (this.length>value)
                {
                    this.length = this.capacity;
                }
                
                Array.Resize(ref this.myArray, this.capacity);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0)
                {

                    return this.myArray[this.length + index];
                }

                if (InRange(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.myArray[index];
            }

            set
            {
                if (InRange(index))
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.myArray[index] = value;
                this.length++;
            }
        }

        private bool InRange(int index)
        {
            if (Math.Abs(index) > this.length-1)
            {
                return true;
            }

            return false;
        }

        #region Constructors

        public DynamicArray()
        {
            this.capacity = 8;
            this.myArray = new T[this.capacity];
        }

        public DynamicArray(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.capacity = capacity;
            this.myArray = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            this.capacity = collection.Count();
            this.length = collection.Count();

            this.myArray = new T[capacity];

            Array.Copy((Array)collection, this.myArray, this.length);
        }

        #endregion

        public void Add(T item)
        {
            this.length++;

            if (this.length >= this.capacity)
            {
                this.capacity += this.capacity;
                Array.Resize(ref this.myArray, capacity);
            }

            this.myArray[this.length - 1] = item;

        }

        public void AddRange(IEnumerable<T> collection)
        {
            int count = collection.Count();
            if (this.capacity < count || this.length < count)
            {
                Array.Resize(ref this.myArray, this.capacity + count);
            }
            else
            {
                Array.Copy((Array)collection, 0, this.myArray, this.length, count);
                this.length += count;
            }
        }

        public bool Remove(T item)
        {
            bool isSuccessfully = false;

            for (int i = 0; i < this.length; i++)
            {
                if (this.myArray[i].Equals(item))
                {
                    RemoveByIndex(i);
                    isSuccessfully = true;
                }
            }

            return isSuccessfully;
        }

        public bool Insert(T item, int index)
        {
            bool isSuccessfully = false;

            DynamicArray<T> newArray = new DynamicArray<T>(this.myArray);

            if (InRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.length == this.capacity)
            {
                capacity += 1;
                Array.Resize(ref this.myArray, capacity);
            }

            for (int i = 0, j = 0; i < this.length + 1; i++, j++)
            {
                if (i == index)
                {
                    this.myArray[i] = item;
                    i++;
                    this.length++;
                    isSuccessfully = true;
                }

                this.myArray[i] = newArray[j];
            }


            return isSuccessfully;
        }

        public void RemoveByIndex(int index)
        {
            if (InRange(index))
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0, j = 0; i < this.length; i++, j++)
            {
                if (j == index)
                {
                    j++;
                }
                this.myArray[i] = this.myArray[j];
            }

            this.length--;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.length];
            Array.Copy(this.myArray, array, this.length);

            return array;
        }

        public virtual IEnumerator GetEnumerator()
        {
            return myArray.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (T item in myArray)
            {
                yield return item;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone() as DynamicArray<T>;
        }
    }
}
