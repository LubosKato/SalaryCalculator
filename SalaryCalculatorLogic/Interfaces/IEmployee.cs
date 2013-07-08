using System.Collections.Generic;
using SalaryCalculatorLogic.Enums;

namespace SalaryCalculatorLogic.Interfaces
{
    public interface IEmployee
    {
        decimal SalaryGross { get; }
        decimal SalaryGrossToPay { get; }
        decimal Bonus { get; set; }
        List<IEmployee> PeopleManaged { get; set; }        
        EmployeeEnums.Level Level { get; set; }
        void CalculateBonus();
    }
}