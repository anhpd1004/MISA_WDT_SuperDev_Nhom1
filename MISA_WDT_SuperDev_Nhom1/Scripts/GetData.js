class GetData {
    GetEmployees() {
        $.ajax({
            url: "/api/Employee",
            type: "GET",
            datatype: "json",
            asyns: false,
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
            asyns: false,
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
}