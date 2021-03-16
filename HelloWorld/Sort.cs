using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Models;

namespace HelloWorld
{
    public static class Sort
    {
        public enum TypeOfSort
        {
            Bubble,
            Shaker,
            Default
        }

        public enum ProductField
        {
            Qty,
            Price
        }

        public static IEnumerable SortProductFields(TypeOfSort type, ProductField field, List<Product> products)
        {
            switch (field)
            {
                case ProductField.Qty:
                    var allQty = products.Select(product => product.Qty).ToArray<int>();
                    switch (type)
                    {
                        case TypeOfSort.Bubble:
                            return BubbleSortArray(allQty);
                        case TypeOfSort.Shaker:
                            return ShakerSortArray(allQty);
                        case TypeOfSort.Default:
                            Array.Sort(allQty);
                            return allQty;
                    }
                    break;
                case ProductField.Price:
                    var allPrices = products.Select(product => product.Price).ToArray<decimal>();
                    switch (type)
                    {
                        case TypeOfSort.Bubble:
                            return BubbleSortArray(allPrices);
                        case TypeOfSort.Shaker:
                            return ShakerSortArray(allPrices);
                        case TypeOfSort.Default:
                            Array.Sort(allPrices);
                            return allPrices;
                    }
                    break;
            }
            return products;
        }

        private static int[] BubbleSortArray(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        private static decimal[] BubbleSortArray(decimal[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        var temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        private static int[] ShakerSortArray(int[] array)
        {
            var left = 0;
            var right = array.Length - 1;
            var flag = true;

            while ((left < right) && flag)
            {
                flag = false;
                for (var i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                right--;
                for (var i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        var temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                left++;
            }
            return array;
        }

        private static decimal[] ShakerSortArray(decimal[] array)
        {
            var left = 0;
            var right = array.Length - 1;
            var flag = true;

            while ((left < right) && flag)
            {
                flag = false;
                for (var i = left; i < right; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                right--;
                for (var i = right; i > left; i--)
                {
                    if (array[i - 1] > array[i])
                    {
                        var temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        flag = true;
                    }
                }
                left++;
            }
            return array;
        }
    }
}