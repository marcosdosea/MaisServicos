using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IServicoPrestadoService
    {
        public int Create(Servico servico);

        public void Edit(Servico servico);

        public void Delete(int idServico);

        public Servico Get(int idServico);

        public IEnumerable<Servico> GetAll();
    }
}
