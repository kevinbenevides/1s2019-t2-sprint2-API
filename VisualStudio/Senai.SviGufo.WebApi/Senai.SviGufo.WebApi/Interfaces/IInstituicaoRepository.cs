using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        InstituicaoDomain BuscarId(int id);

        void Cadastrar(InstituicaoDomain Instituicao);

        void Atualizar(InstituicaoDomain Instituicao, int id);

        void Delete(int id);
    }
}
