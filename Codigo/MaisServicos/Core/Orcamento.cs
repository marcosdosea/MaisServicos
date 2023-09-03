using System;
using System.Collections.Generic;

namespace Core;

public partial class Orcamento
{
    public int Id { get; set; }

    public float Valor { get; set; }

    public string Descricao { get; set; } = null!;

    public DateTime Data { get; set; }

    public int IdSolicita { get; set; }

    public virtual Solicitarorcamento IdSolicitaNavigation { get; set; } = null!;

    public virtual ICollection<Orcamento> Orcamentos { get; set; } = new List<Orcamento>();
}
