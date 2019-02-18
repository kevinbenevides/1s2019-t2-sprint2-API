using Senai.Personagens.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Personagens.WebApi.Manha.Interfaces
{
    interface IPersonagemRepository
    {
        List<PersonagemDomain> Listar();

        void Cadastrar(PersonagemDomain Personagem);
    }
}
