using CTeEmissor.Dominio.Model.Dto;

namespace CTeEmissor.Dominio.Interfaces
{
    public interface IAliquotaService
    {
        public AliquotaDto? ObterAliquota(string estado);
    }
}
