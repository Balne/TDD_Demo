using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemo.Employee.DataAccess
{
    public class EmployeeDbFactory : Disposable, IDbFactory
    {
        EmployeeEntities context = null;
        public EmployeeEntities Init()
        {
            return context ?? (context = new EmployeeEntities());
        }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
