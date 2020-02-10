namespace TDDDemo.Employee.DataAccess
{
    using System;
    using System.Collections.Generic;
    using TDDDemo.Employee.Modals;

    public interface IEmployeeContext : IDisposable
    {
        List<Employee> Employees { get; set; }
    }
}
