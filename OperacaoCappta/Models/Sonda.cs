using System;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class Sonda
    {
        public Sonda(string numero, Posicao posicaoInicial, DirecaoCardeal direcaoInicial, string comandos)
        {
            Numero = numero;
            PosicaoInicial = posicaoInicial;
            DirecaoInicial = direcaoInicial;
            Comandos = comandos;
        }

        public string Numero { get; }

        public Posicao PosicaoInicial { get; set; }

        public DirecaoCardeal DirecaoInicial { get; }

        public string Comandos { get; }

        public Posicao PosicaoFinal { get; set; }

        public DirecaoCardeal DirecaoFinal { get; set; }
        
        public DirecaoCardeal DirecaoAtual { get; set; }

        public Posicao PosicaoAtual { get; set; }

        public Planalto planalto { get; set; }

        #region Movimentos Exploratórios

        private void MoveSentidoHorario()
        {
            DirecaoAtual = DirecaoAtual switch
            {
                DirecaoCardeal.Norte => DirecaoCardeal.Leste,
                DirecaoCardeal.Leste => DirecaoCardeal.Sul,
                DirecaoCardeal.Sul => DirecaoCardeal.Oeste,
                DirecaoCardeal.Oeste => DirecaoCardeal.Norte,
                _ => DirecaoAtual
            };
        }

        private void MoveSentidoAntiHorario()
        {
            DirecaoAtual = DirecaoAtual switch
            {
                DirecaoCardeal.Norte => DirecaoCardeal.Oeste,
                DirecaoCardeal.Oeste => DirecaoCardeal.Sul,
                DirecaoCardeal.Sul => DirecaoCardeal.Leste,
                DirecaoCardeal.Leste => DirecaoCardeal.Norte,
                _ => DirecaoAtual
            };
        }

        public void Vire(DirecaoMovimento direcaoMovimento)
        {
            switch (direcaoMovimento)
            {
                case DirecaoMovimento.Direita:
                    MoveSentidoHorario();
                    break;
                case DirecaoMovimento.Esqueda:
                    MoveSentidoAntiHorario();
                    break;
                default:
                    throw new IndexOutOfRangeException($"Não é possível movimentar a sonda, comando de direção ({direcaoMovimento}) inválido.");
            }
        }

        public void Move(IMovimentoParaFrente movimento)
        {
            movimento.Executar(this);
        }

        #endregion

        public string[] GetInstrucoes()
        {
            if (Comandos.Length < 1)
                throw new IndexOutOfRangeException($"Imposível carregar instruções. A série de comandos deve ser maior que um caracter.");

            var instrucoes = new string[Comandos.Length];

            for (var contador = 0; contador < Comandos.Length; contador++)
            {
                instrucoes[contador] = Comandos[contador].ToString();
            }

            return instrucoes;
        }
    }
}
