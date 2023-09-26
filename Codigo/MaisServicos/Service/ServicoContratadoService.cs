using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ServicoContratadoService : IServicoContratado
    {
        private readonly MaisServicosContext _context;

        public ServicoContratadoService(MaisServicosContext context)
        {
            _context = context;
        }

        ///<sumary>
        ///Cria um novo serviço contratado
        ///</sumary>
        ///<param name="serviço">dados do serviço</param>
        ///<returns>id</returns>
        public int Create(Servicocontratado servico)
        {
            _context.Add(servico);
            _context.SaveChanges();
            return servico.Id;
        }

        ///<sumary>
        ///Alterar dados do serviço contratado na base de dados
        ///</sumary>
        ///<param name="servico"></param>
        public void Edit(Servicocontratado servico)
        {
            _context.Update(servico);
            _context.SaveChanges();
        }

        ///<sumary>
        ///Remove o serviço contratado da base de dados
        ///</sumary>
        ///<param name="Id">id do serviço</param>
        public void Delete(int id)
        {
            var _servico = _context.Servicos.Find(id);
            _context.Remove(_servico);
            _context.SaveChanges();
        }

        /// <summary>
		/// Buscar um serviço contratado na base de dados
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>dados do autor</returns>
        public Servicocontratado Get(int id)
        {
            return _context.Servicocontratados.Find(id);
        }

        ///<sumary>
        ///Buscar todos os serviços cadastrados
        /// </sumary>
        /// <returns>Lista de serviços</returns>
        public IEnumerable<Servicocontratado> GetAll()
        {
            return _context.Servicocontratados.AsNoTracking();
        }
    }
}
