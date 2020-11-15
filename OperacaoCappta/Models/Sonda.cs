using System;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Models
{
    public class Sonda
    {
        private readonly Planalto _planalto;

        public Sonda(Planalto planalto)
        {
            _planalto = planalto;

            DefineNomeParaSonda();
        }

        public string Nome { get; private set; }

        public int[,] PosicaoInicial { get; private set; }

        public DirecaoCardeal DirecaoInicial { get; private set; }

        public int[,] PosicaoFinal { get; }

        public DirecaoCardeal DirecaoFinal { get; }

        public void DefinePosicaoInicial(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException($"Impossível definir a posição inicial da {Nome}. Comando Inválido.");
            }

            PosicaoInicial = new int[1,2];
        }

        public void DefineDirecaoInicial(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException($"Impossível definir a direção inicial da {Nome}. Comando Inválido.");
            }

            DirecaoInicial = DirecaoCardeal.Norte;

        }

        public void DefinePosicaoFinal(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException($"Impossível definir a posição final da {Nome}. Comando Inválido.");
            }

            //todo calcular posicao final com base nos dados do planalto

        }

        public void DefineDirecaoFinal(string comando)
        {
            if (string.IsNullOrEmpty(comando))
            {
                throw new ArgumentException($"Impossível definir a direção final da {Nome}. Comando Inválido.");
            }

            //todo calcular direcao final com base nos dados do planalto
        }

        private void DefineNomeParaSonda()
        {
            var randNum = new Random();
            Nome = "Cappta" + randNum.Next(100);
        }
    }
}
