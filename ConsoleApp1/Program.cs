using System;
using System.Security.Cryptography.X509Certificates;
using SimpleCurriersSchedulerStudyApp.Domain;

namespace SimpleCurriersSchedulerStudyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currier1 = new
                FootCurierAgent
            {
                Name = "Вася",
                InitialLocation = Location.Create(5, 5),
                CarryingCapacity = 5
            };

            var currier2 = new
                FootCurierAgent
            {
                Name = "Петя",
                InitialLocation = Location.Create(3, 3),
                CarryingCapacity = 6
            };

            var currier3 = new
                MobileCurierAgent
            {
                Name = "Коля",
                InitialLocation = Location.Create(1, 1),
                CarryingCapacity = 8
            };

            var currier4 = new
                MobileCurierAgent
            {
                Name = "Нина",
                InitialLocation = Location.Create(3, 3),
                CarryingCapacity = 2
            };

            var order1 = new OrderAgent
            {
                FromLocation = Location.Create(3, 3),
                ToLocation = Location.Create(2, 2),
                Weigth = 5
            };

            var order2 = new OrderAgent
            {
                FromLocation = Location.Create(5, 5),
                ToLocation = Location.Create(5, 1),
                Weigth = 4
            };

            var order3 = new OrderAgent
            {
                FromLocation = Location.Create(1, 5),
                ToLocation = Location.Create(1, 1),
                Weigth = 3
            };

            var order4 = new OrderAgent
            {
                FromLocation = Location.Create(2, 2),
                ToLocation = Location.Create(3, 3),
                Weigth = 3
            };

            var order5 = new OrderAgent
            {
                FromLocation = Location.Create(1, 5),
                ToLocation = Location.Create(5, 1),
                Weigth = 2
            };

            var company = CompanyAgent.CompanyInstance;
            company.Curiers.Add(currier1);
            company.Curiers.Add(currier2);
            company.Curiers.Add(currier3);
            company.Curiers.Add(currier4);

            company.Orders.Add(order1);
            company.Orders.Add(order2);
            company.Orders.Add(order3);
            company.Orders.Add(order4);
            company.Orders.Add(order5);

            company.PrintOrders();
            Console.WriteLine();
            company.PrintCuriers();

            company.StartPlaner();

            Console.ReadKey();
        }
    }
}