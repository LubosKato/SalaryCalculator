using System;
using SalaryCalculatorLogic.Enums;

namespace SalaryCalculatorLogic.Employees
{
    public class Manager : EmployeeBase
    {
        internal Manager(EmployeeEnums.Level level) : base(level) { }

        public override decimal SalaryGross { get { return 10000; }}
        public override decimal SalaryGrossToPay { get { return SalaryGross + Bonus; } }
        public override decimal Bonus { get; set; }

        public override void CalculateBonus()
        {
            this.Bonus += 2000;
            CalculateBonusPerEmployeeManaged();
            if(EmployeeEnums.Level.Junior == this.Level)
                this.Bonus += this.SalaryGross * 0.1m;
            else
                this.Bonus += this.SalaryGross * 0.3m;
        }

        private void CalculateBonusPerEmployeeManaged()
        {
            //TODO: provide constant from configuration
            if (this.PeopleManaged != null && this.PeopleManaged.Count > 0)
            {
                this.Bonus += this.SalaryGross * Convert.ToDecimal(this.PeopleManaged.Count * 0.01);
            }
        }
    }
}