using CTeEmissor.Dominio.Interfaces;

namespace CTeEmissor.Dominio.Services
{
    public class CalculaFreteService : ICalculaFreteService
    {
        public decimal CalculaFrete(decimal TarifaPorPeso, int PesoBrutoTotal, decimal DespesasAdicionais)
        {
            var total = (TarifaPorPeso * PesoBrutoTotal) + DespesasAdicionais;

            return Math.Round(total, 2); 
        }
    }
}
