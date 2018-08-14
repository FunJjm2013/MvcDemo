var picArr = new Array('1.jpg', '2.jpg', '3.jpg', '4.jpg', '5.jpg', '6.jpg', '7.jpg', '8.jpg', '9.jpg')
var index = 0;
function next() {
    index++;
    if (index==picArr.length) {
        index = 0;
    }
    document.getElementById("slidepic").src = '/Areas/JavaScript/Content/Images/' + picArr[index];
    //alert(document.getElementById("slidepic").src);
}

function previous() {
    index--
    if (!index) {
        index = picArr.length-1;
    }
    document.getElementById("slidepic").src = '/Areas/JavaScript/Content/Images/' + picArr[index];
    //alert(document.getElementById("slidepic").src);
}