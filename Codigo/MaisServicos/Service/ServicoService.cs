using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServicoService : IServicoService
    {
        private readonly MaisServicosContext _context;

        public ServicoService(MaisServicosContext context)
        {
            _context = context;
        }

        ///<sumary>
        ///Cria um novo serviço
        ///</sumary>
        ///<param name="serviço">dados do serviço</param>
        ///<returns>id</returns>
        public int Inserir(Servico servico)
        {
            _context.Add(servico);
            _context.SaveChanges();
            return servico.Id;
        }

        ///<sumary>
        ///Alterar dados do serviço na base de dados
        ///</sumary>
        ///<param name="servico"></param>
        public void Alterar(Servico servico)
        {
            _context.Update(servico);
            _context.SaveChanges();
        }

        ///<sumary>
        ///Remove o serviço da base de dados
        ///</sumary>
        ///<param name="Id">id do serviço</param>
        public void Excluir(int idServico)
        {
            var _servico = _context.Servicos.Find(idServico);
            _context.Remove(_servico);
            _context.SaveChanges();
        }

        /// <summary>
		/// Buscar um serviço na base de dados
		/// </summary>
		/// <param name="idServico">id serviço</param>
		/// <returns>dados do autor</returns>
        public Servico Obter(int idServico)
        {
            return _context.Servicos.Find(idServico);
        }

        ///<sumary>
        ///Buscar todos os serviços cadastrados
        /// </sumary>
        /// <returns>Lista de serviços</returns>
        public IEnumerable<Servico> ConsultarTodos()
        {
            return _context.Servicos.AsNoTracking();
        }

        ///<sumary>
        ///Buscar serviços iniciando com o nome
        /// </sumary>
        /// <param name="nome">nome do serviço</param>
        /// <returns>Lista de serviços que inicia com o nome</returns>
        public IEnumerable<Servico> ConsultarPeloNome(string nome)
        {
            var query = from servico in _context.Servicos
                        where servico.Nome.StartsWith(nome)
                        orderby servico.Nome
                        select servico;
            return query.AsNoTracking();
        }
    }
}
