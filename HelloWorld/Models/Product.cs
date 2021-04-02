using System;
using System.Collections.Generic;

namespace HelloWorld.Models
{
    public class Product
    {
        private static readonly Random RandGen = new Random(); // for generating random numbers

        public int Qty;
        public decimal Price;
        public static readonly ProductPriceComparer ByPriceComparer = new ProductPriceComparer();
        public static readonly QtyPriceComparer ByQtyComparer = new QtyPriceComparer();

        public Product(int qty)
        {
            Qty = qty;
            Price = decimal.Parse($"{RandGen.Next(1000)},{RandGen.Next(100)}");
        }

        public class QtyPriceComparer: IComparer<Product> 
        {
            public int Compare(Product x, Product y)
            {
                if (Object.ReferenceEquals(x, y))
                    return 0;
                else if (Object.ReferenceEquals(x, null))
                    return -1;
                else if (Object.ReferenceEquals(null, y))
                    return 1;

                return (x.Qty).CompareTo(y.Qty);
            }
        }

        public class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product x, Product y)
            {
                if (Object.ReferenceEquals(x, y))
                    return 0;
                else if (Object.ReferenceEquals(x, null))
                    return -1;
                else if (Object.ReferenceEquals(null, y))
                    return 1;

                return Decimal.Compare(x.Price, y.Price);
            }
        }

    }
}