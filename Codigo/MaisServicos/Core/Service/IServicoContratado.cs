using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IServicoContratado
    {
        public int Create(Servicocontratado servicocontratado);

        public void Edit(Servicocontratado servicocontratado);

        public void Delete(int id);

        public Servicocontratado Get(int id);

        public IEnumerable<Servicocontratado> GetAll();
    }
}
