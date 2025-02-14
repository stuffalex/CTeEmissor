using CTeEmissor.Dominio.Interfaces;
using CTeEmissor.Dominio.Model.Dto;
using Newtonsoft.Json;

namespace CTeEmissor.Dominio.Services;

public class AliquotaService : IAliquotaService
{

    private readonly List<AliquotaDto> _aliquotas;

    public AliquotaService(string caminhoJson)
    {
        var aliquotasJson = File.ReadAllText(caminhoJson);
        _aliquotas = JsonConvert.DeserializeObject<List<AliquotaDto>>(aliquotasJson);
    }

    public AliquotaDto? ObterAliquota(string estado)
    {
        return _aliquotas.FirstOrDefault(a => a.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
    }
}
