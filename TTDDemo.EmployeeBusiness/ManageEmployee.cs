

namespace TDDDemo.Employee.Business
{
    using System;
    using System.Collections.Generic;
    using TDDDemo.Employee.Business;
    using TDDDemo.Employee.Modals;
    using TDDDemo.Employee.Repository;
    public class ManageEmployee : IManageEmployee
    {
        private readonly IEmployeeRepository employeeRepository = null;
        public ManageEmployee(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.employeeRepository.GetAll();
        }

        public void SaveEmployee(Employee employee)
        {
            int invalidParamsCount = 0;
            bool empNameInvalid = false;
            bool empAgeInvalid = false;
            bool bothInvalid;

            if (!IsValidEmployeeName(employee.EmployeeName))
            {
                invalidParamsCount++;
                empNameInvalid = true;
            }

            if (!IsValidEmployeeAge(employee.Age))
            {
                invalidParamsCount++;
                empAgeInvalid = true;
            }

            bothInvalid = empNameInvalid && empAgeInvalid;

            if (invalidParamsCount > 0)
            {
                if (bothInvalid)
                {
                    throw new Exception($"Input params has invalid params: {nameof(employee.EmployeeName)} - {employee.EmployeeName}, {nameof(employee.Age)} - {employee.Age}");
                }
                else
                {
                    throw new Exception($"Input params has invalid param: {(empNameInvalid ? nameof(employee.EmployeeName) : nameof(employee.Age))} - {(empNameInvalid ? employee.EmployeeName : employee.Age.ToString())}");
                }

            }

            this.employeeRepository.Add(employee);
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
