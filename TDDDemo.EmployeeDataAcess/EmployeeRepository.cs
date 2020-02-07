namespace TDDDemo.Employee.Repository
{ 
    using System.Collections.Generic;
    using TDDDemo.Employee.DataAccess;
    using TDDDemo.Employee.Modals;
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private EmployeeContext employeeContext = null;
        public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        public void Save()
        {
            employeeContext.SaveChanges();
        }
    }
}
