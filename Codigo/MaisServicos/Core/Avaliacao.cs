using System;
using System.Collections.Generic;

namespace Core;

public partial class Avaliacao
{
    public int Id { get; set; }

    public DateTime DataAvaliacao { get; set; }

    public string NotaAvaliacao { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdServicoContratado { get; set; }

    public virtual Servicocontratado IdServicoContratadoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
