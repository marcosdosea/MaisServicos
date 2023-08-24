using System;
using System.Collections.Generic;

namespace Core;

public partial class Servicocontratado
{
    public int Id { get; set; }

    public float Valor { get; set; }

    public int IdCliente { get; set; }

    public int IdTemplateContrato { get; set; }

    public int IdOrçamento { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<Avaliacao> Avaliacaos { get; set; } = new List<Avaliacao>();

    public virtual Orcamento IdOrçamentoNavigation { get; set; } = null!;

    public virtual Templatecontrato IdTemplateContratoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Areadeatuacao> IdAreaDeAtuacaos { get; set; } = new List<Areadeatuacao>();

    public virtual ICollection<Servico> IdServicos { get; set; } = new List<Servico>();
}
