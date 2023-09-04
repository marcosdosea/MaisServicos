using System.ComponentModel.DataAnnotations;

namespace MaisServicosWeb.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome do cliente deve ter entre 2 e 50 caracteres.")]
        public string Nome { get; set; } = null!;

        [StringLength(50)]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Email { get; set; } = null!;

        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Campo CPF inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cpf { get; set; } = null!;

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Campo telefone inválido.")]
        public string? Telefone { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Campo CEP inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cep { get; set; } = null!;

        [StringLength(2, MinimumLength = 2, ErrorMessage = "Campo estado inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Estado { get; set; } = null!;

        [StringLength(28, MinimumLength = 1, ErrorMessage = "Campo cidade inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Cidade { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Campo bairro inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Bairro { get; set; } = null!;

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Campo rua inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Rua { get; set; } = null!;

        [Display(Name = "Número")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Campo número inválido.")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Numero { get; set; } = null!;
    }
}
