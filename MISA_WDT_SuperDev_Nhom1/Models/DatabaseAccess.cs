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
        private string _connectionString = "Data Source=DESKTOP-RSN4E32\\SQLEXPRESS;Initial Catalog=MISA_WDT_SuperDev_Nhom1;Integrated Security=True";

        private SqlConnection _sqlConnection;

        private List<Employee> _listEmployee;

        public List<Employee> ListEmployee
        {
            get { return this._listEmployee; }
            private set { this._listEmployee = value; }
        }

        public DatabaseAccess()
        {

            this._listEmployee = new List<Employee>();

            //Nếu SqlConnection chưa được khởi tạo thì khởi tạo mới 
            if (this._sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(_connectionString);
            }
            if (this._sqlConnection.State == ConnectionState.Closed)
            {
                this._sqlConnection.Open();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Select(string _sqlQuery)
        {
            Employee employee;

            //tao cau truy van
            SqlCommand _sqlCommand = this._sqlConnection.CreateCommand();

            //Khai báo kiểu truy vấn dữ liệu
            _sqlCommand.CommandType = CommandType.Text;

            //Khai báo câu lệnh truy vấn
            _sqlCommand.CommandText = _sqlQuery;

            //Thực hiện truy vấn lấy dữ liệu thông qua SqlDataAdapter
            SqlDataReader _sqlDataReader = _sqlCommand.ExecuteReader();

            //Đọc dữ liệu từ Sql DataReader
            while (_sqlDataReader.Read())
            {
                employee = new Employee();
                employee.EmployeeID = Guid.Parse(_sqlDataReader["EmployeeID"].ToString());
                employee.EmployeeCode = _sqlDataReader["EmployeeCode"].ToString();
                employee.EmployeeName = _sqlDataReader["EmployeeName"].ToString();
                employee.Gender = _sqlDataReader["Gender"].ToString();
                employee.Address = _sqlDataReader["Address"].ToString();
                employee.Birthday = DateTime.Parse(_sqlDataReader["Birthday"].ToString());
                employee.NumberPhone = _sqlDataReader["NumberPhone"].ToString();
                employee.Email = _sqlDataReader["Email"].ToString();
                employee.JobPosition = _sqlDataReader["JobPosition"].ToString();
                employee.CompanyName = _sqlDataReader["CompanyName"].ToString();
                employee.Education = _sqlDataReader["Education"].ToString();
                employee.University = _sqlDataReader["University"].ToString();
                employee.Major = _sqlDataReader["Major"].ToString();
                employee.TrialDate = DateTime.Parse(_sqlDataReader["TrialDate"].ToString());
                employee.OfficalDate = DateTime.Parse(_sqlDataReader["OfficalDate"].ToString());
                employee.ContractType = _sqlDataReader["ContractType"].ToString();
                employee.State = _sqlDataReader["State"].ToString();
                this._listEmployee.Add(employee);
            }
            return true;
        }

        public int Insert(Employee employee)
        {
            // define INSERT query with parameters
            string query = "INSERT INTO dbo.Employee (EmployeeID, EmployeeCode, EmployeeName, Gender, Address, Birthday, NumberPhone, " +
                                                    "Email, JobPosition, CompanyName, Education, University, Major, TrialDate, OfficalDate, ContractType, State) " +
                           "VALUES (@EmployeeID, @EmployeeCode, @EmployeeName, @Gender, @Address, @Birthday, @NumberPhone, " +
                                   "@Email, @JobPosition, @CompanyName, @Education, @University, @Major, @TrialDate, @OfficalDate, @ContractType, @State)";

            // create connection and command
            using (SqlCommand cmd = new SqlCommand(query, this._sqlConnection))
            {

                // define parameters and their values
                cmd.Parameters.Add("@EmployeeID", SqlDbType.UniqueIdentifier).Value = employee.EmployeeID;
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar).Value = employee.EmployeeCode;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = employee.EmployeeName;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = employee.EmployeeCode;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = employee.Address;
                cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = employee.Birthday;
                cmd.Parameters.Add("@NumberPhone", SqlDbType.VarChar).Value = employee.NumberPhone;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("@JobPosition", SqlDbType.NVarChar).Value = employee.JobPosition;
                cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = employee.CompanyName;
                cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = employee.Education;
                cmd.Parameters.Add("@University", SqlDbType.NVarChar).Value = employee.University;
                cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = employee.Major;
                cmd.Parameters.Add("@TrialDate", SqlDbType.DateTime).Value = employee.TrialDate;
                cmd.Parameters.Add("@OfficalDate", SqlDbType.DateTime).Value = employee.OfficalDate;
                cmd.Parameters.Add("@ContractType", SqlDbType.NVarChar).Value = employee.ContractType;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = employee.State;


                // open connection, execute INSERT, close connection
                this._listEmployee.Add(employee);
                return cmd.ExecuteNonQuery();
            }
        }

        public int FakeData()
        {
            //FAKE DATA
            string[] firstNames = new string[] { 
                "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng", "Bùi", "Đỗ", "Hồ", "Ngô", "Dương", "Lý",
                "An", "Ân", "Bạch", "Cao", "Doãn", "Đoàn", "Mai", "Vương", "Trịnh", "Trương", "Lưu", "Tạ", "Tôn", "Thân", "Văn", 
                "Phùng", "Mạc", "Văn", "Hà", "Hình", "Lạc", "Lâm", "Liễu", "Lương"
            };
            string[] lastNames = new string[] {
                "Duy Anh", "Thi Linh", "Thi Huyen", "Thi Quynh", "Yen Nhi", "Anh Thu", "Lan Anh", "Van Anh", "Thu Hien", "Phuong Anh",
                "Thu Quyen", "Khanh Linh", "Khanh Ly", "Thi Trang", "Van Tung", "Huu Thang", "Ngoc Anh", "Duc Huy", "Hong Nhung",
                "Tuong Vy", "Van Hieu", "Ngoc Tram", "Bich Cham", "Thuy Trang", "Bao Thy", "Huong Giang", "Van Hung", "Gia Han",
                "Bich Ngoc", "Minh Chau", "Tu Anh", "Thi Nhan", "Minh Nhan", "Thanh Huyen", "Minh Luong", "Nhu Quynh", "Phuong Uyen",
                "Hai Duong", "Nguyet Minh", "Duy Anh", "Duy Anh", "Mai Linh", "Thanh Hang", "Duy Anh", "Minh Thu", "Tuan Anh",
                "Duy Anh", "Duy Anh"
            };
            string[] states = new string[] {
                "Chính thức", "Thử việc", "Thực tập sinh", "Part time", "Cộng tác viên"
            };
            Random random = new Random();
            ///END FAKE DATA
            for (int i = 0; i < 1000; i++)
            {
                // define INSERT query with parameters
                string query = "INSERT INTO dbo.Employee (EmployeeID, EmployeeCode, EmployeeName, Gender, Address, Birthday, NumberPhone, " +
                                                        "Email, JobPosition, CompanyName, Education, University, Major, TrialDate, OfficalDate, ContractType, State) " +
                               "VALUES (@EmployeeID, @EmployeeCode, @EmployeeName, @Gender, @Address, @Birthday, @NumberPhone, " +
                                       "@Email, @JobPosition, @CompanyName, @Education, @University, @Major, @TrialDate, @OfficalDate, @ContractType, @State)";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, this._sqlConnection))
                {

                    // define parameters and their values
                    cmd.Parameters.Add("@EmployeeID", SqlDbType.UniqueIdentifier).Value = Guid.NewGuid();
                    cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar).Value = this.GetEmployeeCode(i + 1);
                    cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = firstNames[random.Next(firstNames.Length)] + " " +
                                                                                    lastNames[random.Next(lastNames.Length)];
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = "Nam";
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = "Tiên Lãng - Hải Phòng";
                    cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy");
                    cmd.Parameters.Add("@NumberPhone", SqlDbType.VarChar).Value = "01238100497";
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = "AnhPD.soict.hust@gmail.com";
                    cmd.Parameters.Add("@JobPosition", SqlDbType.NVarChar).Value = "Giám đốc phòng tài chính";
                    cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = "Công ty cổ phần Quỳnh Anh";
                    cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = "Đại học";
                    cmd.Parameters.Add("@University", SqlDbType.NVarChar).Value = "Đại học Bách Khoa Hà Nội";
                    cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = "Quản trị kinh doanh";
                    cmd.Parameters.Add("@TrialDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy");
                    cmd.Parameters.Add("@OfficalDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("MM/dd/yyyy");
                    cmd.Parameters.Add("@ContractType", SqlDbType.NVarChar).Value = "Chính thức";
                    cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = states[random.Next(states.Length)];


                    // open connection, execute INSERT, close connection
                    cmd.ExecuteNonQuery();
                }
            }

            return 0;
        }
        private string GetEmployeeCode(int k)
        {
            if (k < 10) return "NV0000" + k;
            if (k < 100) return "NV000" + k;
            if (k < 1000) return "NV00" + k;
            if (k < 10000) return "NV0" + k;
            return "NV" + k;
        }
        /// <summary>
        /// Xóa bản ghi dựa vào ID của nhân viên
        /// </summary>
        /// <param name="employeeID">Employee ID</param>
        /// <returns>Số bản ghi bị xóa khỏi database</returns>
        public int Delete(Guid employeeID)
        {
            string query = "DELETE FROM Employee WHERE EmployeeID='" + employeeID + "'";
            using (SqlCommand _sqlCommand = new SqlCommand(query, this._sqlConnection))
            {
                return _sqlCommand.ExecuteNonQuery();
            }
        }
        public int Delete(string pattern)
        {
            string query = "DELETE FROM Employee WHERE EmployeeName like N'%" + pattern + "%'";
            query += "OR EmployeeCode='" + pattern + "'";
            query += "OR CompanyName='" + pattern + "'";
            using (SqlCommand _sqlCommand = new SqlCommand(query, this._sqlConnection))
            {
                return _sqlCommand.ExecuteNonQuery();
            }
        }

        public int Update(Employee employee, Guid employeeID)
        {
            string query = "UPDATE Employee AS e" +
                           "SET e.State = @State";
            query += " e.EmployeeCode = @EmployeeCode,";
            query += " e.EmployeeName = @EmployeeName,";
            query += " e.Gender = @Gender,";
            query += " e.Address = @Address,";
            query += " e.Birthday = @Birthday,";
            query += " e.NumberPhone = @NumberPhone,";
            query += " e.Email = @Email,";
            query += " e.JobPosition = @JobPosition,";
            query += " e.CompanyName = @CompanyName,";
            query += " e.Education = @Education,";
            query += " e.University = @University,";
            query += " e.Major = @Major,";
            query += " e.TrialDate = @TrialDate,";
            query += " e.OfficalDate = @OfficalDate,";
            query += " e.ContractType = @ContractType";
            query += " WHERE e.EmployeeID='" + employeeID + "'";
            using (SqlCommand cmd = new SqlCommand(query, this._sqlConnection))
            {
                // define parameters and their values
                cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar).Value = employee.EmployeeCode;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = employee.EmployeeName;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = employee.EmployeeCode;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = employee.Address;
                cmd.Parameters.Add("@Birthday", SqlDbType.DateTime).Value = employee.Birthday;
                cmd.Parameters.Add("@NumberPhone", SqlDbType.VarChar).Value = employee.NumberPhone;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("@JobPosition", SqlDbType.NVarChar).Value = employee.JobPosition;
                cmd.Parameters.Add("@CompanyName", SqlDbType.NVarChar).Value = employee.CompanyName;
                cmd.Parameters.Add("@Education", SqlDbType.NVarChar).Value = employee.Education;
                cmd.Parameters.Add("@University", SqlDbType.NVarChar).Value = employee.University;
                cmd.Parameters.Add("@Major", SqlDbType.NVarChar).Value = employee.Major;
                cmd.Parameters.Add("@TrialDate", SqlDbType.DateTime).Value = employee.TrialDate;
                cmd.Parameters.Add("@OfficalDate", SqlDbType.DateTime).Value = employee.OfficalDate;
                cmd.Parameters.Add("@ContractType", SqlDbType.NVarChar).Value = employee.ContractType;
                cmd.Parameters.Add("@State", SqlDbType.NVarChar).Value = employee.State;


                // open connection, execute INSERT, close connection
                int index = this._listEmployee.IndexOf(this._listEmployee.First(n => n.EmployeeID == employeeID));
                if(index != -1) 
                {
                    this._listEmployee[index] = employee;
                }
                return cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            this._sqlConnection.Close();
        }
    }
}