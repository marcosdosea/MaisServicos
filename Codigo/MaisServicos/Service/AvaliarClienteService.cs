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
        /// <exception cref="NotImplementedException"></exception>
        public int Create(Pessoa Cliente)
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
        /// Altera os dados da avaliçao do cliente
        /// </summary>
        /// <param name="Cliente"></param>
        public void Edit(Pessoa Cliente)
        {
            _context.Update(Cliente);
            _context.SaveChanges();
        }


        /// <summary>
        /// Buscar um cliente para avaliaçao na base de dados
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public Pessoa Get(int idCliente)
        {
            return _context.Pessoas.Find(idCliente);
        }


        /// <summary>
        /// Buscar um cliente do serviço prestado
        /// </summary>
        /// <returns></returns>
 
        public IEnumerable<Pessoa> GetAll()
        {
            return (IEnumerable<Pessoa>)_context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Buscar todos os cliente de serviços prestados
        /// </summary>
        /// <param name="nome">nome do cliente</param>
        /// <returns>Lista de clientes que inicia com o nome escolhido</returns>
        public IEnumerable<PessoaDTO> GetByName(string nome)
        {
            var query = from client in _context.Pessoas
                        where client.Nome.StartsWith(nome)
                        orderby client.Nome
                        select new PessoaDTO
                        { 
                            Id = client.Id, 
                            Nome = nome
                        };
            return query;
        }
    }
}
