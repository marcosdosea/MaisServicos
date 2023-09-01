using System;
using System.Collections.Generic;

namespace Core;

public partial class Servicocontratado
{
    public int Id { get; set; }

    public float Valor { get; set; }

    public int IdPessoa { get; set; }

    public int IdAvaliacao { get; set; }

    public int IdTemplateContrato { get; set; }

    public int IdOrcamento { get; set; }

    public virtual Avaliacao IdAvaliacaoNavigation { get; set; } = null!;

    public virtual Orcamento IdOrcamentoNavigation { get; set; } = null!;

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual Templatecontrato IdTemplateContratoNavigation { get; set; } = null!;

    public virtual ICollection<Servico> IdServicos { get; set; } = new List<Servico>();
}
