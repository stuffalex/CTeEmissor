using CTeEmissor.Base;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services;
using CTeEmissor.Dominio.Services.Interfaces;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Services
{
    [TestFixture]
    public class CalculaFreteServiceTeste
    {
        private DadosCalculoFreteDto _dadosDto;
        private ICalculaFreteService _calculaFreteService;

        [SetUp]
        public void SetUp()
        {
            _dadosDto = new DadosCalculoFreteDto
            {
                DespesasAdicionais = 100,
                PesoBrutoTotal = 5,
                TarifaPorPeso = 20
            };
            _calculaFreteService = new CalculaFreteService();
        }

        [Test]
        public void DeveCalcularValorDoFrete()
        {
            var valorAtual = (_dadosDto.PesoBrutoTotal * _dadosDto.TarifaPorPeso) + _dadosDto.DespesasAdicionais;

            var valorEsperado = _calculaFreteService.CalculaFrete(_dadosDto);

            Assert.That(valorAtual, Is.EqualTo(valorEsperado));
        }

        [Test]
        public void NaoDeveCalcularQuandoDtoForNulo()
        {
            DadosCalculoFreteDto dadosDto = null;

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaFreteService.CalculaFrete(dadosDto));

            Assert.That(act.Message, Is.EqualTo("Dados para o cálculo não devem ser vazios."));
        }

        [Test]
        public void NaoDeveCalcularQuandoDespesasAdicionaisForMenorQueZero()
        {
            var dadosDto = new DadosCalculoFreteDto
            {
                DespesasAdicionais = -5,
                PesoBrutoTotal = 12,
                TarifaPorPeso = 3
            };

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaFreteService.CalculaFrete(dadosDto));

            Assert.That(act.Message, Is.EqualTo("DespesasAdicionais não devem ser menor que zero."));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void NaoDeveCalcularQuandoPesoBrutoTotalForMenorOuIgualAZero(int pesoBrutoTotal)
        {
            var dadosDto = new DadosCalculoFreteDto
            {
                DespesasAdicionais = 0,
                PesoBrutoTotal = pesoBrutoTotal,
                TarifaPorPeso = 3
            };

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaFreteService.CalculaFrete(dadosDto));

            Assert.That(act.Message, Is.EqualTo("PesoBrutoTotal não deve ser menor ou igual a zero."));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void NaoDeveCalcularQuandoTarifaPorPesoForMenorOuIgualAZero(decimal tarifaPorPeso)
        {
            var dadosDto = new DadosCalculoFreteDto
            {
                DespesasAdicionais = 0,
                PesoBrutoTotal = 15,
                TarifaPorPeso = tarifaPorPeso
            };

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaFreteService.CalculaFrete(dadosDto));

            Assert.That(act.Message, Is.EqualTo("TarifaPorPeso não deve ser menor ou igual a zero."));
        }
    }
}