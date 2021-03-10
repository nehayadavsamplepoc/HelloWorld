using System;
using System.Collections;
using System.Diagnostics;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = args.Length > 0 ? Int32.Parse(args[0]) : 10;

            var arrayInt = GetRandomIntArray(size);
            PrintArray(arrayInt);
            Console.WriteLine();

            Console.WriteLine("Bubble Sort");
            var timer = Stopwatch.StartNew();
            PrintArray(BubbleSortArray(arrayInt));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");

            Console.WriteLine("Cocktail Sort");
            timer = Stopwatch.StartNew();
            PrintArray(ShakerSortArray(arrayInt));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");

            Console.WriteLine("Quick Default Sort");
            timer = Stopwatch.StartNew();
            Array.Sort(arrayInt);
            timer.Stop();
            PrintArray(arrayInt);
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            var arrayDouble = GetRandomDoubleArray(size);
            PrintArray(arrayDouble);
            Console.WriteLine();

            Console.WriteLine("Bubble Sort");
            timer = Stopwatch.StartNew();
            PrintArray(BubbleSortArray(arrayDouble));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");

            Console.WriteLine("Cocktail Sort");
            timer = Stopwatch.StartNew();
            PrintArray(ShakerSortArray(arrayDouble));
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");

            Console.WriteLine("Quick Default Sort");
            timer = Stopwatch.StartNew();
            Array.Sort(arrayDouble);
            timer.Stop();
            PrintArray(arrayDouble);
            Console.WriteLine($"Execution time {timer.Elapsed}\n");

            Console.ReadLine();
        }

        private static int[] GetRandomIntArray(int size)
        {
            var array = new int[size];
            var randGen = new Random();
            for (int i = 0; i < size; i++)
                array[i] = randGen.Next(1000);
            return array;
        }

        private static double[] GetRandomDoubleArray(int size)
        {
            var array = new double[size];
            var randGen = new Random();
            for (int i = 0; i < size; i++)
                array[i] = randGen.Next(1000)+ randGen.NextDouble();
            return array;
        }

        private static int[] BubbleSortArray(int[] array)
        {
            for (int i=0; i<array.Length-1;i++)
            {
                for (int j=i+1; j<array.Length;j++)
                {
                    if (array[i]>array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        private static double[] BubbleSortArray(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        double temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        private static int[] ShakerSortArray(int[] array)
        {
            int left = 0;
            int right = array.Length-1;
            bool flag = true;

            while ((left<right) && flag)
            {
                flag = false;
                for (int i = left; i< right; i++)
                {
                    if (array[i] > array[i+1])
                    {
                        int temp = array[i+1];
                        array[i+1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                right--;
                for (int i = right; i>left; i--)
                {
                    if (array[i-1] > array[i])
                    {
                        int temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                left++;
            }
            return array;
        }

        private static double[] ShakerSortArray(double[] array)
        {
            int left = 0;
            int right = array.Length - 1;
            bool flag = true;

            while ((left < right) && flag)
            {
                flag = false;
                for (int i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        double temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                right--;
                for (int i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        double temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                left++;
            }
            return array;
        }

        private static void PrintArray(IEnumerable array)
        {
            foreach(var number in array)
            {
                Console.Write($"{number:0.###} ");
            }
            Console.WriteLine();
        }
    }
}
