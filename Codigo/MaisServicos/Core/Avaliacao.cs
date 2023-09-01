using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public int Id { get; set; }

    public DateTime Data { get; set; }

    public string Nota { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int IdPessoa { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual ICollection<Servicocontratado> Servicocontratados { get; set; } = new List<Servicocontratado>();
}
