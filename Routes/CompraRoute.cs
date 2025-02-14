using System.Net.Http;
using CTeEmissor.Data;
using CTeEmissor.Dominio;
using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Models;
using CTeEmissor.Dominio.Models.Dto;
using CTeEmissor.Dominio.Services;

namespace CTeEmissor.Routes;

public static class CompraRoute
{
    public static void CompraRoutes(this WebApplication app)
    {
      
        var route = app.MapGroup("compra");

        route.MapPost("", async (CompraDto compraDto, AppDbContext context, HttpClient httpClient, IAliquotaService aliquotaService) => {

            // Busca o endereço pelo CEP ORIGEM; REGRA DE QUAL CEP AINDA NAO CLARA PRA MMI
            var apiUrl = $"https://viacep.com.br/ws/{compraDto.cepOrigem}/json/";
            var enderecoOrigem = await httpClient.GetFromJsonAsync<Endereco>(apiUrl);
            var estadoOrigem = enderecoOrigem?.Uf;

            if (string.IsNullOrEmpty(estadoOrigem))
            {
                return Results.BadRequest("CEP de origem inválido.");
            }

            var aliquota = aliquotaService.ObterAliquota(estadoOrigem);

            if (aliquota == null)
            {
                return Results.BadRequest("Alíquota não encontrada para o estado de origem.");
            }



            var carga = new Carga(compraDto.Quantidade, compraDto.PesoBrutoTotal, compraDto.Volume);
            var viagem = new Viagem(compraDto.cepOrigem, compraDto.cepDestino, compraDto.distanciaOrigemDestino, compraDto.despesasAdicionais, compraDto.tarifaPorPeso, aliquota);
            var compra = new Compra(compraDto.NomeComprador, carga, viagem);
            await context.AddAsync(compra);
            await context.SaveChangesAsync();

        });
    }
}