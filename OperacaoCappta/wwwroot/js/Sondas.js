var Sondas = function Sondas(SondasInput) {
    this.Sondas = [];
    this.SondasInput = SondasInput;
};

Sondas.prototype.adicionar = function (posicaoInicial, direcaoInicial, comandos) {
    const numero = this.Sondas.length + 1;
    this.Sondas.push({ Numero: numero, PosicaoInicial: posicaoInicial, DirecaoInicial: direcaoInicial, Comandos: comandos });
    this.imprimir();
    return numero;
};

Sondas.prototype.editar = function (numero, posicaoInicial, direcaoInicial, comandos) {
    this.Sondas.splice(numero - 2, 1);
    this.Sondas.push({ Numero: numero, PosicaoInicial: posicaoInicial, DirecaoInicial: direcaoInicial, Comandos: comandos });
    this.imprimir();
};

Sondas.prototype.serialize = function () {
    return JSON.stringify(this.Sondas);
};

Sondas.prototype.imprimir = function () {
    this.SondasInput.val(this.serialize());

    if (this.Sondas.length > 0 && $("#MalhaSuperiorDireita").val() !== "") {
        $("#btn-executar-operacao").prop("disabled", false);
    } else {
        $("#btn-executar-operacao").prop("disabled", true);
    }
};

Sondas.prototype.remover = function (numeroSonda) {
    this.Sondas.splice(numeroSonda - 2, 1);
    this.imprimir();
    $(`#sonda-${numeroSonda}`).remove();
    $("#deleteModal").modal("hide");
};

function convertHTMLEntity(text) {
    var span = document.createElement('span');
    return text
        .replace(/&[#A-Za-z0-9]+;/gi, (entity, position, text) => {
            span.innerHTML = entity;
            return span.innerText;
        });
}