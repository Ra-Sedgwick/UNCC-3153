using System;

using System.Collections.Generic;

namespace MinHeap
{
    public class MinHeap<T> where T : IComparable
    {
        public List<T> Items;

        public MinHeap()
        {
            Items = new List<T>();
        }

        public void Enqueue(T item)
        {
            Items.Add(item);
            int child = Items.Count - 1;     
            
            while (child > 0)
            {
                int parent = (child - 1) / 2;                    

                if (Items[child].CompareTo(Items[parent]) >= 0) 
                    break;                                          // child item is larger than (or equal) parent so we're done

                Swap(ref Items, ref child, ref parent);
            }
        }

        public T Dequeue()
        {
            if (Items.Count == 0)
                throw new InvalidOperationException("Heap Empty");

            int last = Items.Count - 1;
            T first = Items[0];
            Items[0] = Items[last];
            Items.RemoveAt(last);
            int parent = 0;

            last--;

            while (true)
            {
                int left = parent * 2 + 1;               // Left child index of parent

                if (left > last)
                    break;

                int right = left + 1;                    // Right child index

                // If there is a right child, and it is smaller then the left child....
                if (right <= last && Items[right].CompareTo(Items[left]) < 0)
                    left = right;

                // If parent is <= to samllest child; done.
                if (Items[parent].CompareTo(Items[left]) <= 0)
                    break;

                Swap(ref Items, ref parent, ref left);
            }

            return first;
        }

        public T Peek()
        {
            if (Items.Count == 0)
                throw new InvalidOperationException("Heap Empty");

            return Items[0];
        }

        public void Clear()
        {
            Items.Clear();
        }

        public T[] ToArray()
        {
            return Items.ToArray();
        }

        public List<T> ToList()
        {
            return Items;
        }

        public int Count()
        {
            return Items.Count;
        }

        public bool Contains(T item)
        {
            return Items.Contains(item); 
        }

        private void Swap(ref List<T> data, ref int x, ref int y)
        {
            T temp = data[x];
            data[x] = data[y];
            data[y] = temp;
            x = y;
        }


    }
}