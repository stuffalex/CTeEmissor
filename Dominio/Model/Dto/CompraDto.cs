namespace CTeEmissor.Dominio.Model.Dto
{
    public record CompraDto(string NomeComprador, int QuantidadeDoProduto, int PesoUnitarioProduto, int VolumeTotalDosProdutos,
        string CepOrigem, string CepDestino, int DistanciaOrigemDestino, decimal DespesasAdicionais, decimal TarifaPorPeso);
}
