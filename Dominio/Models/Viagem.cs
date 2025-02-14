namespace CTeEmissor.Dominio.Models;

public class Viagem
{
    public Viagem(string cepOrigem, string cepDestino, int distanciaOrigemDestino, double despesasAdicionais, double tarifaPorPeso)
    {
        CepOrigem = cepOrigem;
        CepDestino = cepDestino;
        DistanciaOrigemDestino = distanciaOrigemDestino; //int em km - criar o calculo com a api dps KKK
        InicioOperacao = DateTime.Now;
        DespesasAdicionais = despesasAdicionais;
        TarifaPorPeso = tarifaPorPeso;
        Aliquota = Aliquota;
    }

    public Guid Id { get; init; }
    public string CepOrigem { get; private set; }
    public string CepDestino { get; private set; }
    public int DistanciaOrigemDestino { get; private set; }
    public DateTime InicioOperacao { get; private set; }
    public Aliquota Aliquota { get; private set; }
    //da para criar um objeto valor futuramente para ter especificado o que seria cada despesa adicional
    public double DespesasAdicionais { get; private set; }
    public double TarifaPorPeso { get; private set; }
}
