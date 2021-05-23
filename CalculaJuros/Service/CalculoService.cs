using CalculaJuros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculaJuros.Service
{
    public class CalculoService : ICalculoService
    {

        private const double VAR_FIXO = 1.0;

        public Calculo CalcularTaxaJuros(decimal _valorInicial, int _tempo)
        {
            return CalcularTaxaJuros(_valorInicial, _tempo, RecuperarTaxaJuros());
        }

        public Calculo CalcularTaxaJuros(decimal _valorInicial, int _tempo, decimal _valorJuros)
        {
            Calculo calculo = new Calculo();

            calculo.ValorInicial = _valorInicial;
            calculo.Tempo = _tempo;
            calculo.ValorJuros = _valorJuros;
            calculo.ValorFinal = Math.Truncate(_valorInicial * (decimal)Math.Pow(VAR_FIXO + (double)_valorJuros, _tempo) * 100) / 100;

            return calculo;
        }

        private decimal RecuperarTaxaJuros()
        {
            return GetTaxaDeApi().Result.TaxaJuros;
        }

        private static async Task<ExternalTaxa> GetTaxaDeApi()
        {
            ExternalTaxa taxa = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(Environment.GetEnvironmentVariable("Base_Url"));
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/Taxa/taxaJuros");
                if (response.IsSuccessStatusCode)
                {
                    taxa = await JsonSerializer.DeserializeAsync<ExternalTaxa>(await response.Content.ReadAsStreamAsync());
                }

            }

            return taxa;
        }
    }
}
