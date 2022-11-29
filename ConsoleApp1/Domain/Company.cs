using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Курьерская компания, которая выполняет заказы на перевозку грузов своими курьерами
    /// </summary>
    internal class Company
    {
        public const double PricePerDistance = 100;

        public const double DefaultFootCurierSpeed = 4;

        public const double DefaultMobileCurierSpeed = 8;


        /// <summary>
        /// Курьеры
        /// </summary>
        public HashSet<Curier> Curiers { get; set; } = new HashSet<Curier>();

        /// <summary>
        /// Очередь поступающих заказов
        /// </summary>
        public Queue<Order> OrdersQueue { get; set; } = new Queue<Order>();

        /// <summary>
        /// Заказы компании
        /// </summary>
        public HashSet<Order> Orders { get; set; } = new HashSet<Order>();


        /// <summary>
        /// Получает множество доступных на текущий момент курьеров
        /// </summary>
        /// <returns>Множество доступных курьеров</returns>
        public HashSet<Curier> GetAvailibleCurriers()
        {
            return Curiers;
        }

        /// <summary>
        /// Отображает заказы в консоли
        /// </summary>
        //TODO: Вынести метод - не относится к предметной логике
        public void PrintOrders()
        {
            foreach (var order in Orders)
            {
                Console.WriteLine(order.GetInfo());
            }
        }

        /// <summary>
        /// Отображает курьров в консоли
        /// </summary>
        //TODO: Вынести метод - не относится к предметной логике
        public void PrintCuriers()
        {
            foreach (var curier in Curiers)
            {
                Console.WriteLine(curier.GetInfo());
            }
        }

        /// <summary>
        /// Запускает цикл планирования заказов
        /// </summary>
        public void StartPlaner()
        {
            PrepareQueue();
            PlanningCycle();
        }

        /// <summary>
        /// Подготовка очереди заказов к планирования
        /// </summary>
        private void PrepareQueue()
        {
            var sortedOrders = Orders.OrderByDescending(x => x.OrderPrice);

            foreach (var order in sortedOrders)
            {
                OrdersQueue.Enqueue(order);
            }
        }

        /// <summary>
        /// Реализация цикла планирования заказов
        /// </summary>
        private void PlanningCycle()
        {
            var totalProfit = 0.0;

            while (OrdersQueue.Count > 0)
            {
                var orderForPlanning = OrdersQueue.Dequeue();

                Console.WriteLine($"Планируется заказ: {orderForPlanning.GetInfo()}");
                Console.WriteLine();

                var result = orderForPlanning.PlanOrderAction();

                if (result)
                {
                    totalProfit += orderForPlanning.CurrentPlan.Profit;

                    Console.WriteLine($"Заказ запланирован: " +
                        $"{orderForPlanning.CurrentPlan.Curier.Name}" +
                        $" c прибылью: {Math.Round(orderForPlanning.CurrentPlan.Profit, 2)}");
                }
                else
                {
                    Console.WriteLine($"Заказ не запланирован");
                }
            }

            Console.WriteLine($"Итоговая прибыль: {Math.Round(totalProfit,2)}");
        }

        /// <summary>
        /// Экземпляр компании (внутренее поле)
        /// </summary>
        private static Company _instance;

        /// <summary>
        /// Экземпляр компании
        /// </summary>
        public static Company CompanyInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Company();
                }

                return _instance;
            }
        }
    }    
}
