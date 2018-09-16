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
}