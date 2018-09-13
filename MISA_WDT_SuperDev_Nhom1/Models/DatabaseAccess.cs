using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MISA_WDT_SuperDev_Nhom1.Models
{
    public class DatabaseAccess : IDisposable
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["nhom_1"].ConnectionString;

        private SqlConnection _sqlConnection;

        public DatabaseAccess()
        {
            //Nếu SqlConnection chưa được khởi tạo thì khởi tạo mới 
            if (this._sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(_connectionString);
            }
            if(this._sqlConnection.State == ConnectionState.Closed) 
            {
                this._sqlConnection.Open();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> Select()
        {
            //danh sách nhân viên lấy được từ db
            List<Employee> employees = new List<Employee>();
            Employee employee;

            //tao cau truy van
            SqlCommand _sqlCommand = this._sqlConnection.CreateCommand();

            //Khai báo kiểu truy vấn dữ liệu
            _sqlCommand.CommandType = CommandType.Text;

            //Khai báo câu lệnh truy vấn
            _sqlCommand.CommandText = "SELECT * FROM Employee";

            //Thực hiện truy vấn lấy dữ liệu thông qua SqlDataAdapter
            SqlDataReader _sqlDataReader = _sqlCommand.ExecuteReader();

            //Đọc dữ liệu từ Sql DataReader
            while (_sqlDataReader.Read())
            {
                employee = new Employee();
                employee.EmployeeName = _sqlDataReader["EmployeeName"].ToString();
            }
            return new List<Employee>();
        }

        public int Insert()
        {
            return 0;
        }

        public bool Update()
        {
            return true;
        }

        public void Dispose()
        {
            this._sqlConnection.Close();
        }
    }
}