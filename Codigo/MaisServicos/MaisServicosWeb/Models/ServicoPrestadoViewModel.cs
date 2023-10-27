using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class ServicoPrestadoViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do serviço é obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(50, ErrorMessage = "Nome do serviço deve ter no máximo 50 letras")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(1000, ErrorMessage = "Descrição do serviço deve ter no máximo 1000 letras")]
        public string? Descricao { get; set; }

        [Display(Name = "Código de Área de Atuação")]
        [Required(ErrorMessage = "Código do serviço é obrigatório!")]
        public int IdAreaDeAtuacao { get; set; }
    }
}
