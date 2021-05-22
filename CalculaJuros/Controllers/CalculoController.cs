using CalculaJuros.Models;
using CalculaJuros.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculaJuros.Controllers
{
    [Route("api/[controller]")]
    public class CalculoController : Controller
    {
        private ICalculoService _calculoService;

        public CalculoController(ICalculoService calculoService)
        {
            _calculoService = calculoService;
        }

        [HttpGet]
        [Route("calculaJuros")]
        public Calculo Get([FromQuery] decimal valorInicial, [FromQuery] int tempo)
        {
            return _calculoService.CalcularTaxaJuros(valorInicial, tempo);
        }

        [HttpGet]
        [Route("showmethecode")]
        public string GetGitHubProject()
        {
            return "https://github.com/daybsonrabelo/Softplan";
        }
    }
}
