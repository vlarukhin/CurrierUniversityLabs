using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Company
    {
        public const double PricePerDistance = 100;

        public const double DefaultFootCurierSpeed = 4;

        public const double DefaultMobileCurierSpeed = 8;


        public static HashSet<Curier> Curiers { get; set; } = new HashSet<Curier>();

        public static Queue<Order> Orders { get; set; } = new Queue<Order>();

        public void PrintOrders()
        {
            foreach(var order in Orders)
            {
                Console.WriteLine(order.GetInfo());
            }
        }

        public void PrintCuriers()
        {
            foreach (var curier in Curiers)
            {
                Console.WriteLine(curier.GetInfo());
            }
        }
    }
}
