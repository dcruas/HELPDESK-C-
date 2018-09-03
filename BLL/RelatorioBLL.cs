using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class RelatorioBLL
    {
        private RelatorioDAL relatorioDAL;

        public RelatorioBLL()
        {
           relatorioDAL = new RelatorioDAL();
        }

        public List<Relatorio> GerarRelatorio(Relatorio relatorio, string datainicial, string datafinal)
        {
            return relatorioDAL.GerarRelatorio(relatorio, datainicial, datafinal);
        }
    }
}
