namespace CTeEmissor.Dominio.Models.Dto
{
    public record CompraDto(string NomeComprador, int Quantidade, int PesoBrutoTotal, int Volume, string cepOrigem, 
        string cepDestino, int distanciaOrigemDestino, double despesasAdicionais, double tarifaPorPeso);
}
