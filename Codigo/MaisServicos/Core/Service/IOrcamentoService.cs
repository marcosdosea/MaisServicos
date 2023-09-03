using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.OrcamentoService
{
    public interface IOrcamentoService
    {
        int InserirOrcamento(Orcamento orcamento);

        void AlterarOrcamento(Orcamento orcamento);

        void ExcluirOrcamento(int idOrcamento);

        public Orcamento BuscarOrcamento(int idOrcamento);

        public IEnumerable<Orcamento> ConsultarTodos();

    }
}
