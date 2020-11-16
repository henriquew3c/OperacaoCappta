namespace OperacaoCappta.Models
{
    public class Planalto
    {
        public string MalhaInferiorEsquerda { get; }
        public string MalhaSuperiorDireita { get; }

        public Planalto(string malhaInferiorEsquerda, string malhaSuperiorDireita)
        {
            MalhaInferiorEsquerda = malhaInferiorEsquerda;
            MalhaSuperiorDireita = malhaSuperiorDireita;
        }
    }
}