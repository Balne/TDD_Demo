namespace TDDDemo.EmployeeManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using TDDDemo.Employee.Business;
    using TDDDemo.Employee.Modals;

    public class EmployeeController : ApiController
    {
        private readonly IManageEmployee manageEmployee = null;
        public EmployeeController(IManageEmployee manageEmployee)
        {
            this.manageEmployee = manageEmployee;
        }

        // GET api/employee
        public IEnumerable<Employee> Get()
        {
            return this.manageEmployee.GetAllEmployees();
        }

        // GET api/employee/5
        public Employee Get(int id)
        {
            throw new NotImplementedException();
            //return this.manageEmployee.Get(id);
        }

        // POST api/employee
        public void Post([FromBody]Employee employee)
        {
            // Yet to implement
            manageEmployee.SaveEmployee(employee);
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
