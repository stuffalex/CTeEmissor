using System.Text.Json;
using CTeEmissor.Base;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;

namespace CTeEmissor.Repositorio;
public class AliquotaRepositorio : IAliquotaRepositorio
{
    private List<Aliquota> _aliquotas;

    public List<Aliquota> ObterAliquotas()
    {
        ObterAliquotasDoJson();

        return _aliquotas;
    }

    public Aliquota ObterAliquotaPorEstado(string estado)
    {
        ObterAliquotasDoJson();

        ValidacaoDeDominio.Quando(_aliquotas == null, "Alíquota não encontrada para o estado de origem.");

        return _aliquotas.FirstOrDefault(a => a.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
    }

    private void ObterAliquotasDoJson()
    {
        string caminhoArquivo = "./Data/aliquotas.json";

        if (!File.Exists(caminhoArquivo))
            throw new FileNotFoundException($"Arquivo não encontrado: {caminhoArquivo}");

        string json = File.ReadAllText(caminhoArquivo);

        var dtos = JsonSerializer.Deserialize<List<AliquotaDto>>(json);

        if (dtos == null || !dtos.Any())
            throw new Exception("Nenhuma aliquota encontrada no JSON.");

        _aliquotas = dtos.Select(dto => new Aliquota(dto.Estado, dto.Porcentagem)).ToList();
    }
}
