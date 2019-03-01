using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Context
{
    public class SenaturContext : DbContext
    {
        public DbSet<PacoteDomain> Pacotes { get; set; }

        public DbSet<UsuarioDomain> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.\\SqlExpress; initial catalog = Senatur_Manha; user id = sa; pwd=132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
