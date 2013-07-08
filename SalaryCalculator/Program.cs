using System;
using System.Collections.Generic;
using System.Linq;
using SalaryCalculatorLogic;
using SalaryCalculatorLogic.Employees;
using SalaryCalculatorLogic.Enums;
using SalaryCalculatorLogic.Interfaces;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var employees = new List<IEmployee>();

                //let's create a new employee for each available employee type. Each item is insatantiated
                //without the client needing to know what type of object is being created (this is handled by the factory method)
                foreach (EmployeeEnums.EmployeeType employee in Enum.GetValues(typeof(EmployeeEnums.EmployeeType)))
                {
                    foreach (EmployeeEnums.Level level in Enum.GetValues(typeof(EmployeeEnums.Level)))
                    {
                        var tempEmployee = EmployeeFactory.InitializeEmployee(employee, level);
                        if (!employees.Contains(tempEmployee, new LevelComparer()))
                            employees.Add(tempEmployee);
                    }
                }

                //now let's iterate through our dictionary and diplay the base salary for each factory object
                foreach (var employee in employees)
                {
                    employee.CalculateBonus();
                    Console.WriteLine(string.Format("The base salary for {0} is {1:C}",
                                                    employee.Level + " " + employee.GetType().Name,
                                                    employee.SalaryGrossToPay));
                }

                Console.ReadKey();
            }
            catch (Exception e)
            {

                Console.WriteLine("\n{0}\n", e.Message);
            }
        }
    }
}
