using Senai.InLock.CodeFirst.WebApi.Manha.Context;
using Senai.InLock.CodeFirst.WebApi.Manha.Domains;
using Senai.InLock.CodeFirst.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Manha.Repositorios
{
    public class JogoRepository : IJogoRepository
    {
        public void Atualizar(int id, JogoDomain jogo)
        {
            using(InLockContext ctx = new InLockContext())
            {
                JogoDomain jogosexiste = ctx.Jogos.Find(id);

                jogosexiste.NomeJogo = jogo.NomeJogo;
                jogosexiste.Descricao = jogo.Descricao;
                jogosexiste.DataLancamento = jogo.DataLancamento;
                jogosexiste.Valor = jogo.Valor;
                jogosexiste.EstudioId = jogo.EstudioId;

                ctx.Jogos.Update(jogosexiste);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(JogoDomain jogo)
        {
            using (InLockContext ctx = new InLockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public List<JogoDomain> Listar()
        { 
            using (InLockContext ctx = new InLockContext())
            {
                return ctx.Jogos.ToList();   
            }
            
        }
    }
}
