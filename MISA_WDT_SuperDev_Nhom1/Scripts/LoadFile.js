// viết prototype cho các phần load file và insert vào giao diện
class LoadFile 
{
    //thêm thông tin liên hệ cho nhân viên, phần thêm nhân viên
    AddEmployeeAddress(path) {

    }
    //Thêm thông tin chung cho nhân viên, phần thêm nhân viên
    AddEmployeeGeneral(path) {

    }
    //Thêm thông tin công việc cho nhân viên, phần thêm nhân viên
    AddEmployeeWorking(path) {}
    //
    DialogSettings(path) {}
    //
    EmployeeTable(path, selector) {}
    //
    ExtendedInformation(path, selector) {}
    //
    ImportDictionary() {
        $.ajax({
            url: "/Views/Dictionary.html",
            type: "GET",
            datatype: "html",
            asyns: true,
            success: function(response) {
                $("#dictionary-submenu").html(response);
            }
        });
    }
    //
    ImportReport() {
        $.ajax({
            url: "/Views/Report.html",
            type: "GET",
            datatype: "html",
            asyns: true,
            success: function(response) {
                $("#report-submenu").html(response);
            }
        });
    }
}