using CTeEmissor.Data;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes
{
    public static class CteRoute
    {
        public static void CteRoutes(this WebApplication app)
        {

            var route = app.MapGroup("notaCte");

            route.MapGet("", (AppDbContext context) =>
            {
                var ctes = context.Cte.
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

            route.MapGet("{id:guid}", (Guid id, AppDbContext context) =>
            {
                var ctes = context.Cte.
                  Include(cte => cte.Compra)
                      .ThenInclude(compra => compra.Viagem)
                          .ThenInclude(viagem => viagem.Aliquota)
                  .Include(cte => cte.Compra)
                      .ThenInclude(compra => compra.Carga)
                        .FirstOrDefaultAsync(x => x.CompraId == id);

                if (ctes == null)
                    return Results.NotFound();

                return Results.Ok(ctes);
            });
        }
    }
}
