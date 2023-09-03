using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MaisServicosWeb.Models
{
    public class OrcamentoModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do orçamento é obrigatório!")]
        public int Id { get; set; }
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Código do valor é obrigatório!")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(1000, MinimumLength = 50, ErrorMessage = "Descrição do orçamento deve ter ao menos 50 letras e no máximo 1000")]
        public string? Descricao { get; set; }

        [Display(Name = "Código da Solicitação")]
        [Required(ErrorMessage = "Código da solicitação é obrigatório!")]
        public int IdSolicita { get; set; }

        public SelectList? Orcamentos { get; set; }
    }
}

