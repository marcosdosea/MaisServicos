using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ServicoPrestadoService : IServicoPrestadoService
    {
        private readonly MaisServicosContext _context;

        public ServicoPrestadoService(MaisServicosContext context)
        {
            _context = context;
        }

        ///<sumary>
        ///Cria um novo serviço para o prestador
        ///</sumary>
        ///<param name="serviço">dados do serviço</param>
        ///<returns>id</returns>
        public int Create(Servico servico)
        {
            _context.Add(servico);
            _context.SaveChanges();
            return servico.Id;
        }

        ///<sumary>
        ///Remove o serviço da base de dados
        ///</sumary>
        ///<param name="Id">id do serviço</param>
        public void Delete(int idServico)
        {
            var _servico = _context.Servicos.Find(idServico);
            _context.Remove(_servico);
            _context.SaveChanges();
        }

        ///<sumary>
        ///Alterar dados do serviço na base de dados
        ///</sumary>
        ///<param name="servico"></param>
        public void Edit(Servico servico)
        {
            _context.Update(servico);
            _context.SaveChanges();
        }

        /// <summary>
		/// Buscar um serviço na base de dados
		/// </summary>
		/// <param name="idServico">id serviço</param>
		/// <returns>dados do autor</returns>
        public Servico Get(int idServico)
        {
            return _context.Servicos.Find(idServico);
        }

        ///<sumary>
        ///Buscar todos os serviços cadastrados
        /// </sumary>
        /// <returns>Lista de serviços</returns>
        public IEnumerable<Servico> GetAll()
        {
            return _context.Servicos.AsNoTracking();
        }
    }
}
