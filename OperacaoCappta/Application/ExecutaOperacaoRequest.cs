using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OperacaoCappta.Models;

namespace OperacaoCappta.Application
{
    public class ExecutaOperacaoRequest : IRequest<List<Sonda>>
    {
        [RegularExpression("[1-9][,][1-9]", ErrorMessage = "O valor informado é inválido.")]
        [Display(Name = "Malha Inferior Esquerda*")]
        public string MalhaInferiorEsquerda { get; }

        [RegularExpression("[1-9][,][1-9]", ErrorMessage = "O valor informado é inválido.")]
        [Required(ErrorMessage = "O campo Malha Superior Direita do Planalto é obrigatório.")]
        [Display(Name = "Malha Superior Direita*")]
        public string MalhaSuperiorDireita { get; set; }

        public string SondasInput { set; get; }

        public ExecutaOperacaoRequest()
        {
            MalhaInferiorEsquerda = "0,0";
        }
    }
}
