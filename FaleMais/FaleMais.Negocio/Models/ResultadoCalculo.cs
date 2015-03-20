using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaleMais.Models;

namespace FaleMais.Negocio.Models
{
    public class ResultadoCalculo
    {
        public DDD Origem { get; set; }
        public DDD Destino { get; set; }
        public PLANO Plano { get; set; }
        public DetalheResultado Detalhe { get; set; }

        public ResultadoCalculo()
        {
            this.Detalhe = new DetalheResultado();
        }
        
    }

    public class DetalheResultado
    {
        public bool Sucesso { get; set; }
        public decimal Tempo { get; set; }
        public decimal ValorComPlano { get; set; }
        public decimal ValorSemPlano { get; set; }
    }
}
