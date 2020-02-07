namespace TDDDemo.Employee.DataAccess
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using TDDDemo.Employee.Modals;

    public class EmployeeContext : DbContext, IEmployeeContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {
        }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("public");
        //    base.OnModelCreating(modelBuilder);
        //}

        public List<Employee> Employees { get; set; }
        
    }
}
