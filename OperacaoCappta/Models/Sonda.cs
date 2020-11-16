using System;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class Sonda
    {
        public Sonda(string numero, string posicaoInicial, DirecaoCardeal direcaoInicial, string comandos)
        {
            Numero = numero;
            PosicaoInicial = posicaoInicial;
            DirecaoInicial = direcaoInicial;
            Comandos = comandos;
        }

        public string Numero { get; }

        public string PosicaoInicial { get; }
        
        public DirecaoCardeal DirecaoInicial { get; }

        public string Comandos { get; }
        
        public string PosicaoFinal { get; private set; }

        public DirecaoCardeal DirecaoFinal { get; private set; }

        
        public void CalculaPosicaoFinal(Planalto planalto)
        {
            if (string.IsNullOrEmpty(Comandos))
            {
                throw new ArgumentException($"Impossível definir a posição final da sonda nº {Numero}. Comando Inválido.");
            }

            //todo calcular posicao final com base nos dados do planalto
            //valor fixo para testar saída
            PosicaoFinal = "5,5";
        }

        public void CalculaDirecaoFinal(Planalto planalto)
        {
            if (string.IsNullOrEmpty(Comandos))
            {
                throw new ArgumentException($"Impossível definir a direção final da sonda nº {Numero}. Comando Inválido.");
            }

            //todo calcular direcao final com base nos dados do planalto
            //valor fixo para testar saída
            DirecaoFinal = DirecaoCardeal.Leste;
        }
    }
}
