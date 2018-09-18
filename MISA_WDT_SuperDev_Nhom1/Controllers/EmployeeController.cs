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

        public IEnumerable<Employee> Get(int start, int count)
        {
            DatabaseAccess da = new DatabaseAccess();
            int len = 0;
            if (da.ListEmployee.Count == 0)
            {
                da.Select("SELECT * FROM Employee");
            }
            da.Dispose();
            len = da.ListEmployee.Count;
            if (count > len)
                return null;
            if (start + count > len)
                return null;
            return da.ListEmployee.OrderBy(n => n.EmployeeCode).ToList().GetRange(start, count);
        }

        // GET: api/Employee/5
        public Employee Get(Guid employeeID)
        {
            
            //Get data
            DatabaseAccess da = new DatabaseAccess();
            if (da.ListEmployee.Count == 0)
            {
                da.Select("SELECT * FROM Employee");
            }
            da.Dispose();

            return da.ListEmployee.First(n=>n.EmployeeID==employeeID);
        }
        
         //GET: api/Employee/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public Employee Get(string pattern)
        {
            
            //Get data
            DatabaseAccess da = new DatabaseAccess();
            if (da.ListEmployee.Count == 0)
            {
                da.Select("SELECT * FROM Employee");
            }
            da.Dispose();

            return da.ListEmployee.First(n=>n.EmployeeCode == pattern || n.EmployeeName.Contains(pattern) || n.NumberPhone == pattern);
        }

        // POST: api/Employee
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]Employee e)
        {
            DatabaseAccess da = new DatabaseAccess();
            da.Insert(e);
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
