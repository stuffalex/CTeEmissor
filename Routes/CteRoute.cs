using CTeEmissor.Data;
using Microsoft.EntityFrameworkCore;

namespace CTeEmissor.Routes
{
    public static class CteRoute
    {
        public static void CteRoutes(this WebApplication app)
        {
           
            var route = app.MapGroup("emissorcte");

            route.MapGet("", (AppDbContext context) =>
            {
                var ctes = context.Cte.ToListAsync();
                return Results.Ok(ctes);
            });

            //route.MapGet("", (CTeDto req, CteContext context) => {
            //});
            //var viagem = new ViagemModel("origem", "destino", 125);
            //var carga = new CargaModel(3, 10, 2);
            //route.MapGet("", () => new CTeModel(carga, viagem));
        }
    }
}
