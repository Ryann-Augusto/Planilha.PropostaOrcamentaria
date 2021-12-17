var ValidaExclusao = function (id, evento) {
    if (confirm("Essa exclusão será permanente, perderá todos os dados salvos desse usuário?")) {
        return true
    }
    else {
        evento.preventDefault();
        return false;
    }
}