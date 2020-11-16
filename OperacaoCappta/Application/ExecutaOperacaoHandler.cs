using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OperacaoCappta.Dto;
using OperacaoCappta.Models;

namespace OperacaoCappta.Application
{
    public class ExecutaOperacaoHandler : IRequestHandler<ExecutaOperacaoRequest, List<Sonda>>
    {
        private readonly IMediator _mediator;

        public ExecutaOperacaoHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<Sonda>> Handle(ExecutaOperacaoRequest request, CancellationToken cancellationToken)
        {
            var planalto = new Planalto(request.MalhaInferiorEsquerda, request.MalhaSuperiorDireita);
            var sondas = DeserializeSondas(request.SondasInput);

            if (sondas.Count == 0)
            {
                throw new ArgumentException("Erro ao processar sondas.");
            }

            sondas = CalculaResultadosSondas(sondas, planalto);
            return await Task.FromResult(sondas);
        }

        private List<Sonda> CalculaResultadosSondas(List<Sonda> sondas, Planalto planalto)
        {
            foreach (var sonda in sondas)
            {
                sonda.CalculaDirecaoFinal(planalto);
                sonda.CalculaPosicaoFinal(planalto);
            }

            return sondas;
        }

        private List<Sonda> DeserializeSondas(string arrayJson)
        {
            var sondas = new List<Sonda>();

            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            var sondasDeserialize = JsonSerializer.Deserialize<SondaDto[]>(arrayJson, options);

            if (sondasDeserialize == null) return sondas;

            sondas.AddRange(sondasDeserialize.
                Select(sondaDto => 
                    new Sonda(sondaDto.Numero, sondaDto.PosicaoInicial, sondaDto.DirecaoInicial, sondaDto.Comandos)
                )
            );

            return sondas;
        }

    }
}
