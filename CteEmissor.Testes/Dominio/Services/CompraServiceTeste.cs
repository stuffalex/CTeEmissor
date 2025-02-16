using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services;
using CTeEmissor.Dominio.Services.Interfaces;
using CTeEmissor.Repositorio;
using CTeEmissor.Testes.Helper;
using Moq;
using NUnit.Framework;

namespace CTeEmissor.Testes.Dominio.Services
{
    [TestFixture]
    public class CompraServiceTeste
    {
        private CompraDto _dadosDeEntradaDaCompra;
        private string _estado;
        private ICompraService _compraService;
        private Mock<IAliquotaRepositorio> _aliquotaRepositorioMock;
        private Mock<ICalculaFreteService> _serviceFreteMock;
        private Mock<ICalculaIcmsService> _serviceIcmsMock;

        [SetUp]
        public void Setup()
        {
            _dadosDeEntradaDaCompra = new CompraDto(
                NomeComprador: "John Dutton",
                QuantidadeDoProduto: 3,
                PesoUnitarioProduto: 3,
                CepDestino: "79012580",
                CepOrigem: "79012570",
                DespesasAdicionais: 100,
                DistanciaOrigemDestino: 15,
                TarifaPorPeso: 3,
                VolumeTotalDosProdutos: 3
            );
            _estado = "PB";
            _aliquotaRepositorioMock = new Mock<IAliquotaRepositorio>();
            _serviceFreteMock = new Mock<ICalculaFreteService>();
            _serviceIcmsMock = new Mock<ICalculaIcmsService>();
            _compraService = new CompraService(_serviceFreteMock.Object, _serviceIcmsMock.Object, _aliquotaRepositorioMock.Object);
            var aliquota = new AliquotaBuilder().Default().ComEstado(_estado).Build();

            _aliquotaRepositorioMock.Setup(a => a.ObterAliquotaPorEstado(It.IsAny<string>())).Returns(aliquota);
        }

        [Test]
        public void DeveConseguirObterAliquotaDoEstadoPeloRepositorio()
        {
            _compraService.Gerar(_dadosDeEntradaDaCompra, _estado);

            _aliquotaRepositorioMock.Verify(a => a.ObterAliquotaPorEstado(_estado), Times.Once);
        }

        [Test]
        public void DeveGerarUmaCompra()
        {
            var compra = _compraService.Gerar(_dadosDeEntradaDaCompra, _estado);

            Assert.That(compra, Is.TypeOf<Compra>());
            Assert.That(compra.Id, Is.Not.Null);
        }

        [Test]
        public void DeveCalcularOValorDoFrete()
        {
            var compra = _compraService.Gerar(_dadosDeEntradaDaCompra, _estado);

            _serviceFreteMock.Verify(s => s.CalculaFrete(It.IsAny<DadosCalculoFreteDto>()), Times.Once);
        }

        [Test]
        public void DeveCalcularOValorDoIcms()
        {
            var compra = _compraService.Gerar(_dadosDeEntradaDaCompra, _estado);

            _serviceIcmsMock.Verify(s => s.CalculaIcms(It.IsAny<DadosCalculoIcmsDto>()), Times.Once);
        }
    }
}
