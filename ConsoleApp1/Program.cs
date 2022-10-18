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

            Console.WriteLine(currier1.GetInfo());
            Console.WriteLine(currier2.GetInfo());
            Console.WriteLine(currier3.GetInfo());

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

            Console.WriteLine($"К1 -> З1 {currier1.CanCarry(order1)}");
            Console.WriteLine($"К1 -> З2 {currier1.CanCarry(order2)}");
            Console.WriteLine($"К2 -> З1 {currier2.CanCarry(order1)}");
            Console.WriteLine($"К2 -> З2 {currier2.CanCarry(order2)}");

            Console.ReadKey();
        }
    }
}