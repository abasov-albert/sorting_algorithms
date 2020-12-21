using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace SortLab
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectionSort();
            RadixSort();
        }        

        public static void SelectionSort()
        {
            List<int> numbers = new List<int>() { };
            var rand = new Random();
            Console.Write("Enter the amount of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Before sorting:");
            for (int i = 0; i < n; i++)
            {
                numbers.Add(rand.Next(n));
                Console.Write(numbers[i] + " ");
            }
            
            List<int> sortedNumbers = new List<int>();
            
            // sorting started
            var watch = Stopwatch.StartNew();
            while (numbers.Count > 0)
            {
                sortedNumbers.Add(numbers.Min());
                numbers.Remove(numbers.Min());
            }
            
            watch.Stop();
            Console.WriteLine();
            Console.WriteLine($"Sorting took {watch.Elapsed}");
            Console.WriteLine();
            Console.WriteLine("Sorted with selection sort:");
            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Console.Write(sortedNumbers[i] + " ");
            }
        }

        public static void RadixSort()
        {
            List<int> numbers = new List<int>() { };
            var rand = new Random();
            Console.WriteLine();
            Console.Write("Enter the amount of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Before sorting:");
            for (int i = 0; i < n; i++)
            {
                numbers.Add(rand.Next(n));
                Console.Write(numbers[i] + " ");
            }

            var watch = Stopwatch.StartNew();

            List<int>[] numbers2 = new List<int>[10];
            
            int maxRadix = numbers.Max().ToString().Length;
            
            for(int j = 0; j < maxRadix; j++) 
            {
                for (int i = 0; i < numbers2.Length; i++)
                {
                    numbers2[i] = new List<int>();
                }
                
                while (numbers.Count > 0)
                {
                    numbers2[(numbers[0] / (int)Math.Pow(10, j)) % 10].Add((numbers[0]));
                    numbers.Remove(numbers[0]);
                }
                
                for (int i = 0; i < numbers2.Length; i++)
                {
                    var ints = numbers2[i];
                    numbers.AddRange(ints);
                }

            }

            Console.WriteLine();
            Console.WriteLine($"Sorting took: {watch.Elapsed}");
            Console.WriteLine();
            Console.WriteLine("Sorted with radix sort:");
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}