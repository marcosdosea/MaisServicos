using System;
using System.Collections.Generic;

namespace Core;

public partial class Orcamento
{
    public int Id { get; set; }

    public float Valor { get; set; }

    public string Descricao { get; set; } = null!;

    public int IdSolicita { get; set; }

    public int IdUsuario { get; set; }

    public virtual Solicitum IdSolicitaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Servicocontratado> Servicocontratados { get; set; } = new List<Servicocontratado>();
}
