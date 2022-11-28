using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCurriersSchedulerStudyApp.Domain
{
    internal abstract class Curier : IComparable<Curier>
    {
        public string Name { get; set; }

        public Location InitialLocation { get; set; }

        public double CarryingCapacity { get; set; }

        public double Speed { get; set; }

        public bool CanCarry(Order order)
        {
            return CarryingCapacity >= order.Weigth;
        }

        public int CompareTo(Curier? other)
        {
            return (int)(other != null ? CarryingCapacity - other.CarryingCapacity : -1); ;
        }

        public string GetInfo()
        {
            return string.Format("Курьер: {0}|" +
                " Скорость: {1} |" +
                " Грузоподъмность {2} |" +
                " Находится в {3}",
                Name, Speed, CarryingCapacity, InitialLocation.ToString());
        }

        internal void AcceptPlan(PlanningOption planningOption)
        {
            throw new NotImplementedException();
        }

        internal PlanningOption RequestPlanningOption(Order order)
        {
            throw new NotImplementedException();
        }
    }

    internal class FootCurier : Curier
    {
        public FootCurier()
        {
            Speed = Company.DefaultFootCurierSpeed;
        }
    }

    internal class MobileCurier : Curier
    {
        public MobileCurier()
        {
            Speed = Company.DefaultMobileCurierSpeed;
        }
    }

}
