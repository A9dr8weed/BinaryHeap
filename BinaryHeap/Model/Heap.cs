using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryHeap.Model
{
    /// <summary>
    /// Heap, queue with priority.
    /// </summary>
    /// <typeparam name="T"> Data type. </typeparam>
    public class Heap<T> : IEnumerable where T : IComparable<T>
    {
        /// <summary>
        /// Collection of elements.
        /// </summary>
        private readonly List<T> items = new List<T>();

        /// <summary>
        /// Number of elements.
        /// </summary>
        public int Count => items.Count;

        /// <summary>
        /// The designer installs the entire collection at once.
        /// </summary>
        /// <param name="items"> List of elements. </param>
        public Heap(List<T> items)
        {
            this.items.AddRange(items);

            for (int i = Count; i <= Count; i++)
            {
                HeapifyBottomToTop(i);
            }
        }

        /// <summary>
        /// Peek max element.
        /// </summary>
        /// <returns> First element of heap. </returns>
        public T? PeekMax()
        {
            if (Count > 0)
            {
                return items[0];
            }

            return default;
        }

        /// <summary>
        /// Add data to collection.
        /// </summary>
        /// <param name="item"> Added data. </param>
        public void Add(T item)
        {
            if (Count < 0)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                items.Add(item);

                // An iterator that points to the current element.
                int currentIndex = Count - 1;
                // Ancestor of the element (formula).
                int parentIndex = GetParentIndex(currentIndex);

                // While the current index is greater than zero, and the ancestor is less than the current.
                while (currentIndex > 0 && items[parentIndex].CompareTo(items[currentIndex]) < 0)
                {
                    // Swap elements.
                    Swap(currentIndex, parentIndex);

                    // Go to the next level.
                    currentIndex = parentIndex;
                    parentIndex = GetParentIndex(currentIndex);
                }
            }
        }

        /// <summary>
        /// Method to remove max element (or root) from min heap.
        /// </summary>
        /// <returns> Element of collection, then heapify collection. </returns>
        public T ExtractMax()
        {
            if (Count <= 0)
            {
                return default;
            }

            if (Count - 1 == 1)
            {
                items.RemoveAt(Count - 1);
                return items[0];
            }

            // Get the first element.
            T result = items[0];
            // The element from the tail is moved to the head.
            items[0] = items[Count - 1];
            // Delete by index.
            items.RemoveAt(Count - 1);
            HeapifyBottomToTop(0);

            return result;
        }

        /// <summary>
        /// A recursive method to heapify a subtree
        /// </summary>
        /// <param name="currentIndex"> Root at a given index. </param>
        private void HeapifyBottomToTop(int currentIndex)
        {
            // The root index of any of the under trees. (default maximum)
            int maxIndex = currentIndex;

            // The index of the left element (according to the formula).
            int leftIndex = (2 * currentIndex) + 1;
            // Index of the right element (according to the formula).
            int rightIndex = (2 * currentIndex) + 2;

            // If the left element is larger than the current and less than the number of elements.
            if (leftIndex < Count && items[leftIndex].CompareTo(items[maxIndex]) > 0)
            {
                // поточний дорінює лівому
                maxIndex = leftIndex;
            }

            // if the right element is larger than the current and less than the number of elements.
            if (rightIndex < Count && items[rightIndex].CompareTo(items[maxIndex]) > 0)
            {
                maxIndex = rightIndex;
            }

            // if the current index is not equal to the maximum index.
            if (maxIndex != currentIndex)
            {
                // Swap elements.
                Swap(currentIndex, maxIndex);
                // Recursive deeper.
                HeapifyBottomToTop(maxIndex);
            }
        }

        /// <summary>
        /// Swap elements.
        /// </summary>
        /// <param name="currentIndex"> Current index. </param>
        /// <param name="parentIndex"> Parent index. </param>
        private void Swap(int currentIndex, int parentIndex)
        {
            // Get the current item (optional variable).
            T temp = items[currentIndex];
            // In the current element we place the parent.
            items[currentIndex] = items[parentIndex];
            // In the parent element we place temp.
            items[parentIndex] = temp;
        }

        /// <summary>
        /// Get parent.
        /// </summary>
        /// <param name="currentIndex"> Current index. </param>
        /// <returns> Parent element. </returns>
        private int GetParentIndex(int currentIndex)
        {
            return (currentIndex - 1) / 2;
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            {
                yield return ExtractMax();
            }
        }
    }
}