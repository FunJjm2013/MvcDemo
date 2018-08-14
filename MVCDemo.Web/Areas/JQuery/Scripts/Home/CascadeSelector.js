$(function () {
    $("ol:first li").css("border", "2px solid yellow");
    $("ol:first>li").css("border", "2px solid green");
    $("ol:first>li:eq(3)+*").css("border", "2px solid black");
    $("#divHtml").html("<b>Nice to meet you</b>");
    $("#divText").text("<b>Nice to meet you</b>");
})