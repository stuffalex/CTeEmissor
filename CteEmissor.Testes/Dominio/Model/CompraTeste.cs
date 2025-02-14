using CTeEmissor.Dominio.Model;
using CTeEmissor.Testes.Helper;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Model
{
    [TestFixture]
    public class CompraTeste
    {
        private string _nomeComprador;
        private Carga _carga;
        private Viagem _viagem;
        private decimal _valorDoFrete;
        private decimal _valorDoIcms;

        [SetUp]
        public void SetUp()
        {
            _nomeComprador = "Jessica Rabbit";
            _carga = new CargaBuilder().Default().Build();
            _viagem = new ViagemBuilder().Default().Build();
            _valorDoFrete = 150;
            _valorDoIcms = 150;
        }

        [Test]
        public void DeveCriarCompraComNomeComprador()
        {
            var compra = new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);

            Assert.That(compra.NomeComprador, Is.EqualTo(_nomeComprador));
        }

        [Test]
        public void DeveCriarCompraComCarga()
        {
            var compra = new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);

            Assert.That(compra.Carga, Is.EqualTo(_carga));
        }

        [Test]
        public void DeveCriarCompraComViagem()
        {
            var compra = new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);

            Assert.That(compra.Viagem, Is.EqualTo(_viagem));
        }

        [Test]
        public void DeveCriarCompraComValorDoFrete()
        {
            var compra = new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);

            Assert.That(compra.ValorDoFrete, Is.EqualTo(_valorDoFrete));
        }

        [Test]
        public void DeveCriarCompraComValorDoIcms()
        {
            var compra = new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);

            Assert.That(compra.ValorDoIcms, Is.EqualTo(_valorDoIcms));
        }
    }
}
