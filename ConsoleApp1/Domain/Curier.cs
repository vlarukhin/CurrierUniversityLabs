using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Курьер, способный выполнять заказы на доставку грузов
    /// </summary>
    internal abstract class Curier
    {
        /// <summary>
        /// Наимеование курьера, например ФИО
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Начальное местоположение
        /// </summary>
        public Location InitialLocation { get; set; }

        /// <summary>
        /// Грузоподъемность (вместимость ранца курьера)
        /// </summary>
        public double CarryingCapacity { get; set; }

        /// <summary>
        /// Скорость
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Стоимость курьреа
        /// </summary>
        public double CurreierPrice { get; set; }

        /// <summary>
        /// Проверяет, может ли курьер выполнить Заказ
        /// </summary>
        /// <param name="order">Заказ на перемещение неоторого груза</param>
        /// <returns>Истина, если курьер способен выполнить заказ, ложь - в других случаях</returns>
        public bool CanCarry(Order order)
        {
            return CarryingCapacity >= order.Weigth;
        }

        /// <summary>
        /// Формирует строковое представление с описанием курьера
        /// </summary>
        /// <returns>Строка, содержащая информацию о курьере</returns>
        public string GetInfo()
        {
            return string.Format("Курьер: {0}|" +
                " Скорость: {1} |" +
                " Грузоподъмность {2} |" +
                " Находится в {3}",
                Name, Speed, CarryingCapacity, InitialLocation.ToString());
        }

        /// <summary>
        /// Действие по размещению заказа в плане курьера
        /// </summary>
        /// <param name="planningOption">Вариант размещения заказа в плане курьера</param>        
        internal void AcceptPlanAction(PlanningOption planningOption)
        {
            ScheduledOrder.AddLast(planningOption.Order);
        }

        /// <summary>
        /// Действие по формированию варианта размещения заказа в плане курьера
        /// </summary>
        /// <param name="order">Заказ, рассматриваемый к размещению в плане</param>
        /// <returns>Вариант размещения, включающий оценки</returns>        
        internal PlanningOption RequestPlanningOptionAction(Order order)
        {
            var planningOption = new PlanningOption();

            var currentCurrierLocation =  ScheduledOrder.LastOrDefault()?.ToLocation ?? InitialLocation;

            var distance = currentCurrierLocation.GetDistance(order.FromLocation) + order.OrderDistance;
            var currierCost = distance * this.CurreierPrice;

            planningOption.Curier = this;
            planningOption.Order = order;
            planningOption.Price = currierCost;

            return planningOption;
        }


        private LinkedList<Order> ScheduledOrder = new LinkedList<Order>();
    }
    /// <summary>
    /// Пеший курьер
    /// </summary>
    internal class FootCurier : Curier
    {
        public FootCurier()
        {
            Speed = Company.DefaultFootCurierSpeed;
            CurreierPrice = Company.PricePerDistance * 0.65;
        }
    }

    /// <summary>
    /// Мобильный курьер
    /// </summary>
    internal class MobileCurier : Curier
    {
        public MobileCurier()
        {
            Speed = Company.DefaultMobileCurierSpeed;
            CurreierPrice = Company.PricePerDistance * 0.85;
        }
    }

}
