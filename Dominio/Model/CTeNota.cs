using CTeEmissor.Base;

namespace CTeEmissor.Dominio.Model;

public class CTeNota : EntidadeBase<CTeNota>
{
    public CTeNota(Compra compra)
    {
        ValidacaoDeDominio.Quando(compra == null, "Compra não pode ser vazia");
        CompraId = compra.Id;
        ValorFrete = compra.ValorDoFrete;
        ValorIcms = compra.ValorDoIcms;
        ValorTotal = ValorFrete + ValorIcms;
    }

    private CTeNota() { }

    public Guid CompraId { get; private set; }
    public decimal ValorTotal { get; private set; }
    public decimal ValorFrete { get; private set; }
    public decimal ValorIcms { get; private set; }
}