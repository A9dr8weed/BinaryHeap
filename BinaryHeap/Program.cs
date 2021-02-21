using BinaryHeap.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BinaryHeap
{
    public static class Program
    {
        private static void Main()
        {
            Stopwatch timer = new Stopwatch();
            Random rnd = new Random();
            List<int> startItems = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                startItems.Add(rnd.Next(-100, 100));
            }

            timer.Start();
            Heap<int> heap = new Heap<int>(startItems);
            timer.Stop();
            Console.WriteLine($"First initializing with 1000 elements {timer.Elapsed}");

            timer.Restart();
            for (int i = 0; i < 100; i++)
            {
                heap.Add(rnd.Next(-100, 100));
            }
            timer.Stop();
            Console.WriteLine($"Adding second 1000 elements {timer.Elapsed}");

            timer.Restart();
            foreach (object item in heap)
            {
                Console.WriteLine(item);
            }
            timer.Stop();
            Console.WriteLine($"Printing 2000 elements {timer.Elapsed}");
        }
    }
}