using CTeEmissor.Base;

namespace CTeEmissor.Dominio.Model;

public class Compra : EntidadeBase<Compra>
{
    public string NomeComprador { get; private set; }
    public Carga Carga { get; private set; }
    public Viagem Viagem { get; private set; }
    public decimal ValorDoFrete { get; private set; }
    public decimal ValorDoIcms  { get; private set; }

    public Compra(string nomeComprador, Carga carga, Viagem viagem, decimal valorDoFrete, decimal valorDoIcms)
    {
        NomeComprador = nomeComprador;
        Viagem = viagem;
        Carga = carga;
        ValorDoFrete = valorDoFrete;
        ValorDoIcms = valorDoIcms;
    }
    private Compra() { }
}
