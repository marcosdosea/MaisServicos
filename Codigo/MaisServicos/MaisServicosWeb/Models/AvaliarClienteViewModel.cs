using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class AvaliarClienteViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; } = null!;

        [Display(Name = "O que voce achou do serviço prestador")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Descriçao { get; set; } = null!;

        [Display(Name = "O que pode melhorar ")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Nota { get; set; } = null!;

        [Display(Name = "Qualidades ")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Qualidade { get; set; } = null!;

        [Display(Name = "Descriçao (Opcional)")]
        public string DescriçaoOP { get; set; } = null!;


    }
}
