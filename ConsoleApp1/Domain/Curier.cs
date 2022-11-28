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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Действие по формированию варианта размещения заказа в плане курьера
        /// </summary>
        /// <param name="order">Заказ, рассматриваемый к размещению в плане</param>
        /// <returns>Вариант размещения, включающий оценки</returns>        
        internal PlanningOption RequestPlanningOptionAction(Order order)
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Пеший курьер
    /// </summary>
    internal class FootCurier : Curier
    {
        public FootCurier()
        {
            Speed = Company.DefaultFootCurierSpeed;
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
        }
    }

}
