using SalaryCalculatorLogic.Enums;

namespace SalaryCalculatorLogic.Employees
{
    public class CEO : EmployeeBase
    {
        internal CEO() : base(EmployeeEnums.Level.Senior) { }

        public override decimal SalaryGross { get { return 20000; } }
        public override decimal Bonus { get; set; }
        public override decimal SalaryGrossToPay { get { return SalaryGross + Bonus; } }
        public new EmployeeEnums.Level Level { get { return EmployeeEnums.Level.Senior; } set { } }

        public override void CalculateBonus()
        {
            this.Bonus = (this.SalaryGross * 0.2m) + 2000;
        }
    }
}