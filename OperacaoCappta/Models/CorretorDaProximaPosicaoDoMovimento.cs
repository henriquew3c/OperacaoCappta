using System;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class CorretorDaProximaPosicaoDoMovimento : ICorretorDaProximaPosicaoDoMovimento
    {
        public Posicao Executar(Posicao posicaoAtual, DirecaoCardeal direcaoAtual)
        {
            switch (direcaoAtual)
            {
                case DirecaoCardeal.Norte:
                    return new Posicao(posicaoAtual.X, posicaoAtual.Y + 1);
                case DirecaoCardeal.Leste:
                    return new Posicao(posicaoAtual.X + 1, posicaoAtual.Y);
                case DirecaoCardeal.Sul:
                    return new Posicao(posicaoAtual.X, posicaoAtual.Y - 1);
                case DirecaoCardeal.Oeste:
                    return new Posicao(posicaoAtual.X - 1, posicaoAtual.Y);
                default:
                    throw new ArgumentException("Não foi possivel executar a movimentação.");
            }
        }
    }
}
