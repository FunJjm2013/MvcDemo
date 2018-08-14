function verification() {
    var objExp = /\d/g;
    alert(objExp.test($('#number').val()));
}

function checkTel() {
    var str = form1.tel.value;
    var objExp = /^((\d{3}-)?\d{8})$|^((\d{4}-)?\d{7,8})$/;
    if (objExp.test(str)) {
        alert("你输入的电话合法");
    }
    else {
        alert("你输入的电话不合法");
    }
}

function getBirthday() {
    var str=form1.IDCard.value;
    var objExp = /^(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})(\d{1}|a-z{1})/;
    var arr = objExp.exec(str);
    if (arr) {
        alert("你的身份证："+arr[0]+"\n"+"出生日期为：" + arr[2]+"年"+arr[3]+"月"+arr[4]+"日");
    } else {
        alert("身份证输入不合法");
    }
}