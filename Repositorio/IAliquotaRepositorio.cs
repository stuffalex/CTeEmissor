using CTeEmissor.Dominio.Model;

namespace CTeEmissor.Repositorio
{
    public interface IAliquotaRepositorio 
    {
        Aliquota ObterAliquotaPorEstado(string estadoOrigem);
        public List<Aliquota> ObterAliquotas();
    }
}
