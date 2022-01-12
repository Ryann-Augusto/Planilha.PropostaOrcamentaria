
var ValidaExclusao = function (id, evento) {
    if (confirm("Essa exclusão será permanente, perderá todos os dados salvos desse usuário!")) {
        return true
    }
    else {
        evento.preventDefault();
        return false;
    }
}

var ValidaExclusaoCategoria = function (id, evento) {
    if (confirm("Essa exclusão irá REMOVER a categoria e todos seus valores!")) {
        return true
    }
    else {
        evento.preventDefault();
        return false;
    }
}


function checkPass() {

    var btnCad = document.getElementById('btnCadastrar');
    var Cargos = document.querySelector("#cargos")

    btnCad.disabled = true;

    var pass1 = document.getElementById('pass1');
    var pass2 = document.getElementById('pass2');
    var message = document.getElementById('error-nwl');
    var goodColor = "#66cc66";
    var badColor = "#ff6666";

    if (pass1.value.length > 5) {
        pass1.style.backgroundColor = goodColor;
        message.style.color = goodColor;

    }
    else {
        pass1.style.backgroundColor = badColor;
        message.style.color = badColor;
        message.innerHTML = " A senha deve ter no mínimo 6 dígitos!"
    }

    if (pass1.value == pass2.value) {
        pass2.style.backgroundColor = goodColor;
        message.style.color = goodColor;
        message.innerHTML = "ok"
    }
    else {
        pass2.style.backgroundColor = badColor;
        message.style.color = badColor;
        message.innerHTML = " As Senhas não são iguais!"
    }
    if (pass1.value.length > 5 && pass1.value == pass2.value && Cargos.value != 0) {
        btnCad.disabled = false;
    }
}

//Pagina de edição

function checkPassEdit() {

    var pass1 = document.getElementById('pass1');
    var pass2 = document.getElementById('pass2');
    var message = document.getElementById('error-nwl');
    var goodColor = "#66cc66";
    var badColor = "#ff6666";

    if (pass1.value.length > 5) {
        pass1.style.backgroundColor = goodColor;
        message.style.color = goodColor;

    }
    else {
        pass1.style.backgroundColor = badColor;
        message.style.color = badColor;
        message.innerHTML = " A senha deve ter no mínimo 6 dígitos!"
    }

    if (pass1.value == pass2.value) {
        pass2.style.backgroundColor = goodColor;
        message.style.color = goodColor;
        message.innerHTML = "ok"
    }
    else {
        pass2.style.backgroundColor = badColor;
        message.style.color = badColor;
        message.innerHTML = " As Senhas não são iguais!"
    }
}