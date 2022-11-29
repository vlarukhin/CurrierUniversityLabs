using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Описатель события заказа
    /// </summary>
    internal class OrderEventDescriptor : EventArgs
    {
        /// <summary>
        /// Заказ, для которого произошло событие
        /// </summary>
        public Order Order { get; set; }
    }
}
