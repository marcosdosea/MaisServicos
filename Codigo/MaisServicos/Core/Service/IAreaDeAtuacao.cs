using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IAreaDeAtuacao
    {
        public int Create(Areadeatuacao areaDeAtuacao);

        public void Edit(Areadeatuacao areaDeAtuacao);

        public void Delete(int idAreaDeAtuacao);

        public Areadeatuacao Get(int idAreaDeAtuacao);

        public IEnumerable<Areadeatuacao> GetAll();

        public IEnumerable<Areadeatuacao> GetByName(string nome);
    }
}
