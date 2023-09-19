using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AvaliarClienteService : IAvaliarClienteService
    {
        private readonly MaisServicosContext _context;

        public AvaliarClienteService(MaisServicosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma Avaliaçao de cliente ao serviço prestado
        /// </summary>
        /// <param name="Cliente"></param>
        /// <returns>id</returns>
        public int Create(Avaliacao Cliente)
        {
            _context.Add(Cliente);
            _context.SaveChanges();
            return Cliente.Id;
        }

        /// <summary>
        /// Remove Avaliçao feita ao cliente do serviço prestado
        /// </summary>
        /// <param name="Cliente"></param>
        public void Delete(int idCliente)
        {
            var _cliente = _context.Servicos.Find(idCliente);
            _context.Remove(_cliente);
            _context.SaveChanges();

        }

        /// <summary>
        /// Altera os dados da avaliçao do client
        /// </summary>
        /// <param name="Cliente"></param>
        public void Edit(Avaliacao Cliente)
        {
           _context.Update(Cliente);
           _context.SaveChanges();
        }

        /// <summary>
        /// Buscar um cliente para avaliaçao na base de dados
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Avaliacao Get(int idCliente)
        {
            return _context.Avaliacaos.Find(idCliente);
        }


        /// <summary>
        /// Buscar um cliente do serviço prestado
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Avaliacao> GetAll()
        {
            return (IEnumerable<Avaliacao>)_context.Avaliacaos.AsNoTracking();
        }

        public IEnumerable<Avaliacao> GetByName(string nome)
        {
            var query = from cliente in _context.Avaliacaos
                        where cliente.Nota.StartsWith(nome)
                        select new Avaliacao
                        {
                            Id = cliente.Id
                        };
            return query;

        }
    }

}
