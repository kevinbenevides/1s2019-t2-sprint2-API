using Senai.SviGufo.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista de tipo de evento</returns>

        List<TipoEventoDomain> Listar();

        void Cadastrar(TipoEventoDomain tipoEvento);


        void Alterar(TipoEventoDomain tipoEvento);

        void Deletar(int id);
    }
}
