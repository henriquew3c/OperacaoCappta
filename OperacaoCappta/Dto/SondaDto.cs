using System.ComponentModel.DataAnnotations;
using OperacaoCappta.Models.Enums;

namespace OperacaoCappta.Dto
{
    public class SondaDto
    {
        public string Numero { get; set; }

        [Display(Name = "Posição Inicial*")]
        public string PosicaoInicial { get; set; }

        [Display(Name = "Direção Inicial*")]
        public DirecaoCardeal DirecaoInicial { get; set; }
        
        [Display(Name = "Comandos*")]
        public string Comandos { get; set; }
    }
}