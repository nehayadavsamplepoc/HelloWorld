using System;
using System.Collections.Generic;
using System.Text;
using static HelloWorld.Models.ProductConstants;

namespace HelloWorld.Models
{
    public class ProductWithColorComparer : IComparer<ProductWithColor>
    {
        private ProductField type;

        public ProductWithColorComparer(ProductField type)
        {
            this.type = type;
        }

        public int Compare(ProductWithColor p1, ProductWithColor p2)
        {
            if (type.Equals(ProductField.Qty))
            {
                if (p1.Qty > p2.Qty)
                    return 1;
                else if (p1.Qty < p2.Qty)
                    return -1;
                else
                    return 0;
            }
            else if (type.Equals(ProductField.Price))
            {
                if (p1.Price > p2.Price)
                    return 1;
                else if (p1.Price < p2.Price)
                    return -1;
                else
                    return 0;
            }
            else if (type.Equals(ProductField.Color))
            {
                if (p1.Color.CompareTo(p2.Color) > 0)
                    return 1;
                else if (p1.Color.CompareTo(p2.Color) < 0)
                    return -1;
                else
                    return 0;
            }
            else
                throw new Exception("Please choose Qty, Price or Color product field for sort");
        }
    }
}
