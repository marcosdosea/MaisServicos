﻿using Core.DTO;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IClienteService 
    {
        int Create(Pessoa pessoa);
        void Edit(Pessoa pessoa);
        void Delete(int idPessoa);
        Pessoa Get(int idPessoa);
        IEnumerable<Pessoa> GetAll();
        IEnumerable<PessoaDTO> GetByName(String nome);
    }
}
