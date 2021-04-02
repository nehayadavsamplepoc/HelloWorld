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
            switch (type)
            {
                case TypeOfSort.Bubble:
                    return BubbleSortArray(field, products);
                case TypeOfSort.Shaker:
                    return ShakerSortArray(field, products);
                case TypeOfSort.Default:
                    return SortProductFields(field, products);
                default:
                    Console.WriteLine("Please select type of sort");
                    return products;
            }
        }

        public static IEnumerable SortProductFields(ProductField field, List<Product> products)
        {
            switch (field)
            {
                case ProductField.Qty:
                    products.Sort(Product.ByQtyComparer);
                    break;
                case ProductField.Price:
                    products.Sort(Product.ByPriceComparer);
                    break;
            }
            return products;
        }

        public static IEnumerable SortProductFields(ProductField field, List<ProductWithSize> products)
        {
            switch (field)
            {
                case ProductField.Qty:
                    products.Sort(Product.ByQtyComparer);
                    break;
                case ProductField.Price:
                    products.Sort(Product.ByPriceComparer);
                    break;
                case ProductField.Size:
                    products.Sort(ProductWithSize.BySizeComparer);
                    break;
            }
            return products;
        }

        public static IEnumerable SortProductFields(ProductField field, List<ProductWithColor> products)
        {
            switch (field)
            {
                case ProductField.Qty:
                    products.Sort(Product.ByQtyComparer);
                    break;
                case ProductField.Price:
                    products.Sort(Product.ByPriceComparer);
                    break;
                case ProductField.Color:
                    products.Sort(ProductWithColor.ByColorComparer);
                    break;
            }
            return products;
        }

        private static List<Product> BubbleSortArray(ProductField field, List<Product> array)
        {
            for (var i = 0; i < array.Count - 1; i++)
            {
                for (var j = i + 1; j < array.Count; j++)
                {
                    if ((field.Equals(ProductField.Qty) && (array[i].Qty > array[j].Qty)) 
                        || (field.Equals(ProductField.Price) && (array[i].Price > array[j].Price)))
                    {
                        var temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        private static List<Product> ShakerSortArray(ProductField field, List<Product> array)
        {
            var left = 0;
            var right = array.Count - 1;
            var flag = true;

            while ((left < right) && flag)
            {
                flag = false;
                for (var i = left; i < right; i++)
                {
                    if ((field.Equals(ProductField.Qty) && (array[i].Qty > array[i + 1].Qty))
                        || (field.Equals(ProductField.Price) && (array[i].Price > array[i+1].Price)))
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
                    if ((field.Equals(ProductField.Qty) && (array[i-1].Qty > array[i].Qty))
                        || (field.Equals(ProductField.Price) && (array[i-1].Price > array[i].Price)))
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