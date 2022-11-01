using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Базовый заказ
    /// </summary>
    internal class Order
    {
        public Location FromLocation { get; set; }  

        public Location ToLocation { get; set; }

        public double Weigth { get; set; }

        public double OrderDistance
        {
            get { return FromLocation.GetDistance(ToLocation); }
        }

        public double OrderPrice { get { return GetOrderPrice(); } }

        private double GetOrderPrice()
        {
            return OrderDistance * Company.PricePerDistance;
        }

        public string GetInfo()
        {
            return $"Заказ {FromLocation.ToString()} -> {ToLocation.ToString()}" +
                $" ({OrderDistance} км) | {OrderPrice}";
        }

        public List<Curier> CurriersForOrder()
        {
            var list = new List<Curier>();

            var list2 = Company.Curiers.Where(cur => cur.CanCarry(this));

            foreach (var currer in Company.Curiers)
            {
                if (currer.CanCarry(this))
                {
                    list.Add(currer);
                }
            }

            return list2.ToList();


        }
    }
}
