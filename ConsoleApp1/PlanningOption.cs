using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PlanningOption
    {
        public Order Order { get; set; }

        public Curier Curier { get; set; }

        public double Price { get; set; }

        public double Profit
        {
            get
            { 
                return Order.OrderPrice - Price;
            }
        }
    }
}
