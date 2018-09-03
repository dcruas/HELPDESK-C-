using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class FuncionarioBLL
    {
        private FuncionarioDAL funcionarioDAL;

        public FuncionarioBLL()
        {
           funcionarioDAL = new FuncionarioDAL();
        }

        public Funcionario ValidarLogin(int matricula, string senha)
        {

            return funcionarioDAL.ValidarLogin(matricula, senha);
        }

        public Funcionario EsqueciSenhaBLL(string cpf, string email)
        {
            return funcionarioDAL.EsqueciSenhaDAL(cpf, email);
        }

        public Funcionario ProcurarMatricula(int matricula)
        {

            return funcionarioDAL.ProcurarMatricula(matricula);
        }

      
         public List<Funcionario> ProcurarNome(string nome)
         {
             return funcionarioDAL.procurarNome(nome);
         }

        public int ultimoIdBLL()
        {

            return funcionarioDAL.ultimoIdDAL();
        }

        public void InserirFuncionario(Funcionario funcionario)
        {
            funcionarioDAL.InserirFuncionario(funcionario);
        }

        public void AtualizarFuncionario(Funcionario funcionario)
        {
            funcionarioDAL.AtualizarFuncionario(funcionario);
        }
        /*

       public int IncluirCliente(Funcionario cliente)
       {
           return funcionarioDAL.IncluirCliente(cliente);
       }

       public void AtualizarCliente(Funcionario cliente)
       {
           funcionarioDAL.AtualizarCliente(cliente);
       }

       public void ExcluirCliente(int codigo)
        {
           funcionarioDAL.ExcluirCliente(codigo);
        }
        */


    }
}
