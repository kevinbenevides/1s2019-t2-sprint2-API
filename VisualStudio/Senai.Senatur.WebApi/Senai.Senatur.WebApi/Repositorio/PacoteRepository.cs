using Senai.Senatur.WebApi.Context;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositorio
{
    public class PacoteRepository : IPacoteRepository
    {
        public void Atualizar(int id, PacoteDomain pacote)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                PacoteDomain pacoteexiste = ctx.Pacotes.Find(id);

                pacoteexiste.NomePacote = pacote.NomePacote;
                pacoteexiste.Descricao = pacote.Descricao;
                pacoteexiste.DataIda = pacote.DataIda;
                pacoteexiste.DataVolta = pacote.DataVolta;
                pacoteexiste.Valor = pacote.Valor;
                pacoteexiste.Ativo = pacote.Ativo;
                pacoteexiste.NomeCidade = pacote.NomeCidade;

                ctx.Pacotes.Update(pacote);
                ctx.SaveChanges();
            }
        }

        public List<PacoteDomain> BuscarporId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(PacoteDomain pacote)
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                ctx.Pacotes.Add(pacote);
                ctx.SaveChanges();
            }
        }

        public List<PacoteDomain> Listar()
        {
            using (SenaturContext ctx = new SenaturContext())
            {
                return ctx.Pacotes.ToList();
            }
        }
    }
}
