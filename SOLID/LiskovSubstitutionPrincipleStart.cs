using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// There are three code smells that identify LSP issues:
    /// 1. The need to check for a type
    /// 2. The need to check for nulls
    /// 3. Get a NotImplementedException type
    /// </summary>
    public class LiskovSubstitutionPrincipleStart
    {
        private Employee _employee = new Employee();

        public void Smell1()
        {
            var employeeData = _employee.GetEmployee();

            if (employeeData.Type == "Manager")
                _employee.PrintManager();

            _employee.PrintEmployee();
        }

        public void Smell2()
        {
            var employeeData = _employee.GetEmployee();

            if (employeeData.Id == null)
                Console.WriteLine("Employee not found");

                _employee.PrintEmployee();

        }

        public void Smell3()
        {
            var obj = new DoSomething();
            Console.WriteLine(obj.DoSomething2());// will return an exception.

        }

    }

    public class Employee
    {
        // This breaks the SRP, but it's easier to place all the code in one class for this demo.
        public void PrintManager()
        {
            Console.WriteLine("Im a manager");
        }

        public void PrintEmployee()
        {
            Console.WriteLine("Im an employee");
        }

        public EmployeeModel GetEmployee()
        {
            return new EmployeeModel()
            {
                Id = 1,
                Name = "Emp Name",
                Type = "Manager"
            };
        }
    }
    public class EmployeeModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }

    public interface IDoSomething
    {
        string DoSomething1();
        string DoSomething2();
    }

    public class DoSomething: IDoSomething
    {
        public string DoSomething1()
        {
            return "Doing something 1";
        }

        public string DoSomething2()
        {
            throw new NotImplementedException();
        }
    }
}
