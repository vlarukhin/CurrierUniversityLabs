using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Доска заказов компании
    /// </summary>
    internal class OrderDesk
    {
        public OrderDesk()
        {
            
        }

        /// <summary>
        /// Заказы
        /// </summary>
        public HashSet<Order> Orders { get; private set; } = new HashSet<Order>();

        /// <summary>
        /// Событие появления нового заказа
        /// </summary>
        public event EventHandler<OrderEventDescriptor> NewOrderEvent;


        public void AddOrderToDesk(Order order)
        {
            if (!Orders.Contains(order))
            {
                Console.WriteLine($"Появился новый заказ: {order.GetInfo()}");

                Orders.Add(order);

                //NewOrderEvent.BeginInvoke(this,
                //   new OrderEventDescriptor { Order = order }, null, null);



                NewOrderEvent.Invoke(this,
                    new OrderEventDescriptor { Order = order });
            }            
        }

        public void DeleteOrderFromDesk(Order order)
        {

        }
    }
}
