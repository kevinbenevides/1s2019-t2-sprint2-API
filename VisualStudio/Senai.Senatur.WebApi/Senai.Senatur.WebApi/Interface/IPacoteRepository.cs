using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Interface
{
    interface IPacoteRepository
    {
        List<PacoteDomain> Listar();

        List<PacoteDomain> BuscarporId(int id);

        void Cadastrar(PacoteDomain pacote);

        void Atualizar(int id, PacoteDomain pacote);
    }
}
