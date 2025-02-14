namespace CTeEmissor.Dominio.Models;

public class Aliquota
{
    public Aliquota(string estado, decimal porcentagem)
    {
        Estado = estado;
        Porcentagem = porcentagem;
    }
    public string Estado { get; private set; }
    public decimal Porcentagem { get; private set; }
}