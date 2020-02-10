namespace TDDDemo.Employee.Repository
{ 
    using System.Collections.Generic;
    using TDDDemo.Employee.DataAccess;
    using TDDDemo.Employee.Modals;
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private EmployeeEntities employeeContext = null;
        public EmployeeRepository(EmployeeEntities employeeContext) : base(employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        public void Save()
        {
            employeeContext.SaveChanges();
        }
    }
}
