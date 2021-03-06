using System;
using System.Diagnostics;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = GetRandomIntArray(10);
            PrintArray(arrayInt);

            Console.WriteLine("Bubble Sort");
            PrintArray(BubbleSortArray(arrayInt));

            Console.WriteLine("Cocktail Sort");
            PrintArray(ShakerSortArray(arrayInt));
            Console.WriteLine();

            double[] arrayDouble = GetRandomDoubleArray(10);
            PrintArray(arrayDouble);

            Console.WriteLine("Bubble Sort");
            PrintArray(BubbleSortArray(arrayDouble));

            Console.WriteLine("Cocktail Sort");
            PrintArray(ShakerSortArray(arrayDouble));
            Console.WriteLine();

            Console.ReadLine();
        }

        static int[] GetRandomIntArray(int size)
        {
            int[] array = new int[size];
            var randGen = new Random();
            for (int i = 0; i < size; i++)
                array[i] = randGen.Next()%1000 + 1;
            return array;
        }

        static double[] GetRandomDoubleArray(int size)
        {
            double[] array = new double[size];
            var randGen = new Random();
            for (int i = 0; i < size; i++)
                array[i] = randGen.Next() % 1000 + randGen.NextDouble();
            return array;
        }

        static int[] BubbleSortArray(int[] array)
        {
            var timer = Stopwatch.StartNew();
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
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");
            return array;
        }

        static double[] BubbleSortArray(double[] array)
        {
            var timer = Stopwatch.StartNew();
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
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");
            return array;
        }

        static int[] ShakerSortArray(int[] array)
        {
            var timer = Stopwatch.StartNew();
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
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");
            return array;
        }

        static double[] ShakerSortArray(double[] array)
        {
            var timer = Stopwatch.StartNew();
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
            timer.Stop();
            Console.WriteLine($"Execution time {timer.Elapsed}");
            return array;
        }

        static void PrintArray(int[] array)
        {
            foreach(var number in array)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }

        static void PrintArray(double[] array)
        {
            foreach (var number in array)
            {
                Console.Write($"{number.ToString("0.00")} ");
            }
            Console.WriteLine();
        }
    }
}
