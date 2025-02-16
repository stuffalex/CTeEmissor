using CTeEmissor.Base;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services.Interfaces;

namespace CTeEmissor.Dominio.Services
{
    public class CalculaFreteService : ICalculaFreteService
    {
        public decimal CalculaFrete(DadosCalculoFreteDto dadosDto)
        {
            Validacoes(dadosDto);

            var total = (dadosDto.TarifaPorPeso * dadosDto.PesoBrutoTotal) + dadosDto.DespesasAdicionais;

            return Math.Round(total, 2);
        }

        private static void Validacoes(DadosCalculoFreteDto dadosDto)
        {
            ValidacaoDeDominio.Quando(dadosDto == null, "Dados para o cálculo não devem ser vazios.");
            ValidacaoDeDominio.Quando(dadosDto.TarifaPorPeso <= 0, "TarifaPorPeso não deve ser menor ou igual a zero.");
            ValidacaoDeDominio.Quando(dadosDto.PesoBrutoTotal <= 0, "PesoBrutoTotal não deve ser menor ou igual a zero.");
            ValidacaoDeDominio.Quando(dadosDto.DespesasAdicionais < 0, "DespesasAdicionais não devem ser menor que zero.");
        }
    }
}
