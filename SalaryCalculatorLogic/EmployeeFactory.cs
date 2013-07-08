using System;
using System.Collections.Generic;
using SalaryCalculatorLogic.Employees;
using SalaryCalculatorLogic.Enums;
using SalaryCalculatorLogic.Interfaces;

namespace SalaryCalculatorLogic
{
    public class EmployeeFactory
    {
        public static IEmployee InitializeEmployee(EmployeeEnums.EmployeeType employeeType, EmployeeEnums.Level level)
        {
            IEmployee employee;
            switch (employeeType)
            {
                case EmployeeEnums.EmployeeType.Programmer:
                    employee = new Programmer(level);
                    break;
                case EmployeeEnums.EmployeeType.Manager:
                    employee = new Manager(level);
                    break;
                case EmployeeEnums.EmployeeType.CEO:
                    employee = new CEO();
                    break;
                default:
                    throw new ArgumentException(string.Format("An employee of type {0} cannot be found", Enum.GetName(typeof(EmployeeEnums.EmployeeType), employeeType)));
            }
            return employee;
        }

        public static List<IEmployee> GetSalariesForAllEmployees(List<IEmployee> employees)
        {
            foreach (var employee in employees)
            {
                employee.CalculateBonus();
            }
            return employees;
        }

        public static IEmployee GetSalaryForEmployee(IEmployee employee)
        {
            employee.CalculateBonus();
            return employee;
        }
    }
}