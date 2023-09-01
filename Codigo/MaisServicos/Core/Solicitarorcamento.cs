using System;
using System.Collections.Generic;

namespace Core;

public partial class Solicitarorcamento
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime Data { get; set; }

    public int IdPessoa { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
}
