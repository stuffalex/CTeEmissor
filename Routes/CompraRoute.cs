using CTeEmissor.Data;
using CTeEmissor.Dominio;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes;

public static class CompraRoute
{
    public static void CompraRoutes(this WebApplication app)
    {
        app.MapPost("compra",
            async (CompraDto compraDto, AppDbContext context, HttpClient httpClient,
            ICompraService compraService) =>
            {
                var apiUrl = $"https://viacep.com.br/ws/{compraDto.CepOrigem}/json/";
                var enderecoOrigem = await httpClient.GetFromJsonAsync<Endereco>(apiUrl);
                var estadoOrigem = enderecoOrigem?.Uf;

                if (string.IsNullOrEmpty(estadoOrigem))
                {
                    return Results.BadRequest("CEP de origem inválido.");
                }

                Compra compra = compraService.Gerar(compraDto, estadoOrigem);
                var cte = new CTeNota(compra);

                await context.AddAsync(compra);
                await context.AddAsync(cte);
                await context.SaveChangesAsync();
                return Results.Created($"/compra/{compra.Id}", compra);
            });

        app.MapGet("compras",
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

        app.MapGet("/compra/{id:guid}",
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