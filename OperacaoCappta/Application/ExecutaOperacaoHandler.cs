using System;
using System.Collections.Generic;
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
        private readonly IExploradorDePlanalto _exploradorDePlanalto;

        public ExecutaOperacaoHandler(IExploradorDePlanalto exploradorDePlanalto)
        {
            _exploradorDePlanalto = exploradorDePlanalto;
        }
        public async Task<List<Sonda>> Handle(ExecutaOperacaoRequest request, CancellationToken cancellationToken)
        {

            if(string.IsNullOrEmpty(request.MalhaSuperiorDireita))
                throw new ArgumentException("O valor da malha superior direita não pode ser nulo.");

            if (request.MalhaSuperiorDireita.Contains("0"))
                throw new ArgumentException("O valor da malha superior direita não pode ser conter 0.");

            if (string.IsNullOrEmpty(request.MalhaInferiorEsquerda))
                throw new ArgumentException("O valor da malha inferior esquerda não pode ser nulo.");

            var planalto = new Planalto(request.MalhaInferiorEsquerda, request.MalhaSuperiorDireita);

            if (string.IsNullOrEmpty(request.SondasInput))
                throw new ArgumentException("Deve haver pelo menos uma sonda informada.");

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
                _exploradorDePlanalto.ExecutarExploracao(sonda, planalto);
            }

            return sondas;
        }

        private List<Sonda> DeserializeSondas(string arrayJson)
        {
            var sondas = new List<Sonda>();

            var options = new JsonSerializerOptions();

            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            var sondasDeserialize = JsonSerializer.Deserialize<SondaDto[]>(arrayJson, options);

            if (sondasDeserialize == null)
            {
                return sondas;
            }

            foreach (var sondaDto in sondasDeserialize)
            {
                var posicaoInicial = sondaDto.PosicaoInicial.Split(",");

                var sonda = new Sonda(
                    sondaDto.Numero, 
                    new Posicao( int.Parse(posicaoInicial[0]), int.Parse(posicaoInicial[1])), 
                    sondaDto.DirecaoInicial, 
                    sondaDto.Comandos
                );

                sondas.Add(sonda);
            }

            return sondas;
        }

    }
}
