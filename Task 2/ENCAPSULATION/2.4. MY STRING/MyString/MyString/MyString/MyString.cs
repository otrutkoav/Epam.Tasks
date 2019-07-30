using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyString
{
    public class MyString
    {
        char[] myString;
        int length;

        public int Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                length = value;
            }
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 & index >= Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return myString[index];
            }
            set
            {
                if (index < 0 & index >= Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                myString[index] = value;
            }
        }

        #region Конструкторы

        public MyString()
        {
            myString = new char[0];
        }

        public MyString(int length)
        {
            Length = length;
            myString = new char[Length];
        }

        public MyString(char[] array)
        {
            myString = array;
        }

        public MyString(string str)
        {
            myString = str.ToCharArray();
        }

        public MyString(char ch, int count)
        {
            for (int i = 0; i < count; i++)
            {
                myString[i] = ch;
            }
        }

        public MyString(MyString myString)
        {
            if (myString!=null)
            {
                Length = myString.Length;

                for (int i = 0; i < Length; i++)
                {
                    this.myString[i] = myString[i];
                }
            }
            else
            {
                myString = null;
            }
        }

        #endregion

        public char[] ToCharArray(MyString myString)
        {
            char[] array = new char[myString.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = myString[i];
            }

            return array;
        }

        public static MyString ToMyString(char[] ch)
        {
            MyString myString = new MyString(ch.Length);

            for (int i = 0; i < ch.Length; i++)
            {
                myString[i] = ch[i];
            }

            return myString;
        }

        public static implicit operator MyString(string v)
        {
            MyString myString = new MyString(v);
            myString.Length = v.Length;
            return myString;
        }

        public static implicit operator string(MyString myString)
        {
            string str = new string(myString.myString);
            return str;
        }

        public static MyString operator +(MyString myString, MyString myString1)
        {
            MyString result;

            if (myString == null & myString1 == null)
            {
                result = new MyString();
            }
            else if (myString == null & myString1 != null)
            {
                result = myString1;
            }
            else if (myString1 == null & myString != null)
            {
                result = myString;
            }
            else
            {
                result = new MyString(myString.Length + myString1.Length);

                for (int i = 0; i < myString.length; i++)
                {
                    result[i] = myString[i];
                }

                for (int i = 0; i < myString1.length; i++)
                {
                    result[i + myString.length] = myString1[i];
                }
            }
            return result;
        }

        public static MyString Concat(params MyString[] values)
        {
            if (values==null)
            {
                throw new NullReferenceException();
            }

            MyString result = new MyString();

            for (int i = 0; i < values.Length; i++)
            {
                result += values[i]; 
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj==null)
            {
                throw new NullReferenceException();
            }

            if (Object.ReferenceEquals(this,obj))
            {
                return true;
            }

            return false;
        }

        public int FirstIndexOf(char ch)
        {
            for (int i = 0; i < this.myString.Length; i++)
            {
                if (ch==this[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public int LastIndexOf(char ch)
        {
            for (int i = this.myString.Length-1; i >=0; i--)
            {
                if (ch == this[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public MyString Remove(int startIndex)
        {
            if (startIndex>this.myString.Length && startIndex<0)
            {
                throw new ArgumentOutOfRangeException();
            }

            MyString myString;

            myString = new MyString(this.myString.Length - startIndex);

            for (int i = 0; i < myString.Length; i++)
            {
                myString[i] = this.myString[startIndex];
                startIndex++;
            }
            return myString;
        }

        public MyString Remove(int startIndex,int count)
        {
            if (startIndex > this.myString.Length && startIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count<0 && count>this.myString.Length)
            {
               throw new ArgumentOutOfRangeException();
            }
            MyString myString;

            myString = new MyString(count);

            for (int i = 0; i < myString.Length; i++)
            {
                myString[i] = this.myString[startIndex];
                startIndex++;
            }
            return myString;
        }

        public bool Contains(MyString myString)
        {
            for (int i = 0; i+myString.length <=this.myString.Length; i++)
            {
                MyString newMyString = this.Remove(i, myString.length);

                for (int j = 0; j < newMyString.Length; j++)
                {
                    char ch = newMyString[j];
                    char _ch = myString[j];

                    if (ch!=_ch)
                    {
                        continue;
                    }
                    return true;
                }
            }

            return false;
        }

        public MyString Replace(char oldChar, char newChar)
        {
            MyString myString= new MyString(this.myString.Length);

            for (int i = 0; i < this.myString.Length; i++)
            {
                if (this.myString[i]==oldChar)
                {
                    myString[i] = newChar;
                }
                else
                {
                    myString[i] = this.myString[i];
                }
            }

            return myString;
        }

        //Надо обдумать
        //public MyString Replace(MyString oldValue, MyString newValue)
        //{
        //    MyString myString = new MyString(this.myString.Length-oldValue.Length+newValue.Length);

        //    for (int i = 0; i < this.myString.Length; i++)
        //    {
        //        if (this.myString[i] == oldChar)
        //        {
        //            myString[i] = newChar;
        //        }
        //        else
        //        {
        //            myString[i] = this.myString[i];
        //        }
        //    }

        //    return myString;
        //}


        public MyString Submystring(int startindex)
        {
            if (startindex<0 && startindex>this.myString.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            MyString myString = new MyString(this.myString.Length-startindex);

            int index = startindex;

            for (int i = 0; i < myString.length; i++)
            {
                myString[i] = this.myString[index];
                index++;
            }

            return myString;
        }

        public MyString Submystring(int startindex,int length)
        {
            if (startindex < 0 && startindex > this.myString.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (length<0 && length>this.myString.Length-startindex)
            {
                throw new ArgumentOutOfRangeException();
            }

            MyString myString = new MyString(length);

            int index = startindex;

            for (int i = 0; i < length; i++)
            {
                myString[i] = this.myString[index];
                index++;
            }

            return myString;
        }

        public MyString[] Split(params char[] separator)
        {
            MyString[] myStrings;
            int length = 0;

            for (int i = 0; i < this.myString.Length; i++)
            {
                for (int j = 0; j < separator.Length; j++)
                {
                    if (this.myString[i]==separator[j])
                    {
                        length++;
                    }
                }
               
            }

            myStrings = new MyString[length+1];

            int start = 0;
            int end = 0;
            int index = 0;

            for (int i = 0; i < this.myString.Length; i++)
            {
                for (int j = 0; j < separator.Length; j++)
                {
                    if (i==this.myString.Length-1)
                    {
                        end = i + 1;
                        myStrings[index] = Submystring(start, end-start);
                    }
                    if (this.myString[i] == separator[j])
                    {
                        end = i;
                        myStrings[index] = Submystring(start,end-start);

                        start = end + 1;
                        if (start>this.myString.Length)
                        {
                            break;
                        }
                        index++;
                    }
                }
            }

            return myStrings;
        }

        public bool StartsWith(MyString value)
        {
            if (value==null)
            {
                throw new NullReferenceException();
            }

            if (value.Length>this.myString.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (this.myString[i]!=value[i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool EndsWith(MyString value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            if (value.Length > this.myString.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            int index = this.myString.Length - value.Length;

            for (int i =0; i < value.Length; i++,index++)
            {
                if (this.myString[index] != value[i])
                {
                    return false;
                }
            }
            return true;
        }


        //Надо обдумать
        //public MyString Trim()
        //{
        //    List<char> list = new List<char>();

        //    for (int i = 0; i < this.myString.Length; i++)
        //    {
        //        if (!char.IsSeparator(this.myString[i]))
        //        {
        //            list.Add(this.myString[i]);
        //        }
        //        else
        //        {
        //            if (i - 1 > 0 && i + 1 < this.myString.Length)
        //            {
        //                if (!char.IsSeparator(this.myString[i - 1]) && !char.IsSeparator(this.myString[i + 1]))
        //                {
        //                    if (char.IsSeparator(this.myString[i]))
        //                    {
        //                        list.Add(this.myString[i]);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    MyString myString = new MyString(list.Count);

        //    for (int i = 0; i < myString.Length; i++)
        //    {
        //        myString[i] = list[i];
        //    }

        //    return myString;
        //}

        public override string ToString()
        {
            return new string(myString);
        }
    }
}
