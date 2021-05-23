using CalculaJuros.Service;
using NUnit.Framework;
using System;
using TaxaJuros.Services;

namespace Testes
{
    public class Tests
    {
        TaxaService taxaService;
        CalculoService calculoService;

        [SetUp]
        public void Setup()
        {
            taxaService = new();
            calculoService = new();
        }

        [Test]
        public void TestTaxaJurosZeroVirgulaZeroUm()
        {
            decimal expected = 0.01M;
            Environment.SetEnvironmentVariable("Valor_Taxa", "0,01");
            decimal taxa = taxaService.GetTaxaJuros().TaxaJuros;

            Assert.AreEqual(expected, taxa);
        }

        [Test]
        public void TestCalculaJuros1()
        {
            decimal expected = 105.1M;
            decimal calculado = calculoService.CalcularTaxaJuros(100M, 5, 0.01m).ValorFinal;

            Assert.AreEqual(expected, calculado);
        }

        [Test]
        public void TestCalculaJuros2()
        {
            decimal expected = 130.56M;
            decimal calculado = calculoService.CalcularTaxaJuros(123M, 6, 0.01m).ValorFinal;

            Assert.AreEqual(expected, calculado);
        }
    }
}