using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    /// <summary>
    /// Базовый заказ
    /// </summary>
    internal class Order
    {
        public Location FromLocation { get; set; }

        public Location ToLocation { get; set; }

        public double Weigth { get; set; }

        public double OrderDistance
        {
            get { return FromLocation.GetDistance(ToLocation); }
        }

        public double OrderPrice { get { return GetOrderPrice(); } }

        public PlanningOption CurrentPlan { get; private set; }

        private double GetOrderPrice()
        {
            return OrderDistance * Company.PricePerDistance;
        }

        public string GetInfo()
        {
            return $"Заказ {FromLocation.ToString()} -> {ToLocation.ToString()}" +
                $" ({OrderDistance} км) | {OrderPrice}";
        }

        public bool PlanOrder()
        {
            //Подбираем подходящих курьеров
            var curriers = FindCurriers();

            //Готовим место для ответов
            var planningOptions = new List<PlanningOption>();

            foreach (var currier in curriers)
            {
                //Спрашиваем курьреа о варианте планирования
                var planningOption = currier.RequestPlanningOption(this);

                if (planningOption != null)
                {
                    planningOptions.Add(planningOption);
                }
            }

            if (planningOptions.Count() > 0)
            {
                //Анализируем и выбираем
                var bestOption = GetBestOption(planningOptions);

                if (bestOption != null)
                {
                    bestOption.Curier.AcceptPlan(bestOption);
                    CurrentPlan = bestOption;
                }
            }

            return false;
        }

        private IList<Curier> FindCurriers()
        {
            throw new NotImplementedException();
        }

        private PlanningOption GetBestOption(IList<PlanningOption> options)
        {
            var sortedOption = options.OrderByDescending(option => option.Profit);
            var bestOption = sortedOption.FirstOrDefault(bestOption => bestOption.Profit > 0);

            return bestOption;
        }

        //public List<Curier> CurriersForOrder()
        //{
        //    var list = new List<Curier>();

        //    var list2 = Company.Curiers.Where(cur => cur.CanCarry(this));

        //    foreach (var currer in Company.Curiers)
        //    {
        //        if (currer.CanCarry(this))
        //        {
        //            list.Add(currer);
        //        }
        //    }

        //    return list2.ToList();


        //}
    }
}
