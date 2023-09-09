using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrcamentoDTO
{
    public class OrcamentoDTO
    {
        public float Valor { get; set; }

        public string Descricao { get; set; } = null!;

        public DateTime Data { get; set; }

        public int Id { get; set; }
    }
}
