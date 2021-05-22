using CalculaJuros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Service
{
    public interface ICalculoService
    {
        Calculo CalcularTaxaJuros(decimal valorInicial, int tempo);
        //decimal RecuperarTaxaJuros();
    }
}
