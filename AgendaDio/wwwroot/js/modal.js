function confirmar(mensagem, executar) {
    var confirmModal = new bootstrap.Modal(document.getElementById('confirmationModal'), {
        keyboard: false
    })
    var confirmText = document.getElementById('confirmText')
    $('#btnOK').on('click', function () {
        executar()
        confirmModal.hide()
    });

    confirmText.textContent = mensagem
    confirmModal.show()
}