using System;
using System.Collections.Generic;
using System.Linq;

namespace SortLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers1 = new List<int>() { };
            var rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                numbers1.Add(rand.Next((100)));
            }
            /*
            for (int i = 0; i < numbers1.Count; i++)
            {
                Console.WriteLine(numbers1[i]);
            }
            
            Console.WriteLine();
            Console.WriteLine("Sorted:");

            SelectionSort(numbers1);
            */

            List<int>[] numbers2 = new List<int>[10];

            for (int i = 0; i < numbers2.Length; i++)
            {
                numbers2[i] = new List<int>();
            }

            int count = 0;
            
            for (int i = 0; i < numbers1.Count; i++)
            {
                if (numbers1[i] % 10 < numbers1[i + 1] % 10)
                {
                    numbers2[count].Add(numbers1[i]);
                    
                    if (numbers1[i] > numbers2[count][0])
                    {
                        count++;
                        numbers2[count].Add(numbers1[i]);
                        numbers1.Remove(numbers1[i]);
                    }
                    numbers1.Remove(numbers1[i]);
                    i = -1;
                }
            }
        }

        public static void SelectionSort(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>();

            while (numbers.Count > 0)
            {
                sortedNumbers.Add(numbers.Min());
                numbers.Remove(numbers.Min());
            }

            for (int i = 0; i < sortedNumbers.Count; i++)
            {
                Console.WriteLine(sortedNumbers[i]);
            }
        }
    }
}