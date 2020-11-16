using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperacaoCappta.Models;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Testes.Models
{
    [TestClass]
    public class SondaTestes
    {
        [TestMethod]
        public void DeveObterInstrucoes()
        {
            //arrange
            var sonda = new Sonda
            (
                "1",
                new Posicao(1, 2),
                OperacaoCappta.Models.Enums.DirecaoCardeal.Norte,
                "LMLMLMLMM"
            );

            //act
            var instrucoes = sonda.GetInstrucoes();

            //assert
            Assert.IsTrue(instrucoes.Length == 9);
        }

        [TestMethod]
        public void DeveObterIndexOutOfRangeExceptionAoRecuperarInstrucoes()
        {
            //arrange
            var sonda = new Sonda
            (
                "1",
                new Posicao(1, 2),
                OperacaoCappta.Models.Enums.DirecaoCardeal.Norte,
                "L"
            );

            //act
            //assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => sonda.GetInstrucoes());
        }

        [TestMethod]
        public void DeveObterArgumentExceptionAoRecuperarInstrucoes()
        {
            //arrange
            var sonda = new Sonda
            (
                "1",
                new Posicao(1, 2),
                OperacaoCappta.Models.Enums.DirecaoCardeal.Norte,
                null
            );

            //act
            //assert
            Assert.ThrowsException<ArgumentException>(() => sonda.GetInstrucoes());
        }
        
        [TestMethod]
        public void DeveVirarParaLeste()
        {
            //arrange
            var sonda = new Sonda
            (
                "1",
                new Posicao(1, 2),
                OperacaoCappta.Models.Enums.DirecaoCardeal.Norte,
                null
            );

            //act
            sonda.Vire(DirecaoMovimento.Direita);

            //assert
            Assert.IsTrue(sonda.DirecaoAtual == DirecaoCardeal.Leste);
        }

        [TestMethod]
        public void DeveVirarParaOeste()
        {
            //arrange
            var sonda = new Sonda
            (
                "1",
                new Posicao(1, 2),
                OperacaoCappta.Models.Enums.DirecaoCardeal.Norte,
                null
            );

            //act
            sonda.Vire(DirecaoMovimento.Esqueda);

            //assert
            Assert.IsTrue(sonda.DirecaoAtual == DirecaoCardeal.Oeste);
        }
    }
}
