
using CTeEmissor.Base;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services.Interfaces;

namespace CTeEmissor.Dominio.Services;

public class CalculaIcmsService : ICalculaIcmsService
{
    public decimal CalculaIcms(DadosCalculoIcmsDto dadosIcmsDto)
    {
        var aliquota = dadosIcmsDto.Aliquota;
        Validacoes(aliquota);

        var porcentagemDoCalculo = (100 - aliquota.Porcentagem) / 100m;
        var baseDoCalculo = dadosIcmsDto.ValorDoFrete / porcentagemDoCalculo;
        var valorIcms = baseDoCalculo * (aliquota.Porcentagem / 100m);
        return Math.Round(valorIcms, 2);
    }

    private static void Validacoes(Aliquota? aliquota)
    {
        ValidacaoDeDominio.Quando(aliquota == null, "Alíquota não pode ser vazia.");
        ValidacaoDeDominio.Quando(aliquota?.Porcentagem >= 100, "A alíquota deve ser menor que 100%.");
    }
}
