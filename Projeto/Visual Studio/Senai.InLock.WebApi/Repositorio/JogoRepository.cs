using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositorio
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog = InLock_Games_Manha; user id = sa; pwd=132";

        public void Cadastrar(JogoDomain jogo)
        {
            string QueryCadastrar = "INSERT INTO JOGOS(NomeJogo, Descricao, DataLancamento, Valor, EstudioId) VALUES (@NomeJogos, @Descricao, @DataLancamento, @Valor, @EstudioId)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(QueryCadastrar, con))
                {
                    cmd.Parameters.AddWithValue("@NomeJogos", jogo.NomeJogo);
                    cmd.Parameters.AddWithValue("@Descricao", jogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", jogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogo.Valor);
                    cmd.Parameters.AddWithValue("@EstudioId", jogo.EstudioId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listajogos = new List<JogoDomain>();

            string QueryListar = "SELECT * FROM JOGOS JOIN ESTUDIOS ON JOGOS.EstudioId = ESTUDIOS.EstudioId";

            using (SqlConnection con = new SqlConnection (StringConexao))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand (QueryListar, con))
                {
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        JogoDomain jogos = new JogoDomain

                        {
                            JogoId = Convert.ToInt32(sdr["JogoId"]),
                            NomeJogo = sdr["NomeJogo"].ToString(),
                            Descricao = sdr["Descricao"].ToString(),
                            DataLancamento = Convert.ToDateTime(sdr["DataLancamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            Estudio = new EstudioDomain
                            {
                                EstudioId = Convert.ToInt32(sdr["EstudioId"]),
                                NomeEstudio = sdr["NomeEstudio"].ToString()
                            }
                                
                        };
                        listajogos.Add(jogos);
                    }
                }
            }
            return listajogos;
        }
    }
}
