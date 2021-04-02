using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using HelloWorld.Models;
using static HelloWorld.Models.ProductConstants;

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

            Console.WriteLine("Example of Default Sort for Qty field in class");
            var timer = Stopwatch.StartNew();
            Sort.SortProductFields(ProductField.Qty, products);
            PrintProductFields(ProductField.Qty, products);
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            // Child class sorting
            var sizeProducts = new List<ProductWithSize>();
            foreach (var qty in args)
            {
                sizeProducts.Add(new ProductWithSize(int.Parse(qty)));
            }

            Console.WriteLine("Example of Default Sort for Qty field in child class");
            timer = Stopwatch.StartNew();
            Sort.SortProductFields(ProductField.Qty, sizeProducts);
            PrintProductFields(ProductField.Qty, sizeProducts);
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.WriteLine("Example of Default Sort for Size field in child class");
            timer = Stopwatch.StartNew();
            Sort.SortProductFields(ProductField.Size, sizeProducts);
            PrintProductFields(ProductField.Size, sizeProducts);
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            // Child class sorting
            var colorProducts = new List<ProductWithColor>();
            foreach (var qty in args)
            {
                colorProducts.Add(new ProductWithColor(int.Parse(qty)));
            }

            Console.WriteLine("Example of Default Sort for Qty field in child class");
            timer = Stopwatch.StartNew();
            Sort.SortProductFields(ProductField.Price, colorProducts);
            PrintProductFields(ProductField.Price, colorProducts);
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.WriteLine("Example of Default Sort for Color field in child class");
            timer = Stopwatch.StartNew();
            Sort.SortProductFields(ProductField.Color, colorProducts);
            PrintProductFields(ProductField.Color, colorProducts);
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.ReadLine();
        }

        private static void PrintProductFields(ProductField field, List<Product> array)
        {
            if (field.Equals(ProductField.Qty))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Qty} ");
                }
            }
            else if (field.Equals(ProductField.Price))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Price:0.###} ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintProductFields(ProductField field, List<ProductWithSize> array)
        {
            if (field.Equals(ProductField.Qty))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Qty} ");
                }
            }
            else if (field.Equals(ProductField.Price))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Price:0.###} ");
                }
            }
            else if (field.Equals(ProductField.Size))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Size} ");
                }
            }
            Console.WriteLine();
        }

        private static void PrintProductFields(ProductField field, List<ProductWithColor> array)
        {
            if (field.Equals(ProductField.Qty))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Qty} ");
                }
            }
            else if (field.Equals(ProductField.Price))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Price:0.###} ");
                }
            }
            else if (field.Equals(ProductField.Color))
            {
                foreach (var el in array)
                {
                    Console.Write($"{el.Color} ");
                }
            }
            Console.WriteLine();
        }
    }
}
