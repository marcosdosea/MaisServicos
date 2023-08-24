using System;
using System.Collections.Generic;

namespace Core;

public partial class Usuario
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }

    public string Cep { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public int NumeroDaCasa { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();

    public virtual ICollection<Servicocontratado> Servicocontratados { get; set; } = new List<Servicocontratado>();

    public virtual ICollection<Solicitum> Solicita { get; set; } = new List<Solicitum>();

    public virtual ICollection<Servico> IdServicos { get; set; } = new List<Servico>();
}
