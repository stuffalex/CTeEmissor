using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services.Interfaces;
using CTeEmissor.Repositorio;

namespace CTeEmissor.Dominio.Services
{
    public class CompraService : ICompraService
    {
        private readonly ICalculaFreteService _calculaFreteService;
        private readonly ICalculaIcmsService _calculaIcmsService;
        private readonly IAliquotaRepositorio _repositorio;

        public CompraService(ICalculaFreteService calculaFreteService,
            ICalculaIcmsService calculaIcmsService, IAliquotaRepositorio repositorio)
        {
            _calculaFreteService = calculaFreteService;
            _calculaIcmsService = calculaIcmsService;
            _repositorio = repositorio;
        }

        public Compra Gerar(CompraDto compraDto, string estadoOrigem)
        {
            Aliquota? aliquota = ObterAliquota(estadoOrigem);
            var aliquotaDoEstado = new Aliquota(aliquota.Estado, aliquota.Porcentagem);

            var carga = new Carga(compraDto.QuantidadeDoProduto, compraDto.PesoUnitarioProduto, compraDto.VolumeTotalDosProdutos);
            var viagem = new Viagem(compraDto.CepOrigem, compraDto.CepDestino, compraDto.DistanciaOrigemDestino, compraDto.DespesasAdicionais,
                compraDto.TarifaPorPeso, aliquotaDoEstado);

            decimal valorDoFrete = CalcularFrete(compraDto);
            decimal valorIcms = CalcularIcms(aliquotaDoEstado, valorDoFrete);

            var compra = new Compra(compraDto.NomeComprador, carga, viagem, valorDoFrete, valorIcms);
            return compra;
        }

        private decimal CalcularIcms(Aliquota aliquotaDoEstado, decimal valorDoFrete)
        {
            var dadosCalculoIcms = new DadosCalculoIcmsDto { Aliquota = aliquotaDoEstado, ValorDoFrete = valorDoFrete };
            var valorIcms = _calculaIcmsService.CalculaIcms(dadosCalculoIcms);
            return valorIcms;
        }

        private decimal CalcularFrete(CompraDto compraDto)
        {
            var pesoTotal = compraDto.PesoUnitarioProduto * compraDto.QuantidadeDoProduto;
            var dadosFrete = new DadosCalculoFreteDto { TarifaPorPeso = compraDto.TarifaPorPeso, PesoBrutoTotal = pesoTotal, DespesasAdicionais = compraDto.DespesasAdicionais };
            var valorDoFrete = _calculaFreteService.CalculaFrete(dadosFrete);
            return valorDoFrete;
        }

        private Aliquota? ObterAliquota(string estadoOrigem)
        {
            var aliquota = _repositorio.ObterAliquotaPorEstado(estadoOrigem);

            return aliquota;
        }
    }
}
