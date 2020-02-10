namespace TDDDemo.Employee.Repository
{
    using System;
    using TDDDemo.Employee.DataAccess;

    public class UnitofWork : IUnitofWork
    {
        private EmployeeEntities context;
        private readonly IDbFactory dbFactory;

        public UnitofWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public EmployeeEntities Context
        {
            get
            {
                if(this.context == null)
                {
                    this.context = this.dbFactory.Init();
                }
                return this.context;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
