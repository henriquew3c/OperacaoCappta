using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OperacaoCappta.Application;
using OperacaoCappta.Dto;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Controllers
{
    public class PainelOperacaoController : Controller
    {
        public IActionResult Index()
        {
            return View(new CreateOperacaoRequest());
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
        public void ExecutaOperacao(CreateOperacaoRequest request, string sondasInput)
        {
            request.SondasInput = sondasInput;

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
