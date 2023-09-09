using Core;
using Core.OrcamentoService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly MaisServicosContext _context;

        public OrcamentoService(MaisServicosContext context)
        {
            _context = context;
        }
        public void Edit(Orcamento orcamento)
        {
            _context.Update(orcamento);
            _context.SaveChanges();
        }

        public Orcamento Get(int idOrcamento)
        {
            return _context.Orcamentos.Find(idOrcamento);
        }

        public void Delete(int idOrcamento)
        {
            var _orcamento = _context.Orcamentos.Find(idOrcamento);
            _context.Remove(_orcamento);
            _context.SaveChanges();
        }

        public int Create(Orcamento orcamento)
        {
            _context.Add(orcamento);
            _context.SaveChanges();
            return orcamento.Id;
        }
        public IEnumerable<Orcamento> GetAll()
        {
            return _context.Orcamentos.AsNoTracking();
        }
    }
}
