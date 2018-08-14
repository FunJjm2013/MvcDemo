//$(function () {
//    var btnErgodic = document.getElementById('btnErgodic');
//    btnErgodic.onclick = getElement(document.getElementsByTagName('html'));
//    //body.onLoad = getElement();
//});
function getElement(node) {
    if (node.nodeType==1) {
        console.info(node);
        //var childrens = node.childNodes;
        for (var m = node.firstChild; m != null; m.nextSibling) {
            getElement(m);
        }
    }
}