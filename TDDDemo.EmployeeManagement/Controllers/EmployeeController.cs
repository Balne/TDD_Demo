namespace TDDDemo.EmployeeManagement.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using TDDDemo.Employee.Repository;
    using TDDDemo.Employee.Modals;

    public class EmployeeController : ApiController
    {
        private readonly IUnitofWork unitofWork = null;
        public EmployeeController(IUnitofWork unitofWork)
        {
            this.unitofWork = unitofWork;
        }

        // GET api/employee
        public IEnumerable<Employee> Get()
        {
            return this.unitofWork.EmployeeRepository.GetAll();
        }

        // GET api/employee/5
        public Employee Get(int id)
        {
            return this.unitofWork.EmployeeRepository.Get(id);
        }

        // POST api/employee
        public void Post([FromBody]Employee employee)
        {
            // Yet to implement
            unitofWork.EmployeeRepository.Add(employee);
            unitofWork.SaveChanges();
        }

        // PUT api/employee/5
        public void Put(int id, [FromBody]Employee employee)
        {
            // Yet to implement
        }

        // DELETE api/employee/5
        public void Delete(int id)
        {
            // Yet to implement
        }
    }
}
