namespace OperacaoCappta.Models
{
    public class MovimentoParaFrente : IMovimentoParaFrente
    {
        private readonly ICorretorDaProximaPosicaoDoMovimento _correcaoDaProximaPosicao;

        public MovimentoParaFrente(ICorretorDaProximaPosicaoDoMovimento correcaoDaProximaPosicao)
        {
            _correcaoDaProximaPosicao = correcaoDaProximaPosicao;
        }

        public void Executar(Sonda sonda)
        {
            sonda.PosicaoAtual = _correcaoDaProximaPosicao.Executar(sonda.PosicaoAtual, sonda.DirecaoAtual);
        }
    }
}