using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OperacaoCappta.Application;
using OperacaoCappta.Models;

namespace OperacaoCappta.Testes.Application
{
    [TestClass]
    public class ExecutaOperacaoHandlerTestes
    {
        private readonly ExecutaOperacaoHandler _handler;

        public ExecutaOperacaoHandlerTestes()
        {
            var exploradorDePlanalto = new Mock<IExploradorDePlanalto>();

            _handler = new ExecutaOperacaoHandler(
                exploradorDePlanalto.Object
            );
        }

        [TestMethod]
        public async Task QuandoChamadoDeveInvocarServicoDeExecucao()
        {
            //arrange
            var request = new ExecutaOperacaoRequest
            {
                SondasInput = "[{\"Numero\":\"1\",\"PosicaoInicial\":\"1,2\",\"DirecaoInicial\":\"Norte\",\"Comandos\":\"LMLMLMLM\"}]",
                MalhaSuperiorDireita = "5,5"
            };

            //act
            var sondas = await _handler.Handle(request, new CancellationToken());

            //assert
            Assert.IsTrue(sondas.Count == 1);
        }

        [TestMethod]
        public async Task QuandoChamadoDeveInvocarServicoDeExecucaoSemSondasERetornarArgumentException()
        {
            //arrange
            var request = new ExecutaOperacaoRequest
            {
                SondasInput = null,
                MalhaSuperiorDireita = "5,5"
            };

            //act
            //assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _handler.Handle(request, new CancellationToken()));
        }

        [TestMethod]
        public async Task QuandoChamadoDeveInvocarServicoDeExecucaoSemMalhaSuperiorDireitaERetornarArgumentException()
        {
            //arrange
            var request = new ExecutaOperacaoRequest
            {
                SondasInput = "[{\"Numero\":\"1\",\"PosicaoInicial\":\"1,2\",\"DirecaoInicial\":\"Norte\",\"Comandos\":\"LMLMLMLM\"}]",
                MalhaSuperiorDireita = null
            };

            //act
            //assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(() => _handler.Handle(request, new CancellationToken()));
        }
    }
}
