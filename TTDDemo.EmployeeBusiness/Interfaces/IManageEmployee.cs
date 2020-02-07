namespace TDDDemo.Employee.Business
{
    using System.Collections.Generic;
    using TDDDemo.Employee.Modals;

    public interface IManageEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        void SaveEmployee(Employee employee);
    }
}
