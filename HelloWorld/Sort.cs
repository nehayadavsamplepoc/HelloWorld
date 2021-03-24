using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Models;
using static HelloWorld.Models.ProductConstants;

namespace HelloWorld
{
    public static class Sort
    {
        public static IEnumerable SortProductFields(TypeOfSort type, ProductField field, List<Product> products)
        {
            if (type.Equals(TypeOfSort.Default))
            {
                return SortProductFields(field, products);
            }
            switch (field)
            {
                case ProductField.Qty:
                    var allQty = products.Select(product => product.Qty).ToList<int>();
                    switch (type)
                    {
                        case TypeOfSort.Bubble:
                            return BubbleSortArray(allQty);
                        case TypeOfSort.Shaker:
                            return ShakerSortArray(allQty);
                    }
                    break;
                case ProductField.Price:
                    var allPrices = products.Select(product => product.Price).ToList<decimal>();
                    switch (type)
                    {
                        case TypeOfSort.Bubble:
                            return BubbleSortArray(allPrices);
                        case TypeOfSort.Shaker:
                            return ShakerSortArray(allPrices);
                    }
                    break;
            }
            return products;
        }

        public static IEnumerable SortProductFields(ProductField field, List<Product> products)
        {
            products.Sort(new ProductComparer(field));
            switch (field)
            {
                case ProductField.Qty:
                    return products.Select(product => product.Qty).ToList<int>();
                case ProductField.Price:
                    return products.Select(product => product.Price).ToList<decimal>();
            }
            return products;
        }

        public static IEnumerable SortProductFields(ProductField field, List<ProductWithSize> products)
        {
            products.Sort(new ProductWithSizeComparer(field));
            switch (field)
            {
                case ProductField.Qty:
                    return products.Select(product => product.Qty).ToList<int>();
                case ProductField.Price:
                    return products.Select(product => product.Price).ToList<decimal>();
                case ProductField.Size:
                    return products.Select(product => product.Size).ToList<int>();
            }
            return products;
        }

        public static IEnumerable SortProductFields(ProductField field, List<ProductWithColor> products)
        {
            products.Sort(new ProductWithColorComparer(field));
            switch (field)
            {
                case ProductField.Qty:
                    return products.Select(product => product.Qty).ToList<int>();
                case ProductField.Price:
                    return products.Select(product => product.Price).ToList<decimal>();
                case ProductField.Color:
                    return products.Select(product => product.Color).ToList<string>();
            }
            return products;
        }

        private static List<int> BubbleSortArray(List<int> array)
        {
            for (var i = 0; i < array.Count - 1; i++)
            {
                for (var j = i + 1; j < array.Count; j++)
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

        private static List<decimal> BubbleSortArray(List<decimal> array)
        {
            for (var i = 0; i < array.Count - 1; i++)
            {
                for (var j = i + 1; j < array.Count; j++)
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

        private static List<int> ShakerSortArray(List<int> array)
        {
            var left = 0;
            var right = array.Count - 1;
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

        private static List<decimal> ShakerSortArray(List<decimal> array)
        {
            var left = 0;
            var right = array.Count - 1;
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