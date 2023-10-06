using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Telefone { get; set; }

    public string Cep { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Bairro { get; set; } = null!;

    public string Rua { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string TipoPessoa { get; set; } = null!;

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual ICollection<Servicocontratado> Servicocontratados { get; set; } = new List<Servicocontratado>();

    public virtual ICollection<Solicitarorcamento> Solicitarorcamentos { get; set; } = new List<Solicitarorcamento>();
}
