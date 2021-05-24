using HelloEntityFramework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEntityFramework
{
    public static class WholesalerManagement
    {
        public static void AddWholesaler()
        {
            Console.WriteLine("Enter wholesaler name");
            string wholesalerName = Console.ReadLine();

            WholesalerDataAccess.AddWholesaler(wholesalerName);
        }
    }
}
