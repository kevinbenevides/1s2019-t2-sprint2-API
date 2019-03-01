using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Manha.Context
{
    public class InLockContext : DbContext
    {
        //Jogos
        public DbSet<JogoDomain> Jogos { get; set; }
        //Estudios
        public DbSet<EstudioDomain> Estudios { get; set; }

        // definir a string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.\\SqlExpress; initial catalog = InLock_CodeFirst_Manha; user id = sa; pwd=132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
