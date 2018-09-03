using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Chamado
    {
        public int codigo { get; set; }
        public int codtecnico { get; set; }
        public string dataAbertura { get; set; }
        public string justificativa { get; set; }
        public string descricao { get; set; }
        public string dataEncerramento { get; set; }
        public int codfuncionario { get; set; }
        public int codproblema { get; set; }
        public int codstatus { get; set; }
        public int codavaliacao { get; set; }

      
    }
}
