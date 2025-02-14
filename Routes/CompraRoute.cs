using CTeEmissor.Data;
using CTeEmissor.Dominio;
using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes;

public static class CompraRoute
{
    public static void CompraRoutes(this WebApplication app)
    {

        var route = app.MapGroup("compra");
        //refatorar com uma factory de compra e nota
        route.MapPost("",
            async (CompraDto compraDto, AppDbContext context, HttpClient httpClient,
            IAliquotaService aliquotaService, ICalculaFreteService calculaFreteService, ICalculaIcmsService calculaIcmsService) =>
        {

            // Busca o endereço pelo CEP ORIGEM; REGRA DE QUAL CEP AINDA NAO CLARA PRA MMI
            var apiUrl = $"https://viacep.com.br/ws/{compraDto.CepOrigem}/json/";
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

            var aliquotaDoEstado = new Aliquota(aliquota.Estado, aliquota.Porcentagem);
            var carga = new Carga(compraDto.QuantidadeDoProduto, compraDto.PesoUnitarioProduto, compraDto.VolumeTotalDosProdutos);
            var viagem = new Viagem(compraDto.CepOrigem, compraDto.CepDestino, compraDto.DistanciaOrigemDestino, compraDto.DespesasAdicionais,
                compraDto.TarifaPorPeso, aliquotaDoEstado);
            var pesoTotal = compraDto.PesoUnitarioProduto * compraDto.QuantidadeDoProduto;
            var valorDoFrete = calculaFreteService.CalculaFrete(compraDto.TarifaPorPeso, pesoTotal, compraDto.DespesasAdicionais);
            var valorIcms = calculaIcmsService.CalculaIcms(aliquotaDoEstado, valorDoFrete);
            var compra = new Compra(compraDto.NomeComprador, carga, viagem, valorDoFrete, valorIcms);
            var cte = new CTeNota(compra);
            await context.AddAsync(compra);
            await context.AddAsync(cte);
            await context.SaveChangesAsync();
            return Results.Created($"/compra/{compra.Id}", compra);
        });

        route.MapGet("",
            (AppDbContext context) =>
            {
                var compras = context.Compra
                .Include(compra => compra.Viagem)
                    .ThenInclude(viagem => viagem.Aliquota)
                .Include(cte => cte.Carga)
                    .ToListAsync();

                if (compras == null)
                    return Results.NotFound();

                return Results.Ok(compras);
            });

        route.MapGet("{id:guid}",
            async (Guid id, AppDbContext context) =>
            {
                var compra = await context.Compra
                .Include(compra => compra.Viagem)
                    .ThenInclude(viagem => viagem.Aliquota)
                .Include(cte => cte.Carga)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (compra == null)
                    return Results.NotFound();

                return Results.Ok(compra);
            });
    }
}