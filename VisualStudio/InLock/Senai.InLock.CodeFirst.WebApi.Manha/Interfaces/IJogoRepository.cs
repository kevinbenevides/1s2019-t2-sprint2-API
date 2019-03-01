using Senai.InLock.CodeFirst.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Manha.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        void Cadastrar(JogoDomain jogo);

        void Atualizar(int id, JogoDomain jogo);

        void Deletar(int id);
    }
}
