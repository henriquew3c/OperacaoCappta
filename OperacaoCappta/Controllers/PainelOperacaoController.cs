using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OperacaoCappta.Application;
using OperacaoCappta.Dto;
using OperacaoCappta.Models;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Controllers
{
    public class PainelOperacaoController : Controller
    {
        private readonly IMediator _mediator;

        public PainelOperacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View(new ExecutaOperacaoRequest());
        }

        public ActionResult AdicionarSonda()
        {
            ViewBag.FormTitle = "Adicionar Sonda";
            ViewBag.DirecoesCardeais = GetEnumSelectList<DirecaoCardeal>(DirecaoCardeal.Norte);
            return PartialView("FormSonda", new SondaDto());
        }

        public static IEnumerable<SelectListItem> GetEnumSelectList<T>(DirecaoCardeal valorSelecionado)
        {
            return (Enum.GetValues(typeof(T)).Cast<int>().Select(e => new SelectListItem()
            {
                Text = Enum.GetName(typeof(T), e), 
                Value = e.ToString(),
                Selected = Enum.GetName(typeof(T), e) == valorSelecionado.ToString() ? true : false
            })).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> ExecutaOperacao(ExecutaOperacaoRequest request, string sondasInput)
        {
            request.SondasInput = sondasInput;

            List<Sonda> sondas = await _mediator.Send(request);

            return View("ResultadoOperacao", sondas);

            //executar handler by request
        }

        public ActionResult EditarSonda(string posicaoInicial, DirecaoCardeal direcaoInicial, string comandos, string numero)
        {
            ViewBag.FormTitle = "Editar Sonda";
            ViewBag.DirecoesCardeais = GetEnumSelectList<DirecaoCardeal>(direcaoInicial);

            return PartialView("FormSonda", new SondaDto
            {
                Numero = numero,
                PosicaoInicial = posicaoInicial,
                DirecaoInicial = direcaoInicial,
                Comandos = comandos
            });
        }

        public IActionResult ExemploConfiguracao()
        {
            return View("Exemplo");
        }
    }
}
