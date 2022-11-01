﻿using System;
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

            //foreach (var order in Company.Orders)
            //{
            //    var list = order.CurriersForOrder();

            //    Console.WriteLine(order.GetInfo());

            //    foreach (var cur in list)
            //    {
            //        Console.WriteLine(cur.GetInfo());
            //    }

            //    Console.WriteLine("====");
            //}

            Console.ReadKey();
        }
    }
}