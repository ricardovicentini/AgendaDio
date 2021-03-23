chave = ''
function apagarContato(guid) {
    chave = guid
    confirmar('Tem certeza?', excluir)
}

function excluir() {
    $.ajax("/api/Agenda/" + chave, { method: "delete" })
        .then(function (response) {
            location.reload()
        })
}