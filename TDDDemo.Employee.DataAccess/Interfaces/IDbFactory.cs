using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemo.Employee.DataAccess
{
    public interface IDbFactory : IDisposable
    {
        EmployeeEntities Init();
    }
}
