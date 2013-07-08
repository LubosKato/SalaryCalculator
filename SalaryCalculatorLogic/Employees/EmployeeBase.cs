using System.Collections.Generic;
using SalaryCalculatorLogic.Enums;
using SalaryCalculatorLogic.Interfaces;

namespace SalaryCalculatorLogic.Employees
{
    public abstract class EmployeeBase : IEmployee
    {
        protected EmployeeBase(EmployeeEnums.Level level)
        {
            this.Level = level;
        }

        public List<IEmployee> PeopleManaged { get; set; }
        public EmployeeEnums.Level Level { get; set; }
        public abstract decimal SalaryGross { get; }
        public abstract decimal SalaryGrossToPay { get; }
        public abstract decimal Bonus { get; set; }

        public abstract void CalculateBonus();
    }

    public class LevelComparer : IEqualityComparer<IEmployee>
    {
        public bool Equals(IEmployee x, IEmployee y)
        {
            return x.Level.Equals(y.Level) && x.GetType().Name.Equals(y.GetType().Name);
        }

        public int GetHashCode(IEmployee obj)
        {
            return obj.Level.GetHashCode();
        }
    }
}