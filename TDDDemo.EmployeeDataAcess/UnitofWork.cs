namespace TDDDemo.Employee.Repository
{
    using System;
    using TDDDemo.Employee.DataAccess;

    public class UnitofWork : IUnitofWork
    {
        public readonly EmployeeContext context = null;
        public UnitofWork(EmployeeContext context)
        {
            this.context = context;
            EmployeeRepository = new EmployeeRepository(context);
        }
        public IEmployeeRepository EmployeeRepository { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
