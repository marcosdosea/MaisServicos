using Core.DTO;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPrestadorService
    {
        public int Create(Pessoa prestador);

        public void Edit(Pessoa prestador);

        public void Delete(int idprestador);

        Pessoa Get(int idprestador);
        
        IEnumerable<Pessoa> GetAll();

        IEnumerable<PessoaDTO> GetByName(String nome);
    }
}