using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SalaryCalculatorLogic;
using SalaryCalculatorLogic.Employees;
using SalaryCalculatorLogic.Enums;
using SalaryCalculatorLogic.Interfaces;

namespace SalaryCalculatorTests
{
    [TestFixture]
    public class CalculatorTest
    {
        private static readonly List<IEmployee> employees = new List<IEmployee>();

        [SetUp]
        public void Setup()
        {
            PopulateEmployees();
        }

        [Test]
        public void Test_CEO_Salary_From_All_Employees()
        {
            List<IEmployee> result = EmployeeFactory.GetSalariesForAllEmployees(employees);
            Assert.AreEqual(result[0].GetType().Name, EmployeeEnums.EmployeeType.CEO.ToString());
            Assert.AreEqual(result[0].SalaryGrossToPay , 26000m);
        }

        [Test]
        public void Test_Junior_Manager_Salary()
        {
            var result =
                EmployeeFactory.GetSalaryForEmployee(
                    employees.OfType<Manager>().FirstOrDefault(c => c.Level == EmployeeEnums.Level.Junior));
            Assert.AreEqual(result.GetType().Name, EmployeeEnums.EmployeeType.Manager.ToString());
            Assert.AreEqual(result.SalaryGrossToPay, 13100m);
        }

        [Test]
        public void Test_Senior_Manager_Salary()
        {
            var result =
                EmployeeFactory.GetSalaryForEmployee(
                    employees.OfType<Manager>().FirstOrDefault(c => c.Level == EmployeeEnums.Level.Senior));
            Assert.AreEqual(result.GetType().Name, EmployeeEnums.EmployeeType.Manager.ToString());
            Assert.AreEqual(result.SalaryGrossToPay, 15200m);
        }

        [Test]
        public void Test_Junior_Programmer_Salary()
        {
            var result =
                EmployeeFactory.GetSalaryForEmployee(
                    employees.OfType<Programmer>().FirstOrDefault(c => c.Level == EmployeeEnums.Level.Junior));
            Assert.AreEqual(result.GetType().Name, EmployeeEnums.EmployeeType.Programmer.ToString());
            Assert.AreEqual(result.SalaryGrossToPay, 5500m);
        }

        [Test]
        public void Test_Senior_Programmer_Salary()
        {
            var result =
                EmployeeFactory.GetSalaryForEmployee(
                    employees.OfType<Programmer>().FirstOrDefault(c => c.Level == EmployeeEnums.Level.Senior));
            Assert.AreEqual(result.GetType().Name, EmployeeEnums.EmployeeType.Programmer.ToString());
            Assert.AreEqual(result.SalaryGrossToPay, 6500m);
        }

        private static void PopulateEmployees()
        {
            var internalEmployees = new List<IEmployee>();
            internalEmployees.Add(EmployeeFactory.InitializeEmployee(EmployeeEnums.EmployeeType.CEO,
                                                                     EmployeeEnums.Level.Senior));
            internalEmployees.Add(EmployeeFactory.InitializeEmployee(EmployeeEnums.EmployeeType.Programmer,
                                                                     EmployeeEnums.Level.Senior));
            internalEmployees.Add(EmployeeFactory.InitializeEmployee(EmployeeEnums.EmployeeType.Programmer,
                                                                     EmployeeEnums.Level.Junior));

            employees.AddRange(internalEmployees);
            var seniorManager = EmployeeFactory.InitializeEmployee(EmployeeEnums.EmployeeType.Manager,
                                                                   EmployeeEnums.Level.Senior);
            seniorManager.PeopleManaged = new List<IEmployee>();
            seniorManager.PeopleManaged.AddRange(employees.OfType<Programmer>().ToList());
            employees.Add(seniorManager);

            var juniorManager = EmployeeFactory.InitializeEmployee(EmployeeEnums.EmployeeType.Manager,
                                                                   EmployeeEnums.Level.Junior);
            juniorManager.PeopleManaged = new List<IEmployee>();
            juniorManager.PeopleManaged.Add(
                employees.OfType<Programmer>().FirstOrDefault(c => c.Level == EmployeeEnums.Level.Junior));
            employees.Add(juniorManager);
        }
    }
}
