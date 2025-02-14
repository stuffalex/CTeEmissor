using CTeEmissor.Dominio.Model;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Model
{
    [TestFixture]
    public class CargaTeste
    {
        private int _quantidade;
        private int _pesoUnitario;
        private int _pesoBrutoTotal;
        private int _volume;

        [SetUp]
        public void SetUp()
        {
            _quantidade = 3;
            _pesoUnitario = 12;
            _pesoBrutoTotal = _quantidade * _pesoUnitario;
            _volume = 6;
        }

        [Test]
        public void DeveCriarUmaCargaComQuantidade()
        {
            var carga = new Carga(_quantidade, _pesoUnitario, _volume);

            Assert.That(carga.Quantidade, Is.EqualTo(_quantidade));
        }

        [Test]
        public void DeveCriarUmaCargaComPeso()
        {
            var carga = new Carga(_quantidade, _pesoUnitario, _volume);

            Assert.That(carga.PesoUnitario, Is.EqualTo(_pesoUnitario));
        }

        [Test]
        public void DeveCriarUmaCargaComVolume()
        {
            var carga = new Carga(_quantidade, _pesoUnitario, _volume);

            Assert.That(carga.Volume, Is.EqualTo(_volume));
        }

        [Test]
        public void DeveCriarUmaCargaComPesoBrutoTotal()
        {

            var carga = new Carga(_quantidade, _pesoUnitario, _volume);

            Assert.That(carga.PesoBrutoTotal, Is.EqualTo(_pesoBrutoTotal));
        }

    }
}
