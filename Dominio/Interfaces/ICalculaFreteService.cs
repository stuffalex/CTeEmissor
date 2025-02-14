using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Dominio.Interfaces
{
    public interface ICalculaFreteService
    {
       public decimal CalculaFrete(decimal TarifaPorPeso, int PesoBrutoTotal, decimal DespesasAdicionais);//utilizar dto para nao vazar info de carga e viagem do dominio
    }
}
