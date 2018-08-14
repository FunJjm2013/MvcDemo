function addElement() {
    var person = document.createTextNode(form1.person.value);
    var content = document.createTextNode(form1.content.value);
    var td_person = document.createElement('td');
    var td_content = document.createElement('td');
    var tr = document.createElement('tr');
    var tbody = document.createElement('tbody');
    td_person.appendChild(person);
    td_content.appendChild(content);
    tr.appendChild(td_person);
    tr.appendChild(td_content);
    tbody.appendChild(tr);
    var mytable = document.getElementById('mytable');
    mytable.appendChild(tbody);
    form1.person.value = "";
    form1.content.value = "";
}

function deleteFirstE() {
    var mytable = document.getElementById('mytable');
    if (mytable.rows.length>1) {
        mytable.deleteRow(1);
    }
}

function deleteLastE() {
    var mytable = document.getElementById('mytable');
    if (mytable.rows.length > 1) {
        mytable.deleteRow(mytable.rows.length-1);
    }
}