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
            //Get data
            DatabaseAccess da = new DatabaseAccess();
            if(da.ListEmployee.Count == 0) 
                da.Select("SELECT * FROM Employee");
            da.Dispose();

            return da.ListEmployee.OrderBy(n => n.EmployeeCode).ToList();
        }

        // GET: api/Employee/5
        //public Employee Get(Guid EmployeeID)
        //{
        //    Employee employee = new Employee();

        //    //Get data
        //    DatabaseAccess da = new DatabaseAccess();
        //    string _sqlQuery = "SELECT * FROM Employee AS E" +
        //                       "WHERE E.EmployeeID = " + EmployeeID;
        //    List<Employee> employees = da.SelectById(_sqlQuery);
        //    if (employees.Count > 0)
        //        employee = employees[0];
        //    da.Dispose();

        //    return employee;
        //}
        // GET: api/Employee/5
        //public Employee Get(string pattern)
        //{
        //    Employee employee = new Employee();

        //    //Get data
        //    DatabaseAccess da = new DatabaseAccess();
        //    string _sqlQuery = "SELECT * FROM Employee AS E" +
        //                       "WHERE E.EmployeeName like N'%" + pattern + "%'";
        //    List<Employee> employees = da.Select(_sqlQuery);
        //    if (employees.Count > 0)
        //        employee = employees[0];
        //    da.Dispose();

        //    return employee;
        //}

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
