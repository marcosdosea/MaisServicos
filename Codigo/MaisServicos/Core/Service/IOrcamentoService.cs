using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrcamentoService
{
    public interface IOrcamentoService
    {
        int Create(Orcamento orcamento);

        void Edit(Orcamento orcamento);

        void Delete(int idOrcamento);

        Orcamento Get(int idOrcamento);

        public IEnumerable<Orcamento> GetAll();

    }
}
