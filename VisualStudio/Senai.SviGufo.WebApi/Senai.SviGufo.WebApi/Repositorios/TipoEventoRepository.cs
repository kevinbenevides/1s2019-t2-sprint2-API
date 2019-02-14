using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SviGufo.WebApi.Repositorios
{
    public class TipoEventoRepository : ITipoEventoRepository
    {

        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog=SENAI_SVIGUFO_MANHA_BACKEND;user id=sa; pwd=132";
        
        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="tipoEvento"></param>
        public void Alterar(TipoEventoDomain tipoEvento)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "UPDATE TIPOS_EVENTOS SET TITULO = @TITULO WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                cmd.Parameters.AddWithValue("@ID", tipoEvento.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        public void Cadastrar(TipoEventoDomain tipoEvento)
        {
            //Dlecara a conexão passando sua string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //string QuerySerExecutada = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES('" + tipoEvento.Nome + "')";
                //Declara a query passando o valor como parametro
                string QueryASerExecutada = "INSERT INTO TIPOS_EVENTOS(TITULO) VALUES (@TITULO)";
                //Passa o valor do parametro
                SqlCommand cmd = new SqlCommand(QueryASerExecutada, con);
                cmd.Parameters.AddWithValue("@TITULO", tipoEvento.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deleta um Tipo Evento pelo seu Id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "DELETE FROM TIPOS_EVENTOS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista os tipos de evento
        /// </summary>
        /// <returns></returns>
        public List<TipoEventoDomain> Listar()
        {
            List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>();

            //Declaro a SqlConnection passado a string de conexão
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string QueryaSerExecutada = "SELECT ID, TITULO FROM TIPOS_EVENTOS";

                //Abre o banco de dados
                con.Open();

                //Declaro um SqlDataReader para percorrer a lista
                SqlDataReader rdr;

                //Declaro um command passando o comando a ser excutado e a conexão
                using (SqlCommand cmd = new SqlCommand(QueryaSerExecutada, con))
                {
                    //Executa a query
                    rdr = cmd.ExecuteReader();

                    //Percorre os dados
                    while (rdr.Read())
                    {
                        TipoEventoDomain tipoEvento = new TipoEventoDomain
                        {
                            Id = Convert.ToInt32(rdr["ID"]),
                            Nome = rdr["TITULO"].ToString()
                        };

                        tiposEventos.Add(tipoEvento);

                    }
                }
            }

            return tiposEventos;
        }
    }


}
