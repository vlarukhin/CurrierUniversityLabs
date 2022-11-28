using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    internal class Company
    {
        public const double PricePerDistance = 100;

        public const double DefaultFootCurierSpeed = 4;

        public const double DefaultMobileCurierSpeed = 8;



        public HashSet<Curier> Curiers { get; set; } = new HashSet<Curier>();

        public Queue<Order> OrdersQueue { get; set; } = new Queue<Order>();

        public HashSet<Order> Orders { get; set; } = new HashSet<Order>();

        public void PrintOrders()
        {
            foreach (var order in Orders)
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


        public void StartPlaner()
        {
            PrepaireQueue();
            PlanningCycle();
        }


        private void PrepaireQueue()
        {
            var sortedOrders = Orders.OrderByDescending(x => x.OrderPrice);

            foreach (var order in sortedOrders)
            {
                OrdersQueue.Enqueue(order);
            }
        }

        private void PlanningCycle()
        {
            var totalProfit = 0.0;

            while (OrdersQueue.Count > 0)
            {
                var orderForPlanning = OrdersQueue.Dequeue();

                Console.WriteLine($"Планируется заказ: {orderForPlanning.GetInfo()}");
                Console.WriteLine();

                var result = orderForPlanning.PlanOrder();

                if (result)
                {
                    totalProfit += orderForPlanning.CurrentPlan.Profit;

                    Console.WriteLine($"Заказ запланирован: " +
                        $"{orderForPlanning.CurrentPlan.Curier.ToString()}" +
                        $" c прибылью: {orderForPlanning.CurrentPlan.Profit}");
                }
                else
                {
                    Console.WriteLine($"Заказ не запланирован");
                }
            }

            Console.WriteLine($"Итоговая прибыль: {totalProfit}");
        }
    }
}
