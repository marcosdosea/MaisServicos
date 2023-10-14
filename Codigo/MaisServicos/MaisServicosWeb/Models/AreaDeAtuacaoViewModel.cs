using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class AreaDeAtuacaoViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da área de atuação é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da área de atuação é obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Nome do área de atuação deve ter ao menos 1 letras")]
        public string Nome { get; set; } = null!;
    }
}
