$(function () {
    $("li:first").css("border", "3px dotted lightblue");
    $("li:odd").css("border", "3px dotted yellow");
    $("li:even").css("border", "3px dotted black");
    $("li:last").css("color", "blue");
    $("li:eq(8)").css("background-color", "orange");
    $("li:gt(9)").css("background-color", "green");
    $("li:lt(7)").css("background-color", "red");
    $("div:last").css("background-color", "yellow");
})