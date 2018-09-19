$(document).ready(function () {
    var getData = new GetData();


    var loadFile = new LoadFile();
    loadFile.ImportDictionary();
    loadFile.ImportReport();


    var event = new Event();
    event.OnOutsiteClick();
    event.OnDropdownSidebarClick();
    event.OnMenuItemActive();
    event.OnSidebarSubmenuClick();
    event.OnHeaderMainMenuClick();


    getData.GetEmployees();
    $(".header-account").click(event.OnAccountClick);
    $(".search-settings").click(event.OnSearchSettingsClick);
});