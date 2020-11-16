using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public interface ICorretorDaProximaPosicaoDoMovimento
    {
        Posicao Executar(Posicao posicaoAtual, DirecaoCardeal direcaoAtual);
    }
}