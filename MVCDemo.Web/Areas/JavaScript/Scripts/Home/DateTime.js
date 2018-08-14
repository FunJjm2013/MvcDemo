function getDate() {
    var now = new Date();
    //var year = now.getYear() + 1900;
    var fullyear = now.getFullYear();
    var month = now.getMonth() + 1;
    var date = now.getDate();
    var day = now.getDay();
    var hour = now.getHours();
    var min = now.getMinutes();
    var sec = now.getSeconds();
    var arr_week = new Array('星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六');
    var week = arr_week[day];
    var time =  fullyear + '年' + month + '月' + date + '日' + week + ' ' + hour + ':' + min + ':' + sec;
    document.getElementById('clock').innerHTML = "当前系统时间：" + time;
    //alert(time);

}

window.onload = function () {
    window.setInterval('getDate()', 1000);
}
