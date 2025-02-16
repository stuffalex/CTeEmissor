using CTeEmissor.Base;

namespace CTeEmissor.Dominio.Model;

public class Aliquota : EntidadeBase<Aliquota>
{
    public string Estado { get; private set; }
    public decimal Porcentagem { get; private set; }

    public Aliquota(string estado, decimal porcentagem)
    {
        Estado = estado;
        Porcentagem = porcentagem;
    }

    public Aliquota() { }
}