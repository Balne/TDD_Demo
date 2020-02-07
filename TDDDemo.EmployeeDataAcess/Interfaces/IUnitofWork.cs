using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDemo.Employee.Repository
{
    public interface IUnitofWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        void SaveChanges();
    }
}
