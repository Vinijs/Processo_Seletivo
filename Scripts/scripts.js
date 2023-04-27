$(document).ready(function () {

    $('#novoContato').click(function () {
        $('#nome').val("");
        $('#telefone').val("");
        $('#id').val("0");

        $('.modal-title').html("Novo Contato");
        $('#meuModal').modal('show');
    });

    $('.edit').click(function () {
        var id = $(this).data('id');

        $.ajax({
            url: '/Contatos/Details',
            type: 'POST',
            data: {
                id
            },
            success: function (data) {
                $('#nome').val(data.Nome);
                $('#telefone').val(data.Telefone);
                $('#id').val(data.Id);

                $('.modal-title').html("Editar Contato");
                $('#meuModal').modal('show');
            }
        });
    });

    $('.delete').click(function () {
        const id = $(this).data('id');
        const nome = $(this).data('nome');

        if (confirm(`Deseja excluir o contato ${nome} ?`)) {
            $.ajax({
                url: '/Contatos/Delete/' + id,
                type: 'POST',
                success: function (data) {
                    alert("Excluido com sucesso.");
                    window.location.reload();
                }
            });
        }
    });

    $('#contatoForm').on('submit', (function (e) {
        e.preventDefault();

        const id = $('#id').val();
        const nome = $('#nome').val();
        const telefone = $('#telefone').val();

        if (nome == "" || telefone == "") {
            alert("Preencha todos os campos.");
            return;
        }

        $.ajax({
            url: "Contatos/Create",
            type: "POST",
            data: new FormData(this),
            contentType: false,
            cache: false,
            processData: false,
            success: function (data) {
                if (data.hasError) {
                    alert(`Ocorreu um erro. Erro: ${data.msg}`);
                }
                else {
                    alert(`${(id == 0 ? "Adicionado" : "Editado")} com sucesso.`);
                    window.location.reload();
                }
            }
        });
    }));

});