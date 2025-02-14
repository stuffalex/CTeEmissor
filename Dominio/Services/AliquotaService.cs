using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Models;

namespace CTeEmissor.Dominio.Services
{
    public class AliquotaService : IAliquotaService
    {

        private readonly List<Aliquota> _aliquotas;

        public AliquotaService(IConfiguration configuration)
        {
            var aliquotasJson = configuration.GetSection("Aliquotas").Get<List<Aliquota>>();
            _aliquotas = aliquotasJson ?? new List<Aliquota>();
        }

        public decimal? ObterAliquota(string estado)
        {
            return _aliquotas.FirstOrDefault(a => a.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase))?.Porcentagem;
        }
    }
}
