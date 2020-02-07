namespace TDDDemo.Employee.DataAccess
{
    using System.Collections.Generic;
    using TDDDemo.Employee.Modals;

    public interface IEmployeeContext
    {
        List<Employee> Employees { get; set; }
    }
}
