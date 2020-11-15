(function ($) {
    function Index() {
        const $this = this;
        function initialize() {

            $(".popup").on("click", function (e) {
                modelPopup(this);
            });

            function modelPopup(ref) {
                const url = $(ref).data("url");

                $.get(url).done(function (data) {
                    $("#modal-default").find(".modal-dialog").html(data);
                    $("#modal-default > .modal", data).modal("show");
                });

            }
        }

        $this.init = function () {
            initialize();
        };
    }
    $(function () {
        const self = new Index();
        self.init();
    });
}(jQuery));

sondas = new Sondas($('#sondasInput'));

function habilitaDesabilitaBtnExecucao() {
    const qtdSondas = $("#tbSondasList tbody tr").length;

    if (qtdSondas > 0 && $("#MalhaSuperiorDireita").val() !== "") {
        $("#btn-executar-operacao").prop("disabled", false);
    } else {
        $("#btn-executar-operacao").prop("disabled", true);
    }
}

function editarSonda(trId) {

    const numero = $(`tr#${trId} td:eq(0)`).text();
    const posicaoInicial = $(`tr#${trId} td:eq(1)`).text();
    const direcaoInicial = $(`tr#${trId} td:eq(2)`).text();
    const comandos = $(`tr#${trId} td:eq(3)`).text();

    $.get(`PainelOperacao/editarSonda?posicaoInicial=${posicaoInicial}&direcaoInicial=${direcaoInicial}&comandos=${comandos}&numero=${numero}`,
        function (data) {
            $("#modal-default").find(".modal-dialog").html(data);
            $("#modal-default").modal("show");
        }
    );
}

function abrirModalConfirmacao (action) {
    document.getElementById("btnSubmitConfirmDelete").setAttribute("onclick", action);
    $("#deleteModal").modal("show");
}