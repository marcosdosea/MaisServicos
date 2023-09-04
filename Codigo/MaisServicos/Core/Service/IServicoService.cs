using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IServicoService
    {
        public int Inserir(Servico servico);

        public Servico Obter(int idServico);

        public void Alterar(Servico servico);

        public void Excluir(int idServico);

        public IEnumerable<Servico> ConsultarTodos();

        public IEnumerable<Servico> ConsultarPeloNome(string nome);
    }
}
