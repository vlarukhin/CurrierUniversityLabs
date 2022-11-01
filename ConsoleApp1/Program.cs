using System;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currier1 = new
                FootCurier {Name = "Вася", 
                InitialLocation = Location.Create(5,5),
                CarryingCapacity = 5  };

            var currier2 = new
                FootCurier
            {
                Name = "Петя",
                InitialLocation = Location.Create(3, 3),
                CarryingCapacity = 6
            };

            var currier3 = new
                MobileCurier
            {
                Name = "Коля",
                InitialLocation = Location.Create(1, 1),
                CarryingCapacity = 8
            };

            var currier4 = new
                MobileCurier
            {
                Name = "Нина",
                InitialLocation = Location.Create(3, 3),
                CarryingCapacity = 2
            };

                        var order1 = new Order {
                FromLocation = Location.Create(3, 3),
                ToLocation = Location.Create(2, 2),
                Weigth = 5 };

            var order2 = new Order
            {
                FromLocation = Location.Create(5, 5),
                ToLocation = Location.Create(5, 1),
                Weigth = 10
            };

            var order3 = new Order
            {
                FromLocation = Location.Create(1, 5),
                ToLocation = Location.Create(1, 1),
                Weigth = 3
            };

            var order4 = new Order
            {
                FromLocation = Location.Create(2, 2),
                ToLocation = Location.Create(3, 3),
                Weigth = 3
            };

            var order5 = new Order
            {
                FromLocation = Location.Create(1, 5),
                ToLocation = Location.Create(5, 1),
                Weigth = 10
            };


            var company = new Company();
            Company.Curiers.Add(currier1);
            Company.Curiers.Add(currier2);
            Company.Curiers.Add(currier3);
            Company.Curiers.Add(currier4);

            Company.Orders.Enqueue(order1);
            Company.Orders.Enqueue(order2);
            Company.Orders.Enqueue(order3);
            Company.Orders.Enqueue(order4);
            Company.Orders.Enqueue(order5);

            company.PrintOrders();
            company.PrintCuriers();

            var c = Company.Curiers.OrderBy(x => x.CarryingCapacity);

            foreach (var order in Company.Orders)
            {
                var list = order.CurriersForOrder();

                Console.WriteLine(order.GetInfo());

                foreach (var cur in list)
                {
                    Console.WriteLine(cur.GetInfo());
                }

                Console.WriteLine("====");
            }

            Console.ReadKey();
        }
    }
}