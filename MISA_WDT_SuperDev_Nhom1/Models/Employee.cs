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
        public string Gender { get; set; }
        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Sinh nhật
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string NumberPhone { get; set; }
        /// <summary>
        /// email - thư điện tử
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Vị trí công việc
        /// </summary>
        public string JobPosition { get; set; }
        /// <summary>
        /// Đơn vị công tác
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Trình độ đào tạo
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// Nơi đào tạo
        /// </summary>
        public string University { get; set; }
        /// <summary>
        /// Chuyên ngành
        /// </summary>
        public string Major { get; set; }
        /// <summary>
        /// Ngày thử việc
        /// </summary>
        public DateTime TrialDate { get; set; }
        /// <summary>
        /// Ngày chính thức
        /// </summary>
        public DateTime OfficalDate { get; set; }
        /// <summary>
        /// Loại hợp đồng
        /// </summary>
        public string ContractType { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        public string State { get; set; }
    }
}