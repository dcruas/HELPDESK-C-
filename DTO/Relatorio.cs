using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Relatorio
    {
        public int pendente { get; set; }
        public int atrasados { get; set; }
        public int encatraso { get; set; }
        public int encerrados { get; set; }
        public float pctatendido { get; set; }
        public float pctnaoatendido { get; set; }
        public float pctatendidoforadoprazo { get; set; }
        public int avaliacao { get; set; }
        public int tiporelatorio { get; set; }
        public DateTime datahoje { get; set; }
    }
}
