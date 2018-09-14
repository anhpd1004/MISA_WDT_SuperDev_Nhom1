class GetData {
    constructor() {

    }
    GetEmployees() {
        $.ajax({
            url: "/api/Employee",
            datatype: "json",
            asyns: false,
            type: "GET",
            success: function(response) {
                debugger;
            }
        });
    }
}