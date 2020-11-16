using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class ExploradorDePlanalto : IExploradorDePlanalto
    {
        private IMovimentoParaFrente _movimentoSempreParaFrente;
        
        public ExploradorDePlanalto(IMovimentoParaFrente movimentoSempreParaFrente)
        {
            _movimentoSempreParaFrente = movimentoSempreParaFrente;
        }

        public void ExecutarExploracao(Sonda sonda, Planalto planalto)
        {
            sonda.planalto = planalto;
            sonda.DirecaoAtual = sonda.DirecaoInicial;
            sonda.PosicaoAtual = sonda.PosicaoInicial;

            ExecutarInstrucoesDeMovimento(sonda, _movimentoSempreParaFrente);

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
