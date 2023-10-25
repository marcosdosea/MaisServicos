using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class AreaDeAtuacaoService : IAreaDeAtuacaoService
    {
        private readonly MaisServicosContext _context;

        public AreaDeAtuacaoService(MaisServicosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma area de atuacao na base de dados
        /// </summary>
        /// <param name="areaDeAtuacao">Dados da area de atuacao</param>
        /// <returns>id da area de atuacao</returns>
        public int Create(Areadeatuacao areaDeAtuacao)
        {
            _context.Add(areaDeAtuacao);
            _context.SaveChanges();
            return areaDeAtuacao.Id;
        }

        /// <summary>
        /// Remover uma area de atuacao da base de dados
        /// </summary>
        /// <param name="idAreaDeAtuacao">id da area que deseja excluir</param>
        public void Delete(int idAreaDeAtuacao)
        {
            var area = _context.Areadeatuacaos.Find(idAreaDeAtuacao);
            _context.Remove(area);
            _context.SaveChanges();
        }

        /// <summary>
        /// Editar os dados de uma area de atuacao na base de dados
        /// </summary>
        /// <param name="areaDeAtuacao">Objeto do tipo area de atuacao</param>
        public void Edit(Areadeatuacao areaDeAtuacao)
        {
            _context.Update(areaDeAtuacao);
            _context.SaveChanges();
        }

        /// <summary>
        /// Buscar uma area de atuacao na base de dados
        /// </summary>
        /// <param name="idAreaDeAtuacao">id da area de atuacao desejada</param>
        /// <returns>Dados de uma area de atuacao</returns>
        public Areadeatuacao Get(int idAreaDeAtuacao)
        {
            return _context.Areadeatuacaos.Find(idAreaDeAtuacao);
        }

        /// <summary>
        /// Buscar todas as areas de atuacao cadastradas
        /// </summary>
        /// <returns>Lista de areas de atuacao</returns>
        public IEnumerable<Areadeatuacao> GetAll()
        {
            return _context.Areadeatuacaos.AsNoTracking();
        }

        public IEnumerable<Areadeatuacao> GetByName(string nome)
        {
            var query = from area in _context.Areadeatuacaos
                        where area.Nome.StartsWith(nome)
                        orderby area.Nome
                        select area;
            return query.Take(5).ToList();
        }
    }
}
