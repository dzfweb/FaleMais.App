using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaleMais.Negocio.Models
{
    public class PedidoCalculo
    {
        public int PlanoID { get; set; }
        public decimal Tempo { get; set; }
        public int Origem { get; set; }
        public int Destino { get; set; }
    }
}
