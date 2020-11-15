using System;

namespace OperacaoCappta.Models
{
    public class Planalto
    {
        public int[,] MalhaInferiorEsquerda { get; private set; }
        public int[,] MalhaSuperiorDireita { get; private set; }

        public void DefineMalhaInferiorEsquerda(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException("Comando inválido para definição da malha inferior esquerda do planalto.");
            }

            MalhaInferiorEsquerda = new int[0, 0];
        }

        public void DefineMalhaSuperiorDireita(string comando)
        {

            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException("Comando inválido para definição da malha superior direita do planalto.");
            }

            MalhaSuperiorDireita = new int[5,5];



        }
    }
}