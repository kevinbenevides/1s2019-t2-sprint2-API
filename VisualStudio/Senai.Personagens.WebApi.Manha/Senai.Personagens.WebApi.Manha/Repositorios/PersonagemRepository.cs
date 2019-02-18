using Senai.Personagens.WebApi.Manha.Domains;
using Senai.Personagens.WebApi.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Personagens.WebApi.Manha.Repositorios
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND;user id=sa; pwd=132";
        public void Cadastrar(PersonagemDomain Personagem)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "INSERT INTO PERSONAGENS (NOME, LANCAMENTO)  " +
                    "VALUES(@NOME, @LANCAMENTO)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@NOME", Personagem.Nome);
                cmd.Parameters.AddWithValue("@LANCAMENTO", Personagem.Lancamento);

                cmd.ExecuteNonQuery();
            }
            }

        public List<PersonagemDomain> Listar()
        {
            List<PersonagemDomain> ListaPersonagens = new List<PersonagemDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader rdr;

                string Query = "SELECT ID, NOME, LANCAMENTO FROM PERSONAGEM";
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PersonagemDomain Personagem = new PersonagemDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["NOME"].ToString(),
                            Lancamento = rdr["LANCAMENTO"].ToString()
                        };
                        ListaPersonagens.Add(Personagem);
                    }
                }
            }
            return ListaPersonagens;
        }
    }
}
