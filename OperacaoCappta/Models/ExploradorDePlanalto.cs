using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class ExploradorDePlanalto : IExploradorDePlanalto
    {
        private ICorretorDaProximaPosicaoDoMovimento corretorDaProximaPosicaoDoMovimento;
        private IMovimentoParaFrente movimentoSempreParaFrente;

        public void ExecutarExploracao(Sonda sonda, Planalto planalto)
        {
            corretorDaProximaPosicaoDoMovimento = new CorretorDaProximaPosicaoDoMovimento();
            movimentoSempreParaFrente = new MovimentoParaFrente(corretorDaProximaPosicaoDoMovimento);

            sonda.planalto = planalto;
            sonda.DirecaoAtual = sonda.DirecaoInicial;
            sonda.PosicaoAtual = sonda.PosicaoInicial;

            ExecutarInstrucoesDeMovimento(sonda, movimentoSempreParaFrente);

            sonda.PosicaoFinal = new Posicao(sonda.PosicaoAtual.X, sonda.PosicaoAtual.Y);
            sonda.DirecaoFinal = sonda.DirecaoAtual;
        }

        private void ExecutarInstrucoesDeMovimento(Sonda sonda, IMovimentoParaFrente movimentoSempreParaFrente)
        {
            foreach (var instrucao in sonda.GetInstrucoes())
            {
                switch (instrucao)
                {
                    case "L":
                        sonda.Vire(DirecaoMovimento.Esqueda);
                        break;
                    case "R":
                        sonda.Vire(DirecaoMovimento.Direita);
                        break;
                    case "M":
                        sonda.Move(movimentoSempreParaFrente);
                        break;
                }
            }
        }
    }
}
