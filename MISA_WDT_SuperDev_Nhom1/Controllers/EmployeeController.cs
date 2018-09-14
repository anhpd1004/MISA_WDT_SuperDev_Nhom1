using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MISA_WDT_SuperDev_Nhom1.Models;

namespace MISA_WDT_SuperDev_Nhom1.Controllers
{
    public class EmployeeController : ApiController
    {


        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();

            //Get data
            DatabaseAccess da = new DatabaseAccess();
            employees = da.Select();
            da.Dispose();

            employees.OrderBy(n => n.EmployeeCode);
            return employees;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {
            DatabaseAccess da = new DatabaseAccess();
            da.FakeData();
            da.Dispose();
        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
        }
    }
}
