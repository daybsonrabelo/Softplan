using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxaJuros.Models;
using TaxaJuros.Services;

namespace TaxaJuros.Controllers
{
    [Route("api/[controller]")]
    public class TaxaController : ControllerBase
    {
        private ITaxaService _taxaService;

        public TaxaController(ITaxaService taxaService)
        {
            _taxaService = taxaService;
        }

        [HttpGet]
        [Route("taxaJuros")]
        public Taxa Get()
        {
            return _taxaService.GetTaxaJuros();
        }
    }
}
