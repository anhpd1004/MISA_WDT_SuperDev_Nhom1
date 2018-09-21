class Event {
    ShowHide(selector) {
        $(selector).toggle();
    }
    OnAccountClick() {
        $("#account-dropdown").toggle("blind", "fast");
    }
    OnSearchSettingsClick() {
        $("#header-search-settings").toggle("blind", "fast");
    }
    OnOutsiteClick() {
        $(document).mouseup(function (e) {
            var containers = $(".outsite");

            $.each(containers, function (index, value) {
                // if the target of the click isn't the container nor a descendant of the container
                if (!$(value).is(e.target) && $(value).has(e.target).length === 0) {
                    $(value).hide("fade", "fast");
                }
            });
        });
    }
    OnSidebarSubmenuClick() {
        $("[submenu]").click(function() {
            var thisSubmenu = "#" + $(this).attr("submenu") + "-submenu";
            $(thisSubmenu).toggle("slide", "fast");
        });
    }
    OnDropdownSidebarClick() {
        var dropdownName = "className";
        $(".add-arrow-icon").click(function() {
            var drop = $(this).attr("dropdownName");
            if(drop !== dropdownName) {
                $("[dropdownName='" + dropdownName + "']").removeClass("add-arrow-icon-click");
                $('.' + dropdownName).hide();
                dropdownName = drop;
            }
            var checkShow = $(this).hasClass("add-arrow-icon-click");
            if(checkShow) {
                $(this).removeClass("add-arrow-icon-click");
                $('.' + dropdownName).hide();
            } else {
                $(this).addClass("add-arrow-icon-click");
                $('.' + dropdownName).show();
            }
        });
    }
    OnMenuItemActive() {
        //doi mau back-ground item sidebar khi click
        $("[active='true']").click(function() {
            var this_title = $(this).attr("title");
            $(this).addClass("active-item");
            var arrs = $("[active='true']");
            $.each(arrs, function (i, v) { 
                var t = $(v).attr("title");
                if(t !== this_title) {
                    $(v).removeClass("active-item");
                }
            });
        });
    }
    OnHeaderMainMenuClick() {
        $(".header-logo-main-menu").click(function() {
            
            var dropmenu = $(".dropdown-menu-item");
            $.each(dropmenu, function(i, v) {
                $(v).css("display", "none");
            });
            $(".logo-amis-vn").toggle("fade");
            var hides = $(".cls-menu-right");
            $.each(hides, function(i, v) {
                if($(v).parent().hasClass("width-30")) {
                    $(v).parent().removeClass("width-30");
                    $(v).parent().addClass("width-230");
                } else {
                    $(v).parent().removeClass("width-230");
                    $(v).parent().addClass("width-30");
                }
            });
            if($(".sidebar").hasClass("width-30")) {
                $(".sidebar").addClass("width-230");
                $(".sidebar").removeClass("width-30")
                $(".header-logo").addClass("width-230");
                $(".header-logo").removeClass("width-30")
                $(".header-logo").css("min-width", "230px");
                $(".header-flex-empty").css("width", ($(".header-flex-empty").width() - 200) + "px");
            } else {
                $(".sidebar").addClass("width-30");
                $(".sidebar").removeClass("width-230")
                $(".header-logo").addClass("width-30");
                $(".header-logo").removeClass("width-230")
                $(".header-logo").css("min-width", "30px");
                $(".header-flex-empty").css("width", (200 + $(".header-flex-empty").width()) + "px");
            }
        })
    }
    OnTableRowHover() {
        var TableRows = $(".table-row");
        $.each(TableRows, function(i, v) {
            $(v).mouseenter(function() {
                var EmployeeID = $(v).attr("employeeid");
                var temp = $("[employeeid='" + EmployeeID + "'");
                $.each(temp, function(index, val) { 
                    $(val).addClass("table-row-hover");
                });
            });
            $(v).mouseout(function() {
                var EmployeeID = $(v).attr("employeeid");
                var temp = $("[employeeid='" + EmployeeID + "'");
                $.each(temp, function(index, val) { 
                    $(val).removeClass("table-row-hover");
                });
            });
        });
    }
    OnTableScroll() {
        $("[dataToggle='table-right']").scroll(function() {
            var top = $(this).scrollTop();
            $("[dataToggle='table-left']").scrollTop(top);
        });
    }
    OnTableFilter() {
        $(document).on("click", ".employee-table-select-filter", function() {
            var html = `
                <div class="filter-box outsite">
                    <a class="circle-icon"><span>*</span> : Chứa</a>
                    <a>= : Bằng</a>
                    <a>+ : Bắt đầu bằng</a>
                    <a>- : Kết thúc bằng</a>
                    <a>! : Không chứa</a>
                </div>
            `;
            $(this).parent().append(html);
        }); 
        
    }
    OnTableRowClick() {
        var employeeID = "";
        $(".table-row").click(function() {
            $("[EmployeeID='" + employeeID + "']").removeClass("table-row-active");
            employeeID = $(this).attr("EmployeeID");
            $("[EmployeeID='" + employeeID + "']").addClass("table-row-active");
            $.ajax({
                url: "/api/Employee?employeeID=" + employeeID,
                type: "GET",
                datatype: "json",
                asyns: false,
                success: function(response) {
                    var html = `
                        <div class="Main-Information-left">
                        <img src="./Contents/Icons/ImageHandler (1).png" style="width:100%;height:100%" />
                        </div>
						<div class="Main-Information-right">
                        <div class="Main-Information-right1">
                            <div id="content-information">
                                <span id="Title-Employee">Mã nhân viên:</span>
                                <div id="row1">${response.EmployeeCode}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Họ tên:</span>
                                <div id="row1">${response.EmployeeName}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Giới tính:</span>
                                <div id="row1">${response.Gender}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Ngày sinh:</span>
                                <div id="row1">${response.Birthday}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Số CMT:</span>
                                <div id="row1"></div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Hộ chiếu:</span>
                                <div id="row1"></div>
                            </div>
                        </div>
                        <div class="Main-Information-right2">
                            <div id="content-information">
                                <span id="Title-Employee">Vị trí công việc:</span>
                                <div id="row1">${response.JobPosition}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Đơn vị công tác:</span>
                                <div id="row1">${response.CompanyName}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Ngày thử việc:</span>
                                <div id="row1">${response.TrialDate}</div>
                            </div>
                            <div id="content-information">
                                <span id="Title-Employee">Ngày chính thức:</span>
                                <div id="row1">${response.OfficalDate}</div>
                            </div>
                        </div>
					`;
                    $(".Main-Information").html(html);
                }
            });
        });
    }

    OnAddEmployeeClick() {
        $(".toolbar-item-add-employee").click(function() {
            $("#add-employee-form").show();
        });
    }

    GetDataForRecordLabel() {
        var len = $(".table-row").length;
        $(".employee-record-summary-y").text(len / 2);
    }
    
}