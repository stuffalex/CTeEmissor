using CTeEmissor.Dominio.Model.Dto;

namespace CTeEmissor.Dominio.Services.Interfaces
{
    public interface ICalculaFreteService
    {
        public decimal CalculaFrete(DadosCalculoFreteDto dadosCalculoFrete);
    }
}
