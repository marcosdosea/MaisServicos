using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PrestadorService : IPrestadorService
    {
        private readonly MaisServicosContext _context;

        public PrestadorService(MaisServicosContext context)
        {
            _context = context;
        }   

        /// <summary>
        /// Criar Prestador na base de dados
        /// </summary>
        /// <param name="prestador"></param>
        /// <returns> id do prestador</returns>
         public int Create(Pessoa prestador)
        {
            _context.Add(prestador);
            _context.SaveChanges();
            return prestador.Id;
        }
        /// <summary>
        /// Remover Prestador da base de dados
        /// </summary>
        /// <param name="Idprestador"></param>
        public void Delete(int idprestador)
        {
            var _prestador = _context.Pessoas.Find(idprestador);
            _context.Remove(_prestador);
            _context.SaveChanges();
            throw new NotImplementedException();
        }


        /// <summary>
        /// Editar os dados do Prestador na base de dados
        /// </summary>
        /// <param name="prestador"></param>
        public void Edit(Pessoa prestador)
        {
            _context.Update(prestador);
            _context.SaveChanges(true);
        }

        /// <summary>
        /// Buscar Prestador especifico pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dados do prestador</returns>
        public Pessoa Get(int idprestador)
        {
            return _context.Pessoas.Find(idprestador);
        }

        /// <summary>
        /// Busca todo os prestadores cadastrados
        /// </summary>
        /// <returns>Lista com todos os prestadores</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return (IEnumerable<Pessoa>)_context.Pessoas.AsNoTracking();
        }


        /// <summary>
        /// Busca o prestadores pelo o nome informado
        /// </summary>
        /// <param name="nome">nome do prestador</param>
        /// <returns>Lista de prestadores que o nome informado</returns>
        public IEnumerable<PessoaDTO> GetByName(string nome)
        {
            var query = from prestador in _context.Pessoas
                        where prestador.Nome.StartsWith(nome)
                        orderby prestador.Nome
                        select new PessoaDTO
                        {
                            Id = prestador.Id,
                            Nome = prestador.Nome,
                        };
            return query;
        }

    }
}
