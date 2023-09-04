using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IClienteService 
    {
        int Create(Cliente pessoa);
        void Edit(Cliente pessoa);
        void Delete(int idPessoa);
        Cliente Get(int idPessoa);
        IEnumerable<Cliente> GetAll();
        IEnumerable<ClienteDTO> GetByName(String nome);
    }
}
