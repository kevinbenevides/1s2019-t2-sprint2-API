﻿using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        void Cadastrar(JogoDomain jogo);
    }
}
