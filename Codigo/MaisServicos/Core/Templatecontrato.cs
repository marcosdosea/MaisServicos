using System;
using System.Collections.Generic;

namespace Core;

public partial class Templatecontrato
{
    public int Id { get; set; }

    public byte[] Arquivo { get; set; } = null!;

    public virtual ICollection<Servicocontratado> Servicocontratados { get; set; } = new List<Servicocontratado>();
}
