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
        public int Create(Pessoa Cliente);

        public void Edit(Pessoa Cliente);

        public void Delete(int idCliente);

        Pessoa Get(int idCliente);

        IEnumerable<Pessoa> GetAll();

        IEnumerable<PessoaDTO> GetByName(string nome);
    }
}
