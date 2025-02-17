using CTeEmissor.Data;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes
{
    public static class CteRoute
    {
        public static void CteRoutes(this WebApplication app)
        {
            app.MapGet("notasCte", (AppDbContext context) =>
            {
                var ctes = context.Cte
                    Include(cte => cte.Compra)
                        .ThenInclude(compra => compra.Viagem)
                            .ThenInclude(viagem => viagem.Aliquota)
                    .Include(cte => cte.Compra)
                        .ThenInclude(compra => compra.Carga)
                    .ToListAsync();

                if (ctes == null)
                    return Results.NotFound();

                return Results.Ok(ctes);
            });

            app.MapGet("notaCte/{compraId:guid}", (Guid id, AppDbContext context) =>
            {
                var ctes = context.Cte
                        .FirstOrDefaultAsync(x => x.CompraId == id);

                if (ctes == null)
                    return Results.NotFound();

                return Results.Ok(ctes);
            });
        }
    }
}
