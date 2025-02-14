using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Testes.Helper;
public class CompraBuilder
{
    private string _nomeComprador;
    private Carga _carga;
    private Viagem _viagem;
    private decimal _valorDoFrete;
    private decimal _valorDoIcms;

    public CompraBuilder Default()
    {
        _nomeComprador = "Jessica Rabbit";
        _carga = new CargaBuilder().Default().Build();
        _viagem = new ViagemBuilder().Default().Build();
        _valorDoFrete = 150;
        _valorDoIcms = 150;
        return this;
    }

    public Compra Build()
    {
        return new Compra(_nomeComprador, _carga, _viagem, _valorDoFrete, _valorDoIcms);
    }

    public CompraBuilder ComCarga(Carga carga)
    {
        _carga = carga;
        return this;
    }

    public CompraBuilder ComViagem(Viagem viagem)
    {
        _viagem = viagem;
        return this;
    }

    public CompraBuilder ComValorDeFrete(decimal valorDoFrete)
    {
        _valorDoFrete = valorDoFrete;
        return this;
    }

    public CompraBuilder ComValorDoIcms(decimal valorDoIcms)
    {
        _valorDoIcms = valorDoIcms;
        return this;
    }
}