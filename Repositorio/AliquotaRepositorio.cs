using System.Text.Json;
using CTeEmissor.Dominio.Model;
using CTeEmissor.Dominio.Model.Dto;

namespace CTeEmissor.Repositorio;
public class AliquotaRepositorio : IAliquotaRepositorio
{
    public List<Aliquota> ObterAliquotas()
    {
        string caminhoArquivo = "./Data/aliquotas.json";

        if (!File.Exists(caminhoArquivo))
            throw new FileNotFoundException($"Arquivo não encontrado: {caminhoArquivo}");

        string json = File.ReadAllText(caminhoArquivo);

        var dtos = JsonSerializer.Deserialize<List<AliquotaDto>>(json);

        if (dtos == null || !dtos.Any())
            throw new Exception("Nenhuma aliquota encontrada no JSON.");

        // Mapeando DTO para Aliquota
        return dtos.Select(dto => new Aliquota(dto.Estado, dto.Porcentagem)).ToList();
    }
}
