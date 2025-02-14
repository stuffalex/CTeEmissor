
using CTeEmissor.Dominio.Base;
using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Dominio.Services;

public class CalculaIcmsService : ICalculaIcmsService
{
    public decimal CalculaIcms(Aliquota aliquota, decimal valorDoFrete)
    {
        ValidacaoDeDominio.Quando(aliquota == null, "Aliquota não pode ser vazia");
        ValidacaoDeDominio.Quando(aliquota?.Porcentagem > 100, "A alíquota deve ser menor que 100%.");

        var porcentagem = (100 - aliquota.Porcentagem) / 100m;
        var baseDoCalculo = valorDoFrete / porcentagem;
        var valorIcms = baseDoCalculo * (aliquota.Porcentagem / 100m);
        return Math.Round(valorIcms, 2);
    }
}
