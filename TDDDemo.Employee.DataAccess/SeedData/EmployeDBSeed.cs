namespace TDDDemo.Employee.DataAccess
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using TDDDemo.Employee.Modals;
    public class EmployeDBSeed : DropCreateDatabaseIfModelChanges<EmployeeEntities>
    {
        protected override void Seed(EmployeeEntities context)
        {
            SeedEmployees();

            context.SaveChanges();
        }

        private List<Employee> SeedEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    EmployeeName = "Peter",
                    Age=30
                },
                new Employee
                {
                    EmployeeName = "Alan",
                    Age=35
                }
            };
        }
    }
}
