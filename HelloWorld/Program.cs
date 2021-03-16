using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using HelloWorld.Models;

namespace HelloWorld
{
    public class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter quantities of products as argument in command line");
                Console.ReadLine();
                return;
            }

            // Class fields sorting
            var products = new List<Product>();
            foreach (var qty in args)
            {
                products.Add(new Product(int.Parse(qty)));
            }

            Console.WriteLine("Example of Bubble Sort for Qty field in class");
            var timer = Stopwatch.StartNew();
            PrintArray(Sort.SortProductFields(Sort.TypeOfSort.Bubble,Sort.ProductField.Qty,products));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.WriteLine("Example of Shaker Sort for Price field in class");
            timer = Stopwatch.StartNew();
            PrintArray(Sort.SortProductFields(Sort.TypeOfSort.Shaker, Sort.ProductField.Price, products));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.WriteLine("Example of Quick Sort for Price field in class");
            timer = Stopwatch.StartNew();
            PrintArray(Sort.SortProductFields(Sort.TypeOfSort.Default, Sort.ProductField.Price, products));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.ReadLine();
        }

        private static void PrintArray(IEnumerable array)
        {
            foreach (var el in array)
            {
                Console.Write($"{el:0.###} ");
            }
            Console.WriteLine();
        }
    }
}
