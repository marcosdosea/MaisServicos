using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAvaliarClienteService
    {
        public int Create(Avaliacao Cliente);

        public void Edit(Avaliacao Cliente);

        public void Delete(int idCliente);

        Avaliacao Get(int idCliente);

        IEnumerable<Avaliacao> GetAll();

        IEnumerable<Avaliacao> GetByName(string nome);
    }
}
