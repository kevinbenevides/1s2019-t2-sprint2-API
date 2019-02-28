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
        private string StringConexao = "Data Source =.\\SqlExpress; initial catalog = SENAI_SVIGUFO_MANHA_BACKEND; user id = sa; pwd=132";

        public List<JogoDomain> Listar()
        {
            List<JogoDomain> listajogos = new List<JogoDomain>;

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
                            DataLacamento = Convert.ToDateTime(sdr["DataLacamento"]),
                            Valor = Convert.ToDecimal(sdr["Valor"]),
                            //EstudioId = Convert.ToInt32(sdr["EstudioId"])
                        };
                        listajogos.Add(jogos);
                    }
                }
            }
            return listajogos;
        }
    }
}
