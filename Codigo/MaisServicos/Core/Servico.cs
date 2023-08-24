using System;
using System.Collections.Generic;

namespace Core;

public partial class Servico
{
    public int Id { get; set; }

    public DateTime Nome { get; set; }

    public string Descricao { get; set; } = null!;

    public int IdAreaDeAtuacao { get; set; }

    public virtual Areadeatuacao IdAreaDeAtuacaoNavigation { get; set; } = null!;

    public virtual ICollection<Servicocontratado> IdServicoContratados { get; set; } = new List<Servicocontratado>();

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
