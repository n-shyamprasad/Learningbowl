using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emp.ModelLayer;


namespace Emp.WebAPILayer.Controllers
{
    public class EmployeeController : ApiController
    {
        List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>();
            employees.Add(new Employee { Id = 101, EmpName = "John K", EmpMobile = "+001 1234567", EmpAddress = "Los Angeles, USA" });
            employees.Add(new Employee { Id = 201, EmpName = "David J", EmpMobile = "+65 8234 5678", EmpAddress = "Raffles, Singapore" });
            employees.Add(new Employee { Id = 301, EmpName = "N S Prasad", EmpMobile = "+91 94401 25678", EmpAddress = "Bangalore, India" });
        }

        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        public Employee Get(int Id)
        {
            return employees.FirstOrDefault<Employee>(x => x.Id.Equals(Id));
        }
        #region default methods commented for now
        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        */
        #endregion
    }
}