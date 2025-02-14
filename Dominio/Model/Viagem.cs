using CTeEmissor.Dominio.Base;

namespace CTeEmissor.Dominio.Model;

public class Viagem : EntidadeBase<Viagem>
{
  
    public string CepOrigem { get; private set; }
    public string CepDestino { get; private set; }
    public int DistanciaOrigemDestino { get; private set; }
    public DateTime InicioOperacao { get; private set; }
    public Aliquota Aliquota { get; private set; }
    public decimal DespesasAdicionais { get; private set; }
    public decimal TarifaPorPeso { get; private set; }

    public Viagem()
    {

    }
    public Viagem(string cepOrigem, string cepDestino, int distanciaOrigemDestino, decimal despesasAdicionais, decimal tarifaPorPeso, Aliquota aliquota)
    {
        CepOrigem = cepOrigem;
        CepDestino = cepDestino;
        DistanciaOrigemDestino = distanciaOrigemDestino;
        InicioOperacao = DateTime.Now;
        DespesasAdicionais = despesasAdicionais;
        TarifaPorPeso = tarifaPorPeso;
        Aliquota = aliquota;
    }

}
