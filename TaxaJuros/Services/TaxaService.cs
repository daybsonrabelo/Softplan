using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJuros.Models;

namespace TaxaJuros.Services
{
    public class TaxaService : ITaxaService
    {
        public Taxa GetTaxaJuros()
        {
            decimal taxa = decimal.Parse(Environment.GetEnvironmentVariable("Valor_Taxa"));

            Taxa t = new Taxa();
            t.TaxaJuros = taxa;

            return t;
        }
    }
}
