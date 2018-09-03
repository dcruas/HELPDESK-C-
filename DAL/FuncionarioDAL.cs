using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class FuncionarioDAL
    {
        SqlConnection conexao;
        // Linha que lê o caminho do banco de dados //
        string caminho = @"" + System.IO.File.ReadAllText("caminho.txt");


        public Funcionario ValidarLogin(int matricula, string senha)
        {
            Funcionario funcionario = new Funcionario();

            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);


                    SQL = "SELECT CD_FUNCIONARIO, NM_FUNCIONARIO, CD_ACESSO, NR_SITUACAO FROM TB_FUNCIONARIO WHERE NR_MATRICULA = '" + matricula + "' AND NM_SENHA = '" + senha + "'";



                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {




                        funcionario.codigo = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                       funcionario.nome = dr["NM_FUNCIONARIO"].ToString();
                        funcionario.codacesso = Convert.ToInt32(dr["CD_ACESSO"]);
                        funcionario.situacao = Convert.ToInt32(dr["NR_SITUACAO"]);



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

            return funcionario;
        }

        public Funcionario EsqueciSenhaDAL(string cpf, string email)
        {
            Funcionario funcionario = new Funcionario();

            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);


                    SQL = "SELECT NM_FUNCIONARIO, NM_SENHA FROM TB_FUNCIONARIO WHERE NM_EMAIL = '" + email + "' AND NR_CPF = '" + cpf + "'";



                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {




                        funcionario.senha = (dr["NM_SENHA"]).ToString() ;
                        funcionario.nome = dr["NM_FUNCIONARIO"].ToString();
                      



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

            return funcionario;
        }
       

        public Funcionario ProcurarMatricula(int matricula)
        {
            Funcionario funcionario =  new Funcionario();

            string SQL;
            try
            {
                try
                {
                    conexao = new SqlConnection(caminho);

                  
                    SQL = "SELECT CD_FUNCIONARIO, NM_FUNCIONARIO, NR_ANDAR,NR_RAMAL, NR_CELULAR,NM_EMAIL, NR_SALA, DT_ADMISSAO, NR_MATRICULA, NR_CPF, CD_ACESSO, NR_SITUACAO FROM TB_FUNCIONARIO WHERE NR_MATRICULA = '" + matricula + "' ORDER BY CD_FUNCIONARIO";
                   

                  
                    SqlCommand comando = new SqlCommand(SQL, conexao);

                    SqlDataReader dr;

                    conexao.Open();

                    dr = comando.ExecuteReader();

                    while (dr.Read())
                    {
                                                               
                       funcionario.codigo = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                       funcionario.nome = dr["NM_FUNCIONARIO"].ToString();
                       funcionario.andar = Convert.ToInt32(dr["NR_ANDAR"]);
                       funcionario.ramal = Convert.ToInt32(dr["NR_RAMAL"]);
                       funcionario.celular = Convert.ToInt32(dr["NR_CELULAR"]);
                       funcionario.email = dr["NM_EMAIL"].ToString();
                       funcionario.sala = Convert.ToInt32(dr["NR_SALA"]);
                       funcionario.dataAdmissao = dr["DT_ADMISSAO"].ToString();
                       funcionario.matricula = Convert.ToInt32(dr["NR_MATRICULA"]);
                       funcionario.cpf = dr["NR_CPF"].ToString();
                       funcionario.codacesso = Convert.ToInt32(dr["CD_ACESSO"]);
                       funcionario.situacao = Convert.ToInt32(dr["NR_SITUACAO"]);
                      
                                    
                                                                         
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

            return funcionario;
        }
        
       public List<Funcionario> procurarNome(string nome)
       {
           List<Funcionario> funcionarios = new List<Funcionario>();

           string SQL;

           try
           {
               try
               {

                   conexao = new SqlConnection(caminho);

                   SQL = "SELECT CD_FUNCIONARIO, NM_FUNCIONARIO, NR_ANDAR,NR_RAMAL, NR_CELULAR,NM_EMAIL, NR_SALA, DT_ADMISSAO, NR_MATRICULA, NR_CPF, CD_ACESSO, NR_SITUACAO FROM TB_FUNCIONARIO WHERE NM_FUNCIONARIO LIKE '" + nome + "'  ORDER BY CD_FUNCIONARIO";

                   SqlCommand comando = new SqlCommand(SQL, conexao);

                   SqlDataReader dr;

                   conexao.Open();

                   dr = comando.ExecuteReader();

                   while (dr.Read())
                   {
                       Funcionario funcionario = new Funcionario();



                       funcionario.codigo = Convert.ToInt32(dr["CD_FUNCIONARIO"]);
                       funcionario.nome = dr["NM_FUNCIONARIO"].ToString();
                       funcionario.andar = Convert.ToInt32(dr["NR_ANDAR"]);
                       funcionario.ramal = Convert.ToInt32(dr["NR_RAMAL"]);
                       funcionario.celular = Convert.ToInt32(dr["NR_CELULAR"]);
                       funcionario.email = dr["NM_EMAIL"].ToString();
                       funcionario.sala = Convert.ToInt32(dr["NR_SALA"]);
                       funcionario.dataAdmissao = dr["DT_ADMISSAO"].ToString();
                       funcionario.matricula = Convert.ToInt32(dr["NR_MATRICULA"]);
                       funcionario.cpf = dr["NR_CPF"].ToString();
                       funcionario.codacesso = Convert.ToInt32(dr["CD_ACESSO"]);
                       funcionario.situacao = Convert.ToInt32(dr["NR_SITUACAO"]);

                       funcionarios.Add(funcionario);

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

           return funcionarios;
       }

        public int ultimoIdDAL()
        {
            int id;

            string SQL;

            try
            {
                try
                {

                    conexao = new SqlConnection(caminho);

                    SQL = "SELECT IDENT_CURRENT('TB_FUNCIONARIO')";

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
       

        public void InserirFuncionario(Funcionario funcionario)
         {
             string SQL;
             SqlCommand comando;

             try
             {
                 conexao = new SqlConnection(caminho);


                 conexao.Open();


                 SQL = "INSERT TB_FUNCIONARIO (NM_FUNCIONARIO, NR_ANDAR,NR_RAMAL,NR_CELULAR, NM_EMAIL, NR_SALA,DT_ADMISSAO,NR_MATRICULA, NR_CPF, CD_ACESSO, NR_SITUACAO,NM_SENHA) VALUES ('" + funcionario.nome + "', '" + funcionario.andar + "', '" + funcionario.ramal + "','" + funcionario.celular + "', '" + funcionario.email + "', '" + funcionario.sala + "', '" + funcionario.dataAdmissao + "', '" + funcionario.matricula+ "','" + funcionario.cpf + "','" + funcionario.codacesso + "','" + funcionario.situacao+ "','" + funcionario.senha + "')";



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
       
        public void AtualizarFuncionario(Funcionario funcionario)
        {
            string SQL;
            SqlCommand comando;

            try
            {
                conexao = new SqlConnection(caminho);

                SQL = "UPDATE TB_FUNCIONARIO SET NM_FUNCIONARIO ='" + funcionario.nome + "',NR_ANDAR = '" + funcionario.andar + "', NR_RAMAL = '" + funcionario.ramal + "', NR_CELULAR= '" + funcionario.celular + "', NR_SALA = '" + funcionario.sala + "', DT_ADMISSAO = '" + funcionario.dataAdmissao + "', NR_CPF = '" + funcionario.cpf + "', CD_ACESSO = '" + funcionario.codacesso + "', NR_SITUACAO = '" + funcionario.situacao + "' WHERE NR_MATRICULA = '" + funcionario.matricula + "'";

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
        /*

        public void ExcluirCliente(int codigo)
      {
          string SQL;
          SqlCommand comando;

          try
          {
              conexao = new SqlConnection(@"Data Source = DESKTOP-UTR2P7O\SQLEXPRESS; Initial Catalog = DB_PIZZARIA; Integrated Security = True");

              SQL = "DELETE TB_CLIENTE WHERE CD_CLIENTE = " + codigo.ToString();

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

