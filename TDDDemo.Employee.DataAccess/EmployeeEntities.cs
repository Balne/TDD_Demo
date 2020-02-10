namespace TDDDemo.Employee.DataAccess
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using TDDDemo.Employee.Modals;

    public class EmployeeEntities : DbContext, IEmployeeContext
    {
        public EmployeeEntities() : base("EmployeeDB")
        {
        }

        public List<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
        }
    }

    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employee");
            Property(g => g.EmployeeName).IsRequired().HasMaxLength(50);
            Property(g => g.Age).IsRequired();
        }
    }
}
