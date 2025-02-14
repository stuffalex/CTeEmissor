using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Testes.Helper;

public class ViagemBuilder
{
    private string _cepOrigem;
    private string _cepDestino;
    private int _distanciaOrigemDestino;
    private DateTime _inicioOperacao;
    private Aliquota _aliquota;
    private decimal _despesasAdicionais;
    private decimal _tarifaPorPeso;

    public Viagem Build()
    {
        var viagem = new Viagem(_cepOrigem, _cepDestino, _distanciaOrigemDestino, _despesasAdicionais, _tarifaPorPeso, _aliquota);
        _inicioOperacao = viagem.InicioOperacao;

        return viagem;
    }

    public ViagemBuilder Default()
    {
        _cepOrigem = "79012570";
        _cepDestino = "79570855";
        _distanciaOrigemDestino = 150;
        _despesasAdicionais = 200; 
        _tarifaPorPeso = 3; 
        _aliquota = new AliquotaBuilder().Default().Build();

        return this;
    }
}