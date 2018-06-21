$(document).ready(function () {
    $("#searchBtn").click(function () {
        var SearchValue = $("#searchString").val();
        var SearchDate = $("#requestDate").val();
        var SearchBy = $("#searchForm input[type='radio']:checked").val();
        $.ajax({
            type: "GET",
            url: "/Request/GetDataSearch?SearchValue=" + encodeURIComponent(SearchValue) + "&SearchBy=" + encodeURIComponent(SearchBy) + "&SearchDate=" + encodeURIComponent(SearchDate),
            success: (function (RequestList) {
                $("#DataSearching").html(RequestList);
            })
        });
    });
});