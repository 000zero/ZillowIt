$(function () {
    $("#goBtn").click(function () {
        // render the partial here
        var uri = "/Home/ResultsView?address=" + encodeURIComponent($("#address").val()) + "&citystatezip=" + encodeURIComponent($("#citystatezip").val());

        $("#searchResults").load(uri);
    });
});