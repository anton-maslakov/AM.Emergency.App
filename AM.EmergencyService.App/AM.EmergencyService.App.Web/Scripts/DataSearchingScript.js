$(document).ready(function () {
    
    $("#searchBtn").click(function () {
        var SearchValue = $("#searchString").val();
        //var SearchBy;
        //$('#searchForm input').on('change', function () {
        var SearchBy = $("#searchForm input[type='radio']:checked").val();
        //});
        
        $.ajax({
            type: "GET",
            url: "/Request/GetDataSearch?SearchValue=" + encodeURIComponent(SearchValue) + "&SearchBy=" + encodeURIComponent(SearchBy),
            success: (function (_searchPartialView) {
                $("#DataSearching").html(_searchPartialView);
            })
        });
    });
});