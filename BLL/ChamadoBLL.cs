using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChamadoBLL
    {
        private ChamadoDAL chamadoDAL;

        public ChamadoBLL()
        {
            chamadoDAL = new ChamadoDAL();
        }

       public List<Chamado> ProcurarMatricula(int codigo)
        {
            return chamadoDAL.ProcurarMatricula(codigo);
            
        }

        public Chamado ProcurarProtocolo(int codigo)
        {
            return chamadoDAL.ProcurarProtocolo(codigo);
        }

        public void IncluirChamado(Chamado chamado)
        {
            chamadoDAL.IncluirChamado(chamado);
        }

        public void AtualizarChamado(Chamado chamado)
        {
            chamadoDAL.AtualizarChamado(chamado);
        }

        public int ultimoId()
        {

            return chamadoDAL.ultimoId();
        }

        public List<Chamado> FiltroChamados(Chamado ticket)
        {

            return chamadoDAL.FiltroChamados(ticket);
        }

        public void EncerrarChamado(Chamado chamado)
        {
            chamadoDAL.EncerrarChamado(chamado);
        }

        /* public ChamadoBLL()
        {
            pedidoDAL = new ChamadoDAL();
        }

        public List<Pedido> MostrarTodosPedidos()
        {
            return pedidoDAL.MostrarTodosPedidos();
        }

        public List<Pedido> MostrarPedidos(int codcliente)
        {
            return  pedidoDAL.MostrarPedidos(codcliente);
        }
       
        public int IncluirPedido(Pedido pedido)
        {   
            
            return pedidoDAL.IncluirPedido(pedido);
        }

        public double FinalizarPedido(int codpedido)
        {

            return pedidoDAL.FinalizarPedido(codpedido);
        }

        public void ExcluirPedido(int codigopedido)
        {
          pedidoDAL.ExcluirPedido(codigopedido);
        }
      
              */

    }
}
