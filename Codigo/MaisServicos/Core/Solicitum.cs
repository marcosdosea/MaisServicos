using System;
using System.Collections.Generic;

namespace Core;

public partial class Solicitum
{
    public int Id { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime DataSolicitacao { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
}
