using CTeEmissor.Dominio.Base;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Testes.Helper;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Model
{
    [TestFixture]
    public class CTeNotaTeste
    {
        private Compra _compra;
        private Carga _carga;
        private Viagem _viagem;
        private decimal _valorDoFrete;
        private decimal _valorDoIcms;

        [SetUp]
        public void SetUp()
        {
            _carga = new CargaBuilder().Default().Build();
            _viagem = new ViagemBuilder().Default().Build();
            _compra = new CompraBuilder().ComCarga(_carga).ComViagem(_viagem).ComValorDeFrete(_valorDoFrete).ComValorDoIcms(_valorDoIcms).Build();
            _valorDoFrete = 150;
            _valorDoIcms = 150;
        }

        [Test]
        public void DeveCriarCteNotaComCompra()
        {
            var cte = new CTeNota(_compra);

            Assert.That(cte.Compra, Is.EqualTo(_compra));
        }

        [Test]
        public void NaoDeveCriarCteNotaSemCompra()
        {
            Compra compra = null;

            var act = Assert.Throws<ValidacaoDeDominio>(() => new CTeNota(compra));

            Assert.That(act.Message, Is.EqualTo("Compra não pode ser vazia"));
        }

        [Test]
        public void DeveCriarCteNotaComValorDeIcmsDaCompra()
        {
            var cte = new CTeNota(_compra);

            Assert.That(cte.ValorIcms, Is.EqualTo(_compra.ValorDoIcms));
        }

        [Test]
        public void DeveCriarCteNotaComValorDeFreteDaCompra()
        {
            var cte = new CTeNota(_compra);

            Assert.That(cte.ValorFrete, Is.EqualTo(_compra.ValorDoFrete));
        }

        [Test]
        public void DeveCriarCteNotaComValorTotal()
        {
            var cte = new CTeNota(_compra);
            var valorTotalNota = _compra.ValorDoFrete + _compra.ValorDoIcms;

            Assert.That(cte.ValorTotal, Is.EqualTo(valorTotalNota));
        }
    }
}
