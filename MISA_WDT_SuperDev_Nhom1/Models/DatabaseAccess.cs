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

        public static void Main()
        {
            DatabaseAccess da = new DatabaseAccess();
            da.FakeData();
            da.Dispose();
            System.Console.WriteLine("done");
        }

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

        public int Insert(Employee employee)
        {
            
            return 0;
        }

        public int FakeData()
        {
            // define INSERT query with parameters
            string query = "INSERT INTO dbo.Employee (EmployeeID, EmployeeCode, EmployeeName, Gender, Address, Birthday, NumberPhone, " +
                                                    "Email, CompanyName, Education, Major, TrialDate, OfficalDate, ContractType, State) " +
                           "VALUES (@EmployeeID, @EmployeeCode, @EmployeeName, @Gender, @Address, @Birthday, @NumberPhone, " +
                                   "@Email, @CompanyName, @Education, @Major, @TrialDate, @OfficalDate, @ContractType, @State)";

            // create connection and command
            using (SqlCommand cmd = new SqlCommand(query, this._sqlConnection))
            {
                // define parameters and their values
                cmd.Parameters.Add("@EmployeeID", SqlDbType.VarChar, 50).Value = Guid.NewGuid();
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 50).Value = "NV00001";
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar, 50).Value = "Phạm Duy Anh";
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = "Nam";
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = "Tiên Lãng - Hải Phòng";
                cmd.Parameters.Add("@Birthday", SqlDbType.VarChar, 50).Value = DateTime.Now.ToString("MM/dd/yyyy");
                cmd.Parameters.Add("@NumberPhone", SqlDbType.VarChar, 50).Value = "01238100497";
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = "AnhPD.soict.hust@gmail.com";
                cmd.Parameters.Add("@JobPosition", SqlDbType.VarChar, 50).Value = "Giám đốc phòng tài chính";
                cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 50).Value = "Công ty cổ phần Quỳnh Anh";
                cmd.Parameters.Add("@Education", SqlDbType.VarChar, 50).Value = "Đại học";
                cmd.Parameters.Add("@University", SqlDbType.VarChar, 50).Value = "Đại học Bách Khoa Hà Nội";
                cmd.Parameters.Add("@Major", SqlDbType.VarChar, 50).Value = "Quản trị kinh doanh";
                cmd.Parameters.Add("@TrialDate", SqlDbType.VarChar, 50).Value = DateTime.Now.ToString("MM/dd/yyyy");
                cmd.Parameters.Add("@OfficalDate", SqlDbType.VarChar, 50).Value = DateTime.Now.ToString("MM/dd/yyyy");
                cmd.Parameters.Add("@ContractType", SqlDbType.VarChar, 50).Value = "Chính thức";
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = "Chính thức";


                // open connection, execute INSERT, close connection
                cmd.ExecuteNonQuery();
            }
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