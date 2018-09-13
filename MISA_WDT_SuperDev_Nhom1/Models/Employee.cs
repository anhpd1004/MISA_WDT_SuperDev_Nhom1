using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MISA_WDT_SuperDev_Nhom1.Models
{
    public class Employee
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// Nơi công tác
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Sinh nhật
        /// </summary>
        public string Birthday { get; set; }
    }
}