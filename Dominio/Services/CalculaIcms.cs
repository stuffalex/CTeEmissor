using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Models;

namespace CTeEmissor.Dominio.Services
{
    public class CalculaIcms : ICalculaICMS
    {
        private double CalculaIcms(Compra compra)
        {
            var porcentagem = (100 - aliquota) / 100;
            var baseDoCalculo = ValorFrete / porcentagem;
            return baseDoCalculo * aliquota;
        }
    }
}
