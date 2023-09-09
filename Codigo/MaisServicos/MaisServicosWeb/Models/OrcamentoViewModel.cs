using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class OrcamentoViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código do orçamento é obrigatório!")]
        public int Id { get; set; }
        public float Valor { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(1000, ErrorMessage = "Descrição do orçamento deve ter ao menos 50 letras e no máximo 1000")]
        public string? Descricao { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da solicitação é obrigatório!")]
        public int IdSolicita { get; set; }

    }
}

