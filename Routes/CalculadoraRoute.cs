using CTeEmissor.Data;
using CTeEmissor.Dominio.Model.Dto;
using CTeEmissor.Dominio.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes;

public static class CalculadoraRoute
{
    public static void CalculadoraRoutes(this WebApplication app)
    {
        var rota = app.MapGroup("calculadora");
        rota.MapGet("ValorDeFrete/{compraId:guid}",
             async (Guid id, AppDbContext context) =>
            {
                var compra = await context.Compra.FirstOrDefaultAsync(c => c.Id == id);

                if (compra == null)
                    return Results.NotFound();

                return Results.Ok($"Valor do frete: {compra.ValorDoFrete}, Compra id: {id}");
            });

        rota.MapPost("ValorDeFrete",
            (DadosCalculoFreteDto dto, AppDbContext context, ICalculaFreteService _calculadoraDeFrete) =>
           {
               var frete = _calculadoraDeFrete.CalculaFrete(dto);
               return Results.Ok($"Valor do frete: {frete}");
           });

        rota.MapPost("ValorDeICMS",
            (DadosCalculoIcmsDto dto, AppDbContext context, ICalculaIcmsService _calculadoraDeIcms) =>
           {
               var valorIcms = _calculadoraDeIcms.CalculaIcms(dto);
               return Results.Ok($"Valor do Icms: {valorIcms}");
           });

        rota.MapGet("ValorDeICMS/{compraId:guid}",
        async (Guid id, AppDbContext context, ICalculaIcmsService _calculadoraDeIcms) =>
        {
            var compra = await context.Compra.FirstOrDefaultAsync(c => c.Id == id);

            if (compra == null)
                return Results.NotFound();
            return Results.Ok($"Valor do Icms: {compra.ValorDoIcms}, Compra id: {id}");

        });
    }
}
