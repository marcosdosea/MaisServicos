using System;
using System.Collections.Generic;

namespace Core;

public partial class Servico
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int IdAreaDeAtuacao { get; set; }

    public virtual Areadeatuacao IdAreaDeAtuacaoNavigation { get; set; } = null!;

    public virtual ICollection<Servicocontratado> Ids { get; set; } = new List<Servicocontratado>();
}
