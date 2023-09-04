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
    public class ClienteService : IClienteService
    {
        private readonly MaisServicosContext _context;

        public ClienteService(MaisServicosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar um cliente na base de dados
        /// </summary>
        /// <param name="client"></param>
        /// <returns>id do cliente</returns>
        public int Create(Cliente client)
        {
            _context.Add(client);
            _context.SaveChanges();
            return client.Id;
        }

        /// <summary>
        /// Remover o cliente da base de dados
        /// </summary>
        /// <param name="idClient"></param>
        public void Delete(int idClient)
        {
            var _client = _context.Pessoas.Find(idClient);
            _context.Remove(_client);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar os dados de um cliente na base de dados
        /// </summary>
        /// <param name="client"></param>
        public void Edit(Cliente client)
        {
            _context.Update(client);
            _context.SaveChanges();
        }

        /// <summary>
        /// Buscar um cliente na base de dados
        /// </summary>
        /// <param name="idClient"></param>
        /// <returns>Dados do cliente</returns>
        public Cliente Get(int idClient)
        {
            return (Cliente)_context.Pessoas.Find(idClient);
        }

        /// <summary>
        /// Buscar todos os clientes cadastrados
        /// </summary>
        /// <returns>Lista de clientes</returns>
        public IEnumerable<Cliente> GetAll()
        {
            return (IEnumerable<Cliente>)_context.Pessoas.AsNoTracking();
        }

        /// <summary>
        /// Buscar clientes pelo nome informado
        /// </summary>
        /// <param name="nome">nome do cliente</param>
        /// <returns>Lista de clientes que inicia com o nome</returns>
        IEnumerable<ClienteDTO> IClienteService.GetByName(string nome)
        {
            var query = from client in _context.Pessoas
                        where client.Nome.StartsWith(nome)
                        orderby client.Nome
                        select new ClienteDTO
                        {
                            Id = client.Id,
                            Nome = client.Nome
                        };
            return query;
        }
    }
}
