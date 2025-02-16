using CTeEmissor.Base;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services;
using CTeEmissor.Dominio.Services.Interfaces;
using CTeEmissor.Testes.Helper;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Services
{
    [TestFixture]
    public class CalculaIcmsServiceTeste
    {
        private DadosCalculoIcmsDto _dadosDto;
        private ICalculaIcmsService _calculaIcmsService;

        [SetUp]
        public void SetUp()
        {
            _dadosDto = new DadosCalculoIcmsDto
            {
                Aliquota = new AliquotaBuilder().Default().Build(),
                ValorDoFrete = 150
            };
            _calculaIcmsService = new CalculaIcmsService();
        }

        [Test]
        public void DeveCalcularIcms()
        {
            var porcentagemDoCalculo = (100 - _dadosDto.Aliquota.Porcentagem) / 100m;
            var baseDoCalculo = _dadosDto.ValorDoFrete / porcentagemDoCalculo;
            var valorIcms = baseDoCalculo * (_dadosDto.Aliquota.Porcentagem / 100m);
            var valorEsperado = Math.Round(valorIcms, 2);

            var valorAtual = _calculaIcmsService.CalculaIcms(_dadosDto);

            Assert.That(valorAtual, Is.EqualTo(valorEsperado));
        }

        [TestCase(100)]
        [TestCase(101)]
        [TestCase(100.5)]
        public void NaoDeveCalcularIcmsSePorcentagemDaAliquotaForIgualOuMaiorQue100(decimal porcentagem)
        {
            _dadosDto = new DadosCalculoIcmsDto
            {
                Aliquota = new AliquotaBuilder().ComEstado("MS").ComPorcentagem(porcentagem).Build(),
                ValorDoFrete = 150
            };

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaIcmsService.CalculaIcms(_dadosDto));

            Assert.That(act.Message, Is.EqualTo("A alíquota deve ser menor que 100%."));
        }

        [Test]
        public void NaoDeveCalcularIcmsSeAliquotaForNula()
        {
            _dadosDto = new DadosCalculoIcmsDto
            {
                Aliquota = null,
                ValorDoFrete = 150
            };

            var act = Assert.Throws<ValidacaoDeDominio>(() => _calculaIcmsService.CalculaIcms(_dadosDto));

            Assert.That(act.Message, Is.EqualTo("Alíquota não pode ser vazia."));
        }
    }
}
