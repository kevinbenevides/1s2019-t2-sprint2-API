﻿using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        void Cadastrar(InstituicaoDomain Instituicao);

        InstituicaoDomain BuscarId(int id);
    }
}