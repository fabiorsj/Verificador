$(document).ready(function () {
    $(document).on("click", "#btnEnviar", function (e) {
        e.preventDefault();
        $.ajax({
            url: $("#urlValidar").val(),
            type: 'post',
            data: { cartao: $("#txtCartao").val() },
            success: function (obj) {
                $("#resultado").html(obj.retorno);
            }
        });
    });
});