using System;

namespace OperacaoCappta.Models
{
    public class Planalto
    {
        public string MalhaInferiorEsquerda { get; private set; }
        public string MalhaSuperiorDireita { get; private set; }

        public Planalto(string malhaInferiorEsquerda, string malhaSuperiorDireita)
        {
            MalhaInferiorEsquerda = malhaInferiorEsquerda;
            MalhaSuperiorDireita = malhaSuperiorDireita;
        }
    }
}