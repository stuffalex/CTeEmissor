using CTeEmissor.Dominio.Base;

namespace CTeEmissor.Dominio.Model;

public class Aliquota : EntidadeBase<Aliquota>
{
    public Aliquota(string estado, decimal porcentagem)
    {
        Estado = estado;
        Porcentagem = porcentagem;
    }
    public Aliquota()
    {
        
    }
    public string Estado { get; private set; }
    public decimal Porcentagem { get; private set; }
}