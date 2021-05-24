using HelloEntityFramework.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEntityFramework.DataAccess
{
    public static class WholesalerDataAccess
    {
        public static void AddWholesaler(string wholesalerName)
        {
            using (ProductsEntities db = new ProductsEntities())
            {
                Wholesaler wholesaler = new Wholesaler { Name = wholesalerName };
                db.Wholesalers.Add(wholesaler);
                db.SaveChanges();
                Console.WriteLine("New Wholesaler is added to database");
            }
        }
    }
}
