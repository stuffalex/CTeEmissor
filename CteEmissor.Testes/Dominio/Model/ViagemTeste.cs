using CTeEmissor.Dominio.Model;
using CTeEmissor.Testes.Helper;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Model
{
    [TestFixture]
    public class ViagemTeste
    {
        private string _cepOrigem;
        private string _cepDestino;
        private int _distanciaOrigemDestino;
        private DateTime _inicioOperacao;
        private Aliquota _aliquota;
        private decimal _despesasAdicionais;
        private decimal _tarifaPorPeso;

        [SetUp]
        public void SetuUp()
        {
            _cepOrigem = "79012570";
            _cepDestino = "79570855";
            _distanciaOrigemDestino = 150;
            _despesasAdicionais = 200;
            _tarifaPorPeso = 3;
            _aliquota = new AliquotaBuilder().Default().Build();
        }

        [Test]
        public void DeveCriarUmaViagemComCepDeOrigemInformado()
        {
            var cepOrigem = "798989888";
            var viagem = new Viagem(cepOrigem, _cepDestino, _distanciaOrigemDestino,
               _despesasAdicionais, _tarifaPorPeso, _aliquota);

            Assert.That(cepOrigem, Is.EqualTo(viagem.CepOrigem));
        }
        [Test]
        public void DeveCriarUmaViagemComCepDeDestinoInformado()
        {
            var cepDestino = "79888545";
            var viagem = new Viagem(_cepOrigem, cepDestino, _distanciaOrigemDestino,
               _despesasAdicionais, _tarifaPorPeso, _aliquota);

            Assert.That(cepDestino, Is.EqualTo(viagem.CepDestino));
        }

        [Test]
        public void DeveCriarUmaViagemComDistanciaOrigemDestinoInformada()
        {
            var distanciaOrigemDestino = 120;
            var viagem = new Viagem(_cepOrigem, _cepDestino, distanciaOrigemDestino,
               _despesasAdicionais, _tarifaPorPeso, _aliquota);

            Assert.That(distanciaOrigemDestino, Is.EqualTo(viagem.DistanciaOrigemDestino));
        }

        [Test]
        public void DeveCriarUmaViagemComValorDeDespesasAdicionaisInformado()
        {
            var despesasAdicionais = 200;
            var viagem = new Viagem(_cepOrigem, _cepDestino, _distanciaOrigemDestino,
               despesasAdicionais, _tarifaPorPeso, _aliquota);

            Assert.That(despesasAdicionais, Is.EqualTo(viagem.DespesasAdicionais));
        }

        [Test]
        public void DeveCriarUmaViagemComValorDeTarifaPorPesoInformado()
        {
            var tarifaPorPeso = 100;
            var viagem = new Viagem(_cepOrigem, _cepDestino, _distanciaOrigemDestino,
               _despesasAdicionais, tarifaPorPeso, _aliquota);

            Assert.That(tarifaPorPeso, Is.EqualTo(viagem.TarifaPorPeso));
        }

        [Test]
        public void DeveCriarUmaViagemComValorDeAliquotaInformado()
        {
            var aliquota = new AliquotaBuilder().Default().Build();
            var viagem = new Viagem(_cepOrigem, _cepDestino, _distanciaOrigemDestino,
               _despesasAdicionais, _tarifaPorPeso, aliquota);

            Assert.That(aliquota.Estado, Is.EqualTo(viagem.Aliquota.Estado));
            Assert.That(aliquota.Porcentagem, Is.EqualTo(viagem.Aliquota.Porcentagem));
        }
    }
}
