using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class ChamadoDAL
    {
        SqlConnection conexao;
        // Linha que lê o caminho do banco de dados //
        string caminho = @"" + System.IO.File.ReadAllText("caminho.txt");

                
        public List<Chamado> ProcurarMatricula(int codigo)
        {
            List<Chamado> chamados = new List<Chamado>();
            

            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);


                    SQL = "SELECT CD_CHAMADO,CD_TECNICO, DT_ABERTURA, DS_JUSTIFICATIVA, DS_PROBLEMA,DT_ENCERRAMENTO, CD_FUNCIONARIO,CD_PROBLEMA,CD_STATUS,CD_AVALIACAO FROM TB_CHAMADO WHERE CD_FUNCIONARIO = '" + codigo + "' ORDER BY CD_CHAMADO";



                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        Chamado chamado = new Chamado();

                        chamado.codigo = Convert.ToInt32(dr["CD_CHAMADO"]);
                        chamado.codtecnico = Convert.IsDBNull(dr["CD_TECNICO"]) ? 0 : (int)dr["CD_TECNICO"];
                       // chamado.codtecnico = Convert.ToInt32(dr["CD_TECNICO"]);
                        chamado.dataAbertura = dr["DT_ABERTURA"].ToString();
                        chamado.justificativa = Convert.IsDBNull(dr["DS_JUSTIFICATIVA"]) ? "" : (string)dr["DS_JUSTIFICATIVA"];
                        //chamado.justificativa = dr["DS_JUSTIFICATIVA"].ToString();
                        chamado.descricao = dr["DS_PROBLEMA"].ToString();
                        chamado.dataEncerramento = dr["DT_ENCERRAMENTO"].ToString();
                        chamado.codfuncionario = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                        chamado.codproblema = Convert.ToInt32(dr["CD_PROBLEMA"]);
                        chamado.codstatus = Convert.ToInt32(dr["CD_STATUS"]);
                        chamado.codavaliacao = Convert.IsDBNull(dr["CD_AVALIACAO"]) ? 0 : (int)dr["CD_AVALIACAO"];
                       

                        chamados.Add(chamado);

                       

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

            return chamados;
        }

        public Chamado ProcurarProtocolo(int codigo)
        {
            Chamado chamado = new Chamado();


            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);


                    SQL = "SELECT CD_CHAMADO,CD_TECNICO, DT_ABERTURA, DS_JUSTIFICATIVA, DS_PROBLEMA,DT_ENCERRAMENTO, CD_FUNCIONARIO,CD_PROBLEMA,CD_STATUS,CD_AVALIACAO FROM TB_CHAMADO WHERE CD_CHAMADO = '" + codigo + "' ORDER BY CD_CHAMADO";



                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        

                        chamado.codigo = Convert.ToInt32(dr["CD_CHAMADO"]);
                        chamado.codtecnico = Convert.IsDBNull(dr["CD_TECNICO"]) ? 0 : (int)dr["CD_TECNICO"];
                        // chamado.codtecnico = Convert.ToInt32(dr["CD_TECNICO"]);
                        chamado.dataAbertura = dr["DT_ABERTURA"].ToString();
                        chamado.justificativa = Convert.IsDBNull(dr["DS_JUSTIFICATIVA"]) ? "" : (string)dr["DS_JUSTIFICATIVA"];
                        //chamado.justificativa = dr["DS_JUSTIFICATIVA"].ToString();
                        chamado.descricao = dr["DS_PROBLEMA"].ToString();
                        chamado.dataEncerramento = dr["DT_ENCERRAMENTO"].ToString();
                        chamado.codfuncionario = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                        chamado.codproblema = Convert.ToInt32(dr["CD_PROBLEMA"]);
                        chamado.codstatus = Convert.ToInt32(dr["CD_STATUS"]);
                        chamado.codavaliacao = Convert.IsDBNull(dr["CD_AVALIACAO"]) ? 0 : (int)dr["CD_AVALIACAO"];


                       
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

            return chamado;
        }

        public void IncluirChamado(Chamado chamado)
        {
            string SQL;
            SqlCommand comando;


            try
            {
                conexao = new SqlConnection(caminho);


                conexao.Open();


                SQL = "INSERT INTO TB_CHAMADO (DT_ABERTURA, DS_PROBLEMA, CD_FUNCIONARIO, CD_PROBLEMA, CD_STATUS) VALUES ('" + Convert.ToDateTime(chamado.dataAbertura) + "', '" + chamado.descricao + "', '" + chamado.codfuncionario + "','" + chamado.codproblema + "', '" + chamado.codstatus + "')"; 

                comando = new SqlCommand(SQL, conexao);

                comando.ExecuteNonQuery();


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }

          
        }

        public void AtualizarChamado(Chamado chamado)
        {
            string SQL;
            SqlCommand comando;
            

            try
            {
                conexao = new SqlConnection(caminho);

                SQL = "UPDATE TB_CHAMADO SET CD_PROBLEMA = '" + chamado.codproblema + "', DS_PROBLEMA = '" + chamado.descricao + "' WHERE CD_CHAMADO = '" + chamado.codigo + "'";

                comando = new SqlCommand(SQL, conexao);

                conexao.Open();

                comando.ExecuteNonQuery();
               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
            
        }

        public int ultimoId()
        {
            int id;

            string SQL;

            try
            {
                try
                {

                    conexao = new SqlConnection(caminho);

                    SQL = "SELECT IDENT_CURRENT('TB_CHAMADO')";

                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();
                    id = Convert.ToInt32(comando.ExecuteScalar());

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

            return id;
        }

        public List<Chamado> FiltroChamados(Chamado ticket)
        {
            List<Chamado> chamados = new List<Chamado>();
            string SQL;

            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);


                    if (ticket.codstatus == 2)
                    {
                        if (ticket.dataAbertura != "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "' AND DT_ABERTURA <= '" + ticket.dataEncerramento + "' AND CD_STATUS <='" + ticket.codstatus + "'";

                        }
                        else if (ticket.dataAbertura != "" && ticket.dataEncerramento == "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "' AND CD_STATUS <='" + ticket.codstatus + "'";

                        }
                        else if (ticket.dataAbertura == "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ENCERRAMENTO <= '" + ticket.dataEncerramento + "' AND CD_STATUS <='" + ticket.codstatus + "'";
                        }
                        else
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE CD_STATUS <='" + ticket.codstatus + "'";
                        }
                    }
                    else if (ticket.codstatus == 4)
                    {
                        if (ticket.dataAbertura != "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "' AND DT_ABERTURA <= '" + ticket.dataEncerramento + "' AND CD_STATUS >='" + (ticket.codstatus - 1) + "'";

                        }
                        else if (ticket.dataAbertura != "" && ticket.dataEncerramento == "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "' AND CD_STATUS >'" + (ticket.codstatus - 1) + "'";

                        }
                        else if (ticket.dataAbertura == "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ENCERRAMENTO <= '" + ticket.dataEncerramento + "' AND CD_STATUS >='" + (ticket.codstatus - 1) + "'";
                        }
                        else
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE CD_STATUS >='" + (ticket.codstatus -1)+ "'";
                        }

                    }
                    else 
                    {
                        if (ticket.dataAbertura != "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "' AND DT_ABERTURA <='" + ticket.dataEncerramento + "'";

                        }
                        else if (ticket.dataAbertura != "" && ticket.dataEncerramento == "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ABERTURA >= '" + ticket.dataAbertura + "'";

                        }
                        else if (ticket.dataAbertura == "" && ticket.dataEncerramento != "")
                        {
                            SQL = "SELECT * FROM TB_CHAMADO WHERE DT_ENCERRAMENTO <= '" + ticket.dataEncerramento + "'";
                        }
                        else
                        {
                            SQL = "SELECT * FROM TB_CHAMADO";
                        }

                        
                    }

                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        Chamado chamado = new Chamado();

                        chamado.codigo = Convert.ToInt32(dr["CD_CHAMADO"]);
                        chamado.codtecnico = Convert.IsDBNull(dr["CD_TECNICO"]) ? 0 : (int)dr["CD_TECNICO"];
                        chamado.dataAbertura = dr["DT_ABERTURA"].ToString();
                        chamado.justificativa = Convert.IsDBNull(dr["DS_JUSTIFICATIVA"]) ? "" : (string)dr["DS_JUSTIFICATIVA"];
                        chamado.descricao = dr["DS_PROBLEMA"].ToString();
                        chamado.dataEncerramento = dr["DT_ENCERRAMENTO"].ToString();
                        chamado.codfuncionario = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                        chamado.codproblema = Convert.ToInt32(dr["CD_PROBLEMA"]);
                        chamado.codstatus = Convert.ToInt32(dr["CD_STATUS"]);
                        chamado.codavaliacao = Convert.IsDBNull(dr["CD_AVALIACAO"]) ? 0 : (int)dr["CD_AVALIACAO"];
                        chamados.Add(chamado);
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

            return chamados;
        }

            public void EncerrarChamado(Chamado chamado)
            {
                string SQL;
                SqlCommand comando;


                try
                {
                    conexao = new SqlConnection(caminho);

                    SQL = "UPDATE TB_CHAMADO SET DT_ENCERRAMENTO = '" + Convert.ToDateTime(chamado.dataEncerramento)+ "', CD_STATUS = '" + chamado.codstatus + "', DS_JUSTIFICATIVA = '" + chamado.justificativa + "', CD_TECNICO = '" + chamado.codtecnico + "' WHERE CD_CHAMADO = '" + chamado.codigo + "'";

                    comando = new SqlCommand(SQL, conexao);

                    conexao.Open();

                    comando.ExecuteNonQuery();

                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conexao.Close();
                }

            }
        

        /* public List<Pedido> MostrarTodosPedidos()
        {
            List<Pedido> Pedidos = new List<Pedido>();
            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");

                    SQL = "SELECT P.CD_PEDIDO, P.DT_PEDIDO, C.NM_CLIENTE, C.ENDERECO, C.NR_TELEFONE, P.CD_CLIENTE, P.DS_OBSERVACAO, P.NR_STATUS, P.VL_TOTAL FROM TB_PEDIDO P INNER JOIN TB_CLIENTE C ON P.CD_CLIENTE = C.CD_CLIENTE ORDER BY P.CD_PEDIDO ";


                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        Pedido pedido = new Pedido();



                        
                        pedido.pedido = Convert.ToInt32(dr["CD_PEDIDO"]);
                        pedido.datapedido = dr["DT_PEDIDO"].ToString();
                        pedido.cd_cliente = Convert.ToInt32(dr["CD_CLIENTE"]);
                        pedido.nm_cliente = dr["NM_CLIENTE"].ToString();
                        pedido.endereco = dr["ENDERECO"].ToString();
                        pedido.telefone = Convert.ToInt32(dr["NR_TELEFONE"]);
                        pedido.observacao = dr["DS_OBSERVACAO"].ToString();
                        pedido.status = dr["NR_STATUS"].ToString();
                        pedido.valortotal = Convert.ToDouble(dr["VL_TOTAL"]);


                        if (pedido.status == "1")
                        {
                            pedido.status = "ABERTO";

                        }
                        else if (pedido.status == "2")
                            pedido.status = "FECHADO";
                        else
                            pedido.status = "CANCELADO";

                        Pedidos.Add(pedido);

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

            return Pedidos;
        }

        public List<Pedido> MostrarPedidos(int codcliente)
        {
            List<Pedido> Pedidos = new List<Pedido>();
            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");
                    
                    SQL = "SELECT P.CD_PEDIDO, P.DT_PEDIDO, C.NM_CLIENTE, C.NR_TELEFONE, P.CD_CLIENTE, P.DS_OBSERVACAO, P.NR_STATUS, P.VL_TOTAL FROM TB_PEDIDO P INNER JOIN TB_CLIENTE C ON P.CD_CLIENTE = C.CD_CLIENTE WHERE P.CD_CLIENTE = '" + codcliente + "' ORDER BY P.CD_PEDIDO ";
                  

                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                        Pedido pedido = new Pedido();
                        

                                             
                        
                        pedido.pedido = Convert.ToInt32(dr["CD_PEDIDO"]);
                        pedido.datapedido = dr["DT_PEDIDO"].ToString();
                        pedido.cd_cliente = Convert.ToInt32(dr["CD_CLIENTE"]);
                        pedido.observacao = dr["DS_OBSERVACAO"].ToString();
                        pedido.status = dr["NR_STATUS"].ToString();
                        pedido.valortotal = Convert.ToDouble(dr["VL_TOTAL"]);

                        if (pedido.status == "1")
                        {
                            pedido.status = "ABERTO";

                        }
                        else if (pedido.status == "2")
                            pedido.status = "FECHADO";
                        else
                            pedido.status = "CANCELADO";

                        Pedidos.Add(pedido);
                                                                  
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

            return Pedidos;
        }

         public int IncluirPedido(Pedido pedido)
         {
             string SQL;
             SqlCommand comando;
            

             try
             {
                conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");


                 conexao.Open();


                SQL = "INSERT INTO TB_CHAMADO (DT_ABERTURA, DS_PROBLEMA, CD_FUNCIONARIO, CD_PROBLEMA, CD_STATUS) VALUES ('" + Convert.ToDateTime(pedido.datapedido) + "', '" + pedido.cd_cliente + "', '" + pedido.observacao + "','" + int.Parse(pedido.status) + "', '" + pedido.valortotal + "');" + "Select Scope_Identity()";

                comando = new SqlCommand(SQL, conexao);

                pedido.pedido = Convert.ToInt32(comando.ExecuteScalar());


            }
             catch (Exception)
             {
                 throw;
             }
             finally
             {
                 conexao.Close();
             }

            return pedido.pedido;
         }

        public double FinalizarPedido(int codpedido)
        {
            string SQL;
            SqlCommand comando;
            double valortotal = 0;

            try
            {
                conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");

                SQL = "UPDATE TB_PEDIDO SET VL_TOTAL = (SELECT SUM(PROD.VL_PRODUTO*ITEM.NR_QUANTIDADE) FROM TB_PRODUTO PROD INNER JOIN TB_ITEMPEDIDO ITEM ON PROD.CD_PRODUTO = ITEM.CD_PRODUTO WHERE ITEM.CD_PEDIDO = '"+ codpedido +"');" + "SELECT VL_TOTAL FROM TB_PEDIDO WHERE CD_PEDIDO = '"+codpedido+"'";

                comando = new SqlCommand(SQL, conexao);

                conexao.Open();

                SqlDataReader dr;

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    valortotal = Convert.ToDouble(dr["VL_TOTAL"]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
            return valortotal;
        }

        public void ExcluirPedido(int codigopedido)
        {
            string SQL;
            SqlCommand comando;

            try
            {
                conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");

                SQL = "UPDATE TB_PEDIDO SET NR_STATUS = 3 WHERE CD_PEDIDO = '" + codigopedido + "'";
                    

                comando = new SqlCommand(SQL, conexao);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }
        */


    }

}

