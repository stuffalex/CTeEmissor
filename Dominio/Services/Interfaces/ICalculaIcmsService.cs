using CTeEmissor.Dominio.Model.Dto;

namespace CTeEmissor.Dominio.Services.Interfaces
{
    public interface ICalculaIcmsService
    {
        public decimal CalculaIcms(DadosCalculoIcmsDto dadosIcmsDto);
    }
}
