using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemoConsole
{
    //Model Object
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int Age { get; set; }
    }

    //Context class 

    public interface IEmployeeContext
    {
        List<Employee> Employees { get; set; }
        void SaveChanges();
    }

    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {
        }

        public List<Employee> Employees { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }

    public class DataAccess
    {
        private IEmployeeContext _empContext;
        public DataAccess(IEmployeeContext empContext)
        {
            _empContext = empContext;
        }
        public List<Employee> GetAllEmployees()
        {
            return _empContext.Employees.ToList();
        }

        public void SaveEmployee(string employeeName, int employeeAge)
        {
            int invalidParamsCount = 0;
            bool empNameInvalid = false;
            bool empAgeInvalid = false;
            bool bothInvalid;

            if (!IsValidEmployeeName(employeeName))
            {
                invalidParamsCount++;
                empNameInvalid = true;
            }

            if (!IsValidEmployeeAge(employeeAge))
            {
                invalidParamsCount++;
                empAgeInvalid = true;
            }

            bothInvalid = empNameInvalid && empAgeInvalid;

            if (invalidParamsCount > 0)
            {
                if (bothInvalid)
                {
                    throw new Exception($"Input params has invalid params: {nameof(employeeName)} - {employeeName}, {nameof(employeeAge)} - {employeeAge}");
                }
                else
                {
                    throw new Exception($"Input params has invalid param: {(empNameInvalid ? nameof(employeeName) : nameof(employeeAge))} - {(empNameInvalid ? employeeName : employeeAge.ToString())}");
                }

            }

            var emp = new Employee() { EmployeeName = employeeName, Age = employeeAge };

            // Commenting below statement as Entity Framework is not implemented
            //_empContext.Employees.Add(emp);
            _empContext.SaveChanges();

        }

        private bool IsValidEmployeeName(string empName)
        {
            return (!string.IsNullOrEmpty(empName) && empName.Trim().Length <= 150);
        }

        private bool IsValidEmployeeAge(int age)
        {
            return (age > 15 && age <= 65);
        }
    }
}
