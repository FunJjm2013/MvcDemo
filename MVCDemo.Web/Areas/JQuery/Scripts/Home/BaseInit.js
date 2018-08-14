//Jquery内置对象Jquery
//window.load在全部页面资源加载完成时执行
//jQuery(document).ready()在DOM载入时执行
//通常该方法用于替换window.onload事件，文档就绪函数执行效率更高
//文档就绪函数，用于执行页面加载成功后执行指定的代码
jQuery(document).ready(function () {
    //增加我们要执行的代码
    alert("文档加载完成");
});
jQuery(function () {
    alert("简写后的格式");
});
$(function () {
    alert("最简写后的格式");
});