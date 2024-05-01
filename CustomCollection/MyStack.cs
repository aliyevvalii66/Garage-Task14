using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace CustomCollection
{
    public class MyStack<T> :IEnumerable
    {
        public T[] array;
        public int Count { get; set; }
        public int Capacity { get; set; }

        public MyStack()
        {
            array = new T[4];
            Capacity = 4;
        }
        public MyStack(int capacity)
        {
            Capacity = capacity;
            array = new T[Capacity];
        }
        public MyStack(IEnumerable<T> collaction)
        {
            Capacity = collaction.Count();
            Count = Capacity;

            array = new T[Capacity];


            int i = 0;
            foreach (var item in collaction)
            {
                array[i] = item;
                i++;
            }
        }

        public void Push(T value)
        {
            if (Capacity == Count)
            {
                Capacity *= 2;
                Array.Resize(ref array, Capacity);
            }
            array[Count] = value;
            Count++;
        }


        public T Pop()
        {
            if (Count <= 0)
            {
                throw new Exception("Pop!!!");
            }
            T lastValue = array[Count - 1];
            Count--;
            Array.Resize(ref array, Count);
            return lastValue;
        }

        public T Peek()
        {
            if (Count <= 0)
            {
                throw new Exception("Peek!!!");
            }
            return array[Count - 1];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }
    }
}
