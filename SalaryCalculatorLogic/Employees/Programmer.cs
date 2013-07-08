using SalaryCalculatorLogic.Enums;

namespace SalaryCalculatorLogic.Employees
{
    public class Programmer : EmployeeBase
    {
        internal Programmer(EmployeeEnums.Level level) : base(level) {}

        public override decimal SalaryGross { get { return 5000; } }
        public override decimal SalaryGrossToPay { get { return SalaryGross + Bonus; } }
        public override decimal Bonus { get; set; }

        public override void CalculateBonus()
        {
            this.Bonus += 1000;
            if (EmployeeEnums.Level.Junior == this.Level)
                this.Bonus = this.SalaryGross * 0.1m;
            else
                this.Bonus = this.SalaryGross * 0.3m;
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        