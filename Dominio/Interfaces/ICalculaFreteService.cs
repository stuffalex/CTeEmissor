using CTeEmissor.Dominio.Models;

namespace CTeEmissor.Dominio.Interfaces
{
    public interface ICalculaFreteService
    {
        public double CalculaFretePorPeso(Compra compra); //utilizar dto para nao vazar info de carga e viagem do dominio
    }
}
