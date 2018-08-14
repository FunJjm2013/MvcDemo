$(function () {
    var btnSave = document.getElementById('save');
    btnSave.ondblclick = function () {
        alert('保存按钮被双击');
    };
})

function checkUserName() {
    var userName = $('#userName').val();
    if (userName=='') {
        alert('用户名不能为空');
    }
}

function save() {
    alert('保存成功');
}