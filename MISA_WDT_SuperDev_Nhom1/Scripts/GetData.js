class GetData {
    GetEmployees() {
        $.ajax({
            url: "/api/Employee",
            type: "GET",
            datatype: "json",
            asyns: true,
            success: function(response) {
                
                for(var i = 0; i < response.length; i++) {
                    var row = "<tr class='" + (i % 2 === 1 ? "employee-table-list-line-x" : "employee-table-list-line-y") + 
                            " table-row'";
                    var e = response[i];
                    row += "EmployeeID='" + e.EmployeeID + "'>";
                    var rowLeft  = row +  `
                        <td>${e.EmployeeCode}</td>
                        <td>${e.EmployeeName}</td>
                        </tr>
                    `;
                    var rowRight = row + `
                        <td>${e.Gender}</td>
                        <td>${e.Birthday}</td>
                        <td>${e.Education}</td>
                        <td>${e.University}</td>
                        <td>${e.Major}</td>
                        <td>${e.JobPosition}</td>
                        <td>${e.CompanyName}</td>
                        <td>${e.TrialDate}</td>
                        <td>${e.OfficalDate}</td>
                        <td>${e.ContractType}</td>
                        <td>${e.State}</td>
                        </tr>
                    `;
                    $("#tbody-left").append(rowLeft);
                    $("#tbody-right").append(rowRight);
                }
                var e = new Event();
                e.OnTableRowHover();
                e.OnTableRowClick();
                e.GetDataForRecordLabel();
            },
            fail: function(response) {
                alert("Fail");
            }
        });
    }
    //get employee
    GetEmployeesOffset(start, count) {
        $.ajax({
            url: "/api/Employee?start=0&count=10",
            type: "GET",
            datatype: "json",
            asyns: true,
            success: function(response) {
                
                for(var i = 0; i < response.length; i++) {
                    var row = "<tr class='" + (i % 2 === 1 ? "employee-table-list-line-x" : "employee-table-list-line-y") + 
                            " table-row'";
                    var e = response[i];
                    row += "EmployeeID='" + e.EmployeeID + "'>";
                    var rowLeft  = row +  `
                        <td>${e.EmployeeCode}</td>
                        <td>${e.EmployeeName}</td>
                        </tr>
                    `;
                    var rowRight = row + `
                        <td>${e.Gender}</td>
                        <td>${e.Birthday}</td>
                        <td>${e.Education}</td>
                        <td>${e.University}</td>
                        <td>${e.Major}</td>
                        <td>${e.JobPosition}</td>
                        <td>${e.CompanyName}</td>
                        <td>${e.TrialDate}</td>
                        <td>${e.OfficalDate}</td>
                        <td>${e.ContractType}</td>
                        <td>${e.State}</td>
                        </tr>
                    `;
                    $("#tbody-left").append(rowLeft);
                    $("#tbody-right").append(rowRight);
                }
            },
            fail: function(response) {
                alert("Fail");
            }
        });
    }
    PostEmployee() {
        var employee = {
            EmployeeID : "c85fd95e-9512-4886-b619-5c57cbdc1409",
            EmployeeCode : $("[inputdata='employee-code']").val().trim(),
            EmployeeName : $("[inputdata='employee-name']").val().trim(),
            Gender : $("[inputdata='gender']").val(),
            Address : $("[inputdata='address']").val().trim(),
            Birthday : "9/20/2018",
            NumberPhone : $("[inputdata='number-phone']").val().trim(),
            Email : $("[inputdata='email']").val().trim(),
            JobPosition : $("[inputdata='job-position']").val().trim(),
            CompanyName : $("[inputdata='company-name']").val().trim(),
            Education : $("[inputdata='level']").val().trim(),
            University : $("[inputdata='university']").val().trim(),
            Major : "",
            TrialDate : "9/20/2018",
            OfficalDate : "9/20/2018",
            ContractType : "Nhân viên chính thức",
            State : "Làm việc"
        }
        alert(JSON.stringify(employee))
        $.post("/api/Employee", function(data, status) {
            alert(data + "\n" + status);
        });
    }
}