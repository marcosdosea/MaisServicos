using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class ServicoContratadoViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do serviço é obrigatório!")]
        public int Id { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor do serviço é obrigatório!")]
        public float Valor { get; set; }

        [Display(Name = "Código da Pessoa")]
        [Required(ErrorMessage = "Código da pessoa é obrigatório!")]
        public int IdPessoa { get; set; }

        [Display(Name = "Código da Avaliação")]
        [Required(ErrorMessage = "Código da avaliaçao é obrigatório!")]
        public int IdAvaliacao { get; set; }

        [Display(Name = "Código do Template Contrato")]
        [Required(ErrorMessage = "Código do template contrato é obrigatório!")]
        public int IdTemplateContrato { get; set; }

        [Display(Name = "Código do Orçamento")]
        [Required(ErrorMessage = "Código do orçamento é obrigatório!")]
        public int IdOrcamento { get; set; }
    }
}
