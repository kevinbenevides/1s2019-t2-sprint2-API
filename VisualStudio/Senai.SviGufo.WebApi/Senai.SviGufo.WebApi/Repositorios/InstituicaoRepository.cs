using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositorios
{
    public class InstituicaoRepository : IInstituicaoRepository

    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND;user id=sa; pwd=132";

        public InstituicaoDomain BuscarId(int id)
        {
            InstituicaoDomain Instituicao = new InstituicaoDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string QueryASerExecutada = "SELECT * FROM INSTITUICOES WHERE ID = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(QueryASerExecutada, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        Instituicao.Id = Convert.ToInt32(rdr["ID"]);
                        Instituicao.Nome_Fantasia = rdr["NOME_FANTASIA"].ToString();
                        Instituicao.Razao_Social = rdr["RAZAO_SOCIAL"].ToString();
                        Instituicao.CNPJ = rdr["CNPJ"].ToString();
                        Instituicao.Logradouro = rdr["LOGRADOURO"].ToString();
                        Instituicao.UF = rdr["UF"].ToString();
                        Instituicao.Cidade = rdr["CIDADE"].ToString();
                    }
                }
            }

            return Instituicao;
        }


        public void Cadastrar(InstituicaoDomain Instituicao)
        {
          
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string QueryASerExecutada = "INSERT INTO INSTITUICOES (NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE) VALUES (@NOME_FANTASIA, @RAZAO_SOCIAL, @CNPJ, @LOGRADOURO, @CEP, @UF, @CIDADE)";
                SqlCommand cmd = new SqlCommand(QueryASerExecutada, con);
                cmd.Parameters.AddWithValue("@NOME_FANTASIA", Instituicao.Nome_Fantasia);
                cmd.Parameters.AddWithValue("@RAZAO_SOCIAL", Instituicao.Razao_Social);
                cmd.Parameters.AddWithValue("@CNPJ", Instituicao.CNPJ);
                cmd.Parameters.AddWithValue("@LOGRADOURO", Instituicao.Logradouro);
                cmd.Parameters.AddWithValue("@CEP", Instituicao.CEP);
                cmd.Parameters.AddWithValue("@UF", Instituicao.UF);
                cmd.Parameters.AddWithValue("@CIDADE", Instituicao.Cidade);

                
                cmd.ExecuteNonQuery();

            }



        }
    public List<InstituicaoDomain> Listar()
    {
        List<InstituicaoDomain> Instituicoes = new List<InstituicaoDomain>();

        using (SqlConnection con = new SqlConnection(StringConexao))
        {
            string QueryASerExecutada = "SELECT ID, NOME_FANTASIA, RAZAO_SOCIAL, CNPJ, LOGRADOURO, CEP, UF, CIDADE FROM INSTITUICOES";

            con.Open();

            SqlDataReader rdr;

            using (SqlCommand cmd = new SqlCommand(QueryASerExecutada, con))
            {
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    InstituicaoDomain Instituicao = new InstituicaoDomain
                    {
                        Id = Convert.ToInt32(rdr["ID"])
                        ,
                        Nome_Fantasia = rdr["NOME_FANTASIA"].ToString()
                        ,
                        Razao_Social = rdr["RAZAO_SOCIAL"].ToString()
                        ,
                        CNPJ = rdr["CNPJ"].ToString()
                        ,
                        Logradouro = rdr["LOGRADOURO"].ToString()
                        ,
                        CEP = rdr["CEP"].ToString()
                        ,
                        UF = rdr["UF"].ToString()
                        ,
                        Cidade = rdr["CIDADE"].ToString()
                    };
                    Instituicoes.Add(Instituicao);
                }
            }
        }

        return Instituicoes;
    }
}
}
