using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Models
{
    public class Calculo
    {
        public decimal ValorInicial { get; set; }
        public decimal ValorJuros { get; set; }
        public int Tempo { get; set; }
        public decimal ValorFinal { get; set; }
    }
}
