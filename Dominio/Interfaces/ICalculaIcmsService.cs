using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Dominio.Interfaces
{
    public interface ICalculaIcmsService
    {
        public decimal CalculaIcms(Aliquota Aliquota, decimal ValorDoFrete);
    }
}
