using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID
{
    /// <summary>
    /// Fix1 and Fix 2 use the Tell, don't ask Principle.
    /// Fix 3 splits up a large interface into smaller ones.
    /// In order to make the existing interface backwards compatible, we can remove all definitions
    /// and inherit from the new interfaces: public interface IDoSomething : IDoSomething2a , IDoSomething2b {}
    /// </summary>
    public class LiskovSubstitutionPrincipleEnd
    {
        private Employee2 _employee = new Employee2();

        public void fix1()
        {
            var employeeData = _employee.GetEmployee();

            _employee.Print(employeeData);
        }

        public void fix2()
        {
            var employeeData = _employee.GetEmployee();

            _employee.Print(employeeData);
        }

        public void fix3()
        {
            var obj2a = new DoSomething2a();
            var obj2b = new DoSomething2b();

            Console.WriteLine(obj2a.DoSomething1());
            Console.WriteLine(obj2b.DoSomething2());

        }

    }

    public class Employee2
    {
        public void PrintManager()
        {
            Console.WriteLine("Im a manager");
        }

        public void PrintEmployee()
        {
            Console.WriteLine("Im an employee");
        }


        public void Print(EmployeeModel2 employee)
        {

            if (employee.Type == "Manager")
                PrintManager();

            if (employee.Id == null)
                throw new NullReferenceException("Employee ID can't be null.");

            PrintEmployee();
        }

        public EmployeeModel2 GetEmployee()
        {
            return new EmployeeModel2()
            {
                Id = 1,
                Name = "Emp Name",
                Type = "Manager"
            };
        }
    }
    public class EmployeeModel2
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }


    


    public interface IDoSomething2a
    {
        string DoSomething1();
    }

    public interface IDoSomething2b
    {
        string DoSomething2();
    }

    public class DoSomething2a : IDoSomething2a
    {
        public string DoSomething1()
        {
            return "Doing something 1";
        }


    }

    public class DoSomething2b : IDoSomething2b
    {
        public string DoSomething2()
        {
            return "Doing something 2";
        }


    }

}
