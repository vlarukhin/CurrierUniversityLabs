using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Базовый заказ на перемещение груза, который может быть выполнен курьером
    /// </summary>
    internal class Order
    {
        /// <summary>
        /// Отправная точка заказа
        /// </summary>
        public Location FromLocation { get; set; }

        /// <summary>
        /// Пункт назначения заказа
        /// </summary>
        public Location ToLocation { get; set; }

        /// <summary>
        /// Вес посылки
        /// </summary>
        public double Weigth { get; set; }

        /// <summary>
        /// Расстояние, на которое необходимо переместить посылку
        /// </summary>
        public double OrderDistance
        {
            get { return FromLocation.GetDistance(ToLocation); }
        }

        /// <summary>
        /// Базовая стоимость заказа
        /// </summary>
        public double OrderPrice
        {
            get
            {
                return GetOrderPrice();
            }
        }

        /// <summary>
        /// Текущий вариант исполнения Заказа
        /// </summary>
        public PlanningOption CurrentPlan { get; private set; }

        /// <summary>
        /// Определяет, что заказ запланирован
        /// </summary>
        public bool IsPlanned { get { return CurrentPlan != null; } }

        /// <summary>
        /// Выполняет расчет стоимости Заказа по тарифу Компании
        /// </summary>
        /// <returns>Стоимость выполнения заказа по тарифу компании</returns>
        private double GetOrderPrice()
        {
            return OrderDistance * Company.PricePerDistance;
        }

        /// <summary>
        /// Формирует строковое представление с описанием Заказа
        /// </summary>
        /// <returns>Строка, содержащая информацию о Заказе</returns>
        public string GetInfo()
        {
            return $"Заказ {FromLocation.ToString()} -> {ToLocation.ToString()}" +
                $" ({OrderDistance} км) | {OrderPrice}";
        }

        List<PlanningOption> _planningOptions = new List<PlanningOption>();

        /// <summary>
        /// Базовый процесс планирования Заказа
        /// </summary>
        /// <returns></returns>
        public bool PlanOrderAction()
        {
            //Подбираем подходящих курьеров
            var curriers = FindCurriers();

            //Готовим "место" для ответов вариантов от Курьеров
            _planningOptions = new List<PlanningOption>();

            //Для каждого найденного курьера производится поиск варианта планирования
            foreach (var currier in curriers)
            {
                //Спрашиваем курьреа о варианте планирования
                var planningOption = currier.RequestPlanningOptionAction(this);

                //Если курьер вернул предложение, добавляем вариант в список
                if (planningOption != null)
                {
                    _planningOptions.Add(planningOption);
                }
            }

            //Если мы получили варианты от курьеров, то производим анализ
            if (_planningOptions.Count() > 0)
            {
                //Анализируем варианты и выбираем "лучший" для нас
                var bestOption = GetBestOption(_planningOptions);

                //Если есть лучший вариант, то выбираем лучший
                if (bestOption != null)
                {
                    bestOption.Curier.AcceptPlanAction(bestOption);
                    CurrentPlan = bestOption;

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Производит поиск курьеров для выполнения заказов
        /// </summary>
        /// <returns>Список подходящих курьеров</returns>        
        private IList<Curier> FindCurriers()
        {
            var curriers = Company.CompanyInstance.GetAvailibleCurriers()
                                .Where(x => x.CanCarry(this));

            return curriers.ToList();
        }

        /// <summary>
        /// Выбирает лучший для заказа вариант планирования
        /// </summary>
        /// <param name="options">Варианты размещения заказов</param>
        /// <returns>Лучший вариант размещения</returns>
        private PlanningOption GetBestOption(IList<PlanningOption> options)
        {
            var sortedOption = options.OrderByDescending(option => option.Profit);
            var bestOption = sortedOption.FirstOrDefault(bestOption => bestOption.Profit > 0);

            return bestOption;
        }

        internal void ReviewOffer(PlanningOption option)
        {
            if (!IsPlanned || CurrentPlan.Profit < option.Profit)
            {
                Console.WriteLine($"Заказ получил выгодное предложение {option.Profit}" +
                    $" от курьера {option.Curier.Name}");

                option.Curier.AcceptPlanAction(option);
                CurrentPlan = option;
            }
        }
    }
}
