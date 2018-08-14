$(function () {
    $("input[type='text']").css("border", "1px solid red");
    $("a[href $='.com']").css("border", "5px solid red");
    $("a[href^='http://']").css("border", "5px solid blue");
    $("*[value ~='input']").css("border", "5px solid orange");
    $("*[rows]").css("border", "5px solid green");
    //$("input[checked=checked]").css("background-color", "red");
    $("input[type='radio'][checked='checked'],input[type='checkbox'][checked='checked']").css("width", "100");
    $("input[type='text'][disabled='disabled']").css("border", "5px solid yellow");
})