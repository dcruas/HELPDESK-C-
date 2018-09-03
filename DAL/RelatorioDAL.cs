using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class RelatorioDAL
    {
        SqlConnection conexao;
        // Linha que faz a leitura do caminho do banco de dados
        string caminho = @"" + System.IO.File.ReadAllText("caminho.txt");

        public List<Relatorio> GerarRelatorio(Relatorio relatorio, string datainicial, string datafinal)
        {
            List<Relatorio> relatorios = new List<Relatorio>();

            string SQL;

            try
            {
                try
                {
                    
                    conexao = new SqlConnection(caminho);
                    

                    if (relatorio.tiporelatorio == 1)
                    {
                        SQL = Properties.Resources.RelatorioGeralChamados;

                    }
                    else
                    {
                        SQL = Properties.Resources.RelatorioDetalhadoChamados;
                    }

                    SqlCommand comando = new SqlCommand(SQL, conexao);
                    comando.Parameters.Add(new SqlParameter("@dti", Convert.ToDateTime(datainicial)));
                    comando.Parameters.Add(new SqlParameter("@dtf", Convert.ToDateTime(datafinal)));


                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        Relatorio report = new Relatorio();

                        report.pendente = Convert.ToInt32(dr["PENDENTES"]);
                        report.atrasados = Convert.ToInt32(dr["ATRASADOS"]);
                        report.encatraso = Convert.ToInt32(dr["ENCERRADOC/ATRASO"]);
                        report.encerrados = Convert.ToInt32(dr["TOTALENCERRADOS"]);
                        report.avaliacao = Convert.ToInt32(dr["MEDIA"]);
                        report.pctatendido = ((float)report.encerrados * 100 / ((float)report.pendente + (float)report.encerrados));
                        report.pctnaoatendido = ((float)report.pendente * 100 / ((float)report.pendente + (float)report.encerrados));
                        report.pctatendidoforadoprazo = ((float)report.encatraso / (float)report.encerrados) * 100;
                        if (relatorio.tiporelatorio != 1)
                        {
                            report.datahoje = Convert.ToDateTime(dr["DT_ABERTURA"]);
                        }
                        else
                        {
                            report.datahoje = DateTime.Now;
                        }
                        relatorios.Add(report);
                    }
                    
                }
                catch (Exception)
                {
                    throw;
                }
            }
            finally
            {

                conexao.Close();
            }

            return relatorios;
        }
    }
}
